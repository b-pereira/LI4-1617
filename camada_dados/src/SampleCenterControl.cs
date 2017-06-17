using System;
using System.Collections.Generic;
using Business;

public class SampleCenterControl
{

    static void Main(string[] args)
    {
        try
        {
            //CreateBasedeDadosMMDatabaseSchema.Main(args);
            //CreateBasedeDadosMMData.Main(args);
            //RetrieveAndUpdateBasedeDadosMMData.Main(args);
            //ListBasedeDadosMMData.Main(args);
            //DeleteBasedeDadosMMData.Main(args);
            //DropBasedeDadosMMDatabaseSchema.Main(args);

            Console.WriteLine("A iniciar ... aguarde!");

            //AreaCliente cl = new AreaCliente(1);

            //cl.RegistarCliente("fljaljfla", "mm", "José Lopes da Silva");
            // cl.GerarPedido("Beef");
            //cl.EscolherIguaria(2, 1);
            //cl.EscolherIguaria(1, 1);
            List<Horario> horarios = new List<Horario>();

            for (byte i = 1; i < 8; i++)
            {

                horarios.Add(new Horario(i, new TimeSpan(9, 0, 0), new TimeSpan(23, 59, 00)));
            }
           


            AreaEstabelecimento es = new AreaEstabelecimento();
            
            es.RegistarEstabelecimento("ze@boavista.pt", "pantera", "Acolhedor. Informal.", "Tasca do Zé", 226185325, horarios, new Endereco("4100-031", 41.1664667m, "Porto", -8.6577359m, 437, "R. Dr. Alberto de Macedo"), 1);
            es.Login("ze@boavista.pt", "pantera");

            byte[] foto = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Dictionary<int, Business.Iguaria> menu = new Dictionary<int, Business.Iguaria>();
            menu.Add(1, new Business.Iguaria("Bifana", foto, 5.5M, 1, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));
            menu.Add(2, new Business.Iguaria("Caldo Verde", foto, 5.5M, 2, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));
            menu.Add(3, new Business.Iguaria("Broa", foto, 5.5M, 3, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));
            menu.Add(4, new Business.Iguaria("Bacalhau à Gomes de Sá", foto, 5.5M, 4, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));
            menu.Add(5, new Business.Iguaria("Cabrito Assado", foto, 5.5M, 5, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));
            menu.Add(6, new Business.Iguaria("Tripas à moda do Porto", foto, 5.5M, 6, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));
            //menu.Add(8, new Business.Iguaria("Francesinha Especial", foto, 5.5M, 8, es.AreaEstabelecimentoEstabelecimento.IdEstabelecimento, IguariaStatus.ToInsert));

            es.RegistarEditarEmenta(menu);
            
            es.CarregarEmenta();

            
            Dictionary<int, Business.Iguaria> list = es.AreaEstabelecimentoEstabelecimento.IguariasMap;
            foreach (var item in list)
            {
                Console.WriteLine("Iguaria : {0}", item.Value.Nome);
            }

            Console.ReadLine();
        }
        finally
        {
            BasedeDadosMMPersistentManager.Instance().DisposePersistentManager();
        }

    }

}

