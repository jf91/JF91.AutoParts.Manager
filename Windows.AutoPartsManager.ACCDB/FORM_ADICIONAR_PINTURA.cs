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
    public partial class FORM_ADICIONAR_PINTURA : Form
    {
        FORM_INICIO FormInicio_Objects = (FORM_INICIO)Application.OpenForms["FORM_INICIO"];

        OleDbConnection LigacaoDB = new OleDbConnection(CLASS_BD.EnderecoBD);

        OleDbDataReader Reader;

        OleDbDataAdapter Adapter = new OleDbDataAdapter();

        DataTable TabelaDados = new DataTable();

        public FORM_ADICIONAR_PINTURA()
        {
            InitializeComponent();

            TEXTBOX_NOME.Text = "";
            TEXTBOX_DESCRICAO.Text = "";
            TEXTBOX_PRECO.Text = "";
            TEXTBOX_STOCK.Text = "";
            COMBOBOX_TIPO.SelectedIndex = -1;
        }

        private void TEXTBOX_NOME_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_DESCRICAO.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_STOCK.Text != "" && COMBOBOX_TIPO.SelectedIndex != -1)
                MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Enabled = false;
        }

        private void TEXTBOX_DESCRICAO_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_DESCRICAO.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_STOCK.Text != "" && COMBOBOX_TIPO.SelectedIndex != -1)
                MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Enabled = false;
        }

        private void TEXTBOX_PRECO_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_DESCRICAO.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_STOCK.Text != "" && COMBOBOX_TIPO.SelectedIndex != -1)
                MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Enabled = false;
        }

        private void TEXTBOX_PRECO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void COMBOBOX_TIPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_DESCRICAO.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_STOCK.Text != "" && COMBOBOX_TIPO.SelectedIndex != -1)
                MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Enabled = false;
        }

        private void TEXTBOX_STOCK_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_NOME.Text != "" && TEXTBOX_DESCRICAO.Text != "" && TEXTBOX_PRECO.Text != "" && TEXTBOX_STOCK.Text != "" && COMBOBOX_TIPO.SelectedIndex != -1)
                MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Enabled = true;
            else
                MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Enabled = false;
        }

        private void TEXTBOX_STOCK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR_Click(object sender, EventArgs e)
        {
            string Nome = TEXTBOX_NOME.Text;
            string Descricao = TEXTBOX_DESCRICAO.Text;
            string Preco = TEXTBOX_PRECO.Text;
            string Stock = TEXTBOX_STOCK.Text;
            string Tipo = COMBOBOX_TIPO.Text;

            AdicionarPintura(Nome, Descricao, Preco, Stock, Tipo);

            Reset();
        }

        private void MENUSTRIP_AdicionarPintura_BUTTON_FECHAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }    

        public void AdicionarPintura(string Nome, string Descricao, string Preco, string Stock, string Tipo)
        {
            try
            {
                LigacaoDB.Open();

                string QUERY_TipoID = "SELECT ID FROM PinturaTipo WHERE Nome = '" + Tipo + "'";
                OleDbCommand COMANDO_TipoID = new OleDbCommand(QUERY_TipoID, LigacaoDB);
                string TipoID = COMANDO_TipoID.ExecuteScalar().ToString();

                string QUERY_InserirPintura = "INSERT INTO Pintura(Nome, Preco, Stock, Tipo, Descricao) VALUES('" + Nome + "','" + Preco + "','" + Stock + "','" + TipoID + "','" + Descricao + "')";

                OleDbCommand COMANDO_InserirPintura = new OleDbCommand(QUERY_InserirPintura, LigacaoDB);

                COMANDO_InserirPintura.ExecuteNonQuery();

                LigacaoDB.Close();

                MessageBox.Show("Pintura adicionada com sucesso!", "Pintura Adicionada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult DR = MessageBox.Show("Deseja continuar a adicionar pinturas?", "Continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (LigacaoDB.State == ConnectionState.Open)
                    LigacaoDB.Close();

                FormInicio_Objects.TabelaDados_Pintura.Clear();
                FormInicio_Objects.TabelaDados2_Pintura.Clear();

                FormInicio_Objects.PreencherDataGridView_Pintura();
                FormInicio_Objects.OcultarColunasDesnecessarias_Pintura();
                FormInicio_Objects.ResetPintura();
                FormInicio_Objects.CalcularTotalPintura();
                //FormInicio_Objects.CalcularTotalPinturaFiltrada();
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
            TEXTBOX_DESCRICAO.Text = "";
            TEXTBOX_PRECO.Text = "";
            TEXTBOX_STOCK.Text = "";
            COMBOBOX_TIPO.SelectedIndex = -1;
        }
    }
}
