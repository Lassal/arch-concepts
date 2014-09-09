using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.lassal.Agenda.Data
{
    public class MemoryContactDataAccess: DummyContactDataAccess, IContactDataAccess
    {
        private List<Entity.Contact> contacts = null;
        private long nextContactID = 1000;

        private long NextContactID
        {
            get
            {
                return this.nextContactID++;
            }
        }

        public MemoryContactDataAccess()
        {
            this.contacts = base.ListAllContacts();

            for (int i = 0; i < this.contacts.Count; i++)
            {
                this.contacts[i].ID = this.NextContactID;
            }
        }


        public List<Entity.Contact> FindContacts(string name, string city, string country)
        {
            List<Entity.Contact> searchResults = new List<Entity.Contact>();

            foreach (Entity.Contact contact in this.contacts)
            {
                bool searchHit = false;

                if(!String.IsNullOrWhiteSpace(name))
                {
                    if (contact.Fullname != null && contact.Fullname.ToUpper().IndexOf(name.ToUpper()) > -1)
                    {
                        searchHit = true;
                    }
                }
                if (!String.IsNullOrWhiteSpace(city))
                {
                    if (contact.City != null && contact.City.ToUpper().IndexOf(city.ToUpper()) > -1)
                    {
                        searchHit = true;
                    }
                }
                if (!String.IsNullOrWhiteSpace(country))
                {
                    if (contact.Country != null && contact.Country.ToUpper().IndexOf(country.ToUpper()) > -1)
                    {
                        searchHit = true;
                    }
                }

                if (searchHit)
                {
                    searchResults.Add(contact);
                }
            }

            return searchResults;
        }

        public List<Entity.Contact> ListAllContacts()
        {
            return this.contacts;
        }

        public Entity.Contact GetContactByID(long id)
        {
            return this.contacts.Find(c => c.ID.Equals(id));
        }

        public Entity.Contact Save(Entity.Contact contact)
        {
            if (contact != null)
            {
                if (contact.ID == null)
                {
                    contact.ID = this.NextContactID;
                    this.contacts.Add(contact);
                }
                // if the object already exists it is saved already
            }

            return contact;
        }

        public bool Delete(Entity.Contact contact)
        {
            if (contact != null && contact.ID.HasValue)
            {
                Entity.Contact remContact = this.contacts.Find(c => c.ID.Equals(contact.ID));
                return this.contacts.Remove(remContact);
            }
            else
            {
                return false;
            }
        } 
    }
}
