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
using MsAccess = Microsoft.Office.Interop.Access;
using System.Runtime.InteropServices;

namespace Windows.AutoPartsManager.ACCDB
{
    public partial class FORM_INICIO : Form
    {
        #region OBJECTOS GLOBAIS DE ACESSO À BASE DE DADOS

        OleDbConnection LigacaoDB = new OleDbConnection(CLASS_BD.EnderecoBD);

        OleDbDataReader Reader_Carrocaria;
        OleDbDataReader Reader_Bateria;
        OleDbDataReader Reader_Pintura;

        OleDbDataAdapter Adapter_Carrocaria = new OleDbDataAdapter();
        OleDbDataAdapter Adapter_Bateria = new OleDbDataAdapter();
        OleDbDataAdapter Adapter_Pintura = new OleDbDataAdapter();

        public DataTable TabelaDados_Carrocaria = new DataTable();
        public DataTable TabelaDados2_Carrocaria = new DataTable();

        public DataTable TabelaDados_Bateria = new DataTable();
        public DataTable TabelaDados2_Bateria = new DataTable();

        public DataTable TabelaDados_Pintura = new DataTable();
        public DataTable TabelaDados2_Pintura = new DataTable();

        #endregion

        /*----------------------------------------------------------------------------------*/

        #region STRINGS GLOBAIS

        string ALTERAR_NomeAntigo_Carrocaria = "";
        string ALTERAR_DescricaoAntiga_Carrocaria = "";
        string ALTERAR_AnoAntigo_Carrocaria = "";
        string ALTERAR_PrecoAntigo_Carrocaria = "";
        string ALTERAR_StockAntigo_Carrocaria = "";
        string ALTERAR_MarcaAntiga_Carrocaria = "";
        string ALTERAR_ModeloAntigo_Carrocaria = "";

        string ALTERAR_NomeAntigo_Bateria = "";        
        string ALTERAR_AmpersAntigo_Bateria = "";
        string ALTERAR_PrecoAntigo_Bateria = "";
        string ALTERAR_StockAntigo_Bateria = "";
        string ALTERAR_DescricaoAntiga_Bateria = "";

        string ALTERAR_NomeAntigo_Pintura = "";
        string ALTERAR_DescricaoAntiga_Pintura = "";
        string ALTERAR_AnoAntigo_Pintura = "";
        string ALTERAR_PrecoAntigo_Pintura = "";
        string ALTERAR_StockAntigo_Pintura = "";

        #endregion

        /*----------------------------------------------------------------------------------*/

        #region ARRANQUE DA APLICAÇÃO

        public FORM_INICIO()
        {
            InitializeComponent();

            //DATAGRIDVIEW_CARROCARIA.AutoGenerateColumns = false;           

            PreencherDataGridView_Carrocaria();
            PreencherDataGridView_Bateria();
            PreencherDataGridView_Pintura();

            PreencherComboBox_MarcasCarrocaria();

            OcultarColunasDesnecessarias_Carrocaria();
            OcultarColunasDesnecessarias_Pintura();

            MENUSTRIP_FormInicio_BUTTON_ADICIONAR_VALOR.Text = "Carroçaria";

            CalcularTotalCarrocaria();
            CalcularTotalBateria();
            CalcularTotalPintura();

            CalcularTotalProdutos();
        }

        #endregion

        /*----------------------------------------------------------------------------------*/

        #region MÉTODOS GLOBAIS

        #region EVENTOS GLOBAIS

        private void TABCONTROL_FormInicio_Selected(object sender, TabControlEventArgs e)
        {
            if (TABCONTROL_FormInicio.SelectedIndex == 0)
                MENUSTRIP_FormInicio_BUTTON_ADICIONAR_VALOR.Text = "Carroçaria";
            MENUSTRIP_FormInicio_BUTTON_ADICIONAR_MARCA.Visible = true;
            MENUSTRIP_FormInicio_BUTTON_IMPRIMIR.Text = "Imprimir Relatório da Carroçaria";

            if (TABCONTROL_FormInicio.SelectedIndex == 1)
            {
                MENUSTRIP_FormInicio_BUTTON_ADICIONAR_VALOR.Text = "Bateria";
                MENUSTRIP_FormInicio_BUTTON_ADICIONAR_MARCA.Visible = false;
                MENUSTRIP_FormInicio_BUTTON_IMPRIMIR.Text = "Imprimir Relatório da Bateria";
            }

            if (TABCONTROL_FormInicio.SelectedIndex == 2)
            {
                MENUSTRIP_FormInicio_BUTTON_ADICIONAR_VALOR.Text = "Pintura";
                MENUSTRIP_FormInicio_BUTTON_ADICIONAR_MARCA.Visible = false;
                MENUSTRIP_FormInicio_BUTTON_IMPRIMIR.Text = "Imprimir Relatório da Pintura";
            }
        }

        private void FORM_INICIO_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MENUSTRIP_FormInicio_BUTTON_FECHAR_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MENUSTRIP_FormInicio_BUTTON_ADICIONAR_VALOR_Click(object sender, EventArgs e)
        {
            if (TABCONTROL_FormInicio.SelectedIndex == 0)
            {
                FORM_ADICIONAR_CARROCARIA FormAdicionarCarrocaria = new FORM_ADICIONAR_CARROCARIA();
                FormAdicionarCarrocaria.ShowDialog();
            }

            if (TABCONTROL_FormInicio.SelectedIndex == 1)
            {
                FORM_ADICIONAR_BATERIA FormAdicionarBateria = new FORM_ADICIONAR_BATERIA();
                FormAdicionarBateria.ShowDialog();
            }

            if (TABCONTROL_FormInicio.SelectedIndex == 2)
            {
                FORM_ADICIONAR_PINTURA FormAdicionarPintura = new FORM_ADICIONAR_PINTURA();
                FormAdicionarPintura.ShowDialog();
            }
        }

        private void MENUSTRIP_FormInicio_BUTTON_ADICIONAR_MARCA_Click(object sender, EventArgs e)
        {
            FORM_ADICIONAR_MARCA FormAdicionarMarca = new FORM_ADICIONAR_MARCA();
            FormAdicionarMarca.ShowDialog();
        }

        private void MENUSTRIP_FormInicio_BUTTON_REMOVER_Click(object sender, EventArgs e)
        {
            string Nome = "";

            if (TABCONTROL_FormInicio.SelectedIndex == 0)
            {
                Nome = TEXTBOX_TabPageCarrocaria_NOME.Text;

                RemoverCarrocaria(Nome);

                ResetCarrocaria();

                TabelaDados_Carrocaria.Clear();
                TabelaDados2_Carrocaria.Clear();

                PreencherDataGridView_Carrocaria();

                OcultarColunasDesnecessarias_Carrocaria();

                CalcularTotalCarrocaria();
                CalcularTotalProdutos();
            }

            if (TABCONTROL_FormInicio.SelectedIndex == 1)
            {
                Nome = TEXTBOX_TabPageBateria_NOME.Text;

                RemoverBateria(Nome);

                ResetBateria();

                TabelaDados_Bateria.Clear();
                TabelaDados2_Bateria.Clear();

                PreencherDataGridView_Bateria();

                OcultarColunasDesnecessarias_Bateria();

                CalcularTotalBateria();
                CalcularTotalProdutos();
            }

            if (TABCONTROL_FormInicio.SelectedIndex == 2)
            {
                Nome = TEXTBOX_TabPagePintura_NOME.Text;

                RemoverPintura(Nome);

                ResetPintura();

                TabelaDados_Pintura.Clear();
                TabelaDados2_Pintura.Clear();

                PreencherDataGridView_Pintura();

                OcultarColunasDesnecessarias_Pintura();

                CalcularTotalPintura();
                CalcularTotalProdutos();
            }
        }

        private void MENUSTRIP_FormInicio_BUTTON_ALTERAR_Click(object sender, EventArgs e)
        {
            string Nome = "";
            string Descricao = "";
            string Preco = "";
            string Stock = "";
            string Ano = "";
            string Marca = "";
            string Modelo = "";
            string Ampers = "";
            string Tipo = "";

            if (TABCONTROL_FormInicio.SelectedIndex == 0)
            {
                Nome = TEXTBOX_TabPageCarrocaria_NOME.Text;
                Ano = DATETIMEPICKER_TabPageCarrocaria_ANO.Value.Year.ToString();
                Preco = TEXTBOX_TabPageCarrocaria_PRECO.Text;
                Stock = TEXTBOX_TabPageCarrocaria_STOCK.Text;
                Descricao = TEXTBOX_TabPageCarrocaria_DESCRICAO.Text;
                Marca = COMBOBOX_TabPageCarrocaria_MarcaCarrocaria.Text;
                Modelo = COMBOBOX_TabPageCarrocaria_ModeloCarrocaria.Text;

                AlterarCarrocaria(Nome, Descricao, Ano, Preco, Stock, Marca, Modelo);

                TabelaDados_Carrocaria.Clear();
                TabelaDados2_Carrocaria.Clear();

                PreencherDataGridView_Carrocaria();

                OcultarColunasDesnecessarias_Carrocaria();

                ResetCarrocaria();

                CalcularTotalCarrocaria();
                CalcularTotalProdutos();
            }

            if (TABCONTROL_FormInicio.SelectedIndex == 1)
            {
                Nome = TEXTBOX_TabPageBateria_NOME.Text;
                Ampers = TEXTBOX_TabPageBateria_AMPERS.Text;
                Preco = TEXTBOX_TabPageBateria_PRECO.Text;
                Stock = TEXTBOX_TabPageBateria_STOCK.Text;
                Descricao = TEXTBOX_TabPageBateria_DESCRICAO.Text;

                AlterarBateria(Nome, Ampers, Preco, Stock, Descricao);

                TabelaDados_Bateria.Clear();
                TabelaDados2_Bateria.Clear();

                PreencherDataGridView_Bateria();

                OcultarColunasDesnecessarias_Bateria();

                ResetBateria();

                CalcularTotalBateria();
                CalcularTotalProdutos();
            }

            if (TABCONTROL_FormInicio.SelectedIndex == 2)
            {
                Nome = TEXTBOX_TabPagePintura_NOME.Text;
                Preco = TEXTBOX_TabPagePintura_PRECO.Text;
                Stock = TEXTBOX_TabPagePintura_STOCK.Text;
                Tipo = COMBOBOX_TabPagePintura_TIPO.Text;
                Descricao = TEXTBOX_TabPagePintura_DESCRICAO.Text;

                AlterarPintura(Nome, Preco, Stock, Tipo, Descricao);

                TabelaDados_Pintura.Clear();
                TabelaDados2_Pintura.Clear();

                PreencherDataGridView_Pintura();

                OcultarColunasDesnecessarias_Pintura();

                ResetPintura();

                CalcularTotalPintura();
                CalcularTotalProdutos();
            }
        }

