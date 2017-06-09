using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class AreaCliente
    {
        private Cliente _cliente;
        private List<Iguaria> _historico;
        private Dictionary<int, string> _tendencias;
        private GPSVal _localizacao_cliente;

        private Direcoes _listaDirecoes;

        public Direcoes ListaDirecoes
        {
            get
            {
                return _listaDirecoes;
            }
            set
            {
                _listaDirecoes = value;
            }
        }

        public void PublicarCritica(string descricao,  float rating)
        {

            DateTime data = DateTime.Now;
            Critica c = new Critica(descricao, data, rating);
            
        }

        public void RegistarCliente(string email, string password, byte tipo, string nome)
        {
            Preferencias preferencias = new Preferencias();
            _cliente = new Cliente(email, password, tipo, nome, preferencias);

            // TODO: mandar cliente para a base de dados (insert, select, para obter o id)
            
        }

        public void AtualizarCliente(string email, string password, byte tipo, string nome)
        {
            Preferencias preferencias = new Preferencias();
            _cliente = new Cliente(email, password, tipo, nome);

            // TODO: mandar cliente para a base de dados (update todos os dados pelo id)
        }

        public List<Iguaria> ConsultarHistorico(int idIguaria, int idEstabelecimento)
        {
            int id = _cliente.IdCliente;

            // TODO: select do histórico com os tres identificadors



            return new List<Iguaria>();
        }

        public Estabelecimento EscolherIguaria(int idIguaria, int idEstabelecimento)
        {

            // NOTE : contrutor vazio não está implementado: há uma exceção se se usar
           return new Estabelecimento();
        }

        public List<Iguaria> GerarPedido(string pedido)
        {

            // TODO: ordenar de acordo com preferencias de cliente
            //Distancia 
            return new List<Iguaria>();
        }

        public void PublicarFacebook()
        {
            throw new System.NotImplementedException();
        }

        public void PublicarTwiiter()
        {
            throw new System.NotImplementedException();
        }

        public void ConsultarPreferencias()
        {
            int id = _cliente.IdCliente;
            // TODO: obter lista de preferencias com base no id do cliente


           // _cliente.ListaPreferencias = resultado;
        }

        public void EditarPreferencias(byte _ordem_rating_iguaria, byte _ordem_rating_estabelecimento, byte _ordem_distancia, byte _ordem_popularidade_iguaria, byte _ordem_popularidade_estabelecimento)
        {
            Preferencias pref = new Preferencias(_ordem_rating_iguaria, _ordem_rating_estabelecimento, _ordem_distancia, _ordem_popularidade_iguaria, _ordem_popularidade_estabelecimento);
            // TODO: obter lista de preferencias com base no id do cliente
        }

        public void ReceberDirecoes(int id_estabelecimento)
        {
            int latitude = _localizacao_cliente.Latitude;
            int longitude = _localizacao_cliente.Longitude;

            

            // TODO: comunicar com servico REST Bing

        }

        public void ApagarConta()
        {
            throw new System.NotImplementedException();
        }
    }
}