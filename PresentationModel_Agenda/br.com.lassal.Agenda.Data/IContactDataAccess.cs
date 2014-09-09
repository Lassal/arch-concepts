using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using br.com.lassal.Agenda.Entity;

namespace br.com.lassal.Agenda.Data
{
    public interface IContactDataAccess
    {
        List<Contact> FindContacts(String name, String city, String country);

        List<Contact> ListAllContacts();

        Contact GetContactByID(long id);

        Contact Save(Contact contact);

        bool Delete(Contact contact);
    }
}
