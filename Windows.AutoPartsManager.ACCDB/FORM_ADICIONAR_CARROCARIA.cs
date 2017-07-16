using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Windows.AutoPartsManager.ACCDB
{
    public partial class FORM_ADICIONAR_CARROCARIA : Form
    {
        FORM_INICIO FormInicio_Objects = (FORM_INICIO)Application.OpenForms["FORM_INICIO"];        

        OleDbConnection LigacaoDB = new OleDbConnection(CLASS_BD.EnderecoBD);

        OleDbDataReader Reader;

        OleDbDataAdapter Adapter = new OleDbDataAdapter();

        DataTable TabelaDados = new DataTable();

        public FORM_ADICIONAR_CARROCARIA()
        {
            InitializeComponent();

            PreencherComboBox_MarcasCarrocaria();

            TEXTBOX_NOME.Text = "";
            TEXTBOX_PRECO.Text = "";
            TEXTBOX_STOCK.Text = "";
            TEXTBOX_DESCRICAO.Text = "";
        }

        private void TEXTBOX_NOME_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_STOCK.Text != "" && TEXTBOX_DESCRICAO.Text != "")
                MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Enabled = false;
        }

        private void TEXTBOX_PRECO_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_STOCK.Text != "" && TEXTBOX_DESCRICAO.Text != "")
                MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Enabled = false;
        }

        private void TEXTBOX_PRECO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_STOCK_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_STOCK.Text != "" && TEXTBOX_DESCRICAO.Text != "")
                MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Enabled = false;
        }        

        private void TEXTBOX_STOCK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_DESCRICAO_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_STOCK.Text != "" && TEXTBOX_DESCRICAO.Text != "")
                MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Enabled = false;
        }

        private void COMBOBOX_MARCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (COMBOBOX_MARCA.SelectedIndex != -1)
            {
                COMBOBOX_MODELO.Items.Clear();
                PreencherComboBox_ModelosCarrocaria();
                COMBOBOX_MODELO.SelectedIndex = 0;
                COMBOBOX_MODELO.Enabled = true;
            }
        }

        private void MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR_Click(object sender, EventArgs e)
        {
            string Nome = TEXTBOX_NOME.Text;
            string Descricao = TEXTBOX_DESCRICAO.Text;
            string Preco = TEXTBOX_PRECO.Text;
            string Stock = TEXTBOX_STOCK.Text;
            string Marca = COMBOBOX_MARCA.SelectedItem.ToString();
            string Modelo = COMBOBOX_MODELO.SelectedItem.ToString();
            string Ano = DATETIMEPICKER_ANO.Value.Year.ToString();

            AdicionarCarrocaria(Nome, Descricao, Preco, Stock, Marca, Modelo, Ano);

            Reset();
        }

        private void MENUSTRIP_AdicionarCarrocaria_BUTTON_FECHAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void PreencherComboBox_MarcasCarrocaria()
        {
            try
            {
                LigacaoDB.Open();

                OleDbCommand COMANDO_PreencherComboBox_MarcasCarrocaria = new OleDbCommand(CLASS_BD.QUERY_PreencherComboBox_MarcasCarrocaria, LigacaoDB);

                Reader = COMANDO_PreencherComboBox_MarcasCarrocaria.ExecuteReader();

                while (Reader.Read())
                {
                    COMBOBOX_MARCA.Items.Add(Reader["Nome"].ToString());
                }

                Reader.Close();

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void PreencherComboBox_ModelosCarrocaria()
        {
            try
            {
                LigacaoDB.Open();

                string QUERY_PreencherComboBox_MarcaID_Modelo = "SELECT ID FROM Marca WHERE Nome = '" + COMBOBOX_MARCA.SelectedItem.ToString() + "'";

                OleDbCommand COMANDO_MarcaID_Modelo = new OleDbCommand(QUERY_PreencherComboBox_MarcaID_Modelo, LigacaoDB);

                string MarcaID = COMANDO_MarcaID_Modelo.ExecuteScalar().ToString();

                string QUERY_PreencherComboBox__ModeloMarca_Carrocaria = "SELECT Nome FROM Modelo WHERE ID_Marca =  " + MarcaID + "";

                OleDbCommand COMANDO_ModeloMarca = new OleDbCommand(QUERY_PreencherComboBox__ModeloMarca_Carrocaria, LigacaoDB);

                Reader = COMANDO_ModeloMarca.ExecuteReader();

                while (Reader.Read())
                {
                    COMBOBOX_MODELO.Items.Add(Reader["Nome"].ToString());
                }

                Reader.Close();

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void AdicionarCarrocaria(string Nome, string Descricao, string Preco, string Stock, string Marca, string Modelo, string Ano)
        {
            try
            {
                LigacaoDB.Open();

                string QUERY_AUX_MarcaID = "SELECT ID FROM Marca WHERE Nome = '" + COMBOBOX_MARCA.Text + "'";
                OleDbCommand COMANDO_AUX_MarcaID = new OleDbCommand(QUERY_AUX_MarcaID, LigacaoDB);
                string AUX_MarcaID = COMANDO_AUX_MarcaID.ExecuteScalar().ToString();

                string QUERY_AUX_ModelID = "SELECT ID FROM Modelo WHERE Nome = '" + COMBOBOX_MODELO.Text + "'";
                OleDbCommand COMANDO_AUX_ModelID = new OleDbCommand(QUERY_AUX_ModelID, LigacaoDB);
                string AUX_ModelID = COMANDO_AUX_ModelID.ExecuteScalar().ToString();



                string QUERY_InserirCarrocaria = "INSERT INTO Carrocaria(Nome, Descricao, Preco, Ano, Stock, MarcaID, ModeloID) VALUES('" + Nome + "','" + Descricao + "','" + Preco + "','" + Ano + "','" + Stock + "','" + AUX_MarcaID + "','" + AUX_ModelID + "')";

                OleDbCommand COMANDO_InserirCarrocaria = new OleDbCommand(QUERY_InserirCarrocaria, LigacaoDB);

                COMANDO_InserirCarrocaria.ExecuteNonQuery();

                LigacaoDB.Close();

                string QUERY_MarcaID = "SELECT ID FROM Marca WHERE Nome = '" + Marca + "'";
                OleDbCommand COMANDO_MarcaID = new OleDbCommand(QUERY_MarcaID, LigacaoDB);

                string QUERY_ModeloID = "SELECT ID FROM Modelo WHERE Nome = '" + Modelo + "'";
                OleDbCommand COMANDO_ModeloID = new OleDbCommand(QUERY_ModeloID, LigacaoDB);

                string QUERY_CarrocariaInseridaID = "SELECT ID FROM Carrocaria WHERE Nome = '" + Nome + "'";
                OleDbCommand COMANDO_CarrocariaInseridaID = new OleDbCommand(QUERY_CarrocariaInseridaID, LigacaoDB);

                LigacaoDB.Open();

                string MarcaID = COMANDO_MarcaID.ExecuteScalar().ToString();
                string ModeloID = COMANDO_ModeloID.ExecuteScalar().ToString();
                string CarrocariaInseridaID = COMANDO_CarrocariaInseridaID.ExecuteScalar().ToString();

                string QUERY_InserirCarrocariaMarcaModelo = "INSERT INTO CarrocariaMarcaModelo(ID_Carrocaria, ID_Marca, ID_Modelo) VALUES(" + Convert.ToInt32(CarrocariaInseridaID) + "," + Convert.ToInt32(MarcaID) + "," + Convert.ToInt32(ModeloID) + ")";
                OleDbCommand COMANDO_InserirCarrocariaMarcaModelo = new OleDbCommand(QUERY_InserirCarrocariaMarcaModelo, LigacaoDB);
                COMANDO_InserirCarrocariaMarcaModelo.ExecuteNonQuery();

                LigacaoDB.Close();                

                MessageBox.Show("Carrocaria adicionada com sucesso!", "Carrocaria Adicionada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult DR = MessageBox.Show("Deseja continuar a adicionar peças de carroçaria?","Continuar?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (LigacaoDB.State == ConnectionState.Open)
                    LigacaoDB.Close();

                FormInicio_Objects.TabelaDados_Carrocaria.Clear();
                FormInicio_Objects.TabelaDados2_Carrocaria.Clear();

                FormInicio_Objects.PreencherDataGridView_Carrocaria();
                FormInicio_Objects.OcultarColunasDesnecessarias_Carrocaria();
                FormInicio_Objects.ResetCarrocaria();
                FormInicio_Objects.CalcularTotalCarrocaria();
                FormInicio_Objects.CalcularTotalProdutos();

                if (DR == DialogResult.Yes)
                    return;
                if (DR == DialogResult.No)
                    this.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void Reset()
        {
            TEXTBOX_NOME.Text = "";
            TEXTBOX_PRECO.Text = "";
            TEXTBOX_STOCK.Text = "";
            TEXTBOX_DESCRICAO.Text = "";

            COMBOBOX_MARCA.SelectedIndex = -1;
            COMBOBOX_MODELO.SelectedIndex = -1;

            DATETIMEPICKER_ANO.Value = DateTime.Today;
        }  
    }
}
