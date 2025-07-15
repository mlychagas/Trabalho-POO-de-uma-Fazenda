using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FazendaLibrary.Mapeamento;
using FazendaLibrary.DAO;

namespace FazendaFront
{
    public partial class Registro : Form
    {
        // Responsável pelas operações de acesso a dados da entidade.
        private readonly CompraAnimaisDAO _compraDAO = new CompraAnimaisDAO();

        public Registro()
        {
            InitializeComponent();
            // Configura o DataGridView para não gerar colunas automaticamente.
            this.dgvConsulta.AutoGenerateColumns = false;

        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.ShowDialog();
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                // Chama o método da biblioteca e define como a fonte de dados do grid.
                dgvConsulta.DataSource = _compraDAO.ListarTodos();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}");
            }
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string termo = txtBusca.Text;
                if (string.IsNullOrWhiteSpace(termo))
                {
                    // Se a busca estiver vazia, carrega tudo
                    CarregarGrid();
                }
                else
                {
                    // Senão, busca pelo termo
                    dgvConsulta.DataSource = _compraDAO.Buscar(termo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na busca: {ex.Message}");
            }
        }

        private void btDeletar_Click(object sender, EventArgs e)
        {
            // Verifica se alguma linha foi selecionada.
            if (dgvConsulta.SelectedRows.Count > 0)
            {
                // Pega o objeto CompraAnimais da linha selecionada.
                CompraAnimais compraSelecionada = dgvConsulta.SelectedRows[0].DataBoundItem as CompraAnimais;

                if (compraSelecionada != null)
                {
                    // Pede confirmação ao usuário.
                    var result = MessageBox.Show($"Deseja realmente deletar a compra NF '{compraSelecionada.NumeroNotaFiscal}'?",
                                                 "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            _compraDAO.Deletar(compraSelecionada);
                            MessageBox.Show("Registro deletado com sucesso!");
                            CarregarGrid(); // Recarrega o grid para mostrar a mudança.
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao deletar: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma linha para deletar.");
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            if (dgvConsulta.SelectedRows.Count > 0)
            {
                CompraAnimais compraParaEditar = dgvConsulta.SelectedRows[0].DataBoundItem as CompraAnimais;

                if (compraParaEditar != null)
                {
                    // Abre a tela de cadastro, passando o objeto para o construtor.
                    Cadastro formCadastro = new Cadastro(compraParaEditar);
                    formCadastro.ShowDialog();
                    CarregarGrid(); // Recarrega após a edição.
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma linha para editar.");
            }
        }
    }
}
