using System;
public class SampleCenterControl {
	[STAThread]
	static void Main(string[] args) {
        try
        {
            //CreateBasedeDadosMMDatabaseSchema.Main(args);
            //CreateBasedeDadosMMData.Main(args);
            //RetrieveAndUpdateBasedeDadosMMData.Main(args);
            //ListBasedeDadosMMData.Main(args);
            //DeleteBasedeDadosMMData.Main(args);
            //DropBasedeDadosMMDatabaseSchema.Main(args);

            Console.WriteLine("A iniciar ... aguarde!");

            AreaCliente cl = new AreaCliente(1);

            //cl.RegistarCliente("fljaljfla", "mm", "José Lopes da Silva");
            cl.GerarPedido("Beef");
            //cl.EscolherIguaria(2, 1);
            //cl.EscolherIguaria(1, 1);
            //cl.ListarTendencias();

            Console.ReadLine();
        }
        finally
        {
            BasedeDadosMMPersistentManager.Instance().DisposePersistentManager();
        }

    }
	
}

