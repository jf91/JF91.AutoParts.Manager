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
    public partial class FORM_ADICIONAR_MARCA : Form
    {
        OleDbConnection LigacaoDB = new OleDbConnection(CLASS_BD.EnderecoBD);

        OleDbDataReader Reader;

        OleDbDataAdapter Adapter_ProcurarMarcas = new OleDbDataAdapter();
        OleDbDataAdapter Adapter_ProcurarModelosMarcas = new OleDbDataAdapter();

        DataTable TabelaDados = new DataTable();
        DataTable TabelaDados2 = new DataTable();

        public FORM_ADICIONAR_MARCA()
        {
            InitializeComponent();

            TEXTBOX_MARCA.Text = "";
            TEXTBOX_MODELO.Text = "";

            PreencherListBox_Marcas();
            ProcurarModelosMarcas();
        }

        private void TEXTBOX_MARCA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true)
                e.Handled = true;
        }

        private void LISTVIEW_MARCAS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LISTVIEW_MARCAS.SelectedItems.Count == -1 || LISTVIEW_MARCAS.SelectedItems.Count == 0)
                BUTTON_REMOVER_MARCA.Enabled = false;
            else
                BUTTON_REMOVER_MARCA.Enabled = true;
        }

        private void LISTVIEW_MARCAS_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (LISTVIEW_MARCAS.SelectedItems.Count == -1 || LISTVIEW_MARCAS.SelectedItems.Count == 0)
                BUTTON_REMOVER_MARCA.Enabled = false;
            else
                BUTTON_REMOVER_MARCA.Enabled = true;
        }

        private void MENUSTRIP_AdicionarMarca_BUTTON_FECHAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BUTTON_ADICIONAR_MARCA_Click(object sender, EventArgs e)
        {
            if (TEXTBOX_MARCA.Text != "")
            {
                TREEVIEW_MODELOS.Nodes.Clear();
                LISTVIEW_MARCAS.Items.Clear();

                AdicionarMarca(TEXTBOX_MARCA.Text);

                Reset();

                PreencherListBox_Marcas();
                ProcurarModelosMarcas();
            }
        }

        private void BUTTON_REMOVER_MARCA_Click(object sender, EventArgs e)
        {
            for (int idx = LISTVIEW_MARCAS.Items.Count - 1; idx >= 0; idx--)
            {
                if (LISTVIEW_MARCAS.Items[idx].Selected == true)
                {
                    RemoverMarca(LISTVIEW_MARCAS.Items[idx].Text.ToString());
                }
            }

            TREEVIEW_MODELOS.Nodes.Clear();
            LISTVIEW_MARCAS.Items.Clear();

            Reset();

            PreencherListBox_Marcas();
            ProcurarModelosMarcas();
        }

        private void BUTTON_ADICIONAR_MODELO_Click(object sender, EventArgs e)
        {
            string Marca = "";

            if (TEXTBOX_MODELO.Text != "")
            {
                foreach (TreeNode TN in TREEVIEW_MODELOS.Nodes)
                {
                    if (TN.IsSelected == true)
                    {
                        Marca = TN.Text.ToString();
                    }

                    foreach (TreeNode TN2 in TN.Nodes)
                    {
                        if (TN2.IsSelected == true)
                        {
                            Marca = TN2.Tag.ToString();
                        }
                    }
                }

                if (Marca != "")
                {
                    TREEVIEW_MODELOS.Nodes.Clear();
                    LISTVIEW_MARCAS.Items.Clear();

                    AdicionarModelo(Marca, TEXTBOX_MODELO.Text);

                    Reset();

                    PreencherListBox_Marcas();
                    ProcurarModelosMarcas();
                }
            }
        }

        private void BUTTON_REMOVER_MODELO_Click(object sender, EventArgs e)
        {
            string Modelo = "";

            foreach (TreeNode TN in TREEVIEW_MODELOS.Nodes)
            {
                foreach (TreeNode TN2 in TN.Nodes)
                {
                    if (TN.IsSelected == true || TN2.IsSelected == true)
                    {
                        Modelo = TN2.Text;
                    }
                }
            }

            if (Modelo != "")
            {
                RemoverModelo(Modelo);

                TREEVIEW_MODELOS.Nodes.Clear();
                LISTVIEW_MARCAS.Items.Clear();

                Reset();

                PreencherListBox_Marcas();
                ProcurarModelosMarcas();
            }
        }

        private void TREEVIEW_MODELOS_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode TN in TREEVIEW_MODELOS.Nodes)
            {
                foreach (TreeNode TN2 in TN.Nodes)
                {
                    if (TN.IsSelected == true || TN2.IsSelected == true)
                    {
                        BUTTON_REMOVER_MODELO.Enabled = true;
                        return;
                    }

                    else
                        BUTTON_REMOVER_MODELO.Enabled = false;
                }
            }
        }

        public void PreencherListBox_Marcas()
        {
            try
            {
                LigacaoDB.Open();

                ListViewItem LVI = new ListViewItem();

                string QUERY_ProcurarMarcas = "SELECT * FROM Marca";

                OleDbCommand COMANDO_ProcurarMarcas = new OleDbCommand(QUERY_ProcurarMarcas, LigacaoDB);

                Reader = COMANDO_ProcurarMarcas.ExecuteReader();

                while(Reader.Read())
                {
                    LISTVIEW_MARCAS.Items.Add((Reader["Nome"].ToString()));
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

        public void ProcurarModelosMarcas()
        {
            try
            {
                LigacaoDB.Open();

                string QUERY_ProcurarMarca = "SELECT * FROM Marca";
                string QUERY_ProcurarModelo = "SELECT * FROM Modelo";

                OleDbCommand COMANDO_ProcurarMarca = new OleDbCommand(QUERY_ProcurarMarca, LigacaoDB);
                OleDbCommand COMANDO_ProcurarModelo = new OleDbCommand(QUERY_ProcurarModelo, LigacaoDB);

                Adapter_ProcurarMarcas.SelectCommand = COMANDO_ProcurarMarca;
                Adapter_ProcurarModelosMarcas.SelectCommand = COMANDO_ProcurarModelo;

                Adapter_ProcurarMarcas.Fill(TabelaDados);
                Adapter_ProcurarModelosMarcas.Fill(TabelaDados2);

                PreencherTreeView_Modelos(TabelaDados, TabelaDados2, TREEVIEW_MODELOS.Nodes);

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void PreencherTreeView_Modelos(DataTable TabelaDados, DataTable TabelaDados2, TreeNodeCollection NODES)
        {
            foreach(DataRow ROW in TabelaDados.Rows)
            {
                //string Marca = ROW["Nome"].ToString();

                TreeNode TN = new TreeNode();
                TN.Text = ROW["Nome"].ToString();
                TN.Tag = ROW["ID"].ToString();

                TREEVIEW_MODELOS.Nodes.Add(TN);

                foreach(DataRow ROW2 in TabelaDados2.Rows)
                {
                    if (ROW2["ID_Marca"].ToString() == ROW["ID"].ToString())
                    {
                        foreach(TreeNode Marca in TREEVIEW_MODELOS.Nodes)
                        {
                            if (Marca.Tag.ToString() == ROW2["ID_Marca"].ToString())
                            {
                                TreeNode TN2 = new TreeNode();
                                TN2.Text = ROW2["Nome"].ToString();
                                TN2.Tag = ROW["Nome"].ToString();

                                Marca.Nodes.Add(TN2);
                            }
                        }
                    }

                }
            }

            TabelaDados.Clear();
            TabelaDados2.Clear();
        }        

        public void AdicionarMarca(string Marca)
        {
            try
            {
                LigacaoDB.Open();

                string QUERY_InserirMarca = "INSERT INTO Marca(Nome) VALUES('" + Marca + "');";

                OleDbCommand COMANDO_InserirMarca = new OleDbCommand(QUERY_InserirMarca, LigacaoDB);

                COMANDO_InserirMarca.ExecuteNonQuery();

                LigacaoDB.Close();

                MessageBox.Show("Marca adicionada com sucesso!", "Marca Adicionada: " + Marca + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void RemoverMarca(string Marca)
        {
            try
            {
                LigacaoDB.Open();

                string QUERY_RemoverMarca = "DELETE FROM Marca WHERE Nome = '" + Marca + "'";

                OleDbCommand COMANDO_RemoverMarca = new OleDbCommand(QUERY_RemoverMarca, LigacaoDB);

                COMANDO_RemoverMarca.ExecuteNonQuery();

                LigacaoDB.Close();

                MessageBox.Show("Marca removida com sucesso!", "Marca Removida: " + Marca + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void AdicionarModelo(string Marca, string Modelo)
        {
            try
            {
                LigacaoDB.Open();

                string QUERY_Adquirir_MarcaID = "SELECT ID FROM Marca WHERE Nome = '" + Marca + "'";

                OleDbCommand COMANDO_Adquirir_MarcaID = new OleDbCommand(QUERY_Adquirir_MarcaID, LigacaoDB);

                string MarcaID = COMANDO_Adquirir_MarcaID.ExecuteScalar().ToString();

                string QUERY_InserirModelo = "INSERT INTO Modelo(Nome, ID_Marca) VALUES('" + Modelo + "'," + MarcaID + ");";

                OleDbCommand COMANDO_InserirModelo = new OleDbCommand(QUERY_InserirModelo, LigacaoDB);

                COMANDO_InserirModelo.ExecuteNonQuery();

                LigacaoDB.Close();

                MessageBox.Show("Modelo adicionado com sucesso!", "Modelo Adicionado: " + Modelo + " na marca" + Marca + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void RemoverModelo(string Modelo)
        {
            if(BUTTON_REMOVER_MODELO.Enabled == true)
            {
                try
                {
                    LigacaoDB.Open();

                    string QUERY_RemoverModelo = "DELETE FROM Modelo WHERE Nome = '" + Modelo + "'";

                    OleDbCommand COMANDO_RemoverModelo = new OleDbCommand(QUERY_RemoverModelo, LigacaoDB);

                    COMANDO_RemoverModelo.ExecuteNonQuery();

                    LigacaoDB.Close();

                    MessageBox.Show("Modelo removido com sucesso!", "Modelo Removido: " + Modelo + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                    LigacaoDB.Close();
                }
            }
        }

        public void Reset()
        {
            TEXTBOX_MARCA.Text = "";
            TEXTBOX_MODELO.Text = "";

            LISTVIEW_MARCAS.Items.Clear();
            TREEVIEW_MODELOS.Nodes.Clear();
        }
    }
}