        private void MENUSTRIP_FormInicio_BUTTON_IMPRIMIR_Click(object sender, EventArgs e)
        {
            string Caminho = Directory.GetCurrentDirectory();
            Caminho += @"\bd.accdb";

            MsAccess.Application ACC = new MsAccess.Application();
            ACC.OpenCurrentDatabase(Caminho, false, "");
            ACC.Visible = false;

            if (TABCONTROL_FormInicio.SelectedIndex == 0)
            {
                using (PrintDialog printDlg = new PrintDialog())
                {
                    if (printDlg.ShowDialog() == DialogResult.OK)
                    {
                        foreach (Microsoft.Office.Interop.Access.Printer printer in ACC.Printers)
                        {
                            if (printer.DeviceName.Equals(printDlg.PrinterSettings.PrinterName, StringComparison.CurrentCultureIgnoreCase))
                            {
                                // Set the selected printer in the ms access application.
                                ACC.Printer = printer;
                                break;
                            }
                        }
                    }

                }

                ACC.DoCmd.OpenReport("RelatorioCarrocaria", Microsoft.Office.Interop.Access.AcView.acViewPreview, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

                ACC.DoCmd.PrintOut(MsAccess.AcPrintRange.acPrintAll, Type.Missing, Type.Missing, MsAccess.AcPrintQuality.acHigh, Type.Missing, Type.Missing);

                ACC.CloseCurrentDatabase();
                ACC = null;
            }

            if (TABCONTROL_FormInicio.SelectedIndex == 1)
            {
                using (PrintDialog printDlg = new PrintDialog())
                {
                    if (printDlg.ShowDialog() == DialogResult.OK)
                    {
                        foreach (Microsoft.Office.Interop.Access.Printer printer in ACC.Printers)
                        {
                            if (printer.DeviceName.Equals(printDlg.PrinterSettings.PrinterName, StringComparison.CurrentCultureIgnoreCase))
                            {
                                // Set the selected printer in the ms access application.
                                ACC.Printer = printer;
                                break;
                            }
                        }
                    }

                }

                ACC.DoCmd.OpenReport("RelatorioBateria", Microsoft.Office.Interop.Access.AcView.acViewPreview, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

                ACC.DoCmd.PrintOut(MsAccess.AcPrintRange.acPrintAll, Type.Missing, Type.Missing, MsAccess.AcPrintQuality.acHigh, Type.Missing, Type.Missing);

                ACC.CloseCurrentDatabase();
                ACC = null;
            }

            if (TABCONTROL_FormInicio.SelectedIndex == 2)
            {
                using (PrintDialog printDlg = new PrintDialog())
                {
                    if (printDlg.ShowDialog() == DialogResult.OK)
                    {
                        foreach (Microsoft.Office.Interop.Access.Printer printer in ACC.Printers)
                        {
                            if (printer.DeviceName.Equals(printDlg.PrinterSettings.PrinterName, StringComparison.CurrentCultureIgnoreCase))
                            {
                                // Set the selected printer in the ms access application.
                                ACC.Printer = printer;
                                break;
                            }
                        }
                    }

                }

                ACC.DoCmd.OpenReport("RelatorioPintura", Microsoft.Office.Interop.Access.AcView.acViewPreview, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

                ACC.DoCmd.PrintOut(MsAccess.AcPrintRange.acPrintAll, Type.Missing, Type.Missing, MsAccess.AcPrintQuality.acHigh, Type.Missing, Type.Missing);

                ACC.CloseCurrentDatabase();
                ACC = null;
            }
        }        

        #endregion

        #region FUNÇÕES GLOBAIS

        public void ResetCarrocaria()
        {
            TEXTBOX_TabPageCarrocaria_NOME.Text = "";
            TEXTBOX_TabPageCarrocaria_DESCRICAO.Text = "";
            TEXTBOX_TabPageCarrocaria_PRECO.Text = "";
            TEXTBOX_TabPageCarrocaria_STOCK.Text = "";

            CHECKBOX_TabPageCarrocaria_MARCA.Checked = false;
            CHECKBOX_TabPageCarrocaria_MODELO.Checked = false;
            CHECKBOX_TabPageCarrocaria_ANO.Checked = false;

            COMBOBOX_TabPageCarrocaria_MARCA.SelectedIndex = -1;
            COMBOBOX_TabPageCarrocaria_MODELO.SelectedIndex = -1;
            DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value = DateTime.Today;

            LABEL_TabPageCarrocaria_TotalCarrocariaValor.Text = "";
            LABEL_TabPageCarrocaria_TotalCarrocariaFiltradaValor.Text = "";
            LABEL_TabPageCarrocaria_TotalTodosProdutosValor.Text = "";

            foreach(DataGridViewRow DR in DATAGRIDVIEW_CARROCARIA.Rows)
            {
                if (DR.Index == 1)
                    DR.Selected = true;
            }
        }

        public void ResetBateria()
        {
            TEXTBOX_TabPageBateria_NOME.Text = "";
            TEXTBOX_TabPageBateria_AMPERS.Text = "";
            TEXTBOX_TabPageBateria_PRECO.Text = "";
            TEXTBOX_TabPageBateria_STOCK.Text = "";
            TEXTBOX_TabPageBateria_DESCRICAO.Text = "";

            CHECKBOX_TabPageBateria_FiltrarResultados_AMPERAGEM.Checked = false;
            TEXTBOX_TabPageBateria_FiltrarResultados_AMPERAGEM.Text = "";

            LABEL_TabPageBateria_TotalBateriaValor.Text = "";
            LABEL_TabPageBateria_TotalBateriaFiltradaValor.Text = "";
            LABEL_TabPageBateria_TotalProdutosValor.Text = "";

            foreach (DataGridViewRow DR in DATAGRIDVIEW_BATERIAS.Rows)
            {
                if (DR.Index == 1)
                    DR.Selected = true;
            }
        }

        public void ResetPintura()
        {
            TEXTBOX_TabPagePintura_NOME.Text = "";
            TEXTBOX_TabPagePintura_PRECO.Text = "";
            TEXTBOX_TabPagePintura_STOCK.Text = "";
            TEXTBOX_TabPagePintura_DESCRICAO.Text = "";
            COMBOBOX_TabPagePintura_TIPO.SelectedIndex = -1;

            CHECKBOX_TabPagePintura_FiltrarResultados_TIPO.Checked = false;
            COMBOBOX_TabPagePintura_FiltrarResultados_TIPO.SelectedIndex = -1;

            LABEL_TabPagePintura_TotalPinturaValor.Text = "";
            LABEL_TabPagePintura_TotalPinturaFiltradaValor.Text = "";
            LABEL_TabPagePintura_TotalProdutosValor.Text = "";

            foreach (DataGridViewRow DR in DATAGRIDVIEW_PINTURA.Rows)
            {
                if (DR.Index == 1)
                    DR.Selected = true;
            }
        }

        public void CalcularTotalProdutos()
        {
            double Preco = 0.0;
            double Total = 0.0;
            int Stock = 0;

            try
            {
                foreach (DataGridViewRow DR_Carrocaria in DATAGRIDVIEW_CARROCARIA.Rows)
                {
                    foreach(DataGridViewColumn DC in DATAGRIDVIEW_CARROCARIA.Columns)
                    {
                        if(DC.Name == "Stock")
                            DC.Name = "HEADER_STOCK";
                    }

                    if (Convert.ToInt32(DR_Carrocaria.Cells["HEADER_STOCK"].Value) > 1)
                        Stock = Convert.ToInt32(DR_Carrocaria.Cells["HEADER_STOCK"].Value);

                    Preco = Convert.ToDouble(DR_Carrocaria.Cells["HEADER_PRECO"].Value.ToString());

                    if (Convert.ToInt32(DR_Carrocaria.Cells["HEADER_STOCK"].Value) > 1)
                        Preco = Preco * Stock;

                    Total += Preco;
                }

                foreach (DataGridViewRow DR_Bateria in DATAGRIDVIEW_BATERIAS.Rows)
                {
                    foreach(DataGridViewColumn DC in DATAGRIDVIEW_BATERIAS.Columns)
                    {
                        if(DC.Name == "Stock")
                            DC.Name = "HEADER_StockBateria";
                    }

                    if (Convert.ToInt32(DR_Bateria.Cells["HEADER_StockBateria"].Value) > 1)
                        Stock = Convert.ToInt32(DR_Bateria.Cells["HEADER_StockBateria"].Value);

                    Preco = Convert.ToDouble(DR_Bateria.Cells["HEADER_PrecoBateria"].Value.ToString());

                    if (Convert.ToInt32(DR_Bateria.Cells["HEADER_StockBateria"].Value) > 1)
                        Preco = Preco * Stock;

                    Total += Preco;
                }

                foreach (DataGridViewRow DR_Pintura in DATAGRIDVIEW_PINTURA.Rows)
                {
                    foreach(DataGridViewColumn DC in DATAGRIDVIEW_PINTURA.Columns)
                    {
                        if(DC.Name == "Stock")
                            DC.Name = "HEADER_StockPintura";
                    }

                    if (Convert.ToInt32(DR_Pintura.Cells["HEADER_StockPintura"].Value) > 1)
                        Stock = Convert.ToInt32(DR_Pintura.Cells["HEADER_StockPintura"].Value);

                    Preco = Convert.ToDouble(DR_Pintura.Cells["HEADER_PrecoPintura"].Value.ToString());

                    if (Convert.ToInt32(DR_Pintura.Cells["HEADER_StockPintura"].Value) > 1)
                        Preco = Preco * Stock;

                    Total += Preco;
                }

                LABEL_TabPageCarrocaria_TotalTodosProdutosValor.Text = Total.ToString() + " €";
                LABEL_TabPageBateria_TotalProdutosValor.Text = Total.ToString() + " €";
                LABEL_TabPagePintura_TotalProdutosValor.Text = Total.ToString() + " €";
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        #endregion

        #endregion

        /*----------------------------------------------------------------------------------*/

        #region SECÇÃO DA CARROÇARIA

        #region EVENTOS

        private void TEXTBOX_TabPageCarrocaria_NOME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_TabPageCarrocaria_ANO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_TabPageCarrocaria_PRECO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_TabPageCarrocaria_PRECO_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_TabPageCarrocaria_PRECO.Text.Contains("€") == true)
            {
                int Index = TEXTBOX_TabPageCarrocaria_PRECO.Text.IndexOf("€");

                TEXTBOX_TabPageCarrocaria_PRECO.Text = TEXTBOX_TabPageCarrocaria_PRECO.Text.Substring(0, Index);
            }
        }

        private void TEXTBOX_TabPageCarrocaria_DESCRICAO_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (Char.IsDigit(e.KeyChar) == true)
                e.Handled = true;
            */
        }        

        private void DATAGRIDVIEW_CARROCARIA_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DATAGRIDVIEW_CARROCARIA.SelectedRows.Count == 1)
                {
                    DataGridViewRow DGR = DATAGRIDVIEW_CARROCARIA.SelectedRows[0];

                    string ItemID = DGR.Cells[0].Value.ToString();

                    PreencherTextBoxs_Carrocaria(ItemID);

                    MENUSTRIP_FormInicio_BUTTON_REMOVER.Visible = true;
                }
            }

