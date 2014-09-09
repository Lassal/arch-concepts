using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using br.com.lassal.Agenda.Entity;

namespace br.com.lassal.Agenda.WinForms.Controls
{
    public partial class ContactItemCtrx : UserControl
    {
        private Contact contact;

        public Contact Contact
        {
            get
            {
                return this.contact;
            }
            set
            {
                this.contact = value;
                this.RenderValues(value);
            }
        }

        public ContactItemCtrx()
        {
            InitializeComponent();
            this.BindChildClickToParent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            e.Graphics.DrawLine(pen, 0, this.Size.Height -1, this.Size.Width, this.Size.Height-1);
        }

        private void RenderValues(Contact contact)
        {
            if(contact != null)
            {
                this.lblLastname.Text = contact.LastName;
                this.lblFullname.Text = contact.Fullname;
                this.lblMobile.Text = contact.MobilePhone;
                this.lblWorkPhone.Text = contact.WorkPhone;
                String location = contact.City;
                if(String.IsNullOrWhiteSpace(location))
                {
                    location = contact.Country;
                }
                else if(!String.IsNullOrWhiteSpace(contact.Country))
                {
                    location += ", " + contact.Country;
                }
                this.lblLocation.Text = location;
            }
        }

        private void BindChildClickToParent()
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Click += new EventHandler(DelegateChildClick);
            }
        }

        private void DelegateChildClick(object sender, EventArgs e)
        {
            this.OnClick(e);
        }


        /*
         * Surname
Full name
Mobile
Work phone
Email
City, Country
         */
    }
}
