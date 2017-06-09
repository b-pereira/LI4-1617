using System;
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
        ListBasedeDadosMMData.Main(args);
        //Delete
        //DeleteBasedeDadosMMData.Main(args);


        // Para apagar base de dados
        //DropBasedeDadosMMDatabaseSchema.Main(args);
    }

}

