namespace Windows.AutoPartsManager.ACCDB
{
    partial class FORM_ADICIONAR_PINTURA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_ADICIONAR_PINTURA));
            this.MENUSTRIP_AdicionarBateria = new System.Windows.Forms.MenuStrip();
            this.MENUSTRIP_AdicionarPintura_BUTTON_FECHAR = new System.Windows.Forms.ToolStripMenuItem();
            this.MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR = new System.Windows.Forms.ToolStripMenuItem();
            this.TEXTBOX_DESCRICAO = new System.Windows.Forms.TextBox();
            this.LABEL_DESCRICAO = new System.Windows.Forms.Label();
            this.TEXTBOX_PRECO = new System.Windows.Forms.TextBox();
            this.LABEL_PRECO = new System.Windows.Forms.Label();
            this.LABEL_TIPO = new System.Windows.Forms.Label();
            this.TEXTBOX_NOME = new System.Windows.Forms.TextBox();
            this.LABEL_NOME = new System.Windows.Forms.Label();
            this.COMBOBOX_TIPO = new System.Windows.Forms.ComboBox();
            this.TEXTBOX_STOCK = new System.Windows.Forms.TextBox();
            this.LABEL_STOCK = new System.Windows.Forms.Label();
            this.MENUSTRIP_AdicionarBateria.SuspendLayout();
            this.SuspendLayout();
            // 
            // MENUSTRIP_AdicionarBateria
            // 
            this.MENUSTRIP_AdicionarBateria.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MENUSTRIP_AdicionarPintura_BUTTON_FECHAR,
            this.MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR});
            this.MENUSTRIP_AdicionarBateria.Location = new System.Drawing.Point(0, 0);
            this.MENUSTRIP_AdicionarBateria.Name = "MENUSTRIP_AdicionarBateria";
            this.MENUSTRIP_AdicionarBateria.Size = new System.Drawing.Size(327, 24);
            this.MENUSTRIP_AdicionarBateria.TabIndex = 0;
            this.MENUSTRIP_AdicionarBateria.Text = "menuStrip1";
            // 
            // MENUSTRIP_AdicionarPintura_BUTTON_FECHAR
            // 
            this.MENUSTRIP_AdicionarPintura_BUTTON_FECHAR.Name = "MENUSTRIP_AdicionarPintura_BUTTON_FECHAR";
            this.MENUSTRIP_AdicionarPintura_BUTTON_FECHAR.Size = new System.Drawing.Size(54, 20);
            this.MENUSTRIP_AdicionarPintura_BUTTON_FECHAR.Text = "Fechar";
            this.MENUSTRIP_AdicionarPintura_BUTTON_FECHAR.Click += new System.EventHandler(this.MENUSTRIP_AdicionarPintura_BUTTON_FECHAR_Click);
            // 
            // MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR
            // 
            this.MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Enabled = false;
            this.MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Name = "MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR";
            this.MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Size = new System.Drawing.Size(70, 20);
            this.MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Text = "Adicionar";
            this.MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR.Click += new System.EventHandler(this.MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR_Click);
            // 
            // TEXTBOX_DESCRICAO
            // 
            this.TEXTBOX_DESCRICAO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_DESCRICAO.Location = new System.Drawing.Point(19, 101);
            this.TEXTBOX_DESCRICAO.Multiline = true;
            this.TEXTBOX_DESCRICAO.Name = "TEXTBOX_DESCRICAO";
            this.TEXTBOX_DESCRICAO.Size = new System.Drawing.Size(197, 198);
            this.TEXTBOX_DESCRICAO.TabIndex = 26;
            this.TEXTBOX_DESCRICAO.TextChanged += new System.EventHandler(this.TEXTBOX_DESCRICAO_TextChanged);
            // 
            // LABEL_DESCRICAO
            // 
            this.LABEL_DESCRICAO.AutoSize = true;
            this.LABEL_DESCRICAO.Location = new System.Drawing.Point(16, 83);
            this.LABEL_DESCRICAO.Name = "LABEL_DESCRICAO";
            this.LABEL_DESCRICAO.Size = new System.Drawing.Size(55, 13);
            this.LABEL_DESCRICAO.TabIndex = 25;
            this.LABEL_DESCRICAO.Text = "Descrição";
            // 
            // TEXTBOX_PRECO
            // 
            this.TEXTBOX_PRECO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_PRECO.Location = new System.Drawing.Point(225, 162);
            this.TEXTBOX_PRECO.Name = "TEXTBOX_PRECO";
            this.TEXTBOX_PRECO.Size = new System.Drawing.Size(84, 20);
            this.TEXTBOX_PRECO.TabIndex = 24;
            this.TEXTBOX_PRECO.TextChanged += new System.EventHandler(this.TEXTBOX_PRECO_TextChanged);
            this.TEXTBOX_PRECO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_PRECO_KeyPress);
            // 
            // LABEL_PRECO
            // 
            this.LABEL_PRECO.AutoSize = true;
            this.LABEL_PRECO.Location = new System.Drawing.Point(222, 144);
            this.LABEL_PRECO.Name = "LABEL_PRECO";
            this.LABEL_PRECO.Size = new System.Drawing.Size(35, 13);
            this.LABEL_PRECO.TabIndex = 23;
            this.LABEL_PRECO.Text = "Preço";
            // 
            // LABEL_TIPO
            // 
            this.LABEL_TIPO.AutoSize = true;
            this.LABEL_TIPO.Location = new System.Drawing.Point(222, 100);
            this.LABEL_TIPO.Name = "LABEL_TIPO";
            this.LABEL_TIPO.Size = new System.Drawing.Size(28, 13);
            this.LABEL_TIPO.TabIndex = 22;
            this.LABEL_TIPO.Text = "Tipo";
            // 
            // TEXTBOX_NOME
            // 
            this.TEXTBOX_NOME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_NOME.Location = new System.Drawing.Point(19, 49);
            this.TEXTBOX_NOME.Name = "TEXTBOX_NOME";
            this.TEXTBOX_NOME.Size = new System.Drawing.Size(290, 20);
            this.TEXTBOX_NOME.TabIndex = 21;
            this.TEXTBOX_NOME.TextChanged += new System.EventHandler(this.TEXTBOX_NOME_TextChanged);
            // 
            // LABEL_NOME
            // 
            this.LABEL_NOME.AutoSize = true;
            this.LABEL_NOME.Location = new System.Drawing.Point(16, 33);
            this.LABEL_NOME.Name = "LABEL_NOME";
            this.LABEL_NOME.Size = new System.Drawing.Size(35, 13);
            this.LABEL_NOME.TabIndex = 20;
            this.LABEL_NOME.Text = "Nome";
            // 
            // COMBOBOX_TIPO
            // 
            this.COMBOBOX_TIPO.DisplayMember = "Nome";
            this.COMBOBOX_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMBOBOX_TIPO.FormattingEnabled = true;
            this.COMBOBOX_TIPO.Items.AddRange(new object[] {
            "Vernizes",
            "Tintas",
            "Corantes",
            "Diversos",
            "Aparelho",
            "Activadores",
            "Catalisadores"});
            this.COMBOBOX_TIPO.Location = new System.Drawing.Point(225, 116);
            this.COMBOBOX_TIPO.Name = "COMBOBOX_TIPO";
            this.COMBOBOX_TIPO.Size = new System.Drawing.Size(84, 21);
            this.COMBOBOX_TIPO.TabIndex = 27;
            this.COMBOBOX_TIPO.ValueMember = "Nome";
            this.COMBOBOX_TIPO.SelectedIndexChanged += new System.EventHandler(this.COMBOBOX_TIPO_SelectedIndexChanged);
            // 
            // TEXTBOX_STOCK
            // 
            this.TEXTBOX_STOCK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_STOCK.Location = new System.Drawing.Point(225, 209);
            this.TEXTBOX_STOCK.Name = "TEXTBOX_STOCK";
            this.TEXTBOX_STOCK.Size = new System.Drawing.Size(84, 20);
            this.TEXTBOX_STOCK.TabIndex = 29;
            this.TEXTBOX_STOCK.TextChanged += new System.EventHandler(this.TEXTBOX_STOCK_TextChanged);
            this.TEXTBOX_STOCK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_STOCK_KeyPress);
            // 
            // LABEL_STOCK
            // 
            this.LABEL_STOCK.AutoSize = true;
            this.LABEL_STOCK.Location = new System.Drawing.Point(222, 191);
            this.LABEL_STOCK.Name = "LABEL_STOCK";
            this.LABEL_STOCK.Size = new System.Drawing.Size(35, 13);
            this.LABEL_STOCK.TabIndex = 28;
            this.LABEL_STOCK.Text = "Stock";
            // 
            // FORM_ADICIONAR_PINTURA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 311);
            this.Controls.Add(this.TEXTBOX_STOCK);
            this.Controls.Add(this.LABEL_STOCK);
            this.Controls.Add(this.COMBOBOX_TIPO);
            this.Controls.Add(this.TEXTBOX_DESCRICAO);
            this.Controls.Add(this.LABEL_DESCRICAO);
            this.Controls.Add(this.TEXTBOX_PRECO);
            this.Controls.Add(this.LABEL_PRECO);
            this.Controls.Add(this.LABEL_TIPO);
            this.Controls.Add(this.TEXTBOX_NOME);
            this.Controls.Add(this.LABEL_NOME);
            this.Controls.Add(this.MENUSTRIP_AdicionarBateria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MENUSTRIP_AdicionarBateria;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FORM_ADICIONAR_PINTURA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionar Pintura";
            this.MENUSTRIP_AdicionarBateria.ResumeLayout(false);
            this.MENUSTRIP_AdicionarBateria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MENUSTRIP_AdicionarBateria;
        private System.Windows.Forms.ToolStripMenuItem MENUSTRIP_AdicionarPintura_BUTTON_FECHAR;
        private System.Windows.Forms.ToolStripMenuItem MENUSTRIP_AdicionarPintura_BUTTON_ADICIONAR;
        private System.Windows.Forms.TextBox TEXTBOX_DESCRICAO;
        private System.Windows.Forms.Label LABEL_DESCRICAO;
        private System.Windows.Forms.TextBox TEXTBOX_PRECO;
        private System.Windows.Forms.Label LABEL_PRECO;
        private System.Windows.Forms.Label LABEL_TIPO;
        private System.Windows.Forms.TextBox TEXTBOX_NOME;
        private System.Windows.Forms.Label LABEL_NOME;
        private System.Windows.Forms.ComboBox COMBOBOX_TIPO;
        private System.Windows.Forms.TextBox TEXTBOX_STOCK;
        private System.Windows.Forms.Label LABEL_STOCK;
    }
}