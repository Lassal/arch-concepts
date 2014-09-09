using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using br.com.lassal.Agenda.PM;
using br.com.lassal.Agenda.Entity;

namespace br.com.lassal.Agenda.WinForms.Controls
{
    public partial class ContactEditCtrx : UserControl
    {
        ContactUIModel model = null; //new ContactUIModel(new Contact());

        public event EventHandler Saved;
        public event EventHandler CanceledEdition;

        public ContactEditCtrx()
        {
            InitializeComponent();
            this.ReadOnly = true;
            this.DataBind();
            this.btnCancelar.Click += new EventHandler(btnCancelar_Click);
            this.btnSalvar.Click += new EventHandler(btnSalvar_Click);
        }

        public void btnSalvar_Click(object sender, EventArgs e)
        {
                if (this.Saved != null)
                {
                    this.Saved(this, e);
                }
        }

        public void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.CanceledEdition != null)
            {
                this.CanceledEdition(this, e);
            }
        }

        public ContactUIModel Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
                this.DataBind();
            }
        }

        public void SetModel(Contact contact)
        {
            if (contact != null)
            {
                this.Model = new ContactUIModel(contact);
            }
        }

        private void DataBind()
        {
            if (this.model != null)
            {
                this.txtFirstName.DataBindings.Clear();
                this.txtFirstName.DataBindings.Add(new Binding("Text", this.model, "Contact.FirstName"));
                this.txtLastName.DataBindings.Clear();
                this.txtLastName.DataBindings.Add(new Binding("Text", this.model, "Contact.LastName"));
                this.txtAlias.DataBindings.Clear();
                this.txtAlias.DataBindings.Add(new Binding("Text", this.model, "Contact.Alias"));
                this.txtAddress.DataBindings.Clear();
                this.txtAddress.DataBindings.Add(new Binding("Text", this.model, "Contact.Address"));
                this.txtCity.DataBindings.Clear();
                this.txtCity.DataBindings.Add(new Binding("Text", this.model, "Contact.City"));
                this.txtState.DataBindings.Clear();
                this.txtState.DataBindings.Add(new Binding("Text", this.model, "Contact.State"));
                this.txtCountry.DataBindings.Clear();
                this.txtCountry.DataBindings.Add(new Binding("Text", this.model, "Contact.Country"));
                this.dtxtDOB.DataBindings.Clear();
                this.dtxtDOB.DataBindings.Add(new Binding("Text", this.model, "Contact.DateOfBirth"));
                this.txtMobilePhone.DataBindings.Clear();
                this.txtMobilePhone.DataBindings.Add(new Binding("Text", this.model, "Contact.MobilePhone"));
                this.txtHomePhone.DataBindings.Clear();
                this.txtHomePhone.DataBindings.Add(new Binding("Text", this.model, "Contact.HomePhone"));
               // this.dgvEmails.DataBindings.Clear();
               // this.dgvEmails.DataBindings.Add(new Binding("Email", this.model, "Contact.Emails")); 
            }
        }

        private bool readOnly = false;
        public bool ReadOnly
        {
            get
            {
                return this.readOnly;
            }
            set
            {
                this.readOnly = value;

                if (this.readOnly)
                {
                    this.SetToReadOnly();
                }
                else
                {
                    this.SetToEditMode();
                }
            }
        }

        private void SetToEditMode()
        {
            this.hintAlias.Visible = true;
            this.btnCancelar.Visible = true;
            this.btnSalvar.Visible = true;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox txb = (TextBox)ctrl;
                    txb.ReadOnly = false;
                    txb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    txb.BackColor = SystemColors.Window;
                }
            }
        }

        private void SetToReadOnly()
        {
            this.hintAlias.Visible = false;
            this.btnCancelar.Visible = false;
            this.btnSalvar.Visible = false;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox txb = (TextBox)ctrl;
                    txb.ReadOnly = true;
                    txb.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    txb.BackColor = Color.FromArgb(248,248,248);
                }
            }
        }

        private void dgvEmails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                DataGridViewRow row = this.dgvEmails.Rows[e.ColumnIndex];
                if (!row.IsNewRow)
                {
                    this.dgvEmails.Rows.Remove(row);
                    this.dgvEmails.Rows.Insert(0, row);
                }
            }
        }

        private void dgvEmails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            this.dgvEmails.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        public void ShowErrors()
        {
            if (!this.Model.IsValid)
            {
                this.contactEditErrorCtrl.Clear();
                if (this.Model.NameError != null)
                {
                    if (String.IsNullOrWhiteSpace(this.txtFirstName.Text))
                    {
                        this.contactEditErrorCtrl.SetError(this.txtFirstName, this.Model.NameError);
                    }
                    if (String.IsNullOrWhiteSpace(this.txtLastName.Text))
                    {
                        this.contactEditErrorCtrl.SetError(this.txtLastName, this.Model.NameError);
                    }
                }
                if (this.Model.CityError != null)
                {
                    this.contactEditErrorCtrl.SetError(this.txtCity, this.Model.CityError);
                }
                if (this.Model.CountryError != null)
                {
                    this.contactEditErrorCtrl.SetError(this.txtCountry, this.Model.CountryError);
                }
            }
        }
    }
}
