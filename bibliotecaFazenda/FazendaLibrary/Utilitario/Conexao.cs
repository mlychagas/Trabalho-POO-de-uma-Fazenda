using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FazendaLibrary.Utilitario
{
    public class Conexao
    {
        // Classe utilitária responsável por fornecer conexões com o banco de dados MySQL da aplicação.
        // A string de conexão deve ser ajustada conforme o ambiente de execução (ex: produção, desenvolvimento).

        private static readonly string conexaoString =
            "server = localhost; uid = root; pwd = r00t; database = Fazenda";

        public static MySqlConnection CriarConexao() 
        {
            return new MySqlConnection(conexaoString);
        }
    }
}
