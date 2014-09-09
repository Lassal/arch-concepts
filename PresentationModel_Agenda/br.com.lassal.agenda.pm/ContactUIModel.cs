using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using br.com.lassal.Agenda.Entity;
using br.com.lassal.Agenda.Business;

namespace br.com.lassal.Agenda.PM
{
    public class ContactUIModel
    {
        private bool? isValid = null;

        public ContactUIModel(Contact contact)
        {
            this.contact = contact;
        }

        private Contact contact = null;
        public Contact Contact
        {
            get
            {
                return this.contact;
            }
        }

        public bool Save()
        {
            if (this.Validate())
            {
                this.contact = ContactBusiness.Save(this.contact);
                return true;
            }
            return false;
        }

        public bool Validate()
        {
            this.ResetValidation();

            bool isvalid = true;

            if (String.IsNullOrWhiteSpace(this.Contact.FirstName)
               && String.IsNullOrWhiteSpace(this.Contact.LastName)
               && String.IsNullOrWhiteSpace(this.Contact.Alias))
            {
                isvalid = false;
                this.nameError = Resources.AgendaResources.ContactEdit_Edit_NameErrorMSG;
            }

            if (String.IsNullOrWhiteSpace(this.Contact.City))
            {
                isvalid = false;
                this.cityError = Resources.AgendaResources.ContactEdit_Edit_CityErrorMSG;
            }

            if (String.IsNullOrWhiteSpace(this.Contact.Country))
            {
                isvalid = false;
                this.countryError = Resources.AgendaResources.ContactEdit_Edit_CountryErrorMSG;
            }

            this.isValid = isvalid;
            return isvalid; 
        }

        private void ResetValidation()
        {
            this.isValid = null;
            this.nameError = null;
            this.cityError = null;
            this.countryError = null;
        }

        private String nameError = null;
        public String NameError
        {
            get
            {
                return this.nameError;
            }
        }

        public String cityError = null;
        public String CityError
        {
            get
            {
                return this.cityError;
            }
        }

        public String countryError = null;
        public String CountryError
        {
            get
            {
                return this.countryError;
            }
        }

        public bool IsValid
        {
            get
            {
                return (this.isValid == null) || this.isValid.Value;
            }
        }

    }
}
