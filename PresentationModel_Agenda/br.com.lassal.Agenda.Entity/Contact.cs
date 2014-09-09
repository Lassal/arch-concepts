using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.lassal.Agenda.Entity
{
    public class Contact
    {
        public long? ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Alias { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
        public DateTime? DateOfBirth {get; set;}
        public String HomePhone { get; set; }
        public String WorkPhone { get; set; }
        public String MobilePhone { get; set; }
        public List<String> Emails { get; set; }

        /// <summary>
        /// Considers that the default e-mail will always be the first one
        /// Some logic must be used in the application to ensure it
        /// </summary>
        public String DefaultEmail
        {
            get
            {
                if (this.Emails != null && this.Emails.Count > 0)
                {
                    return this.Emails[0];
                }
                return null;

            }
        }

        public String Fullname
        {
            get
            {
                String fn = String.Format("{0} {1}", this.FirstName, this.LastName);

                return fn.Trim();
            }
        }

        public String Name
        {
            get
            {
                return String.IsNullOrWhiteSpace(this.Alias) ? this.FirstName : this.Alias;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Contact other = (Contact)obj;

                return this.ID.Equals(other.ID) && !String.IsNullOrWhiteSpace(this.LastName) && this.LastName.Equals(other.LastName)
                       && !String.IsNullOrWhiteSpace(this.FirstName) && this.FirstName.Equals(other.FirstName);
            }

            return false;
        }

    }
}
