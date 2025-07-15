using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FazendaLibrary.Mapeamento;
using FazendaLibrary.Utilitario; 
using MySql.Data.MySqlClient;

namespace FazendaLibrary.DAO
{
    public class FornecedorDAO
    {
        public List<Fornecedor> ListarTodos()
        {
            var lista = new List<Fornecedor>();
            string sql = "SELECT * FROM fornecedor ORDER BY razao_social"; // Ordenado para ficar bonito no ComboBox

            try
            {
                
                using (var conectar = Conexao.CriarConexao())
                {
                    conectar.Open();
                    using (var comando = new MySqlCommand(sql, conectar))
                    {
                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Mapeia cada linha para um objeto Fornecedor
                                Fornecedor fornecedor = new Fornecedor
                                {
                                    IdFornecedor = reader.GetInt32("id_fornecedor"),
                                    RazaoSocial = reader.GetString("razao_social"),
                                    CpfCnpj = reader.GetString("cpf_cnpj"),
                                    Telefone = reader.GetString("telefone")
                                };
                                lista.Add(fornecedor);
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
