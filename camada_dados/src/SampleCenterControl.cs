using System;
using System.Collections.Generic;
using Business;

public class SampleCenterControl
{

    static void Main(string[] args)
    {
        try
        {
          

            Console.WriteLine("A iniciar ... aguarde!");
            
            List<Horario> horarios = new List<Horario>();

            for (byte i = 1; i < 8; i++)
            {

                horarios.Add(new Horario(i, new TimeSpan(9, 0, 0), new TimeSpan(23, 59, 00)));
            }



            /*AreaEstabelecimento es = new AreaEstabelecimento();

            es.RegistarEstabelecimento("ze@boavista.pt", "pantera", "Acolhedor. Informal.", "Tasca do Z�", 226185325, horarios, new Endereco("4100-031", 41.1664667m, "Porto", -8.6577359m, 437, "R. Dr. Alberto de Macedo"), 1);
            es.Login("ze@boavista.pt", "pantera");

            byte[] foto = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Dictionary<int, Business.Iguaria> menu = new Dictionary<int, Business.Iguaria>();
            menu.Add(1, new Business.Iguaria("Bifana", foto, 5.5M, 1, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));
            menu.Add(2, new Business.Iguaria("Caldo Verde", foto, 5.5M, 2, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));
            menu.Add(3, new Business.Iguaria("Broa", foto, 5.5M, 3, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));
            menu.Add(4, new Business.Iguaria("Bacalhau � Gomes de S�", foto, 5.5M, 4, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));
            menu.Add(5, new Business.Iguaria("Cabrito Assado", foto, 5.5M, 5, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));
            menu.Add(6, new Business.Iguaria("Tripas � moda do Porto", foto, 5.5M, 6, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));
            menu.Add(7, new Business.Iguaria("Francesinha Especial", foto, 5.5M, 8, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));

            es.RegistarEditarEmenta(menu);

            es.CarregarEmenta();


            Dictionary<int, Business.Iguaria> list = es.AreaEstabelecimentoEstabelecimento.IguariasMap;
            foreach (var item in list)
            {
                Console.WriteLine("Iguaria : {0}", item.Value.Nome);
            }

            */

            AreaCliente cl = new AreaCliente();

            cl.RegistarCliente("to_silva@mail.com", "mm", "Ant�nio Silva");

            cl.Login("to_silva@mail.com", "m1");
            Console.WriteLine(cl.AreaClienteCliente.ToString());
            Business.Iguaria[] igu = cl.GerarPedido("Bife").ToArray();
             foreach (var item in igu)
             {
                 Console.WriteLine(item.ToString());
             }

             int idIguaria = 2;
             int idEstabelecimento = 1;
             Console.WriteLine("Digite um ID iguaria");
             idIguaria =  Int32.Parse(Console.ReadLine());
             Console.WriteLine("Digite um ID Estabelecimento");
             idEstabelecimento = Int32.Parse(Console.ReadLine());
            Business.Estabelecimento estab = cl.EscolherIguaria(idIguaria, idEstabelecimento);

            Console.WriteLine(estab.ToString());
            Console.ReadLine();
            Console.WriteLine("Publicar critica??(0-N, 1-S)");
            int pub = Int32.Parse(Console.ReadLine());
            decimal ratingEstabelecimento = 0;
            decimal ratingIgu = 5;
            string descricao = "Excelente!";
              switch (pub)
              {
                  case 0:
                      break;

                  case 1:
                      Console.WriteLine("Escreva a critica!");
                      descricao = Console.ReadLine();
                      Console.WriteLine("Avalie o estabelecimento!");
                      ratingEstabelecimento = Decimal.Parse(Console.ReadLine());
                      Console.WriteLine("Avalie a Iguaria!");
                      ratingIgu= Decimal.Parse(Console.ReadLine());
            cl.PublicarCritica(estab.IguariasMap[idIguaria].IdIguaria, estab.IdEstabelecimento, descricao, ratingEstabelecimento, ratingIgu);
                 break;
          }
            Console.WriteLine("Consultar prefer�ncias");
            cl.ConsultarPreferencias();

            Console.WriteLine("Editar prefer�ncias");
            
            cl.EditarPreferencias(0, 0, 0, 1, 2);
            Console.WriteLine(cl.AreaClienteCliente.ToString());
            Console.ReadLine();
            Console.WriteLine("Consultar prefer�ncias");
            cl.ConsultarPreferencias();
            Console.WriteLine(cl.AreaClienteCliente.ListaPreferencias.ToString());
            Console.WriteLine("Atualizar Cliente");
            cl.AtualizarCliente("m1", "Ant�nio Lopes da Silva");
            Console.WriteLine(cl.AreaClienteCliente.ToString());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Hist�rico");

            Business.Iguaria[] ls = cl.ConsultarHistorico().ToArray();

            foreach (var item in ls)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine();
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            List<string>[] matrix = cl.ListarTendencias().ToArray();

            Console.WriteLine("Rating Iguarias\n --------------");
            foreach (var item in matrix[0])
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Popularidade Iguarias\n --------------");
            foreach (var item in matrix[1])
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Rating Estabelecimentos\n --------------");
            foreach (var item in matrix[2])
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Popularidade Estabelecimentos\n --------------");
            foreach (var item in matrix[3])
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            

            

            Console.WriteLine(estab.ToString());

            Console.ReadLine();
        }
        finally
        {
            BasedeDadosMMPersistentManager.Instance().DisposePersistentManager();
        }

    }

}

