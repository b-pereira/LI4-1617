using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public struct Direcoes
    {
        private List<string> _direcoes;

        public List<string> ListaDirecoes
        {
            get
            {

                List<string> tmp = new List<string>();

                foreach (string item in _direcoes)
                {
                    tmp.Add(item);
                }

                return tmp;

            }
            set
            {
                _direcoes.Clear();

                foreach (string item in value)
                {
                    _direcoes.Add(item);
                }

            }
        }

        public void AdicionarDirecao(string direcao)
        {
            _direcoes.Add(direcao);
        }
    }
}