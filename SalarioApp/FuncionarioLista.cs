using System.Collections;
using System.Collections.Generic;

namespace SalarioApp
{
    public class FuncionarioLista : IEnumerable<Funcionario>
    {
        public readonly List<Funcionario> funcionarios;
        public FuncionarioLista()
        {
            funcionarios = new List<Funcionario>();
        }

        private List<double> myData;

        public IEnumerator<Funcionario> GetEnumerator()
        {
            foreach (var item in funcionarios)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
