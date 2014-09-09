namespace br.com.lassal.Agenda.WinForms
{
    partial class AgendaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgendaForm));
            this.bookContainer = new System.Windows.Forms.SplitContainer();
            this.contactListLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tctrListaContatosGrp = new System.Windows.Forms.TabControl();
            this.pnlLimpaBusca = new System.Windows.Forms.Panel();
            this.btnLimpaBusca = new System.Windows.Forms.Button();
            this.contactListFilterGroup = new System.Windows.Forms.GroupBox();
            this.txbBuscaPais = new System.Windows.Forms.TextBox();
            this.txbBuscaCidade = new System.Windows.Forms.TextBox();
            this.txbBuscaNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBusca = new System.Windows.Forms.Label();
            this.lblBuscaNome = new System.Windows.Forms.Label();
            this.btnBusca = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contactEditCtrx1 = new br.com.lassal.Agenda.WinForms.Controls.ContactEditCtrx();
            ((System.ComponentModel.ISupportInitialize)(this.bookContainer)).BeginInit();
            this.bookContainer.Panel1.SuspendLayout();
            this.bookContainer.Panel2.SuspendLayout();
            this.bookContainer.SuspendLayout();
            this.contactListLayout.SuspendLayout();
            this.pnlLimpaBusca.SuspendLayout();
            this.contactListFilterGroup.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bookContainer
            // 
            this.bookContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookContainer.Location = new System.Drawing.Point(0, 0);
            this.bookContainer.Name = "bookContainer";
            // 
            // bookContainer.Panel1
            // 
            this.bookContainer.Panel1.AutoScroll = true;
            this.bookContainer.Panel1.Controls.Add(this.contactListLayout);
            // 
            // bookContainer.Panel2
            // 
            this.bookContainer.Panel2.Controls.Add(this.toolStrip1);
            this.bookContainer.Panel2.Controls.Add(this.panel1);
            this.bookContainer.Size = new System.Drawing.Size(786, 529);
            this.bookContainer.SplitterDistance = 410;
            this.bookContainer.TabIndex = 0;
            // 
            // contactListLayout
            // 
            this.contactListLayout.ColumnCount = 1;
            this.contactListLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.contactListLayout.Controls.Add(this.tctrListaContatosGrp, 0, 2);
            this.contactListLayout.Controls.Add(this.pnlLimpaBusca, 0, 1);
            this.contactListLayout.Controls.Add(this.contactListFilterGroup, 0, 0);
            this.contactListLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contactListLayout.Location = new System.Drawing.Point(0, 0);
            this.contactListLayout.Name = "contactListLayout";
            this.contactListLayout.RowCount = 3;
            this.contactListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contactListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contactListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contactListLayout.Size = new System.Drawing.Size(410, 529);
            this.contactListLayout.TabIndex = 0;
            // 
            // tctrListaContatosGrp
            // 
            this.tctrListaContatosGrp.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tctrListaContatosGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tctrListaContatosGrp.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tctrListaContatosGrp.ItemSize = new System.Drawing.Size(25, 20);
            this.tctrListaContatosGrp.Location = new System.Drawing.Point(3, 141);
            this.tctrListaContatosGrp.Multiline = true;
            this.tctrListaContatosGrp.Name = "tctrListaContatosGrp";
            this.tctrListaContatosGrp.SelectedIndex = 0;
            this.tctrListaContatosGrp.Size = new System.Drawing.Size(404, 385);
            this.tctrListaContatosGrp.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tctrListaContatosGrp.TabIndex = 0;
            this.tctrListaContatosGrp.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tctrListaContatosGrp_DrawItem);
            // 
            // pnlLimpaBusca
            // 
            this.pnlLimpaBusca.Controls.Add(this.btnLimpaBusca);
            this.pnlLimpaBusca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLimpaBusca.Location = new System.Drawing.Point(3, 93);
            this.pnlLimpaBusca.Name = "pnlLimpaBusca";
            this.pnlLimpaBusca.Size = new System.Drawing.Size(404, 42);
            this.pnlLimpaBusca.TabIndex = 2;
            // 
            // btnLimpaBusca
            // 
            this.btnLimpaBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpaBusca.Location = new System.Drawing.Point(136, 6);
            this.btnLimpaBusca.Name = "btnLimpaBusca";
            this.btnLimpaBusca.Size = new System.Drawing.Size(120, 30);
            this.btnLimpaBusca.TabIndex = 0;
            this.btnLimpaBusca.Text = "Limpa Busca";
            this.btnLimpaBusca.UseVisualStyleBackColor = true;
            this.btnLimpaBusca.Click += new System.EventHandler(this.btnLimpaBusca_Click);
            // 
            // contactListFilterGroup
            // 
            this.contactListFilterGroup.Controls.Add(this.txbBuscaPais);
            this.contactListFilterGroup.Controls.Add(this.txbBuscaCidade);
            this.contactListFilterGroup.Controls.Add(this.txbBuscaNome);
            this.contactListFilterGroup.Controls.Add(this.label3);
            this.contactListFilterGroup.Controls.Add(this.lblBusca);
            this.contactListFilterGroup.Controls.Add(this.lblBuscaNome);
            this.contactListFilterGroup.Controls.Add(this.btnBusca);
            this.contactListFilterGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contactListFilterGroup.Location = new System.Drawing.Point(3, 3);
            this.contactListFilterGroup.Name = "contactListFilterGroup";
            this.contactListFilterGroup.Size = new System.Drawing.Size(404, 84);
            this.contactListFilterGroup.TabIndex = 1;
            this.contactListFilterGroup.TabStop = false;
            this.contactListFilterGroup.Text = "Buscar contato";
            // 
            // txbBuscaPais
            // 
            this.txbBuscaPais.Location = new System.Drawing.Point(231, 47);
            this.txbBuscaPais.Name = "txbBuscaPais";
            this.txbBuscaPais.Size = new System.Drawing.Size(164, 20);
            this.txbBuscaPais.TabIndex = 6;
            // 
            // txbBuscaCidade
            // 
            this.txbBuscaCidade.Location = new System.Drawing.Point(46, 48);
            this.txbBuscaCidade.Name = "txbBuscaCidade";
            this.txbBuscaCidade.Size = new System.Drawing.Size(144, 20);
            this.txbBuscaCidade.TabIndex = 5;
            // 
            // txbBuscaNome
            // 
            this.txbBuscaNome.Location = new System.Drawing.Point(46, 21);
            this.txbBuscaNome.Name = "txbBuscaNome";
            this.txbBuscaNome.Size = new System.Drawing.Size(253, 20);
            this.txbBuscaNome.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "País";
            // 
            // lblBusca
            // 
            this.lblBusca.AutoSize = true;
            this.lblBusca.Location = new System.Drawing.Point(6, 51);
            this.lblBusca.Name = "lblBusca";
            this.lblBusca.Size = new System.Drawing.Size(40, 13);
            this.lblBusca.TabIndex = 2;
            this.lblBusca.Text = "Cidade";
            // 
            // lblBuscaNome
            // 
            this.lblBuscaNome.AutoSize = true;
            this.lblBuscaNome.Location = new System.Drawing.Point(6, 24);
            this.lblBuscaNome.Name = "lblBuscaNome";
            this.lblBuscaNome.Size = new System.Drawing.Size(35, 13);
            this.lblBuscaNome.TabIndex = 1;
            this.lblBuscaNome.Text = "Nome";
            // 
            // btnBusca
            // 
            this.btnBusca.Location = new System.Drawing.Point(320, 19);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(75, 23);
            this.btnBusca.TabIndex = 0;
            this.btnBusca.Text = "Buscar";
            this.btnBusca.UseVisualStyleBackColor = true;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnNew,
            this.toolStripButton2,
            this.toolbtnEdit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(372, 29);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnNew
            // 
            this.toolbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnNew.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnNew.Image")));
            this.toolbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnNew.Name = "toolbtnNew";
            this.toolbtnNew.Size = new System.Drawing.Size(26, 26);
            this.toolbtnNew.Text = "New Contact";
            this.toolbtnNew.Click += new System.EventHandler(this.toolbtnNew_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(26, 26);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolbtnEdit
            // 
            this.toolbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnEdit.DoubleClickEnabled = true;
            this.toolbtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnEdit.Image")));
            this.toolbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnEdit.Name = "toolbtnEdit";
            this.toolbtnEdit.Size = new System.Drawing.Size(26, 26);
            this.toolbtnEdit.Text = "Editar Contato";
            this.toolbtnEdit.ToolTipText = "Editar Contato";
            this.toolbtnEdit.Click += new System.EventHandler(this.toolbtnEdit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.contactEditCtrx1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 529);
            this.panel1.TabIndex = 0;
            // 
            // contactEditCtrx1
            // 
            this.contactEditCtrx1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.contactEditCtrx1.AutoScroll = true;
            this.contactEditCtrx1.AutoSize = true;
            this.contactEditCtrx1.Location = new System.Drawing.Point(0, 30);
            this.contactEditCtrx1.Model = null;
            this.contactEditCtrx1.Name = "contactEditCtrx1";
            this.contactEditCtrx1.ReadOnly = true;
            this.contactEditCtrx1.Size = new System.Drawing.Size(372, 529);
            this.contactEditCtrx1.TabIndex = 0;
            // 
            // AgendaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 529);
            this.Controls.Add(this.bookContainer);
            this.Name = "AgendaForm";
            this.Text = "Agenda";
            this.bookContainer.Panel1.ResumeLayout(false);
            this.bookContainer.Panel2.ResumeLayout(false);
            this.bookContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookContainer)).EndInit();
            this.bookContainer.ResumeLayout(false);
            this.contactListLayout.ResumeLayout(false);
            this.pnlLimpaBusca.ResumeLayout(false);
            this.contactListFilterGroup.ResumeLayout(false);
            this.contactListFilterGroup.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer bookContainer;
        private System.Windows.Forms.TabControl tctrListaContatosGrp;
        private System.Windows.Forms.Panel pnlLimpaBusca;
        private System.Windows.Forms.Button btnLimpaBusca;
        private System.Windows.Forms.GroupBox contactListFilterGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBusca;
        private System.Windows.Forms.Label lblBuscaNome;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.TextBox txbBuscaPais;
        private System.Windows.Forms.TextBox txbBuscaCidade;
        private System.Windows.Forms.TextBox txbBuscaNome;
        private System.Windows.Forms.TableLayoutPanel contactListLayout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnNew;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolbtnEdit;
        private System.Windows.Forms.Panel panel1;
        private Controls.ContactEditCtrx contactEditCtrx1;
    }
}