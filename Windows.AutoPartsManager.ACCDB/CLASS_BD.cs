using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.AutoPartsManager.ACCDB
{
    class CLASS_BD
    {
        public static string EnderecoBD = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\\bd.accdb;";

        public static string QUERY_PreencherDataGridView_Carrocaria = "SELECT * FROM (Carrocaria INNER JOIN Marca ON Carrocaria.MarcaID = Marca.ID) INNER JOIN Modelo ON Modelo.ID = Carrocaria.ModeloID;";

        public static string QUERY_PreencherDataGridView_Bateria = "SELECT * FROM Bateria;";

        public static string QUERY_PreencherDataGridView_Pintura = "SELECT * FROM Pintura INNER JOIN PinturaTipo ON Pintura.Tipo = PinturaTipo.ID;";

        public static string QUERY_PreencherComboBox_MarcasCarrocaria = "SELECT * FROM Marca";

        public static string ALTERAR_NomeAntigo_Carrocaria = "";

        public static string ALTERAR_NomeAntigo_Bateria = "";

        public static string ALTERAR_NomeAntigo_Pintura = "";
    }
}
