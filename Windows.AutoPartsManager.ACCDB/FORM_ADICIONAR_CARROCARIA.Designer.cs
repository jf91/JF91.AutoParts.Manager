namespace Windows.AutoPartsManager.ACCDB
{
    partial class FORM_ADICIONAR_CARROCARIA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_ADICIONAR_CARROCARIA));
            this.MENUSTRIP_AdicionarCarrocaria = new System.Windows.Forms.MenuStrip();
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_FECHAR = new System.Windows.Forms.ToolStripMenuItem();
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR = new System.Windows.Forms.ToolStripMenuItem();
            this.LABEL_NOME = new System.Windows.Forms.Label();
            this.TEXTBOX_NOME = new System.Windows.Forms.TextBox();
            this.LABEL_PRECO = new System.Windows.Forms.Label();
            this.TEXTBOX_PRECO = new System.Windows.Forms.TextBox();
            this.LABEL_ANO = new System.Windows.Forms.Label();
            this.DATETIMEPICKER_ANO = new System.Windows.Forms.DateTimePicker();
            this.LABEL_STOCK = new System.Windows.Forms.Label();
            this.TEXTBOX_STOCK = new System.Windows.Forms.TextBox();
            this.LABEL_DESCRICAO = new System.Windows.Forms.Label();
            this.TEXTBOX_DESCRICAO = new System.Windows.Forms.TextBox();
            this.LABEL_MARCA = new System.Windows.Forms.Label();
            this.COMBOBOX_MARCA = new System.Windows.Forms.ComboBox();
            this.LABEL_MODELO = new System.Windows.Forms.Label();
            this.COMBOBOX_MODELO = new System.Windows.Forms.ComboBox();
            this.MENUSTRIP_AdicionarCarrocaria.SuspendLayout();
            this.SuspendLayout();
            // 
            // MENUSTRIP_AdicionarCarrocaria
            // 
            this.MENUSTRIP_AdicionarCarrocaria.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_FECHAR,
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR});
            this.MENUSTRIP_AdicionarCarrocaria.Location = new System.Drawing.Point(0, 0);
            this.MENUSTRIP_AdicionarCarrocaria.Name = "MENUSTRIP_AdicionarCarrocaria";
            this.MENUSTRIP_AdicionarCarrocaria.Size = new System.Drawing.Size(327, 24);
            this.MENUSTRIP_AdicionarCarrocaria.TabIndex = 0;
            this.MENUSTRIP_AdicionarCarrocaria.Text = "menuStrip1";
            // 
            // MENUSTRIP_AdicionarCarrocaria_BUTTON_FECHAR
            // 
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_FECHAR.Name = "MENUSTRIP_AdicionarCarrocaria_BUTTON_FECHAR";
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_FECHAR.Size = new System.Drawing.Size(54, 20);
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_FECHAR.Text = "Fechar";
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_FECHAR.Click += new System.EventHandler(this.MENUSTRIP_AdicionarCarrocaria_BUTTON_FECHAR_Click);
            // 
            // MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR
            // 
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Enabled = false;
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Name = "MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR";
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Size = new System.Drawing.Size(70, 20);
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Text = "Adicionar";
            this.MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR.Click += new System.EventHandler(this.MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR_Click);
            // 
            // LABEL_NOME
            // 
            this.LABEL_NOME.AutoSize = true;
            this.LABEL_NOME.Location = new System.Drawing.Point(16, 33);
            this.LABEL_NOME.Name = "LABEL_NOME";
            this.LABEL_NOME.Size = new System.Drawing.Size(35, 13);
            this.LABEL_NOME.TabIndex = 1;
            this.LABEL_NOME.Text = "Nome";
            // 
            // TEXTBOX_NOME
            // 
            this.TEXTBOX_NOME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_NOME.Location = new System.Drawing.Point(19, 49);
            this.TEXTBOX_NOME.Name = "TEXTBOX_NOME";
            this.TEXTBOX_NOME.Size = new System.Drawing.Size(290, 20);
            this.TEXTBOX_NOME.TabIndex = 2;
            this.TEXTBOX_NOME.TextChanged += new System.EventHandler(this.TEXTBOX_NOME_TextChanged);
            // 
            // LABEL_PRECO
            // 
            this.LABEL_PRECO.AutoSize = true;
            this.LABEL_PRECO.Location = new System.Drawing.Point(222, 101);
            this.LABEL_PRECO.Name = "LABEL_PRECO";
            this.LABEL_PRECO.Size = new System.Drawing.Size(35, 13);
            this.LABEL_PRECO.TabIndex = 3;
            this.LABEL_PRECO.Text = "Preço";
            // 
            // TEXTBOX_PRECO
            // 
            this.TEXTBOX_PRECO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_PRECO.Location = new System.Drawing.Point(225, 116);
            this.TEXTBOX_PRECO.Name = "TEXTBOX_PRECO";
            this.TEXTBOX_PRECO.Size = new System.Drawing.Size(84, 20);
            this.TEXTBOX_PRECO.TabIndex = 4;
            this.TEXTBOX_PRECO.TextChanged += new System.EventHandler(this.TEXTBOX_PRECO_TextChanged);
            this.TEXTBOX_PRECO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_PRECO_KeyPress);
            // 
            // LABEL_ANO
            // 
            this.LABEL_ANO.AutoSize = true;
            this.LABEL_ANO.Location = new System.Drawing.Point(225, 265);
            this.LABEL_ANO.Name = "LABEL_ANO";
            this.LABEL_ANO.Size = new System.Drawing.Size(26, 13);
            this.LABEL_ANO.TabIndex = 5;
            this.LABEL_ANO.Text = "Ano";
            // 
            // DATETIMEPICKER_ANO
            // 
            this.DATETIMEPICKER_ANO.CustomFormat = "yyyy";
            this.DATETIMEPICKER_ANO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DATETIMEPICKER_ANO.Location = new System.Drawing.Point(228, 279);
            this.DATETIMEPICKER_ANO.Name = "DATETIMEPICKER_ANO";
            this.DATETIMEPICKER_ANO.Size = new System.Drawing.Size(81, 20);
            this.DATETIMEPICKER_ANO.TabIndex = 6;
            // 
            // LABEL_STOCK
            // 
            this.LABEL_STOCK.AutoSize = true;
            this.LABEL_STOCK.Location = new System.Drawing.Point(222, 144);
            this.LABEL_STOCK.Name = "LABEL_STOCK";
            this.LABEL_STOCK.Size = new System.Drawing.Size(35, 13);
            this.LABEL_STOCK.TabIndex = 7;
            this.LABEL_STOCK.Text = "Stock";
            // 
            // TEXTBOX_STOCK
            // 
            this.TEXTBOX_STOCK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_STOCK.Location = new System.Drawing.Point(225, 162);
            this.TEXTBOX_STOCK.Name = "TEXTBOX_STOCK";
            this.TEXTBOX_STOCK.Size = new System.Drawing.Size(84, 20);
            this.TEXTBOX_STOCK.TabIndex = 8;
            this.TEXTBOX_STOCK.TextChanged += new System.EventHandler(this.TEXTBOX_STOCK_TextChanged);
            this.TEXTBOX_STOCK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_STOCK_KeyPress);
            // 
            // LABEL_DESCRICAO
            // 
            this.LABEL_DESCRICAO.AutoSize = true;
            this.LABEL_DESCRICAO.Location = new System.Drawing.Point(16, 83);
            this.LABEL_DESCRICAO.Name = "LABEL_DESCRICAO";
            this.LABEL_DESCRICAO.Size = new System.Drawing.Size(55, 13);
            this.LABEL_DESCRICAO.TabIndex = 9;
            this.LABEL_DESCRICAO.Text = "Descrição";
            // 
            // TEXTBOX_DESCRICAO
            // 
            this.TEXTBOX_DESCRICAO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_DESCRICAO.Location = new System.Drawing.Point(19, 101);
            this.TEXTBOX_DESCRICAO.Multiline = true;
            this.TEXTBOX_DESCRICAO.Name = "TEXTBOX_DESCRICAO";
            this.TEXTBOX_DESCRICAO.Size = new System.Drawing.Size(197, 198);
            this.TEXTBOX_DESCRICAO.TabIndex = 10;
            this.TEXTBOX_DESCRICAO.TextChanged += new System.EventHandler(this.TEXTBOX_DESCRICAO_TextChanged);
            // 
            // LABEL_MARCA
            // 
            this.LABEL_MARCA.AutoSize = true;
            this.LABEL_MARCA.Location = new System.Drawing.Point(225, 185);
            this.LABEL_MARCA.Name = "LABEL_MARCA";
            this.LABEL_MARCA.Size = new System.Drawing.Size(37, 13);
            this.LABEL_MARCA.TabIndex = 11;
            this.LABEL_MARCA.Text = "Marca";
            // 
            // COMBOBOX_MARCA
            // 
            this.COMBOBOX_MARCA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMBOBOX_MARCA.FormattingEnabled = true;
            this.COMBOBOX_MARCA.Location = new System.Drawing.Point(225, 201);
            this.COMBOBOX_MARCA.Name = "COMBOBOX_MARCA";
            this.COMBOBOX_MARCA.Size = new System.Drawing.Size(84, 21);
            this.COMBOBOX_MARCA.TabIndex = 12;
            this.COMBOBOX_MARCA.SelectedIndexChanged += new System.EventHandler(this.COMBOBOX_MARCA_SelectedIndexChanged);
            // 
            // LABEL_MODELO
            // 
            this.LABEL_MODELO.AutoSize = true;
            this.LABEL_MODELO.Location = new System.Drawing.Point(225, 225);
            this.LABEL_MODELO.Name = "LABEL_MODELO";
            this.LABEL_MODELO.Size = new System.Drawing.Size(42, 13);
            this.LABEL_MODELO.TabIndex = 13;
            this.LABEL_MODELO.Text = "Modelo";
            // 
            // COMBOBOX_MODELO
            // 
            this.COMBOBOX_MODELO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMBOBOX_MODELO.Enabled = false;
            this.COMBOBOX_MODELO.FormattingEnabled = true;
            this.COMBOBOX_MODELO.Location = new System.Drawing.Point(225, 241);
            this.COMBOBOX_MODELO.Name = "COMBOBOX_MODELO";
            this.COMBOBOX_MODELO.Size = new System.Drawing.Size(84, 21);
            this.COMBOBOX_MODELO.TabIndex = 14;
            // 
            // FORM_ADICIONAR_CARROCARIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 311);
            this.Controls.Add(this.COMBOBOX_MODELO);
            this.Controls.Add(this.LABEL_MODELO);
            this.Controls.Add(this.COMBOBOX_MARCA);
            this.Controls.Add(this.LABEL_MARCA);
            this.Controls.Add(this.TEXTBOX_DESCRICAO);
            this.Controls.Add(this.LABEL_DESCRICAO);
            this.Controls.Add(this.TEXTBOX_STOCK);
            this.Controls.Add(this.LABEL_STOCK);
            this.Controls.Add(this.DATETIMEPICKER_ANO);
            this.Controls.Add(this.LABEL_ANO);
            this.Controls.Add(this.TEXTBOX_PRECO);
            this.Controls.Add(this.LABEL_PRECO);
            this.Controls.Add(this.TEXTBOX_NOME);
            this.Controls.Add(this.LABEL_NOME);
            this.Controls.Add(this.MENUSTRIP_AdicionarCarrocaria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MENUSTRIP_AdicionarCarrocaria;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FORM_ADICIONAR_CARROCARIA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionar Peça de Carroçaria";
            this.MENUSTRIP_AdicionarCarrocaria.ResumeLayout(false);
            this.MENUSTRIP_AdicionarCarrocaria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MENUSTRIP_AdicionarCarrocaria;
        private System.Windows.Forms.ToolStripMenuItem MENUSTRIP_AdicionarCarrocaria_BUTTON_FECHAR;
        private System.Windows.Forms.ToolStripMenuItem MENUSTRIP_AdicionarCarrocaria_BUTTON_ADICIONAR;
        private System.Windows.Forms.Label LABEL_NOME;
        private System.Windows.Forms.TextBox TEXTBOX_NOME;
        private System.Windows.Forms.Label LABEL_PRECO;
        private System.Windows.Forms.TextBox TEXTBOX_PRECO;
        private System.Windows.Forms.Label LABEL_ANO;
        private System.Windows.Forms.DateTimePicker DATETIMEPICKER_ANO;
        private System.Windows.Forms.Label LABEL_STOCK;
        private System.Windows.Forms.TextBox TEXTBOX_STOCK;
        private System.Windows.Forms.Label LABEL_DESCRICAO;
        private System.Windows.Forms.TextBox TEXTBOX_DESCRICAO;
        private System.Windows.Forms.Label LABEL_MARCA;
        private System.Windows.Forms.ComboBox COMBOBOX_MARCA;
        private System.Windows.Forms.Label LABEL_MODELO;
        private System.Windows.Forms.ComboBox COMBOBOX_MODELO;
    }
}