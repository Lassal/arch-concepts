using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.lassal.Agenda.Entity
{
    public class ContactSet
    {
        public static ContactSet GroupByFirstLetterSurname(String title, List<Contact> contacts)
        {
            ContactSet set = new ContactSet();
            set.Title = title;
            set.organizedBy = ContactSetOrganization.Surname;

            Dictionary<Char, ContactGroup> groups = new Dictionary<char, ContactGroup>();

            if (contacts != null)
            {
                foreach (Contact ctt in contacts)
                {
                    if (!String.IsNullOrWhiteSpace(ctt.LastName))
                    {
                        if (!groups.ContainsKey(ctt.LastName[0]))
                        {
                            ContactGroup grp = new ContactGroup();
                            grp.Name = Convert.ToString(ctt.LastName[0]).ToUpper();
                            grp.Contacts = new List<Contact>();

                            groups[ctt.LastName[0]] = grp;
                        }

                        groups[ctt.LastName[0]].Contacts.Add(ctt);

                    }
                }

                set.Groups =  groups.Values.OrderBy(x => x.Name).ToList();

                foreach (ContactGroup cg in set.Groups)
                {
                    cg.Contacts = cg.Contacts.OrderBy(c => c.LastName).ToList();
                }
            }

            return set;
        }

        public static ContactSet GroupByCity(String title, List<Contact> contacts)
        {
            throw new NotImplementedException();
        }

        public static ContactSet GroupByCountry(String title, List<Contact> contacts)
        {
            throw new NotImplementedException();
        }


        private ContactSetOrganization organizedBy = ContactSetOrganization.Surname;
        public ContactSetOrganization OrganizedBy
        {
            get
            {
                return this.organizedBy;
            }
        }

        /// <summary>
        /// Title of the contact set
        /// </summary>
        public String Title { get; set; }

        public List<ContactGroup> Groups { get; set; }

        public void AddContact(Contact contact)
        {
            if (this.OrganizedBy == ContactSetOrganization.Surname)
            {
                this.AddContactSurnameSet(contact);
            }
        }

        private void AddContactSurnameSet(Contact contact)
        {
            if (this.Groups != null && this.Groups.Count > 0)
            {
                String lastNameInitial = Convert.ToString(contact.LastName[0]);
                foreach (ContactGroup cgrp in this.Groups)
                {
                    if (cgrp.Name.Equals(lastNameInitial))
                    {
                        cgrp.Contacts.Add(contact);
                        cgrp.Contacts.OrderBy(c => c.LastName).ToList();
                        return;
                    }
                }
                ContactGroup newGrp = new ContactGroup();
                newGrp.Name = lastNameInitial;
                newGrp.Contacts = new List<Contact>();
                newGrp.Contacts.Add(contact);
                this.Groups.Add(newGrp);

                this.Groups = this.Groups.OrderBy(x => x.Name).ToList();
            }
        }
    }

    public class ContactGroup
    {
        public String Name { get; set; }

        public List<Contact> Contacts { get; set; }
    }

    public enum ContactSetOrganization
    {
        Surname,
        City,
        Country
    }
}
