using FazendaLibrary.Interfaces;
using FazendaLibrary.Mapeamento;
using FazendaLibrary.Utilitario;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FazendaLibrary.DAO
{
    public class CompraAnimaisDAO : ICrudDAO<CompraAnimais>
    {
        // Seleciona as informações da compra e fornecedores
        private const string BaseSelectQuery = @"
        SELECT 
            c.id_compra, c.data_compra, c.numero_nota_fiscal, c.valor_total_nota, 
            c.valor_frete, c.GTA, c.quantidade,
            f.id_fornecedor, f.razao_social, f.cpf_cnpj, f.telefone
        FROM 
            compra_animais c
        LEFT JOIN 
            fornecedor f ON c.fk_id_fornecedor = f.id_fornecedor";

        public void Cadastrar(CompraAnimais item)
        {
            string dataCompra = item.DataCompra.ToString("yyyy-MM-dd");
            string sql = @"INSERT INTO compra_animais (Data_Compra, 
                Numero_Nota_Fiscal, Valor_Total_Nota, Valor_Frete, GTA, Quantidade, fk_id_fornecedor) 
                VALUES (@DataCompra, @NumeroNotaFiscal, @ValorTotalNota, 
                @ValorFrete, @GTA, @Quantidade, @Fornecedor)";
            try
            {
                // Abre uma conexão com o banco de dados e garante seu
                // fechamento automático ao final do bloco using
                using (var conectar = Conexao.CriarConexao())
                {
                    conectar.Open();
                    using (var comando = new MySqlCommand(sql, conectar))
                    {
                        comando.Parameters.AddWithValue("@DataCompra", dataCompra);
                        comando.Parameters.AddWithValue("@NumeroNotaFiscal", item.NumeroNotaFiscal);
                        comando.Parameters.AddWithValue("@ValorTotalNota", item.ValorTotalNota);
                        comando.Parameters.AddWithValue("@ValorFrete", item.ValorFrete ?? (object)DBNull.Value);
                        comando.Parameters.AddWithValue("@GTA", item.GTA);
                        comando.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                        comando.Parameters.AddWithValue("@Fornecedor", item.Fornecedor.IdFornecedor);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Atualizar(CompraAnimais item)
        {
            string dataCompra = item.DataCompra.ToString("yyyy-MM-dd");
            string sql = @"UPDATE compra_animais SET Data_Compra = @DataCompra, 
                Numero_Nota_Fiscal = @NumeroNotaFiscal, Valor_Total_Nota = @ValorTotalNota, 
                Valor_Frete = @ValorFrete, GTA = @GTA, Quantidade = @Quantidade, fk_id_fornecedor = @Fornecedor
                WHERE Id_Compra = @IdCompra";
            try
            {
                using (var conectar = Conexao.CriarConexao())
                {
                    conectar.Open();
                    using (var comando = new MySqlCommand(sql, conectar))
                    {
                        comando.Parameters.AddWithValue("@IdCompra", item.IdCompra);
                        comando.Parameters.AddWithValue("@DataCompra", dataCompra);
                        comando.Parameters.AddWithValue("@NumeroNotaFiscal", item.NumeroNotaFiscal);
                        comando.Parameters.AddWithValue("@ValorTotalNota", item.ValorTotalNota);
                        comando.Parameters.AddWithValue("@ValorFrete", item.ValorFrete ?? (object)DBNull.Value);
                        comando.Parameters.AddWithValue("@GTA", item.GTA);
                        comando.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                        comando.Parameters.AddWithValue("@Fornecedor", item.Fornecedor.IdFornecedor);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Deletar(CompraAnimais item)
        {
            string sql = @"DELETE FROM compra_animais 
                    WHERE Id_Compra = @IdCompra";
            try
            {
                using (var conectar = Conexao.CriarConexao())
                {
                    conectar.Open();
                    using (var comando = new MySqlCommand(sql, conectar))
                    {
                        comando.Parameters.AddWithValue("@IdCompra", item.IdCompra);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private CompraAnimais MapearCompraDoReader(MySqlDataReader reader)
        {
            CompraAnimais compra = new CompraAnimais
            {
                IdCompra = reader.GetInt32("id_compra"),
                DataCompra = reader.GetDateTime("data_compra"),
                NumeroNotaFiscal = reader.GetString("numero_nota_fiscal"),
                ValorTotalNota = reader.GetDouble("valor_total_nota"),
                ValorFrete = reader.IsDBNull(reader.GetOrdinal("valor_frete")) ? (double?)null : reader.GetDouble("valor_frete"),
                GTA = reader.GetString("GTA"),
                Quantidade = reader.GetInt32("quantidade"),
                Fornecedor = null // Começa com o Fornecedor como nulo
            };

            
            // Verifica se a coluna NÃO está nula no banco.
            if (!reader.IsDBNull(reader.GetOrdinal("id_fornecedor")))
            {
                // Se não for nula, aí sim, nós le os dados do fornecedor e os adiciona ao objeto 'compra'.
                compra.Fornecedor = new Fornecedor
                {
                    IdFornecedor = reader.GetInt32("id_fornecedor"),
                    RazaoSocial = reader.IsDBNull(reader.GetOrdinal("razao_social")) ? "" : reader.GetString("razao_social"),
                    CpfCnpj = reader.IsDBNull(reader.GetOrdinal("cpf_cnpj")) ? "" : reader.GetString("cpf_cnpj"),
                    Telefone = reader.IsDBNull(reader.GetOrdinal("telefone")) ? "" : reader.GetString("telefone")
                };
            }
            // Se for nula, a propriedade 'compra.Fornecedor' simplesmente permanece como 'null'

            return compra;
        }

        public List<CompraAnimais> ListarTodos()
        {
            var lista = new List<CompraAnimais>();
            string sql = BaseSelectQuery;
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
                                CompraAnimais compra = MapearCompraDoReader(reader);
                                lista.Add(compra);
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

        public List<CompraAnimais> Buscar(string termo)
        {
            var lista = new List<CompraAnimais>();
            string sql = $@"{BaseSelectQuery} 
                  WHERE c.numero_nota_fiscal LIKE @termo 
                  OR DATE_FORMAT(c.data_compra, '%Y-%m-%d') LIKE @termo";
            try
            {
                using (var conectar = Conexao.CriarConexao())
                {
                    conectar.Open();
                    using (var comando = new MySqlCommand(sql, conectar))
                    {
                        comando.Parameters.AddWithValue("@termo", $"%{termo}%");
                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(MapearCompraDoReader(reader));
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
