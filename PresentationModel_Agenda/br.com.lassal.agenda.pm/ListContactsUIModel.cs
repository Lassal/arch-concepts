using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using br.com.lassal.Agenda.Entity;
using br.com.lassal.Agenda.Business;

namespace br.com.lassal.Agenda.PM
{

    public class ListContactsUIModel : INotifyPropertyChanged
    {
        public ListContactsUIModel()
        {
            this.AtualizaListaContatos();
        }

        #region Search Panel Properties
        private ContactSet todosContatos = null;
        public ContactSet TodosContatos
        {
            get
            {
                return this.todosContatos;
            }
        }

        private List<Contact> resultadoBusca = null;
        public List<Contact> ResultadoBusca
        {
            get
            {
                return this.resultadoBusca;
            }
        }

        public String NomeBusca { get; set; }
        public String CidadeBusca { get; set; }
        public String PaisBusca { get; set; }

        public bool TemBusca
        {
            get
            {
                return this.resultadoBusca != null;
            }
        }

        private String erroBusca = null;
        public String ErroBusca
        {
            get
            {
                return this.erroBusca;
            }
        }

        private Contact selectedContact = null;
        public Contact SelectedContact
        {
            get
            {
                return this.selectedContact;
            }
            set
            {
                if (this.selectedContact == null || !this.selectedContact.Equals(value))
                {
                    this.selectedContact = value;
                    OnPropertyChanged("SelectedContact");
                }
            }
        }

        #endregion

        #region Search Panel Methods
        public void BuscarContatos()
        {
            if (String.IsNullOrWhiteSpace(this.NomeBusca) && String.IsNullOrWhiteSpace(this.CidadeBusca) && String.IsNullOrWhiteSpace(this.PaisBusca))
            {
                this.erroBusca = Resources.AgendaResources.ContactList_Search_SearchErrorMSG;
            }
            else
            {
                this.resultadoBusca = ContactBusiness.FindContacts(this.NomeBusca, this.CidadeBusca, this.PaisBusca);
                this.erroBusca = null;
                if (this.resultadoBusca != null && this.resultadoBusca.Count > 0)
                {
                    this.SelectedContact = this.resultadoBusca[0];
                }
                else
                {
                    this.SelectedContact = null;
                }
            }
        }

        public void LimparBusca()
        {
            this.resultadoBusca = null;
            this.erroBusca = null;
        }

        public void AtualizaListaContatos()
        {
            this.todosContatos = ContactBusiness.ListAllContactsGroupBySurname();
            if (this.todosContatos != null && this.todosContatos.Groups != null && this.todosContatos.Groups.Count > 0 &&
               this.todosContatos.Groups[0].Contacts != null && this.todosContatos.Groups[0].Contacts.Count > 0)
            {
                this.SelectedContact = this.todosContatos.Groups[0].Contacts[0];
            }
        }

        //public void SelectContact(Contact contact)
        //{
        //    if (this.selectedContact == null || !this.selectedContact.Equals(contact))
        //    {
        //        this.selectedContact = contact;
        //    }
        //}

        #endregion

        #region Crud Contact Properties

        private ContactUIModel currentEditContact = null;
        public ContactUIModel CurrentEditContact
        {
            get
            {
                return this.currentEditContact;
            }
        }

        #endregion

        #region CRUD Contact Methods
        private bool CurrentEditContactIsNew = false;

        public void NewContact()
        {
            this.currentEditContact = new ContactUIModel(new Contact());
            this.CurrentEditContactIsNew = true;
        }

        public void EditContact()
        {
            if (this.currentEditContact == null)
            {
                this.currentEditContact = new ContactUIModel(this.SelectedContact);
            }
        }

        public void CancelEditContact()
        {
            this.currentEditContact = null;
            this.CurrentEditContactIsNew = false;
        }

        public bool SaveContact()
        {
            if (this.currentEditContact.Save())
            {
                if (this.CurrentEditContactIsNew)
                {
                    this.TodosContatos.AddContact(this.CurrentEditContact.Contact);
                }
                this.CancelEditContact();
                return true;
            }
            return false;
        }

        public bool DeleteContact()
        {
            if (this.SelectedContact != null)
            {
                return ContactBusiness.Delete(this.SelectedContact);
            }

            return false;
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
