using FazendaLibrary.DAO;
using FazendaLibrary.Mapeamento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FazendaFront
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
            CarregarFornecedores();
        }
        // Responsável pelas operações de acesso a dados da entidade.
        private readonly CompraAnimaisDAO _compraDAO = new CompraAnimaisDAO();
        private CompraAnimais _compraParaEditar; // Guarda a compra que está sendo editada
        private readonly FornecedorDAO _fornecedorDAO = new FornecedorDAO();
        // Readonly proteger a integridade da lógica da sua aplicação.
        // Ele deixa claro que esses DAOs são dependências fixas e não devem
        // ser trocadas durante a execução da classe.

        // Construtor para EDITAR um cadastro existente
        public Cadastro(CompraAnimais compra) : this() 
        {
            _compraParaEditar = compra;
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            dtpDataCompra.Value = _compraParaEditar.DataCompra;
            txtNotaFiscal.Text = _compraParaEditar.NumeroNotaFiscal;
            txtValorTotal.Text = _compraParaEditar.ValorTotalNota.ToString();
            txtFrete.Text = _compraParaEditar.ValorFrete?.ToString();
            txtGta.Text = _compraParaEditar.GTA;
            txtQuantidade.Text = _compraParaEditar.Quantidade.ToString();

            // Define o item selecionado no ComboBox com base no ID do fornecedor
            if (_compraParaEditar.Fornecedor != null)
            {
                cbxFornecedor.SelectedValue = _compraParaEditar.Fornecedor.IdFornecedor;
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Valida os campos antes de prosseguir com o salvamento.
                if (!ValidarCampos())
                {           
                    return;
                }
                // Cria um objeto para preencher, seja ele novo ou o de edição.
                CompraAnimais compraParaSalvar = _compraParaEditar ?? new CompraAnimais();
                compraParaSalvar.DataCompra = dtpDataCompra.Value;
                compraParaSalvar.NumeroNotaFiscal = txtNotaFiscal.Text;
                compraParaSalvar.ValorTotalNota = double.Parse(txtValorTotal.Text);
                compraParaSalvar.ValorFrete = string.IsNullOrWhiteSpace(txtFrete.Text) ? (double?)null : double.Parse(txtFrete.Text);
                compraParaSalvar.GTA = txtGta.Text;
                compraParaSalvar.Quantidade = int.Parse(txtQuantidade.Text);

                // Pega o objeto Fornecedor inteiro que está selecionado no ComboBox
                compraParaSalvar.Fornecedor = cbxFornecedor.SelectedItem as Fornecedor;

                
                // Agora, com o objeto preenchido, decidimos qual método chamar
                if (_compraParaEditar == null)
                {
                    _compraDAO.Cadastrar(compraParaSalvar);
                    MessageBox.Show("Compra cadastrada com sucesso!");
                }
                else
                {
                    _compraDAO.Atualizar(compraParaSalvar);
                    MessageBox.Show("Compra atualizada com sucesso!");
                }

                this.Close(); // Fecha a tela de cadastro.
            }
            catch (ArgumentOutOfRangeException ex) // Captura a exceção específica
            {
                
                MessageBox.Show(ex.Message, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtValorTotal.Focus();
                txtValorTotal.SelectAll();
            }
            catch (FormatException)
            {
                MessageBox.Show("Erro de formato. Verifique se os números e datas estão corretos.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarFornecedores()
        {
            // Carrega os fornecedores do banco de dados e preenche o ComboBox.
            try
            {
                var fornecedores = _fornecedorDAO.ListarTodos();
                cbxFornecedor.DataSource = fornecedores;
                cbxFornecedor.DisplayMember = "RazaoSocial";
                cbxFornecedor.ValueMember = "IdFornecedor";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}");
            }
        }

        private void txtValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números, a tecla Backspace, e uma única vírgula.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true; // Ignora o caractere digitado
            }

            // Permite apenas uma vírgula
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true; // Ignora a segunda vírgula
            }
        }

        private void txtFrete_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true; 
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true; 
            }
        }
        private bool ValidarCampos()
        {
            // Verifica o campo NumeroNotaFiscal
            if (string.IsNullOrWhiteSpace(txtNotaFiscal.Text))
            {
                MessageBox.Show("O campo 'Número NF' é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNotaFiscal.Focus(); // Coloca o cursor no campo para o usuário corrigir
                return false; // A validação falhou
            }

            if (string.IsNullOrWhiteSpace(txtValorTotal.Text))
            {
                MessageBox.Show("O campo 'Valor Total' é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorTotal.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGta.Text))
            {
                MessageBox.Show("O campo 'GTA' é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGta.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuantidade.Text))
            {
                MessageBox.Show("O campo 'Quantidade' é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantidade.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtFrete.Text))
            {
                MessageBox.Show("O campo 'Frete' é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFrete.Focus();
                return false;
            }

            if (cbxFornecedor.SelectedItem == null)
            {
                MessageBox.Show("É obrigatório selecionar um 'Fornecedor'.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxFornecedor.Focus();
                return false;
            }

            return true; 
        }
    }
}
