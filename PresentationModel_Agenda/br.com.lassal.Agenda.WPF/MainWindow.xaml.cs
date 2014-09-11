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

        public String SimpleTeste
        {
            get
            {
                return "Bdafa dfa";
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
    }
}
