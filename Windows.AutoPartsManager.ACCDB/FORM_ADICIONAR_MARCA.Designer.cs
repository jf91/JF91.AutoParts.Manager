namespace Windows.AutoPartsManager.ACCDB
{
    partial class FORM_ADICIONAR_MARCA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_ADICIONAR_MARCA));
            this.MENUSTRIP_AdicionarMarca = new System.Windows.Forms.MenuStrip();
            this.MENUSTRIP_AdicionarMarca_BUTTON_FECHAR = new System.Windows.Forms.ToolStripMenuItem();
            this.TABCONTROL_AdicionarMarca = new System.Windows.Forms.TabControl();
            this.TABPAGE_AdicionarMarca = new System.Windows.Forms.TabPage();
            this.BUTTON_REMOVER_MARCA = new System.Windows.Forms.Button();
            this.LISTVIEW_MARCAS = new System.Windows.Forms.ListView();
            this.HEADER_MARCA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BUTTON_ADICIONAR_MARCA = new System.Windows.Forms.Button();
            this.TEXTBOX_MARCA = new System.Windows.Forms.TextBox();
            this.LABEL_MARCA = new System.Windows.Forms.Label();
            this.TABPAGE_AcrescentarModelo = new System.Windows.Forms.TabPage();
            this.BUTTON_REMOVER_MODELO = new System.Windows.Forms.Button();
            this.TREEVIEW_MODELOS = new System.Windows.Forms.TreeView();
            this.BUTTON_ADICIONAR_MODELO = new System.Windows.Forms.Button();
            this.TEXTBOX_MODELO = new System.Windows.Forms.TextBox();
            this.LABEL_MODELO = new System.Windows.Forms.Label();
            this.MENUSTRIP_AdicionarMarca.SuspendLayout();
            this.TABCONTROL_AdicionarMarca.SuspendLayout();
            this.TABPAGE_AdicionarMarca.SuspendLayout();
            this.TABPAGE_AcrescentarModelo.SuspendLayout();
            this.SuspendLayout();
            // 
            // MENUSTRIP_AdicionarMarca
            // 
            this.MENUSTRIP_AdicionarMarca.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MENUSTRIP_AdicionarMarca_BUTTON_FECHAR});
            this.MENUSTRIP_AdicionarMarca.Location = new System.Drawing.Point(0, 0);
            this.MENUSTRIP_AdicionarMarca.Name = "MENUSTRIP_AdicionarMarca";
            this.MENUSTRIP_AdicionarMarca.Size = new System.Drawing.Size(260, 24);
            this.MENUSTRIP_AdicionarMarca.TabIndex = 0;
            this.MENUSTRIP_AdicionarMarca.Text = "menuStrip1";
            // 
            // MENUSTRIP_AdicionarMarca_BUTTON_FECHAR
            // 
            this.MENUSTRIP_AdicionarMarca_BUTTON_FECHAR.Name = "MENUSTRIP_AdicionarMarca_BUTTON_FECHAR";
            this.MENUSTRIP_AdicionarMarca_BUTTON_FECHAR.Size = new System.Drawing.Size(54, 20);
            this.MENUSTRIP_AdicionarMarca_BUTTON_FECHAR.Text = "Fechar";
            this.MENUSTRIP_AdicionarMarca_BUTTON_FECHAR.Click += new System.EventHandler(this.MENUSTRIP_AdicionarMarca_BUTTON_FECHAR_Click);
            // 
            // TABCONTROL_AdicionarMarca
            // 
            this.TABCONTROL_AdicionarMarca.Controls.Add(this.TABPAGE_AdicionarMarca);
            this.TABCONTROL_AdicionarMarca.Controls.Add(this.TABPAGE_AcrescentarModelo);
            this.TABCONTROL_AdicionarMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TABCONTROL_AdicionarMarca.Location = new System.Drawing.Point(0, 24);
            this.TABCONTROL_AdicionarMarca.Name = "TABCONTROL_AdicionarMarca";
            this.TABCONTROL_AdicionarMarca.SelectedIndex = 0;
            this.TABCONTROL_AdicionarMarca.Size = new System.Drawing.Size(260, 186);
            this.TABCONTROL_AdicionarMarca.TabIndex = 1;
            // 
            // TABPAGE_AdicionarMarca
            // 
            this.TABPAGE_AdicionarMarca.Controls.Add(this.BUTTON_REMOVER_MARCA);
            this.TABPAGE_AdicionarMarca.Controls.Add(this.LISTVIEW_MARCAS);
            this.TABPAGE_AdicionarMarca.Controls.Add(this.BUTTON_ADICIONAR_MARCA);
            this.TABPAGE_AdicionarMarca.Controls.Add(this.TEXTBOX_MARCA);
            this.TABPAGE_AdicionarMarca.Controls.Add(this.LABEL_MARCA);
            this.TABPAGE_AdicionarMarca.Location = new System.Drawing.Point(4, 22);
            this.TABPAGE_AdicionarMarca.Name = "TABPAGE_AdicionarMarca";
            this.TABPAGE_AdicionarMarca.Padding = new System.Windows.Forms.Padding(3);
            this.TABPAGE_AdicionarMarca.Size = new System.Drawing.Size(252, 160);
            this.TABPAGE_AdicionarMarca.TabIndex = 0;
            this.TABPAGE_AdicionarMarca.Text = "Marca";
            this.TABPAGE_AdicionarMarca.UseVisualStyleBackColor = true;
            // 
            // BUTTON_REMOVER_MARCA
            // 
            this.BUTTON_REMOVER_MARCA.Enabled = false;
            this.BUTTON_REMOVER_MARCA.Location = new System.Drawing.Point(140, 129);
            this.BUTTON_REMOVER_MARCA.Name = "BUTTON_REMOVER_MARCA";
            this.BUTTON_REMOVER_MARCA.Size = new System.Drawing.Size(104, 23);
            this.BUTTON_REMOVER_MARCA.TabIndex = 11;
            this.BUTTON_REMOVER_MARCA.Text = "Remover";
            this.BUTTON_REMOVER_MARCA.UseVisualStyleBackColor = true;
            this.BUTTON_REMOVER_MARCA.Click += new System.EventHandler(this.BUTTON_REMOVER_MARCA_Click);
            // 
            // LISTVIEW_MARCAS
            // 
            this.LISTVIEW_MARCAS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HEADER_MARCA});
            this.LISTVIEW_MARCAS.FullRowSelect = true;
            this.LISTVIEW_MARCAS.HideSelection = false;
            this.LISTVIEW_MARCAS.Location = new System.Drawing.Point(6, 8);
            this.LISTVIEW_MARCAS.Name = "LISTVIEW_MARCAS";
            this.LISTVIEW_MARCAS.Size = new System.Drawing.Size(125, 144);
            this.LISTVIEW_MARCAS.TabIndex = 10;
            this.LISTVIEW_MARCAS.UseCompatibleStateImageBehavior = false;
            this.LISTVIEW_MARCAS.View = System.Windows.Forms.View.Details;
            this.LISTVIEW_MARCAS.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LISTVIEW_MARCAS_ItemSelectionChanged);
            this.LISTVIEW_MARCAS.SelectedIndexChanged += new System.EventHandler(this.LISTVIEW_MARCAS_SelectedIndexChanged);
            // 
            // HEADER_MARCA
            // 
            this.HEADER_MARCA.Text = "Marca";
            this.HEADER_MARCA.Width = 120;
            // 
            // BUTTON_ADICIONAR_MARCA
            // 
            this.BUTTON_ADICIONAR_MARCA.Location = new System.Drawing.Point(140, 51);
            this.BUTTON_ADICIONAR_MARCA.Name = "BUTTON_ADICIONAR_MARCA";
            this.BUTTON_ADICIONAR_MARCA.Size = new System.Drawing.Size(104, 23);
            this.BUTTON_ADICIONAR_MARCA.TabIndex = 9;
            this.BUTTON_ADICIONAR_MARCA.Text = "Adicionar";
            this.BUTTON_ADICIONAR_MARCA.UseVisualStyleBackColor = true;
            this.BUTTON_ADICIONAR_MARCA.Click += new System.EventHandler(this.BUTTON_ADICIONAR_MARCA_Click);
            // 
            // TEXTBOX_MARCA
            // 
            this.TEXTBOX_MARCA.Location = new System.Drawing.Point(140, 25);
            this.TEXTBOX_MARCA.Name = "TEXTBOX_MARCA";
            this.TEXTBOX_MARCA.Size = new System.Drawing.Size(104, 20);
            this.TEXTBOX_MARCA.TabIndex = 6;
            // 
            // LABEL_MARCA
            // 
            this.LABEL_MARCA.AutoSize = true;
            this.LABEL_MARCA.Location = new System.Drawing.Point(137, 9);
            this.LABEL_MARCA.Name = "LABEL_MARCA";
            this.LABEL_MARCA.Size = new System.Drawing.Size(37, 13);
            this.LABEL_MARCA.TabIndex = 5;
            this.LABEL_MARCA.Text = "Marca";
            // 
            // TABPAGE_AcrescentarModelo
            // 
            this.TABPAGE_AcrescentarModelo.Controls.Add(this.BUTTON_REMOVER_MODELO);
            this.TABPAGE_AcrescentarModelo.Controls.Add(this.TREEVIEW_MODELOS);
            this.TABPAGE_AcrescentarModelo.Controls.Add(this.BUTTON_ADICIONAR_MODELO);
            this.TABPAGE_AcrescentarModelo.Controls.Add(this.TEXTBOX_MODELO);
            this.TABPAGE_AcrescentarModelo.Controls.Add(this.LABEL_MODELO);
            this.TABPAGE_AcrescentarModelo.Location = new System.Drawing.Point(4, 22);
            this.TABPAGE_AcrescentarModelo.Name = "TABPAGE_AcrescentarModelo";
            this.TABPAGE_AcrescentarModelo.Padding = new System.Windows.Forms.Padding(3);
            this.TABPAGE_AcrescentarModelo.Size = new System.Drawing.Size(252, 160);
            this.TABPAGE_AcrescentarModelo.TabIndex = 1;
            this.TABPAGE_AcrescentarModelo.Text = "Acrescentar Modelo";
            this.TABPAGE_AcrescentarModelo.UseVisualStyleBackColor = true;
            // 
            // BUTTON_REMOVER_MODELO
            // 
            this.BUTTON_REMOVER_MODELO.Enabled = false;
            this.BUTTON_REMOVER_MODELO.Location = new System.Drawing.Point(140, 129);
            this.BUTTON_REMOVER_MODELO.Name = "BUTTON_REMOVER_MODELO";
            this.BUTTON_REMOVER_MODELO.Size = new System.Drawing.Size(104, 23);
            this.BUTTON_REMOVER_MODELO.TabIndex = 14;
            this.BUTTON_REMOVER_MODELO.Text = "Remover";
            this.BUTTON_REMOVER_MODELO.UseVisualStyleBackColor = true;
            this.BUTTON_REMOVER_MODELO.Click += new System.EventHandler(this.BUTTON_REMOVER_MODELO_Click);
            // 
            // TREEVIEW_MODELOS
            // 
            this.TREEVIEW_MODELOS.FullRowSelect = true;
            this.TREEVIEW_MODELOS.HideSelection = false;
            this.TREEVIEW_MODELOS.Location = new System.Drawing.Point(6, 8);
            this.TREEVIEW_MODELOS.Name = "TREEVIEW_MODELOS";
            this.TREEVIEW_MODELOS.Size = new System.Drawing.Size(125, 144);
            this.TREEVIEW_MODELOS.TabIndex = 13;
            this.TREEVIEW_MODELOS.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TREEVIEW_MODELOS_AfterSelect);
            // 
            // BUTTON_ADICIONAR_MODELO
            // 
            this.BUTTON_ADICIONAR_MODELO.Location = new System.Drawing.Point(140, 51);
            this.BUTTON_ADICIONAR_MODELO.Name = "BUTTON_ADICIONAR_MODELO";
            this.BUTTON_ADICIONAR_MODELO.Size = new System.Drawing.Size(104, 23);
            this.BUTTON_ADICIONAR_MODELO.TabIndex = 12;
            this.BUTTON_ADICIONAR_MODELO.Text = "Adicionar";
            this.BUTTON_ADICIONAR_MODELO.UseVisualStyleBackColor = true;
            this.BUTTON_ADICIONAR_MODELO.Click += new System.EventHandler(this.BUTTON_ADICIONAR_MODELO_Click);
            // 
            // TEXTBOX_MODELO
            // 
            this.TEXTBOX_MODELO.Location = new System.Drawing.Point(140, 25);
            this.TEXTBOX_MODELO.Name = "TEXTBOX_MODELO";
            this.TEXTBOX_MODELO.Size = new System.Drawing.Size(100, 20);
            this.TEXTBOX_MODELO.TabIndex = 10;
            // 
            // LABEL_MODELO
            // 
            this.LABEL_MODELO.AutoSize = true;
            this.LABEL_MODELO.Location = new System.Drawing.Point(137, 9);
            this.LABEL_MODELO.Name = "LABEL_MODELO";
            this.LABEL_MODELO.Size = new System.Drawing.Size(42, 13);
            this.LABEL_MODELO.TabIndex = 9;
            this.LABEL_MODELO.Text = "Modelo";
            // 
            // FORM_ADICIONAR_MARCA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 210);
            this.Controls.Add(this.TABCONTROL_AdicionarMarca);
            this.Controls.Add(this.MENUSTRIP_AdicionarMarca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MENUSTRIP_AdicionarMarca;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FORM_ADICIONAR_MARCA";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionar Marca";
            this.TopMost = true;
            this.MENUSTRIP_AdicionarMarca.ResumeLayout(false);
            this.MENUSTRIP_AdicionarMarca.PerformLayout();
            this.TABCONTROL_AdicionarMarca.ResumeLayout(false);
            this.TABPAGE_AdicionarMarca.ResumeLayout(false);
            this.TABPAGE_AdicionarMarca.PerformLayout();
            this.TABPAGE_AcrescentarModelo.ResumeLayout(false);
            this.TABPAGE_AcrescentarModelo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MENUSTRIP_AdicionarMarca;
        private System.Windows.Forms.ToolStripMenuItem MENUSTRIP_AdicionarMarca_BUTTON_FECHAR;
        private System.Windows.Forms.TabControl TABCONTROL_AdicionarMarca;
        private System.Windows.Forms.TabPage TABPAGE_AdicionarMarca;
        private System.Windows.Forms.Button BUTTON_ADICIONAR_MARCA;
        private System.Windows.Forms.TextBox TEXTBOX_MARCA;
        private System.Windows.Forms.Label LABEL_MARCA;
        private System.Windows.Forms.TabPage TABPAGE_AcrescentarModelo;
        private System.Windows.Forms.Button BUTTON_ADICIONAR_MODELO;
        private System.Windows.Forms.TextBox TEXTBOX_MODELO;
        private System.Windows.Forms.Label LABEL_MODELO;
        private System.Windows.Forms.TreeView TREEVIEW_MODELOS;
        private System.Windows.Forms.ListView LISTVIEW_MARCAS;
        private System.Windows.Forms.ColumnHeader HEADER_MARCA;
        private System.Windows.Forms.Button BUTTON_REMOVER_MARCA;
        private System.Windows.Forms.Button BUTTON_REMOVER_MODELO;

    }
}