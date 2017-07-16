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
    public partial class FORM_ADICIONAR_BATERIA : Form
    {
        FORM_INICIO FormInicio_Objects = (FORM_INICIO)Application.OpenForms["FORM_INICIO"];

        OleDbConnection LigacaoDB = new OleDbConnection(CLASS_BD.EnderecoBD);

        OleDbDataReader Reader;

        OleDbDataAdapter Adapter = new OleDbDataAdapter();

        DataTable TabelaDados = new DataTable();

        public FORM_ADICIONAR_BATERIA()
        {
            InitializeComponent();

            TEXTBOX_NOME.Text = "";
            TEXTBOX_PRECO.Text = "";
            TEXTBOX_AMPERS.Text = "";
            TEXTBOX_DESCRICAO.Text = "";
            TEXTBOX_STOCK.Text = "";
        }

        private void TEXTBOX_NOME_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_AMPERS.Text != "" && TEXTBOX_DESCRICAO.Text != "" && TEXTBOX_STOCK.Text != "")
                MENUSTRIP_AdicionarBateria_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarBateria_BUTTON_ADICIONAR.Enabled = false;
        }

        private void TEXTBOX_NOME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_DESCRICAO_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_AMPERS.Text != "" && TEXTBOX_DESCRICAO.Text != "" && TEXTBOX_STOCK.Text != "")
                MENUSTRIP_AdicionarBateria_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarBateria_BUTTON_ADICIONAR.Enabled = false;
        }

        private void TEXTBOX_AMPERS_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_AMPERS.Text != "" && TEXTBOX_DESCRICAO.Text != "" && TEXTBOX_STOCK.Text != "")
                MENUSTRIP_AdicionarBateria_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarBateria_BUTTON_ADICIONAR.Enabled = false;
        }

        private void TEXTBOX_AMPERS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_PRECO_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_AMPERS.Text != "" && TEXTBOX_DESCRICAO.Text != "" && TEXTBOX_STOCK.Text != "")
                MENUSTRIP_AdicionarBateria_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarBateria_BUTTON_ADICIONAR.Enabled = false;
        }

        private void TEXTBOX_PRECO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_STOCK_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_AMPERS.Text != "" && TEXTBOX_DESCRICAO.Text != "" && TEXTBOX_STOCK.Text != "")
                MENUSTRIP_AdicionarBateria_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarBateria_BUTTON_ADICIONAR.Enabled = false;
        }

        private void TEXTBOX_STOCK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void MENUSTRIP_AdicionarBateria_BUTTON_ADICIONAR_Click(object sender, EventArgs e)
        {
            string Nome = TEXTBOX_NOME.Text;
            string Ampers = TEXTBOX_AMPERS.Text;
            string Preco = TEXTBOX_PRECO.Text;
            string Stock = TEXTBOX_STOCK.Text;
            string Descricao = TEXTBOX_DESCRICAO.Text;

            AdicionarBateria(Nome, Ampers, Preco, Stock, Descricao);

            Reset();
        }

        private void MENUSTRIP_AdicionarBateria_BUTTON_FECHAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AdicionarBateria(string Nome, string Ampers, string Preco, string Stock, string Descricao)
        {
            try
            {
                LigacaoDB.Open();

                string QUERY_InserirBateria = "INSERT INTO Bateria(Nome, Ampers, Preco, Stock, Descricao) VALUES('" + Nome + "','" + Ampers + "','" + Preco + "','" + Stock + "','" + Descricao + "')";

                OleDbCommand COMANDO_InserirBateria = new OleDbCommand(QUERY_InserirBateria, LigacaoDB);

                COMANDO_InserirBateria.ExecuteNonQuery();

                LigacaoDB.Close();

                MessageBox.Show("Carrocaria adicionada com sucesso!", "Carrocaria Adicionada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult DR = MessageBox.Show("Deseja continuar a adicionar baterias?", "Continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (LigacaoDB.State == ConnectionState.Open)
                    LigacaoDB.Close();

                FormInicio_Objects.TabelaDados_Bateria.Clear();
                FormInicio_Objects.TabelaDados2_Bateria.Clear();

                FormInicio_Objects.PreencherDataGridView_Bateria();
                FormInicio_Objects.OcultarColunasDesnecessarias_Bateria();
                FormInicio_Objects.ResetBateria();
                FormInicio_Objects.CalcularTotalBateria();
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
            TEXTBOX_AMPERS.Text = "";
            TEXTBOX_PRECO.Text = "";
            TEXTBOX_STOCK.Text = "";
            TEXTBOX_DESCRICAO.Text = "";
        }
    }
}
