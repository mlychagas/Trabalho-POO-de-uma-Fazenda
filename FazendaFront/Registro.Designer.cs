namespace FazendaFront
{
    partial class Registro
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
            this.components = new System.ComponentModel.Container();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.btDeletar = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.colIdCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroNF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colquantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colgta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomeFornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCpfCnpjFornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(49, 57);
            this.txtBusca.Multiline = true;
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(337, 33);
            this.txtBusca.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtBusca, "Pesquise pelo número da Nota Fiscal ou pela data (formato AAAA-MM-DD) ou pelo dia" +
        ".");
            // 
            // btBuscar
            // 
            this.btBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Location = new System.Drawing.Point(405, 51);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(139, 41);
            this.btBuscar.TabIndex = 1;
            this.btBuscar.Text = "BUSCAR";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // btNovo
            // 
            this.btNovo.BackColor = System.Drawing.Color.PowderBlue;
            this.btNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNovo.Location = new System.Drawing.Point(1131, 51);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(139, 41);
            this.btNovo.TabIndex = 2;
            this.btNovo.Text = "NOVO";
            this.toolTip1.SetToolTip(this.btNovo, "Clique para cadastrar uma nova compra.");
            this.btNovo.UseVisualStyleBackColor = false;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // btDeletar
            // 
            this.btDeletar.BackColor = System.Drawing.Color.Red;
            this.btDeletar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeletar.Location = new System.Drawing.Point(49, 557);
            this.btDeletar.Name = "btDeletar";
            this.btDeletar.Size = new System.Drawing.Size(139, 41);
            this.btDeletar.TabIndex = 3;
            this.btDeletar.Text = "DELETAR";
            this.toolTip1.SetToolTip(this.btDeletar, "Clique para deletar um registro por definitivo.");
            this.btDeletar.UseVisualStyleBackColor = false;
            this.btDeletar.Click += new System.EventHandler(this.btDeletar_Click);
            // 
            // btEditar
            // 
            this.btEditar.BackColor = System.Drawing.Color.Orange;
            this.btEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEditar.Location = new System.Drawing.Point(1131, 557);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(139, 41);
            this.btEditar.TabIndex = 4;
            this.btEditar.Text = "EDITAR";
            this.toolTip1.SetToolTip(this.btEditar, "Clique para editar um registro.");
            this.btEditar.UseVisualStyleBackColor = false;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Consulta";
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsulta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCompra,
            this.colData,
            this.colNumeroNF,
            this.colquantidade,
            this.colValorTotal,
            this.colgta,
            this.colFrete,
            this.colNomeFornecedor,
            this.colCpfCnpjFornecedor,
            this.colTelefone});
            this.dgvConsulta.Location = new System.Drawing.Point(49, 123);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.RowHeadersWidth = 51;
            this.dgvConsulta.RowTemplate.Height = 24;
            this.dgvConsulta.Size = new System.Drawing.Size(1221, 409);
            this.dgvConsulta.TabIndex = 7;
            // 
            // colIdCompra
            // 
            this.colIdCompra.DataPropertyName = "IdCompra";
            this.colIdCompra.HeaderText = "Código";
            this.colIdCompra.MinimumWidth = 6;
            this.colIdCompra.Name = "colIdCompra";
            this.colIdCompra.ReadOnly = true;
            this.colIdCompra.Width = 80;
            // 
            // colData
            // 
            this.colData.DataPropertyName = "DataCompra";
            this.colData.HeaderText = "Data da Compra";
            this.colData.MinimumWidth = 6;
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 124;
            // 
            // colNumeroNF
            // 
            this.colNumeroNF.DataPropertyName = "NumeroNotaFiscal";
            this.colNumeroNF.HeaderText = "Nota Fiscal";
            this.colNumeroNF.MinimumWidth = 6;
            this.colNumeroNF.Name = "colNumeroNF";
            this.colNumeroNF.ReadOnly = true;
            this.colNumeroNF.Width = 96;
            // 
            // colquantidade
            // 
            this.colquantidade.DataPropertyName = "Quantidade";
            this.colquantidade.HeaderText = "Quantidade";
            this.colquantidade.MinimumWidth = 6;
            this.colquantidade.Name = "colquantidade";
            this.colquantidade.ReadOnly = true;
            this.colquantidade.Width = 106;
            // 
            // colValorTotal
            // 
            this.colValorTotal.DataPropertyName = "ValorTotalNota";
            this.colValorTotal.HeaderText = "Valor Total";
            this.colValorTotal.MinimumWidth = 6;
            this.colValorTotal.Name = "colValorTotal";
            this.colValorTotal.ReadOnly = true;
            this.colValorTotal.Width = 94;
            // 
            // colgta
            // 
            this.colgta.DataPropertyName = "GTA";
            this.colgta.HeaderText = "GTA";
            this.colgta.MinimumWidth = 6;
            this.colgta.Name = "colgta";
            this.colgta.ReadOnly = true;
            this.colgta.Width = 64;
            // 
            // colFrete
            // 
            this.colFrete.DataPropertyName = "ValorFrete";
            this.colFrete.HeaderText = "Frete";
            this.colFrete.MinimumWidth = 6;
            this.colFrete.Name = "colFrete";
            this.colFrete.ReadOnly = true;
            this.colFrete.Width = 67;
            // 
            // colNomeFornecedor
            // 
            this.colNomeFornecedor.DataPropertyName = "RazaoSocialFornecedor";
            this.colNomeFornecedor.HeaderText = "Fornecedor";
            this.colNomeFornecedor.MinimumWidth = 6;
            this.colNomeFornecedor.Name = "colNomeFornecedor";
            this.colNomeFornecedor.ReadOnly = true;
            this.colNomeFornecedor.Width = 106;
            // 
            // colCpfCnpjFornecedor
            // 
            this.colCpfCnpjFornecedor.DataPropertyName = "CpfCnpjFornecedor";
            this.colCpfCnpjFornecedor.HeaderText = "CPF/CNPJ";
            this.colCpfCnpjFornecedor.MinimumWidth = 6;
            this.colCpfCnpjFornecedor.Name = "colCpfCnpjFornecedor";
            this.colCpfCnpjFornecedor.ReadOnly = true;
            this.colCpfCnpjFornecedor.Width = 101;
            // 
            // colTelefone
            // 
            this.colTelefone.DataPropertyName = "TelefoneFornecedor";
            this.colTelefone.HeaderText = "Telefone";
            this.colTelefone.MinimumWidth = 6;
            this.colTelefone.Name = "colTelefone";
            this.colTelefone.ReadOnly = true;
            this.colTelefone.Width = 90;
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 652);
            this.Controls.Add(this.dgvConsulta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.btDeletar);
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.txtBusca);
            this.Name = "Registro";
            this.Text = "Registro";
            this.Load += new System.EventHandler(this.Registro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Button btDeletar;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colquantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colgta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeFornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCpfCnpjFornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefone;
    }
}