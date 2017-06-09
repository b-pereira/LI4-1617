using System;
using Orm;
public class SampleCenterControl
{
    [STAThread]
    static void Main(string[] args)
    {
        //Para criar base de dados
        //CreateBasedeDadosMMDatabaseSchema.Main(args);

        /**
        * Estas 4 classes é que interessam
*/
        // Insert
        //CreateBasedeDadosMMData.Main(args);
        // Update
        //RetrieveAndUpdateBasedeDadosMMData.Main(args);
        // Select
        //ListBasedeDadosMMData.Main(args);
        //Delete
        //DeleteBasedeDadosMMData.Main(args);

        PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
        try
        {
            Cliente_seleciona_iguariaCriteria cliente_seleciona_iguariaCriteria = new Cliente_seleciona_iguariaCriteria();
                cliente_seleciona_iguariaCriteria.Cliente_id_cliente.Eq(1);
                cliente_seleciona_iguariaCriteria.Iguaria_Estabelecimento.Eq(1);
            cliente_seleciona_iguariaCriteria.Iguaria_id_iguaria.Eq(1);

                Cliente_seleciona_iguaria clsig = cliente_seleciona_iguariaCriteria.UniqueCliente_seleciona_iguaria();
            SelecaoIguariaCriteria selecaoIguariaCriteria = new SelecaoIguariaCriteria();
            

            selecaoIguariaCriteria.Cliente_Cliente.Eq(1);
            
            selecaoIguariaCriteria.Cliente_Iguaria.Eq(1);
            selecaoIguariaCriteria.Cliente_Estabelecimento.Eq(1);

            SelecaoIguaria[] si = selecaoIguariaCriteria.ListSelecaoIguaria();

            for (int i = si.Length -1; i >= 0; i--)
            {
                Console.WriteLine("ID {0}", si[i].ToString());
                if (i == si.Length - 5)
                    break;
            }

            Console.WriteLine("ID {0}", clsig.ToString());
            Console.ReadLine();

           

        }
        catch (Exception e)
        {
            t.RollBack();
            Console.WriteLine(e);
            Console.ReadLine();
        }
        finally
        {
            BasedeDadosMMPersistentManager.Instance().DisposePersistentManager();
        }


        // Para apagar base de dados
        //DropBasedeDadosMMDatabaseSchema.Main(args);
    }

}

