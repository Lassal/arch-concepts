using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using br.com.lassal.Agenda.WinForms.Controls;
using br.com.lassal.Agenda.PM;
using br.com.lassal.Agenda.Entity;

namespace br.com.lassal.Agenda.WinForms
{
    public partial class AgendaForm : Form
    {
        #region Propriedades

        private ListContactsUIModel frmModel = new ListContactsUIModel();
        private Panel pnlResultadoBusca = null;

        public AgendaForm()
        {
            InitializeComponent();
            this.contactEditCtrx1.Saved += new EventHandler(SaveContactCtrl);
            this.contactEditCtrx1.CanceledEdition += new EventHandler(CancelEditionContactCtrl);
        }

        void CancelEditionContactCtrl(object sender, EventArgs e)
        {
            ContactEditCtrx ctCtrl = (ContactEditCtrx)sender;
            this.frmModel.CancelEditContact();
            ctCtrl.ReadOnly = true;
        }

        void SaveContactCtrl(object sender, EventArgs e)
        {
            ContactEditCtrx ctCtrl = (ContactEditCtrx)sender;

            if (this.frmModel.SaveContact())
            {
                ctCtrl.ReadOnly = true;
                this.ExibeTodosContatos();
            }
            else
            {
                ctCtrl.ShowErrors();
            }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.pnlLimpaBusca.Visible = false;
            this.ExibeTodosContatos();
        }

        /*
        private void PopulaTabsExemplo()
        {
            this.pnlLimpaBusca.Height = -10;

            for (char l = 'A'; l < 'Z' + 1; l++)
            {
                TabPage tp = new TabPage();
                //tp.Name = "tp_" + l;
                tp.Text = Convert.ToString(l);
                tp.AutoScroll = true;
                int lastVPos = 0;

                for (int i = 0; i < 20; i++)
                {
                    ContactItemCtrx ctrl = new ContactItemCtrx();
                    //   ctrl.Name = "thing" + i;
                    ctrl.Location = new Point(0, lastVPos);
                    lastVPos += ctrl.Size.Height;

                    tp.Controls.Add(ctrl);
                }

                tctrListaContatosGrp.TabPages.Add(tp);

            }
        }*/



        #region Form Behaviour

        private void ExibeTodosContatos()
        {
            if (this.frmModel != null && this.frmModel.TodosContatos != null)
            {
                if (this.frmModel.TodosContatos.Groups != null)
                {
                    this.tctrListaContatosGrp.TabPages.Clear();
                    foreach (ContactGroup grp in this.frmModel.TodosContatos.Groups)
                    {
                        TabPage tp = new TabPage();
                        tp.Text = grp.Name;
                        tp.AutoScroll = true;
                        int lastVPos = 0;

                        foreach (Contact ctt in grp.Contacts)
                        {
                            ContactItemCtrx ctrl = new ContactItemCtrx();
                            ctrl.Location = new Point(0, lastVPos);
                            lastVPos += ctrl.Size.Height;
                            ctrl.Contact = ctt;
                            ctrl.Click += new EventHandler(Select_ContactItem);

                            tp.Controls.Add(ctrl);
                        }

                        tctrListaContatosGrp.TabPages.Add(tp);
                    }
                    this.BindSelectedContact();
                }
            }
        }

        private ContactItemCtrx lastSelectedItem = null;

        public void Select_ContactItem(object sender, EventArgs e)
        {
            if (this.lastSelectedItem != null)
            {
                this.lastSelectedItem.BackColor = Color.White;
            }
            this.lastSelectedItem = (ContactItemCtrx)sender;
            this.lastSelectedItem.BackColor = Color.Wheat;
            this.frmModel.SelectContact(this.lastSelectedItem.Contact);
            this.BindSelectedContact();
        }

        private void BindSelectedContact()
        {
            this.contactEditCtrx1.SetModel(this.frmModel.SelectedContact);
        }

        private void ExibeResultadoBusca()
        {
            this.pnlLimpaBusca.Visible = true;

            if (this.pnlResultadoBusca == null)
            {
                this.pnlResultadoBusca = new Panel();
            }
            else
            {
                this.pnlResultadoBusca.Controls.Clear();
                this.pnlResultadoBusca.Visible = true;
            }

            pnlResultadoBusca.AutoScroll = true;
            pnlResultadoBusca.Dock = DockStyle.Fill;

            int lastVPos = 0;

            foreach (Contact ctt in this.frmModel.ResultadoBusca)
            {
                ContactItemCtrx ctrl = new ContactItemCtrx();
                ctrl.Location = new Point(0, lastVPos);
                lastVPos += ctrl.Size.Height;
                ctrl.Contact = ctt;

                pnlResultadoBusca.Controls.Add(ctrl);
            }

            this.contactListLayout.Controls.Add(pnlResultadoBusca);
            this.contactListLayout.SetRow(pnlResultadoBusca, 2);
            this.tctrListaContatosGrp.Visible = false;

            this.BindSelectedContact();
        }

        private void OcultaResultadoBusca()
        {
            this.frmModel.AtualizaListaContatos();
            this.ExibeTodosContatos();

            this.pnlResultadoBusca.Visible = false;
            this.pnlLimpaBusca.Visible = false;
            this.tctrListaContatosGrp.Visible = true;

        }

        #endregion

        #region Form Event Handlers

        /// <summary>
        /// Renderiza os labels das tabs de forma horizontal (texto) para tabs dispostas
        /// de forma vertical
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tctrListaContatosGrp_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tctrListaContatosGrp.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tctrListaContatosGrp.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            this.frmModel.NomeBusca = this.txbBuscaNome.Text;
            this.frmModel.CidadeBusca = this.txbBuscaCidade.Text;
            this.frmModel.PaisBusca = this.txbBuscaPais.Text;

            this.frmModel.BuscarContatos();

            if (!String.IsNullOrWhiteSpace(this.frmModel.ErroBusca))
            {
                MessageBox.Show(this.frmModel.ErroBusca);
            }
            else
            {
                this.ExibeResultadoBusca();
            }

        }

        private void btnLimpaBusca_Click(object sender, EventArgs e)
        {
            this.OcultaResultadoBusca();
        }

        #endregion

       

        private void toolbtnEdit_Click(object sender, EventArgs e)
        {
            this.frmModel.EditContact();
            this.contactEditCtrx1.Model = this.frmModel.CurrentEditContact;
            this.contactEditCtrx1.ReadOnly = false;
        }

        private void toolbtnNew_Click(object sender, EventArgs e)
        {
            this.frmModel.NewContact();
            this.contactEditCtrx1.Model = this.frmModel.CurrentEditContact;
            this.contactEditCtrx1.ReadOnly = false;
        }

        

    }
}
