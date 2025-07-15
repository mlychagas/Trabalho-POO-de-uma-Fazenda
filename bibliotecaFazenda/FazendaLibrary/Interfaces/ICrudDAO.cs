using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FazendaLibrary.Interfaces
{
    public interface ICrudDAO<T> where T : class
    {
        void Cadastrar(T entidade);
        void Atualizar(T entidade);
        void Deletar(T id);
        List<T> ListarTodos();
        List<T> Buscar(string termo);
    }
}
