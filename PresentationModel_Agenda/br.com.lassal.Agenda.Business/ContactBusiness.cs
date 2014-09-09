using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using br.com.lassal.Agenda.Entity;
using br.com.lassal.Agenda.Data;

namespace br.com.lassal.Agenda.Business
{
    public class ContactBusiness
    {
        private static IContactDataAccess dao = new MemoryContactDataAccess();
            //DummyContactDataAccess();

        public Contact GetContactByID(long id)
        {
            return dao.GetContactByID(id);
        }

        public static List<Contact> FindContacts(String name, String city, String country)
        {
            return dao.FindContacts(name, city, country);
        }

        public static List<Contact> ListAllContacts()
        {
            return dao.ListAllContacts();
        }

        public static ContactSet ListAllContactsGroupBySurname()
        {
            return ContactSet.GroupByFirstLetterSurname("Contact List Group by Surname first letter", dao.ListAllContacts());
        }

        public static Contact Save(Contact contact)
        {
            return dao.Save(contact);
        }

        public static bool Delete(Contact contact)
        {
            return dao.Delete(contact);
        }
    }
}
