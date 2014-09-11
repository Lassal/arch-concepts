using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using br.com.lassal.Agenda.PM;
using br.com.lassal.Agenda.Entity;

namespace br.com.lassal.Agenda.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListContactsUIModel frmModel = new ListContactsUIModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this.ViewModel;
           // this.TabSetContacts.DataContext = this.frmModel.TodosContatos;

        }

        public ListContactsUIModel ViewModel
        {
            get
            {
                return this.frmModel;
            }
        }

        private DataTemplate editContactTemplate = null;
        private DataTemplate viewContactTemplate = null;
        private bool editContactMode = false;
        private bool EditContactMode
        {
            get
            {
                return this.editContactMode;
            }
            set
            {
                if (value)
                {
                    if (this.editContactTemplate == null)
                    {
                        this.editContactTemplate = this.Resources["ContactDetailEdit"] as DataTemplate;
                    }
                    this.ContactDetails.ContentTemplate = this.editContactTemplate;
                }
                else
                {
                    if (this.viewContactTemplate == null)
                    {
                        this.viewContactTemplate = this.Resources["ContactDetailView"] as DataTemplate;
                    }
                    this.ContactDetails.ContentTemplate = this.viewContactTemplate;
                }

                this.editContactMode = value;
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is ListBox)
            {
                Contact selectedContact = (Contact)((ListBox)e.Source).SelectedItem;
                this.frmModel.SelectedContact = selectedContact;
            }
        }

        private void EditContact_CMD(object sender, RoutedEventArgs e)
        {
            this.frmModel.EditContact();
            this.EditContactMode = true;
        }

        private void DeleteContact_CMD(object sender, RoutedEventArgs e)
        {

        }

        private void NewContact_CMD(object sender, RoutedEventArgs e)
        {
            this.frmModel.NewContact();
            this.EditContactMode = true;
        }

        private void CancelEditionContact_CMD(object sender, RoutedEventArgs e)
        {
            this.frmModel.CancelEditContact();
            this.EditContactMode = false;

        }

        private void SaveContact_CMD(object sender, RoutedEventArgs e)
        {
            if (this.frmModel.SaveContact())
            {
                this.EditContactMode = false;
            }
            else
            {
                // show errors
            }
        }
    }
}
