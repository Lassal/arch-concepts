using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using br.com.lassal.Agenda.Entity;
using br.com.lassal.Agenda.PM;

namespace Test.br.com.lassal.Agenda
{
    /// <summary>
    /// Summary description for PresentationModelTestFixture
    /// </summary>
    [TestClass]
    public class PresentationModelTestFixture
    {
        public PresentationModelTestFixture()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestCarregaTela()
        {
            ListContactsUIModel form = new ListContactsUIModel();

            Assert.IsTrue(form.TodosContatos.Groups[0].Contacts.Count > 1);

        }

        [TestMethod]
        public void TestBuscaContato()
        {
            ListContactsUIModel form = new ListContactsUIModel();

            Assert.IsTrue(form.TodosContatos.Groups[0].Contacts.Count > 1);
            Assert.IsNull(form.ResultadoBusca);

            form.NomeBusca = "Ibaré";
            form.CidadeBusca = "Coimbra";
            form.BuscarContatos();

            Assert.IsNull(form.ErroBusca);
            Assert.IsTrue(form.ResultadoBusca.Count > 1);

        }

        [TestMethod]
        public void TestSelecionaContatoLista()
        {
            ListContactsUIModel form = new ListContactsUIModel();
            Assert.IsTrue(form.TodosContatos.Groups[0].Contacts.Count > 1);

            Contact firstContact = form.TodosContatos.Groups[0].Contacts[0];
            Contact selectedContact = form.TodosContatos.Groups[1].Contacts[2];

            Assert.AreEqual(firstContact, form.SelectedContact);

            form.SelectedContact = selectedContact;
            Assert.AreEqual(selectedContact, form.SelectedContact);
        }

        [TestMethod]
        public void TestSelecionaContatoDuranteEdicao()
        {
            ListContactsUIModel form = new ListContactsUIModel();
            Assert.IsTrue(form.TodosContatos.Groups[0].Contacts.Count > 1);

            Contact firstContact = form.TodosContatos.Groups[0].Contacts[0];
            Contact selectedContact = form.TodosContatos.Groups[1].Contacts[2];

            Assert.AreEqual(firstContact, form.SelectedContact);

            // seleciona contato
            form.SelectedContact = selectedContact;
            Assert.AreEqual(selectedContact, form.SelectedContact);

            // verifica que nenhum contato esta sendo editado agora
            Assert.IsNull(form.CurrentEditContact);
            form.EditContact();
            Assert.IsNotNull(form.CurrentEditContact);

            Assert.AreEqual(selectedContact, form.CurrentEditContact.Contact);
            Assert.IsTrue(form.CurrentEditContact.IsValid);

            //seleciona outro contato
            Contact selectedContact2 = form.TodosContatos.Groups[2].Contacts[1];
            form.SelectedContact = selectedContact2;
            form.EditContact();
            Assert.AreEqual(selectedContact, form.CurrentEditContact.Contact);

            // cancela ediçao e edita formulario novamente
            form.CancelEditContact();
            form.EditContact();
            Assert.AreEqual(selectedContact2, form.CurrentEditContact.Contact);
        }

        [TestMethod]
        public void TestEditaContatoErro()
        {
            ListContactsUIModel form = new ListContactsUIModel();
            Assert.IsTrue(form.TodosContatos.Groups[0].Contacts.Count > 1);

            Contact selectedContact = form.TodosContatos.Groups[1].Contacts[2];

            // seleciona contato
            form.SelectedContact = selectedContact;
            Assert.AreEqual(selectedContact, form.SelectedContact);

            // verifica que nenhum contato esta sendo editado agora
            Assert.IsNull(form.CurrentEditContact);
            form.EditContact();
            Assert.IsNotNull(form.CurrentEditContact);

            Assert.AreEqual(selectedContact, form.CurrentEditContact.Contact);
            Assert.IsTrue(form.CurrentEditContact.IsValid);

            // Edita formulario 
            Contact cEdit = form.CurrentEditContact.Contact;
            cEdit.DateOfBirth = DateTime.Today;
            cEdit.FirstName = "João";
            cEdit.LastName = "da Silva";

            Assert.IsTrue(form.SaveContact());
            Contact changedContact = this.FindContact(form, selectedContact.ID);
            Assert.AreEqual(changedContact, cEdit);
            Assert.IsNull(form.CurrentEditContact);

            form.NewContact();
            Assert.IsNull(form.CurrentEditContact.Contact.ID);
            Assert.IsNull(form.CurrentEditContact.NameError);
            Assert.IsNull(form.CurrentEditContact.CityError);
            Assert.IsNull(form.CurrentEditContact.CountryError);
            Assert.IsFalse(form.SaveContact());
            Assert.IsNotNull(form.CurrentEditContact.NameError);
            Assert.IsNotNull(form.CurrentEditContact.CityError);
            Assert.IsNotNull(form.CurrentEditContact.CountryError);
            
        }

        [TestMethod]
        public void TestDeleteContact()
        {
            ListContactsUIModel form = new ListContactsUIModel();
            Assert.IsTrue(form.TodosContatos.Groups[0].Contacts.Count > 1);

            Contact selectedContact = form.TodosContatos.Groups[1].Contacts[2];
            long selContactID = selectedContact.ID.Value;

            // seleciona contato
            form.SelectedContact = selectedContact;
            Assert.AreEqual(selectedContact, form.SelectedContact);

            form.DeleteContact();
            Contact deletedContact = this.FindContact(form, selContactID);
            Assert.IsNull(deletedContact);

        }

        [TestMethod]
        public void TestAddNewContact()
        {
            throw new NotImplementedException("Criar data store na memoria para os objetos");
        }

        private Contact FindContact(ListContactsUIModel model, long? ID)
        {
            if (model != null && model.TodosContatos != null && model.TodosContatos.Groups != null)
            {
                foreach (ContactGroup grp in model.TodosContatos.Groups)
                {
                    if (grp.Contacts != null)
                    {
                        foreach (Contact c in grp.Contacts)
                        {
                            if (c.ID.Equals(ID))
                            {
                                return c;
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}
