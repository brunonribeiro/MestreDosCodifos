using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApp
{
    public class ManipulardorDeLista
    {
        public ManipulardorDeLista()
        {
            _numeros = new List<int?>();
        }

        private List<int?> _numeros;

        internal void AdicionarNoInicio(int valor)
        {
            _numeros.Insert(0, valor);
        }

        internal void AdicionarNoFinal(int valor)
        {
            _numeros.Add(valor);
        }

        internal void RemoverPrimeiro()
        {
            if (_numeros.Count() > 0)
            {
                _numeros.RemoveAt(0);
            }
        }

        internal void RemoverUltimo()
        {
            if (_numeros.Count() > 0)
            {
                var ultimaPosicao = _numeros.Count - 1;
                _numeros.RemoveAt(ultimaPosicao);
            }
        }

        internal int?[] ListarTodos()
        {
            return _numeros.ToArray();
        }

        internal List<int?> ListarEmOrdemCrescente()
        {
            return _numeros.OrderBy(x => x).ToList();
        }

        internal List<int?> ListarEmOrdemDecrescente()
        {
            return _numeros.OrderByDescending(x => x).ToList();
        }

        internal int? ExibirPrimeiro()
        {
            return _numeros.FirstOrDefault();
        }

        internal int? ExibirUltimo()
        {
            return _numeros.LastOrDefault();
        }

        internal List<int?> ListarPares()
        {
            return ListarEmOrdemCrescente().Where(x => (x % 2 == 0)).ToList();
        }

        internal List<int?> ListarImpares()
        {
            return ListarEmOrdemCrescente().Where(x => (x % 2 != 0)).ToList();
        }

        internal int? ExibirNumeroInformado(int numero)
        {
            return _numeros.FirstOrDefault(x => x == numero);
        }
    }
}
