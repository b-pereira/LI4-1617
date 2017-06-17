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

             
                return _direcoes;

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


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("----- Direções -----").AppendLine();
            foreach (var item in _direcoes)
            {
                sb.Append(item).AppendLine();
            }
            sb.AppendLine();

            return sb.ToString();
        }

    }
}