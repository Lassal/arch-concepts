using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.lassal.Agenda.Data
{
    public class DummyContactDataAccess: IContactDataAccess
    {
        public List<Entity.Contact> FindContacts(string name, string city, string country)
        {
            List<Entity.Contact> contacts = new List<Entity.Contact>();

            for (int i = 0; i < 15; i++)
            {
                Entity.Contact ctt = this.CreateContact(name, i);
                contacts.Add(ctt);
            }

            return contacts;
        }

        public List<Entity.Contact> ListAllContacts()
        {
            List<Entity.Contact> contacts = new List<Entity.Contact>();

            for (int i = 0; i < 100; i++)
            {
                char initial = 'A';
                initial += Convert.ToChar(i % 18);
                string lastname = Convert.ToString(initial + "laflaglu");

                Entity.Contact ctt = this.CreateContact(lastname, i);
                contacts.Add(ctt);
            }

            return contacts;
        }

        public Entity.Contact GetContactByID(long id)
        {
            return this.CreateContact(id);
        }

        protected Entity.Contact CreateContact(long id)
        {
            return this.CreateContact("DummyDumi" + id, id);
        }

        protected Entity.Contact CreateContact(String lastname, long id)
        {
            Entity.Contact ctt = new Entity.Contact();

            int cTemplate = (int) id % 4;

            if (cTemplate == 0)
            {
                ctt.ID = id;
                ctt.FirstName = "Maria Alberta";
                ctt.LastName = lastname;
                ctt.Alias = "MaryLoca";
                ctt.City = "Vitória";
                ctt.State = "ES";
                ctt.Country = "Brasil";
                ctt.Address = "Rua Alfa Beta, 339";
                ctt.Emails = new List<string>();
                ctt.Emails.Add("malberta@goves.com.br");
                ctt.MobilePhone = "+55 ?? 78995444";
                ctt.WorkPhone = "+55 ?? 4545-4455";
                ctt.HomePhone = "3030 6622";
            }
            else if (cTemplate == 1)
            {
                ctt.ID = id;
                ctt.FirstName = "Marcus Guzmão Gutierrez";
                ctt.LastName = lastname;
                ctt.Alias = "Magu";
                ctt.City = "Rio de Janeiro";
                ctt.State = "RJ";
                ctt.Country = "Brasil";
                ctt.Address = "Rua Macaco Prego, 601";
                ctt.Emails = new List<string>();
                ctt.Emails.Add("magugu99@somesite.com");
                ctt.MobilePhone = "+55 21 9812 9990";
                ctt.WorkPhone = "+55 21 40516666";
                ctt.HomePhone = "+55 21 42215553";
            }
            else if (cTemplate == 2)
            {
                ctt.ID = id;
                ctt.FirstName = "João Augusto";
                ctt.LastName = lastname;
                ctt.City = "Tobias Barreto";
                ctt.State = "SE";
                ctt.Country = "Brasil";
                ctt.Address = "Rua Albano Franco, 56";
                ctt.Emails = new List<string>();
                ctt.Emails.Add("ocs@blabla.com.br");
                ctt.MobilePhone = "+55 79 78902344";
                ctt.WorkPhone = "+55 79 5041-6633";
                ctt.HomePhone = "79 50410234";
            }
            else
            {
                ctt.ID = id;
                ctt.FirstName = "Raimundo Severino";
                ctt.LastName = lastname;
                ctt.Alias = "Lindinho";
                ctt.City = "Belo Horizonte";
                ctt.State = "MG";
                ctt.Country = "Brasil";
                ctt.Address = "Rua da Goma, 954";
                ctt.Emails = new List<string>();
                ctt.Emails.Add("raisev@pdq.com.br");
                ctt.MobilePhone = "+55 31 99544564";
                ctt.WorkPhone = "+55 31 4545-4455";
                ctt.HomePhone = "2212 5241";
            }

            return ctt;
        }


        public Entity.Contact Save(Entity.Contact contact)
        {
            return contact;
        }

        public bool Delete(Entity.Contact contact)
        {
            return true;
        }
    }
}