            catch (Exception EX)
            {
                //MessageBox.Show(EX.Message);
            }
        }

        private void CHECKBOX_TabPageCarrocaria_MARCA_CheckedChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(TabelaDados2_Carrocaria);

            // FILTRAR MARCA
            if (CHECKBOX_TabPageCarrocaria_MARCA.Checked == true && CHECKBOX_TabPageCarrocaria_ANO.Checked == false)
            {
                COMBOBOX_TabPageCarrocaria_MARCA.Enabled = true;

                if (COMBOBOX_TabPageCarrocaria_MARCA.SelectedIndex != -1)
                {
                    DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text);

                    DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                    CalcularTotalCarrocariaFiltrada();
                }
            }

            // FILTRAR POR MARCA E ANO
            if(CHECKBOX_TabPageCarrocaria_MARCA.Checked == true && CHECKBOX_TabPageCarrocaria_ANO.Checked == true)
            {
                COMBOBOX_TabPageCarrocaria_MARCA.Enabled = true;

                if (COMBOBOX_TabPageCarrocaria_MARCA.SelectedIndex != -1)
                {
                    DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Ano LIKE '%{1}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text, DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                    DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                    CalcularTotalCarrocariaFiltrada();
                }
            }

            // LIMPAR A FILTRAGEM E MANTER A FILTRAGEM DO ANO
            if(CHECKBOX_TabPageCarrocaria_MARCA.Checked == false && CHECKBOX_TabPageCarrocaria_ANO.Checked == true)
            {
                COMBOBOX_TabPageCarrocaria_MARCA.Enabled = false;
                CHECKBOX_TabPageCarrocaria_MODELO.Checked = false;

                if (COMBOBOX_TabPageCarrocaria_MARCA.SelectedIndex != -1)
                {
                    DV.RowFilter = string.Format("Ano LIKE '%{0}%'", DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                    DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                    CalcularTotalCarrocariaFiltrada();
                }
            }

            // LIMPAR A FILTRAGEM E RECARREGAR A TABELA
            if (CHECKBOX_TabPageCarrocaria_MARCA.Checked == false && CHECKBOX_TabPageCarrocaria_ANO.Checked == false)
            {
                COMBOBOX_TabPageCarrocaria_MARCA.Enabled = false;
                CHECKBOX_TabPageCarrocaria_MODELO.Checked = false;

                TabelaDados_Carrocaria.Clear();
                TabelaDados2_Carrocaria.Clear();

                this.DATAGRIDVIEW_CARROCARIA.DataSource = null;
                this.DATAGRIDVIEW_CARROCARIA.Rows.Clear();
                this.DATAGRIDVIEW_CARROCARIA.Update();
                this.DATAGRIDVIEW_CARROCARIA.Refresh();

                PreencherDataGridView_Carrocaria();

                OcultarColunasDesnecessarias_Carrocaria();
                LABEL_TabPageCarrocaria_TotalCarrocariaFiltradaValor.Text = "";
            }
        }

        private void CHECKBOX_TabPageCarrocaria_MODELO_CheckedChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(TabelaDados2_Carrocaria);

            // FILTRAR POR MARCA E MODELO
            if (CHECKBOX_TabPageCarrocaria_MODELO.Checked == true && CHECKBOX_TabPageCarrocaria_ANO.Checked == false && CHECKBOX_TabPageCarrocaria_MARCA.Checked == true)
            {
                CHECKBOX_TabPageCarrocaria_MARCA.Checked = true;
                COMBOBOX_TabPageCarrocaria_MODELO.Enabled = true;

                if (COMBOBOX_TabPageCarrocaria_MODELO.SelectedIndex != -1)
                {
                    DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Modelo.Nome LIKE '%{1}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text, COMBOBOX_TabPageCarrocaria_MODELO.Text);

                    DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                    CalcularTotalCarrocariaFiltrada();
                }
            }

            // FILTRAR POR MARCA, MODELO E ANO
            if (CHECKBOX_TabPageCarrocaria_MODELO.Checked == true && CHECKBOX_TabPageCarrocaria_ANO.Checked == true)
            {
                CHECKBOX_TabPageCarrocaria_MARCA.Checked = true;
                COMBOBOX_TabPageCarrocaria_MODELO.Enabled = true;

                if (COMBOBOX_TabPageCarrocaria_MODELO.SelectedIndex != -1)
                {
                    DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Modelo.Nome LIKE '%{1}%' AND Ano LIKE '%{2}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text, COMBOBOX_TabPageCarrocaria_MODELO.Text, DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                    DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                    CalcularTotalCarrocariaFiltrada();
                }
            }

            // LIMPAR A FILTRAGEM E MANTER A FILTRAGEM DA MARCA E ANO
            if (CHECKBOX_TabPageCarrocaria_MODELO.Checked == false && CHECKBOX_TabPageCarrocaria_MARCA.Checked == true && CHECKBOX_TabPageCarrocaria_ANO.Checked == true)
            {
                DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Ano LIKE '%{1}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text, DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                CalcularTotalCarrocariaFiltrada();
            }

            // LIMPAR A FILTRAGEM E MANTER A FILTRAGEM DA MARCA
            if(CHECKBOX_TabPageCarrocaria_MODELO.Checked == false && CHECKBOX_TabPageCarrocaria_MARCA.Checked == true && CHECKBOX_TabPageCarrocaria_ANO.Checked == false)
            {
                DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text);

                DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                CalcularTotalCarrocariaFiltrada();
            }

            // LIMPAR A FILTRAGEM E MANTER A FILTRAGEM DO ANO
            if(CHECKBOX_TabPageCarrocaria_MODELO.Checked == false && CHECKBOX_TabPageCarrocaria_ANO.Checked == true)
            {
                CHECKBOX_TabPageCarrocaria_MARCA.Checked = false;
                COMBOBOX_TabPageCarrocaria_MODELO.Enabled = false;

                DV.RowFilter = string.Format("Ano LIKE '%{0}%'", DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                CalcularTotalCarrocariaFiltrada();
            }

            // LIMPAR A FILTRAGEM E RECARREGAR TABELA
            if (CHECKBOX_TabPageCarrocaria_MODELO.Checked == false && CHECKBOX_TabPageCarrocaria_MARCA.Checked == false && CHECKBOX_TabPageCarrocaria_ANO.Checked == false)
            {
                CHECKBOX_TabPageCarrocaria_MARCA.Checked = false;
                COMBOBOX_TabPageCarrocaria_MODELO.Enabled = false;

                TabelaDados_Carrocaria.Clear();
                TabelaDados2_Carrocaria.Clear();

                this.DATAGRIDVIEW_CARROCARIA.DataSource = null;
                this.DATAGRIDVIEW_CARROCARIA.Rows.Clear();
                this.DATAGRIDVIEW_CARROCARIA.Update();
                this.DATAGRIDVIEW_CARROCARIA.Refresh();

                PreencherDataGridView_Carrocaria();

                OcultarColunasDesnecessarias_Carrocaria();

                LABEL_TabPageCarrocaria_TotalCarrocariaFiltradaValor.Text = "";
            }
        }

        private void CHECKBOX_TabPageCarrocaria_ANO_CheckedChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(TabelaDados2_Carrocaria);

            // FILTRAR POR MARCA E ANO
            if (CHECKBOX_TabPageCarrocaria_MARCA.Checked == true && CHECKBOX_TabPageCarrocaria_MODELO.Checked == false && CHECKBOX_TabPageCarrocaria_ANO.Checked == true)
            {
                DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Enabled = true;

                DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Ano LIKE '%{1}%'",COMBOBOX_TabPageCarrocaria_MARCA.Text, DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                CalcularTotalCarrocariaFiltrada();
            }

            // FILTRAR POR MARCA, MODELO E ANO
            if (CHECKBOX_TabPageCarrocaria_MODELO.Checked == true && CHECKBOX_TabPageCarrocaria_ANO.Checked == true)
            {
                DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Enabled = true;

                DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Modelo.Nome LIKE '%{1}%' AND ANO LIKE '%{2}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text, COMBOBOX_TabPageCarrocaria_MODELO.Text, DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                CalcularTotalCarrocariaFiltrada();
            }

            // FILTRAR SÓ POR ANO
            if (CHECKBOX_TabPageCarrocaria_MARCA.Checked == false && CHECKBOX_TabPageCarrocaria_MODELO.Checked == false && CHECKBOX_TabPageCarrocaria_ANO.Checked == true)
            {
                DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Enabled = true;

                DV.RowFilter = string.Format("Ano LIKE '%{0}%'", DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                CalcularTotalCarrocariaFiltrada();
            }            

            // LIMPAR FILTRAGEM ANO E MANTER FILTRAGEM DA MARCA E MODELO
            if(CHECKBOX_TabPageCarrocaria_ANO.Checked == false && CHECKBOX_TabPageCarrocaria_MARCA.Checked == true && CHECKBOX_TabPageCarrocaria_MODELO.Checked == true)
            {
                DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Enabled = false;

                DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Modelo.Nome LIKE '%{1}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text, COMBOBOX_TabPageCarrocaria_MODELO.Text);

                DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                CalcularTotalCarrocariaFiltrada();
            }

            // LIMPAR FILTRAGEM ANO E MANTER FILTRAGEM DA MARCA
            if(CHECKBOX_TabPageCarrocaria_ANO.Checked == false && CHECKBOX_TabPageCarrocaria_MODELO.Checked == false && CHECKBOX_TabPageCarrocaria_MARCA.Checked == true)
            {
                DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Enabled = false;

                DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text);

                DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                CalcularTotalCarrocariaFiltrada();
            }

            // LIMPAR FILTRAGEM E RECARREGAR TABELA
            if (CHECKBOX_TabPageCarrocaria_MODELO.Checked == false && CHECKBOX_TabPageCarrocaria_MARCA.Checked == false && CHECKBOX_TabPageCarrocaria_ANO.Checked == false)
            {
                DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Enabled = false;

                TabelaDados_Carrocaria.Clear();
                TabelaDados2_Carrocaria.Clear();

                this.DATAGRIDVIEW_CARROCARIA.DataSource = null;
                this.DATAGRIDVIEW_CARROCARIA.Rows.Clear();
                this.DATAGRIDVIEW_CARROCARIA.Update();
                this.DATAGRIDVIEW_CARROCARIA.Refresh();

                PreencherDataGridView_Carrocaria();

                OcultarColunasDesnecessarias_Carrocaria();

                LABEL_TabPageCarrocaria_TotalCarrocariaFiltradaValor.Text = "";
            }            
        }

        private void COMBOBOX_TabPageCarrocaria_MARCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(TabelaDados2_Carrocaria);

            // FILTRAR SÓ A MARCA
            if (CHECKBOX_TabPageCarrocaria_MODELO.Checked == false && CHECKBOX_TabPageCarrocaria_ANO.Checked == false)
            {
                COMBOBOX_TabPageCarrocaria_MODELO.Items.Clear();
                PreencherComboBox_ModelosCarrocaria();
                COMBOBOX_TabPageCarrocaria_MODELO.SelectedIndex = 0;

                if (COMBOBOX_TabPageCarrocaria_MARCA.SelectedIndex != -1)
                {
                    DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text);

                    DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                    CalcularTotalCarrocariaFiltrada();
                }
            }

            // FILTRAR A MARCA COM O MODELO
            if (CHECKBOX_TabPageCarrocaria_MODELO.Checked == true && CHECKBOX_TabPageCarrocaria_ANO.Checked == false)
            {
                if (COMBOBOX_TabPageCarrocaria_MARCA.SelectedIndex != -1)
                {
                    COMBOBOX_TabPageCarrocaria_MODELO.Items.Clear();
                    PreencherComboBox_ModelosCarrocaria();
                    COMBOBOX_TabPageCarrocaria_MODELO.SelectedIndex = 0;

                    if (COMBOBOX_TabPageCarrocaria_MODELO.SelectedIndex != -1)
                    {
                        DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Modelo.Nome LIKE '%{1}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text, COMBOBOX_TabPageCarrocaria_MODELO.Text);

                        DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                        CalcularTotalCarrocariaFiltrada();
                    }
                }
            }

            // FILTRAR A MARCA COM O ANO
            if (CHECKBOX_TabPageCarrocaria_MARCA.Checked == true && CHECKBOX_TabPageCarrocaria_MODELO.Checked == false && CHECKBOX_TabPageCarrocaria_ANO.Checked == true)
            {
                if (COMBOBOX_TabPageCarrocaria_MARCA.SelectedIndex != -1)
                {
                    DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Ano LIKE '%{1}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text, DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                    DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                    CalcularTotalCarrocariaFiltrada();
                }
            }

            // FILTRAR A MARCA COM O MODELO E ANO
            if (CHECKBOX_TabPageCarrocaria_MODELO.Checked == true && CHECKBOX_TabPageCarrocaria_ANO.Checked == true)
            {
                if (COMBOBOX_TabPageCarrocaria_MARCA.SelectedIndex != -1)
                {
                    COMBOBOX_TabPageCarrocaria_MODELO.Items.Clear();
                    PreencherComboBox_ModelosCarrocaria();
                    COMBOBOX_TabPageCarrocaria_MODELO.SelectedIndex = 0;

                    if (COMBOBOX_TabPageCarrocaria_MODELO.SelectedIndex != -1)
                    {
                        DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Modelo.Nome LIKE '%{1}%' AND Ano LIKE '%{2}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text, COMBOBOX_TabPageCarrocaria_MODELO.Text, DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                        DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                        CalcularTotalCarrocariaFiltrada();
                    }
                }
            }
        }

        private void COMBOBOX_TabPageCarrocaria_MODELO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (COMBOBOX_TabPageCarrocaria_MODELO.Enabled == true)
            {
                DataView DV = new DataView(TabelaDados2_Carrocaria);

                // FILTRAR MODELO COM MARCA
                if (COMBOBOX_TabPageCarrocaria_MODELO.SelectedIndex != -1)
                {
                    DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Modelo.Nome LIKE '%{1}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text, COMBOBOX_TabPageCarrocaria_MODELO.Text);

                    DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                    CalcularTotalCarrocariaFiltrada();
                }

                // FILTRAR MODELO COM MARCA E ANO
                if (COMBOBOX_TabPageCarrocaria_MODELO.SelectedIndex != -1)
                {
                    DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Modelo.Nome LIKE '%{1}%' AND Ano LIKE '%{2}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text, COMBOBOX_TabPageCarrocaria_MODELO.Text, DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                    DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                    CalcularTotalCarrocariaFiltrada();
                }
            }
        }

        private void DATETIMEPICKER_TabPageCarrocaria_ANO_ValueChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(TabelaDados2_Carrocaria);

            // FILTRAR SO O ANO
            if (CHECKBOX_TabPageCarrocaria_ANO.Checked == true && CHECKBOX_TabPageCarrocaria_MARCA.Checked == false && CHECKBOX_TabPageCarrocaria_MODELO.Checked == false)
            {
                DV.RowFilter = string.Format("Ano LIKE '%{0}%'", DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                CalcularTotalCarrocariaFiltrada();
            }

            // FILTRAR ANO E MARCA
            if (CHECKBOX_TabPageCarrocaria_ANO.Checked == true && CHECKBOX_TabPageCarrocaria_MARCA.Checked == true && CHECKBOX_TabPageCarrocaria_MODELO.Checked == false)
            {
                DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Ano LIKE '%{1}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text, DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                CalcularTotalCarrocariaFiltrada();
            }

            // FILTRAR ANO MARCA E MODELO
            if (CHECKBOX_TabPageCarrocaria_ANO.Checked == true && CHECKBOX_TabPageCarrocaria_MARCA.Checked == true && CHECKBOX_TabPageCarrocaria_MODELO.Checked == true)
            {
                DV.RowFilter = string.Format("Marca.Nome LIKE '%{0}%' AND Modelo.Nome LIKE '%{1}%' AND ANO LIKE '%{2}%'", COMBOBOX_TabPageCarrocaria_MARCA.Text, COMBOBOX_TabPageCarrocaria_MODELO.Text, DATETIMEPICKER_TabPageCarrocaria_FiltrarAno.Value.Year.ToString());

                DATAGRIDVIEW_CARROCARIA.DataSource = DV;

                CalcularTotalCarrocariaFiltrada();
            }

        }

        private void COMBOBOX_TabPageCarrocaria_MarcaCarrocaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (COMBOBOX_TabPageCarrocaria_MarcaCarrocaria.SelectedIndex != -1)
            {
                COMBOBOX_TabPageCarrocaria_ModeloCarrocaria.Items.Clear();
                PreencherComboBox_ModelosCarrocariaInfo();
            }
        }

        #endregion

        #region FUNÇÕES

        public void PreencherDataGridView_Carrocaria()
        {
            try
            {
                this.DATAGRIDVIEW_CARROCARIA.DataSource = null;
                this.DATAGRIDVIEW_CARROCARIA.Rows.Clear();
                this.DATAGRIDVIEW_CARROCARIA.Update();
                this.DATAGRIDVIEW_CARROCARIA.Refresh();

                LigacaoDB.Open();

                OleDbCommand COMANDO_PreencherDataGridView = new OleDbCommand(CLASS_BD.QUERY_PreencherDataGridView_Carrocaria, LigacaoDB);

                COMANDO_PreencherDataGridView.CommandType = CommandType.Text;

                Adapter_Carrocaria.SelectCommand = COMANDO_PreencherDataGridView;

                Adapter_Carrocaria.Fill(TabelaDados_Carrocaria);
                Adapter_Carrocaria.Fill(TabelaDados2_Carrocaria);

                LigacaoDB.Close();

                BindingSource ColecaoDados = new BindingSource();

                ColecaoDados.DataSource = TabelaDados_Carrocaria;

                DATAGRIDVIEW_CARROCARIA.DataSource = ColecaoDados;

                Adapter_Carrocaria.Update(TabelaDados_Carrocaria);
                Adapter_Carrocaria.Update(TabelaDados2_Carrocaria);
            }

            catch(Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void PreencherComboBox_MarcasCarrocaria()
        {
            try
            {
                LigacaoDB.Open();

                OleDbCommand COMANDO_PreencherComboBox_MarcasCarrocaria = new OleDbCommand(CLASS_BD.QUERY_PreencherComboBox_MarcasCarrocaria, LigacaoDB);

                Reader_Carrocaria = COMANDO_PreencherComboBox_MarcasCarrocaria.ExecuteReader();

                while (Reader_Carrocaria.Read())
                {
                    COMBOBOX_TabPageCarrocaria_MARCA.Items.Add(Reader_Carrocaria["Nome"].ToString());
                    COMBOBOX_TabPageCarrocaria_MarcaCarrocaria.Items.Add(Reader_Carrocaria["Nome"].ToString());
                }

                Reader_Carrocaria.Close();   

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

                string QUERY_PreencherComboBox_MarcaID_Modelo = "SELECT ID FROM Marca WHERE Nome = '" + COMBOBOX_TabPageCarrocaria_MARCA.SelectedItem.ToString() + "'";
                
                OleDbCommand COMANDO_MarcaID_Modelo = new OleDbCommand(QUERY_PreencherComboBox_MarcaID_Modelo, LigacaoDB);

                string MarcaID = COMANDO_MarcaID_Modelo.ExecuteScalar().ToString();

                string QUERY_PreencherComboBox__ModeloMarca_Carrocaria = "SELECT Nome FROM Modelo WHERE ID_Marca =  " + MarcaID + "";

                OleDbCommand COMANDO_ModeloMarca = new OleDbCommand(QUERY_PreencherComboBox__ModeloMarca_Carrocaria, LigacaoDB);

                Reader_Carrocaria = COMANDO_ModeloMarca.ExecuteReader();

                while (Reader_Carrocaria.Read())
                {
                    COMBOBOX_TabPageCarrocaria_MODELO.Items.Add(Reader_Carrocaria["Nome"].ToString());
                }

                Reader_Carrocaria.Close();   

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void PreencherComboBox_ModelosCarrocariaInfo()
        {
            try
            {
                if(LigacaoDB.State == ConnectionState.Closed)
                    LigacaoDB.Open();

                string QUERY_PreencherComboBox_MarcaID_Modelo = "SELECT ID FROM Marca WHERE Nome = '" + COMBOBOX_TabPageCarrocaria_MarcaCarrocaria.SelectedItem.ToString() + "'";

                OleDbCommand COMANDO_MarcaID_Modelo = new OleDbCommand(QUERY_PreencherComboBox_MarcaID_Modelo, LigacaoDB);

                string MarcaID = COMANDO_MarcaID_Modelo.ExecuteScalar().ToString();

                string QUERY_PreencherComboBox__ModeloMarca_Carrocaria = "SELECT Nome FROM Modelo WHERE ID_Marca =  " + MarcaID + "";

                OleDbCommand COMANDO_ModeloMarca = new OleDbCommand(QUERY_PreencherComboBox__ModeloMarca_Carrocaria, LigacaoDB);

                Reader_Carrocaria = COMANDO_ModeloMarca.ExecuteReader();

                while (Reader_Carrocaria.Read())
                {
                    COMBOBOX_TabPageCarrocaria_ModeloCarrocaria.Items.Add(Reader_Carrocaria["Nome"].ToString());
                }

                Reader_Carrocaria.Close();

                if(LigacaoDB.State == ConnectionState.Open)
                    LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void PreencherTextBoxs_Carrocaria(string ItemID)
        {
            try
            {
                LigacaoDB.Open();

                string Query_NomeCarrocaria = "SELECT Nome FROM Carrocaria WHERE ID = " + ItemID + "";
                string Query_DescricaoCarrocaria = "SELECT Descricao FROM Carrocaria WHERE ID = " + ItemID + "";
                string Query_PrecoCarrocaria = "SELECT Preco FROM Carrocaria WHERE ID = " + ItemID + "";
                string Query_AnoCarrocaria = "SELECT Ano FROM Carrocaria WHERE ID = " + ItemID + "";
                string Query_StockCarrocaria = "SELECT Stock FROM Carrocaria WHERE ID = " + ItemID + "";

                string QUERY_MarcaID = "SELECT ID_Marca FROM CarrocariaMarcaModelo WHERE ID_Carrocaria = " + ItemID + "";
                string QUERY_ModeloID = "SELECT ID_Modelo FROM CarrocariaMarcaModelo WHERE ID_Carrocaria = " + ItemID + "";

                OleDbCommand Comando_Querys = new OleDbCommand();
                Comando_Querys.Connection = LigacaoDB;

                Comando_Querys.CommandText = Query_NomeCarrocaria;
                TEXTBOX_TabPageCarrocaria_NOME.Text = Comando_Querys.ExecuteScalar().ToString();

                Comando_Querys.CommandText = Query_DescricaoCarrocaria;
                TEXTBOX_TabPageCarrocaria_DESCRICAO.Text = Comando_Querys.ExecuteScalar().ToString();

                Comando_Querys.CommandText = Query_PrecoCarrocaria;
                TEXTBOX_TabPageCarrocaria_PRECO.Text = Comando_Querys.ExecuteScalar().ToString();

                TEXTBOX_TabPageCarrocaria_PRECO.Text = String.Format("{0:C}", Convert.ToDouble(TEXTBOX_TabPageCarrocaria_PRECO.Text));

                Comando_Querys.CommandText = Query_AnoCarrocaria;
                string Ano = Comando_Querys.ExecuteScalar().ToString();
                DateTime DAno = new DateTime(int.Parse(Ano), 1, 1);
                DATETIMEPICKER_TabPageCarrocaria_ANO.Value = DAno;

                Comando_Querys.CommandText = Query_StockCarrocaria;
                TEXTBOX_TabPageCarrocaria_STOCK.Text = Comando_Querys.ExecuteScalar().ToString();

                Comando_Querys.CommandText = QUERY_MarcaID;
                string MarcaID = Comando_Querys.ExecuteScalar().ToString();

                Comando_Querys.CommandText = QUERY_ModeloID;
                string ModeloID = Comando_Querys.ExecuteScalar().ToString();

                string QUERY_Marca = "SELECT Nome FROM Marca WHERE ID = " + Convert.ToInt32(MarcaID) + "";
                string QUERY_Modelo = "SELECT Nome FROM Modelo WHERE ID = " + Convert.ToInt32(ModeloID) +"";

                Comando_Querys.CommandText = QUERY_Marca;
                string Marca = Comando_Querys.ExecuteScalar().ToString();
                COMBOBOX_TabPageCarrocaria_MarcaCarrocaria.SelectedItem = Marca;

                if (LigacaoDB.State == ConnectionState.Closed)
                    LigacaoDB.Open();
                
                Comando_Querys.CommandText = QUERY_Modelo;
                string Modelo = Comando_Querys.ExecuteScalar().ToString();
                COMBOBOX_TabPageCarrocaria_ModeloCarrocaria.SelectedItem = Modelo;

                ALTERAR_NomeAntigo_Carrocaria = TEXTBOX_TabPageCarrocaria_NOME.Text;

                if(LigacaoDB.State == ConnectionState.Open)
                    LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void RemoverCarrocaria(string Nome)
        {
            try
            {
                if (Nome != "")
                {
                    LigacaoDB.Open();

                    string QUERY_RemoverCarrocaria = "DELETE FROM Carrocaria WHERE Nome = '" + Nome + "'";

                    OleDbCommand COMANDO_RemoverCarrocaria = new OleDbCommand(QUERY_RemoverCarrocaria, LigacaoDB);

                    COMANDO_RemoverCarrocaria.ExecuteNonQuery();

                    LigacaoDB.Close();

                    MessageBox.Show("Carrocaria removida com sucesso!", "Carrocaria Removida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }        

        public void AlterarCarrocaria(string Nome, string Descricao, string Ano, string Preco, string Stock, string Marca, string Modelo)
        {
            try
            {
                LigacaoDB.Open();

                string QUERY_ItemID = "SELECT ID FROM Carrocaria WHERE Nome = '" + ALTERAR_NomeAntigo_Carrocaria + "'";
                OleDbCommand COMANDO_ItemID = new OleDbCommand(QUERY_ItemID, LigacaoDB);
                string ItemID = COMANDO_ItemID.ExecuteScalar().ToString();                

                string QUERY_AlterarCarrocaria = "UPDATE Carrocaria SET Nome = '" + Nome + "', Descricao = '" + Descricao + "', Preco = '" + Preco + "', Ano = '" + Ano + "', Stock = '" + Stock + "' WHERE Nome = '" + ALTERAR_NomeAntigo_Carrocaria + "'";

                OleDbCommand COMANDO_AlterarCarrocaria = new OleDbCommand(QUERY_AlterarCarrocaria, LigacaoDB);
                COMANDO_AlterarCarrocaria.ExecuteNonQuery();

                string QUERY_MarcaID = "SELECT ID FROM Marca WHERE Nome = '" + Marca + "'";
                OleDbCommand COMANDO_MarcaID = new OleDbCommand(QUERY_MarcaID, LigacaoDB);
                string MarcaID = COMANDO_MarcaID.ExecuteScalar().ToString();

                string QUERY_ModeloID = "SELECT ID FROM Modelo WHERE Nome = '" + Modelo + "'";
                OleDbCommand COMANDO_ModeloID = new OleDbCommand(QUERY_ModeloID, LigacaoDB);
                string ModeloID = COMANDO_ModeloID.ExecuteScalar().ToString();

                string QUERY_AlterarMarcaCarrocaria = "UPDATE CarrocariaMarcaModelo SET ID_Marca = " + Convert.ToInt32(MarcaID) + ", ID_Modelo = " + Convert.ToInt32(ModeloID) + " WHERE ID_Carrocaria = " + Convert.ToInt32(ItemID) + "";

                OleDbCommand COMANDO_AlterarMarcaCarrocaria = new OleDbCommand(QUERY_AlterarMarcaCarrocaria, LigacaoDB);
                COMANDO_AlterarMarcaCarrocaria.ExecuteNonQuery();

                MessageBox.Show("Carrocaria Alterada com Sucesso!", "Carrocaria Alterada", MessageBoxButtons.OK, MessageBoxIcon.Information); 

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }        

        public void OcultarColunasDesnecessarias_Carrocaria()
        {
            try
            {
                DATAGRIDVIEW_CARROCARIA.Columns["MarcaID"].Visible = false;
                DATAGRIDVIEW_CARROCARIA.Columns["ModeloID"].Visible = false;
                DATAGRIDVIEW_CARROCARIA.Columns["Marca.ID"].Visible = false;
                DATAGRIDVIEW_CARROCARIA.Columns["Modelo.ID"].Visible = false;
                DATAGRIDVIEW_CARROCARIA.Columns["ModeloID"].Visible = false;
                DATAGRIDVIEW_CARROCARIA.Columns["ID_Marca"].Visible = false;

                int Column = 0;
                string ColumnName = "";

                for (Column = 0; Column < DATAGRIDVIEW_CARROCARIA.Columns.Count; Column++)
                {
                    ColumnName = DATAGRIDVIEW_CARROCARIA.Columns[Column].Name;

                    if (ColumnName == "Preco")
                    {
                        DATAGRIDVIEW_CARROCARIA.Columns[Column].Name = "HEADER_PRECO";
                        DATAGRIDVIEW_CARROCARIA.Columns[Column].HeaderText = "Preco";
                    }

                    if(ColumnName == "Carrocaria.ID")
                    {
                        DATAGRIDVIEW_CARROCARIA.Columns[Column].HeaderText = "ID";
                    }

                    if (ColumnName == "Carrocaria.Nome")
                    {
                        DATAGRIDVIEW_CARROCARIA.Columns[Column].HeaderText = "Nome";
                    }

                    if (ColumnName == "Marca.Nome")
                    {
                        DATAGRIDVIEW_CARROCARIA.Columns[Column].HeaderText = "Marca";
                    }

                    if (ColumnName == "Modelo.Nome")
                    {
                        DATAGRIDVIEW_CARROCARIA.Columns[Column].HeaderText = "Modelo";
                    }
                }
                //DATAGRIDVIEW_CARROCARIA.Columns["Carrocaria.ID"].Visible = false;
                //DATAGRIDVIEW_CARROCARIA.Columns["Carrocaria.Nome"].Visible = false;
            }

            catch(Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        public void CalcularTotalCarrocaria()
        {
            double Preco = 0.0;
            double Total = 0.0;
            int Stock = 0;

            try
            {
                foreach(DataGridViewRow DR in DATAGRIDVIEW_CARROCARIA.Rows)
                {
                    foreach (DataGridViewColumn DC in DATAGRIDVIEW_CARROCARIA.Columns)
                    {
                        if (DC.Name == "Stock")
                            DC.Name = "HEADER_STOCK";
                    }

                    if (Convert.ToInt32(DR.Cells["HEADER_STOCK"].Value) > 1)
                        Stock = Convert.ToInt32(DR.Cells["HEADER_STOCK"].Value);

                    Preco = Convert.ToDouble(DR.Cells["HEADER_PRECO"].Value.ToString());

                    if (Convert.ToInt32(DR.Cells["HEADER_STOCK"].Value) > 1)
                        Preco = Preco * Stock;

                    Total += Preco;
                }

                LABEL_TabPageCarrocaria_TotalCarrocariaValor.Text = Total.ToString() + " €";
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void CalcularTotalCarrocariaFiltrada()
        {
            double Preco = 0.0;
            double Total = 0.0;
            int Stock = 0;

            try
            {
                foreach (DataGridViewRow DR in DATAGRIDVIEW_CARROCARIA.Rows)
                {
                    foreach (DataGridViewColumn DC in DATAGRIDVIEW_CARROCARIA.Columns)
                    {
                        if (DC.Name == "Stock")
                            DC.Name = "HEADER_STOCK";
                    }

                    if (Convert.ToInt32(DR.Cells["HEADER_STOCK"].Value) > 1)
                        Stock = Convert.ToInt32(DR.Cells["HEADER_STOCK"].Value);

                    Preco = Convert.ToDouble(DR.Cells["HEADER_PRECO"].Value.ToString());

                    if (Convert.ToInt32(DR.Cells["HEADER_STOCK"].Value) > 1)
                        Preco = Preco * Stock;

                    Total += Preco;
                }

                LABEL_TabPageCarrocaria_TotalCarrocariaFiltradaValor.Text = Total.ToString() + " €";
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        #endregion

        #endregion

        /*----------------------------------------------------------------------------------*/

        #region SECÇÃO DA BATERIA

        #region EVENTOS

        private void TEXTBOX_TabPageBateria_NOME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_TabPageBateria_AMPERS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_TabPageBateria_PRECO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_TabPageBateria_PRECO_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_TabPageBateria_PRECO.Text.Contains("€") == true)
            {
                int Index = TEXTBOX_TabPageBateria_PRECO.Text.IndexOf("€");

                TEXTBOX_TabPageBateria_PRECO.Text = TEXTBOX_TabPageBateria_PRECO.Text.Substring(0, Index);
            }
        }

        private void TEXTBOX_TabPageBateria_STOCK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_TabPageBateria_FiltrarResultados_AMPERAGEM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void DATAGRIDVIEW_BATERIAS_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DATAGRIDVIEW_BATERIAS.SelectedRows.Count == 1)
                {
                    DataGridViewRow DGR = DATAGRIDVIEW_BATERIAS.SelectedRows[0];

                    string ItemID = DGR.Cells[0].Value.ToString();

                    PreencherTextBoxs_Bateria(ItemID);

                    MENUSTRIP_FormInicio_BUTTON_REMOVER.Visible = true;
                }
            }

            catch (Exception EX)
            {
                //MessageBox.Show(EX.Message);
            }
        }

        private void CHECKBOX_TabPageBateria_FiltrarResultados_AMPERAGEM_CheckedChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(TabelaDados2_Bateria);

            // FILTRAR AMPERAGEM
            if (CHECKBOX_TabPageBateria_FiltrarResultados_AMPERAGEM.Checked == true)
            {
                TEXTBOX_TabPageBateria_FiltrarResultados_AMPERAGEM.Enabled = true;

                if (TEXTBOX_TabPageBateria_FiltrarResultados_AMPERAGEM.Text.Length != 0)
                {
                    DV.RowFilter = string.Format("Ampers LIKE '%{0}%'", TEXTBOX_TabPageBateria_FiltrarResultados_AMPERAGEM.Text);

                    DATAGRIDVIEW_BATERIAS.DataSource = DV;

                    CalcularTotalBateriaFiltrada();
                }
            }

            // LIMPAR A FILTRAGEM E RECARREGAR A TABELA
            if (CHECKBOX_TabPageBateria_FiltrarResultados_AMPERAGEM.Checked == false)
            {
                TEXTBOX_TabPageBateria_FiltrarResultados_AMPERAGEM.Enabled = false;

                TabelaDados_Bateria.Clear();
                TabelaDados2_Bateria.Clear();

                this.DATAGRIDVIEW_BATERIAS.DataSource = null;
                this.DATAGRIDVIEW_BATERIAS.Rows.Clear();
                this.DATAGRIDVIEW_BATERIAS.Update();
                this.DATAGRIDVIEW_BATERIAS.Refresh();

                PreencherDataGridView_Bateria();

                OcultarColunasDesnecessarias_Bateria();

                LABEL_TabPageBateria_TotalBateriaFiltradaValor.Text = "";
            }
        }

        private void TEXTBOX_TabPageBateria_FiltrarResultados_AMPERAGEM_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(TabelaDados2_Bateria);

            if(TEXTBOX_TabPageBateria_FiltrarResultados_AMPERAGEM.Text.Length != 0)
            {
                DV.RowFilter = string.Format("Ampers LIKE '%{0}%'", TEXTBOX_TabPageBateria_FiltrarResultados_AMPERAGEM.Text);

                DATAGRIDVIEW_BATERIAS.DataSource = DV;

                CalcularTotalBateriaFiltrada();
            }
        }

        #endregion

        #region FUNÇÕES

        public void PreencherDataGridView_Bateria()
        {
            try
            {
                this.DATAGRIDVIEW_BATERIAS.DataSource = null;
                this.DATAGRIDVIEW_BATERIAS.Rows.Clear();
                this.DATAGRIDVIEW_BATERIAS.Update();
                this.DATAGRIDVIEW_BATERIAS.Refresh();

                LigacaoDB.Open();

                OleDbCommand COMANDO_PreencherDataGridView = new OleDbCommand(CLASS_BD.QUERY_PreencherDataGridView_Bateria, LigacaoDB);

                COMANDO_PreencherDataGridView.CommandType = CommandType.Text;

                Adapter_Bateria.SelectCommand = COMANDO_PreencherDataGridView;

                Adapter_Bateria.Fill(TabelaDados_Bateria);
                Adapter_Bateria.Fill(TabelaDados2_Bateria);

                LigacaoDB.Close();

                BindingSource ColecaoDados = new BindingSource();

                ColecaoDados.DataSource = TabelaDados_Bateria;

                DATAGRIDVIEW_BATERIAS.DataSource = ColecaoDados;

                Adapter_Bateria.Update(TabelaDados_Bateria);
                Adapter_Bateria.Update(TabelaDados2_Bateria);
            }

            catch(Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void PreencherTextBoxs_Bateria(string ItemID)
        {
            try
            {
                LigacaoDB.Open();

                string Query_NomeBateria = "SELECT Nome FROM Bateria WHERE ID = " + ItemID + "";
                string Query_DescricaoBateria = "SELECT Descricao FROM Bateria WHERE ID = " + ItemID + "";
                string Query_AmpersBateria = "SELECT Ampers FROM Bateria WHERE ID = " + ItemID + "";
                string Query_PrecoBateria = "SELECT Preco FROM Bateria WHERE ID = " + ItemID + "";
                string Query_StockBateria = "SELECT Stock FROM Bateria WHERE ID = " + ItemID + "";

                OleDbCommand Comando_Querys = new OleDbCommand();
                Comando_Querys.Connection = LigacaoDB;

                Comando_Querys.CommandText = Query_NomeBateria;
                TEXTBOX_TabPageBateria_NOME.Text = Comando_Querys.ExecuteScalar().ToString();      

                Comando_Querys.CommandText = Query_AmpersBateria;
                TEXTBOX_TabPageBateria_AMPERS.Text = Comando_Querys.ExecuteScalar().ToString();

                Comando_Querys.CommandText = Query_PrecoBateria;
                TEXTBOX_TabPageBateria_PRECO.Text = Comando_Querys.ExecuteScalar().ToString();

                TEXTBOX_TabPageBateria_PRECO.Text = String.Format("{0:C}", Convert.ToDouble(TEXTBOX_TabPageBateria_PRECO.Text));

                Comando_Querys.CommandText = Query_StockBateria;
                TEXTBOX_TabPageBateria_STOCK.Text = Comando_Querys.ExecuteScalar().ToString();

                Comando_Querys.CommandText = Query_DescricaoBateria;
                TEXTBOX_TabPageBateria_DESCRICAO.Text = Comando_Querys.ExecuteScalar().ToString();

                CLASS_BD.ALTERAR_NomeAntigo_Bateria = TEXTBOX_TabPageBateria_NOME.Text;

                if(LigacaoDB.State == ConnectionState.Open)
                    LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void RemoverBateria(string Nome)
        {
            try
            {
                if (Nome != "")
                {
                    LigacaoDB.Open();

                    string QUERY_RemoverBateria = "DELETE FROM Bateria WHERE Nome = '" + Nome + "'";

                    OleDbCommand COMANDO_RemoverBateria = new OleDbCommand(QUERY_RemoverBateria, LigacaoDB);

                    COMANDO_RemoverBateria.ExecuteNonQuery();

                    LigacaoDB.Close();

                    MessageBox.Show("Bateria removida com sucesso!", "Bateria Removida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void AlterarBateria(string Nome, string Ampers, string Preco, string Stock, string Descricao)
        {
            try
            {
                LigacaoDB.Open();

                string QUERY_ItemID = "SELECT ID FROM Bateria WHERE Nome = '" + CLASS_BD.ALTERAR_NomeAntigo_Bateria + "'";
                OleDbCommand COMANDO_ItemID = new OleDbCommand(QUERY_ItemID, LigacaoDB);
                string ItemID = COMANDO_ItemID.ExecuteScalar().ToString();

                string QUERY_AlterarBateria = "UPDATE Bateria SET Nome = '" + Nome + "', Ampers = '" + Ampers + "', Preco = '" + Preco + "', Stock = '" + Stock + "', Descricao = '" + Descricao + "' WHERE Nome = '" + CLASS_BD.ALTERAR_NomeAntigo_Bateria + "'";

                OleDbCommand COMANDO_AlterarBateria = new OleDbCommand(QUERY_AlterarBateria, LigacaoDB);
                COMANDO_AlterarBateria.ExecuteNonQuery();

                MessageBox.Show("Bateria Alterada com Sucesso!", "Bateria Alterada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void CalcularTotalBateria()
        {
            double Preco = 0.0;
            double Total = 0.0;
            string QTD = "";
            int Stock = 0;

            try
            {
                foreach (DataGridViewRow DR in DATAGRIDVIEW_BATERIAS.Rows)
                {
                    foreach(DataGridViewColumn DC in DATAGRIDVIEW_BATERIAS.Columns)
                    {
                        if (DC.Name == "Stock")
                            DC.Name = "HEADER_StockBateria";
                    }

                    if (Convert.ToInt32(DR.Cells["HEADER_StockBateria"].Value) > 1)
                    {
                        Stock = Convert.ToInt32(DR.Cells["HEADER_StockBateria"].Value);
                    }

                    Preco = Convert.ToDouble(DR.Cells["HEADER_PrecoBateria"].Value);

                    if (Convert.ToInt32(DR.Cells["HEADER_StockBateria"].Value) > 1)
                        Preco = Preco * Stock;

                    Total += Preco;
                }

                LABEL_TabPageBateria_TotalBateriaValor.Text = Total.ToString() + " €";
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void CalcularTotalBateriaFiltrada()
        {
            double Preco = 0.0;
            double Total = 0.0;
            int Stock = 0;

            try
            {
                foreach (DataGridViewRow DR in DATAGRIDVIEW_BATERIAS.Rows)
                {
                    foreach(DataGridViewColumn DC in DATAGRIDVIEW_BATERIAS.Columns)
                    {
                        if (DC.Name == "Stock")
                            DC.Name = "HEADER_StockBateria";
                    }

                    if (Convert.ToInt32(DR.Cells["HEADER_StockBateria"].Value) > 1)
                        Stock = Convert.ToInt32(DR.Cells["HEADER_StockBateria"].Value);

                    Preco = Convert.ToDouble(DR.Cells["HEADER_PrecoBateria"].Value.ToString());

                    if (Convert.ToInt32(DR.Cells["HEADER_StockBateria"].Value) > 1)
                        Preco = Preco * Stock;

                    Total += Preco;
                }

                LABEL_TabPageBateria_TotalBateriaFiltradaValor.Text = Total.ToString() + " €";
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void OcultarColunasDesnecessarias_Bateria()
        {
            int Column = 0;
            string ColumnName = "";

            for (Column = 0; Column < DATAGRIDVIEW_BATERIAS.Columns.Count; Column++)
            {
                ColumnName = DATAGRIDVIEW_BATERIAS.Columns[Column].Name;

                if (ColumnName == "Preco")
                {
                    DATAGRIDVIEW_BATERIAS.Columns[Column].Name = "HEADER_PrecoBateria";
                }
            }
        }

        #endregion

        #endregion

        /*----------------------------------------------------------------------------------*/

        #region SECÇÃO DA PINTURA

        #region EVENTOS

        private void TEXTBOX_TabPagePintura_NOME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_TabPagePintura_PRECO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }

        private void TEXTBOX_TabPagePintura_PRECO_TextChanged(object sender, EventArgs e)
        {
            if (TEXTBOX_TabPagePintura_PRECO.Text.Contains("€") == true)
            {
                int Index = TEXTBOX_TabPagePintura_PRECO.Text.IndexOf("€");

                TEXTBOX_TabPagePintura_PRECO.Text = TEXTBOX_TabPagePintura_PRECO.Text.Substring(0, Index);
            }
        }

        private void CHECKBOX_TabPagePintura_FiltrarResultados_TIPO_CheckedChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(TabelaDados2_Pintura);

            // FILTRAR TIPO
            if (CHECKBOX_TabPagePintura_FiltrarResultados_TIPO.Checked == true)
            {
                COMBOBOX_TabPagePintura_FiltrarResultados_TIPO.Enabled = true;
                COMBOBOX_TabPagePintura_FiltrarResultados_TIPO.SelectedIndex = 0;

                if (COMBOBOX_TabPagePintura_FiltrarResultados_TIPO.SelectedIndex != -1)
                {
                    DV.RowFilter = string.Format("PinturaTipo.Nome LIKE '%{0}%'", COMBOBOX_TabPagePintura_FiltrarResultados_TIPO.Text);

                    DATAGRIDVIEW_PINTURA.DataSource = DV;

                    CalcularTotalPinturaFiltrada();
                }
            }

            // LIMPAR A FILTRAGEM E RECARREGAR A TABELA
            if (CHECKBOX_TabPagePintura_FiltrarResultados_TIPO.Checked == false)
            {
                COMBOBOX_TabPagePintura_FiltrarResultados_TIPO.Enabled = false;
                COMBOBOX_TabPagePintura_FiltrarResultados_TIPO.SelectedIndex = -1;

                TabelaDados_Pintura.Clear();
                TabelaDados2_Pintura.Clear();

                this.DATAGRIDVIEW_PINTURA.DataSource = null;
                this.DATAGRIDVIEW_PINTURA.Rows.Clear();
                this.DATAGRIDVIEW_PINTURA.Update();
                this.DATAGRIDVIEW_PINTURA.Refresh();

                PreencherDataGridView_Pintura();

                OcultarColunasDesnecessarias_Pintura();

                LABEL_TabPagePintura_TotalPinturaFiltradaValor.Text = "";
            }
        }

        private void COMBOBOX_TabPageBateria_FiltrarResultados_TIPO_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(TabelaDados2_Pintura);

            if (COMBOBOX_TabPagePintura_FiltrarResultados_TIPO.SelectedIndex != -1)
            {
                DV.RowFilter = string.Format("PinturaTipo.Nome LIKE '%{0}%'", COMBOBOX_TabPagePintura_FiltrarResultados_TIPO.Text);

                DATAGRIDVIEW_PINTURA.DataSource = DV;

                CalcularTotalPinturaFiltrada();
            }
        }

        private void DATAGRIDVIEW_PINTURA_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DATAGRIDVIEW_PINTURA.SelectedRows.Count == 1)
                {
                    DataGridViewRow DGR = DATAGRIDVIEW_PINTURA.SelectedRows[0];

                    string ItemID = DGR.Cells[0].Value.ToString();

                    PreencherTextBoxs_Pintura(ItemID);

                    MENUSTRIP_FormInicio_BUTTON_REMOVER.Visible = true;
                }
            }

            catch (Exception EX)
            {
                //MessageBox.Show(EX.Message);
            }
        }        

        #endregion

        #region FUNÇÕES

        public void PreencherDataGridView_Pintura()
        {
            try
            {
                this.DATAGRIDVIEW_PINTURA.DataSource = null;
                this.DATAGRIDVIEW_PINTURA.Rows.Clear();
                this.DATAGRIDVIEW_PINTURA.Update();
                this.DATAGRIDVIEW_PINTURA.Refresh();

                LigacaoDB.Open();

                OleDbCommand COMANDO_PreencherDataGridView = new OleDbCommand(CLASS_BD.QUERY_PreencherDataGridView_Pintura, LigacaoDB);

                COMANDO_PreencherDataGridView.CommandType = CommandType.Text;

                Adapter_Pintura.SelectCommand = COMANDO_PreencherDataGridView;

                Adapter_Pintura.Fill(TabelaDados_Pintura);
                Adapter_Pintura.Fill(TabelaDados2_Pintura);

                LigacaoDB.Close();

                BindingSource ColecaoDados = new BindingSource();

                ColecaoDados.DataSource = TabelaDados_Pintura;

                DATAGRIDVIEW_PINTURA.DataSource = ColecaoDados;

                Adapter_Pintura.Update(TabelaDados_Pintura);
                Adapter_Pintura.Update(TabelaDados2_Pintura);
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void PreencherComboBoxTipo_Pintura()
        {

        }

        public void PreencherTextBoxs_Pintura(string ItemID)
        {
            try
            {
                LigacaoDB.Open();

                string Query_NomePintura = "SELECT Nome FROM Pintura WHERE ID = " + ItemID + "";
                string Query_PrecoPintura = "SELECT Preco FROM Pintura WHERE ID = " + ItemID + "";
                string Query_StockPintura = "SELECT Stock FROM Pintura WHERE ID = " + ItemID + "";
                string Query_TipoPintura = "SELECT Tipo FROM Pintura WHERE ID = " + ItemID + "";
                string Query_DescricaoPintura = "SELECT Descricao FROM Pintura WHERE ID = " + ItemID + "";

                OleDbCommand Comando_Querys = new OleDbCommand();
                Comando_Querys.Connection = LigacaoDB;

                Comando_Querys.CommandText = Query_NomePintura;
                TEXTBOX_TabPagePintura_NOME.Text = Comando_Querys.ExecuteScalar().ToString();
                string Nome = TEXTBOX_TabPagePintura_NOME.Text;

                Comando_Querys.CommandText = Query_PrecoPintura;
                TEXTBOX_TabPagePintura_PRECO.Text = Comando_Querys.ExecuteScalar().ToString();

                TEXTBOX_TabPagePintura_PRECO.Text = String.Format("{0:C}", Convert.ToDouble(TEXTBOX_TabPagePintura_PRECO.Text));

                Comando_Querys.CommandText = Query_StockPintura;
                TEXTBOX_TabPagePintura_STOCK.Text = Comando_Querys.ExecuteScalar().ToString();

                Comando_Querys.CommandText = Query_TipoPintura;
                string Tipo = Comando_Querys.ExecuteScalar().ToString();
                if (Tipo == "1")
                    COMBOBOX_TabPagePintura_TIPO.SelectedIndex = 0;
                if (Tipo == "2")
                    COMBOBOX_TabPagePintura_TIPO.SelectedIndex = 1;
                if (Tipo == "3")
                    COMBOBOX_TabPagePintura_TIPO.SelectedIndex = 2;
                if (Tipo == "4")
                    COMBOBOX_TabPagePintura_TIPO.SelectedIndex = 3;
                if (Tipo == "5")
                    COMBOBOX_TabPagePintura_TIPO.SelectedIndex = 4;
                if (Tipo == "6")
                    COMBOBOX_TabPagePintura_TIPO.SelectedIndex = 5;
                if (Tipo == "7")
                    COMBOBOX_TabPagePintura_TIPO.SelectedIndex = 6;

                Comando_Querys.CommandText = Query_DescricaoPintura;
                TEXTBOX_TabPagePintura_DESCRICAO.Text = Comando_Querys.ExecuteScalar().ToString();

                CLASS_BD.ALTERAR_NomeAntigo_Pintura = Nome;

                if (LigacaoDB.State == ConnectionState.Open)
                    LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void RemoverPintura(string Nome)
        {
            try
            {
                if (Nome != "")
                {
                    LigacaoDB.Open();

                    string QUERY_RemoverPintura = "DELETE FROM Pintura WHERE Nome = '" + Nome + "'";

                    OleDbCommand COMANDO_RemoverPintura = new OleDbCommand(QUERY_RemoverPintura, LigacaoDB);

                    COMANDO_RemoverPintura.ExecuteNonQuery();

                    LigacaoDB.Close();

                    MessageBox.Show("Pintura removida com sucesso!", "Pintura Removida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void AlterarPintura(string Nome, string Preco, string Stock, string Tipo, string Descricao)
        {
            try
            {
                LigacaoDB.Open();

                string QUERY_ItemID = "SELECT ID FROM Pintura WHERE Nome = '" + CLASS_BD.ALTERAR_NomeAntigo_Pintura + "'";
                OleDbCommand COMANDO_ItemID = new OleDbCommand(QUERY_ItemID, LigacaoDB);
                string ItemID = COMANDO_ItemID.ExecuteScalar().ToString();

                string QUERY_TipoID = "SELECT ID FROM PinturaTipo WHERE Nome = '" + Tipo + "'";
                OleDbCommand COMANDO_TipoID = new OleDbCommand(QUERY_TipoID, LigacaoDB);
                string TipoID = COMANDO_TipoID.ExecuteScalar().ToString();

                string QUERY_AlterarPintura = "UPDATE Pintura SET Nome = '" + Nome + "', Preco = '" + Preco + "', Stock = '" + Stock + "', Tipo = '" + TipoID + "', Descricao = '" + Descricao + "' WHERE Nome = '" + CLASS_BD.ALTERAR_NomeAntigo_Pintura + "'";

                OleDbCommand COMANDO_AlterarPintura = new OleDbCommand(QUERY_AlterarPintura, LigacaoDB);
                COMANDO_AlterarPintura.ExecuteNonQuery();

                MessageBox.Show("Pintura Alterada com Sucesso!", "Pintura Alterada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void CalcularTotalPintura()
        {
            double Preco = 0.0;
            double Total = 0.0;
            int Stock = 0;

            try
            {
                foreach (DataGridViewRow DR in DATAGRIDVIEW_PINTURA.Rows)
                {
                    foreach(DataGridViewColumn DC in DATAGRIDVIEW_PINTURA.Columns)
                    {
                        if (DC.Name == "Stock")
                            DC.Name = "HEADER_StockPintura";
                    }

                    if(Convert.ToInt32(DR.Cells["HEADER_StockPintura"].Value) > 1)
                        Stock = Convert.ToInt32(DR.Cells["HEADER_StockPintura"].Value);

                    Preco = Convert.ToDouble(DR.Cells["HEADER_PrecoPintura"].Value.ToString());

                    if (Convert.ToInt32(DR.Cells["HEADER_StockPintura"].Value) > 1)
                        Preco = Preco * Stock;

                    Total += Preco;
                }

                LABEL_TabPagePintura_TotalPinturaValor.Text = Total.ToString() + " €";
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void CalcularTotalPinturaFiltrada()
        {
            double Preco = 0.0;
            double Total = 0.0;
            int Stock = 0;

            try
            {
                foreach (DataGridViewRow DR in DATAGRIDVIEW_PINTURA.Rows)
                {
                    foreach (DataGridViewColumn DC in DATAGRIDVIEW_PINTURA.Columns)
                    {
                        if (DC.Name == "Stock")
                            DC.Name = "HEADER_StockPintura";
                    }

                    if (Convert.ToInt32(DR.Cells["HEADER_StockPintura"].Value) > 1)
                        Stock = Convert.ToInt32(DR.Cells["HEADER_StockPintura"].Value);

                    Preco = Convert.ToDouble(DR.Cells["HEADER_PrecoPintura"].Value.ToString());

                    if (Convert.ToInt32(DR.Cells["HEADER_StockPintura"].Value) > 1)
                        Preco = Preco * Stock;

                    Total += Preco;
                }

                LABEL_TabPagePintura_TotalPinturaFiltradaValor.Text = Total.ToString() + " €";
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                LigacaoDB.Close();
            }
        }

        public void OcultarColunasDesnecessarias_Pintura()
        {
            try
            {
                foreach (DataGridViewColumn DC in DATAGRIDVIEW_PINTURA.Columns)
                {
                    if (DC.Name == "Pintura.ID")
                    {
                        DC.Name = "HEADER_IDPintura";
                        DC.HeaderText = "ID";
                    }

                    if (DC.Name == "Pintura.Nome")
                    {
                        DC.Name = "HEADER_NomePintura";
                        DC.HeaderText = "Nome";
                    }

                    if (DC.Name == "HEADER_TipoPintura" && DC.Index == 7)
                    {
                        //DC.Visible = false;
                        //DC.Name = "HEADER_TipoPintura";
                    }

                    if (DC.Name == "Tipo" && DC.Index == 4)
                    {
                        DC.Visible = false;
                        //DC.Name = "HEADER_TipoPintura";
                    }

                    if (DC.Name == "PinturaTipo.Nome" && DC.Index == 7)
                    {
                        DC.Name = "HEADER_TipoPintura";
                        DC.HeaderText = "Tipo";
                        DC.DisplayIndex = 4;
                    }
                }

                //DATAGRIDVIEW_PINTURA.Columns["Preco"].Visible = false;
                //DATAGRIDVIEW_PINTURA.Columns["Pintura.ID"].Visible = false;
                //DATAGRIDVIEW_PINTURA.Columns["Tipo"].Visible = false;
                DATAGRIDVIEW_PINTURA.Columns["PinturaTipo.ID"].Visible = false;

                int Column = 0;
                string ColumnName = "";

                for (Column = 0; Column < DATAGRIDVIEW_PINTURA.Columns.Count; Column++)
                {
                    ColumnName = DATAGRIDVIEW_PINTURA.Columns[Column].Name;

                    if (ColumnName == "Preco")
                    {
                        DATAGRIDVIEW_PINTURA.Columns[Column].Name = "HEADER_PrecoPintura";
                    }
                }
            }

            catch(Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        #endregion  

        #endregion       

        /*----------------------------------------------------------------------------------*/
    }
}
