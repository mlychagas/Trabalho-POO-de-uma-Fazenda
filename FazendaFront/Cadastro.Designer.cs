namespace FazendaFront
{
    partial class Cadastro
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
            this.txtNotaFiscal = new System.Windows.Forms.TextBox();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.txtFrete = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtGta = new System.Windows.Forms.TextBox();
            this.cbxFornecedor = new System.Windows.Forms.ComboBox();
            this.btSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDataCompra = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtNotaFiscal
            // 
            this.txtNotaFiscal.Location = new System.Drawing.Point(562, 101);
            this.txtNotaFiscal.Multiline = true;
            this.txtNotaFiscal.Name = "txtNotaFiscal";
            this.txtNotaFiscal.Size = new System.Drawing.Size(178, 36);
            this.txtNotaFiscal.TabIndex = 1;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(846, 101);
            this.txtValorTotal.Multiline = true;
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(181, 36);
            this.txtValorTotal.TabIndex = 2;
            this.txtValorTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorTotal_KeyPress);
            // 
            // txtFrete
            // 
            this.txtFrete.Location = new System.Drawing.Point(75, 259);
            this.txtFrete.Multiline = true;
            this.txtFrete.Name = "txtFrete";
            this.txtFrete.Size = new System.Drawing.Size(177, 36);
            this.txtFrete.TabIndex = 3;
            this.txtFrete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFrete_KeyPress);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(775, 259);
            this.txtQuantidade.Multiline = true;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(163, 36);
            this.txtQuantidade.TabIndex = 4;
            // 
            // txtGta
            // 
            this.txtGta.Location = new System.Drawing.Point(457, 259);
            this.txtGta.Multiline = true;
            this.txtGta.Name = "txtGta";
            this.txtGta.Size = new System.Drawing.Size(177, 36);
            this.txtGta.TabIndex = 5;
            // 
            // cbxFornecedor
            // 
            this.cbxFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFornecedor.FormattingEnabled = true;
            this.cbxFornecedor.Location = new System.Drawing.Point(75, 431);
            this.cbxFornecedor.Name = "cbxFornecedor";
            this.cbxFornecedor.Size = new System.Drawing.Size(177, 24);
            this.cbxFornecedor.TabIndex = 6;
            // 
            // btSalvar
            // 
            this.btSalvar.BackColor = System.Drawing.Color.YellowGreen;
            this.btSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalvar.Location = new System.Drawing.Point(1008, 541);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(139, 41);
            this.btSalvar.TabIndex = 7;
            this.btSalvar.Text = "SALVAR";
            this.btSalvar.UseVisualStyleBackColor = false;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Data da compra:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(841, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "Valor Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(770, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Quantidade:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(452, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "GTA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(557, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "Número NF:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(70, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 29);
            this.label6.TabIndex = 13;
            this.label6.Text = "Frete:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(70, 399);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 29);
            this.label7.TabIndex = 14;
            this.label7.Text = "Fornecedor:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 32);
            this.label8.TabIndex = 15;
            this.label8.Text = "Cadastro";
            // 
            // dtpDataCompra
            // 
            this.dtpDataCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataCompra.Location = new System.Drawing.Point(75, 115);
            this.dtpDataCompra.Name = "dtpDataCompra";
            this.dtpDataCompra.Size = new System.Drawing.Size(206, 22);
            this.dtpDataCompra.TabIndex = 16;
            // 
            // Cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 635);
            this.Controls.Add(this.dtpDataCompra);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.cbxFornecedor);
            this.Controls.Add(this.txtGta);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtFrete);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.txtNotaFiscal);
            this.Name = "Cadastro";
            this.Text = "Cadastro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNotaFiscal;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.TextBox txtFrete;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtGta;
        private System.Windows.Forms.ComboBox cbxFornecedor;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDataCompra;
    }
}