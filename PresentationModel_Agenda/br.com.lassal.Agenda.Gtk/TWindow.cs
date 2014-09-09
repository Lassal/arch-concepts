using System;
using System.Text;
using Gtk;

using br.com.lassal.Agenda.PM;
using br.com.lassal.Agenda.Entity;

namespace br.com.lassal.Agenda.GtkApp
{
	public partial class TWindow : Gtk.Window
	{
		private ListContactsUIModel frmModel = new ListContactsUIModel();

		public TWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.DeleteEvent += OnDeleteEvent;

			this.ListaContatos();
		}


		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}

		private void ListaContatos()
		{
			StringBuilder clist = new StringBuilder ();

			foreach (ContactGroup grp in this.frmModel.TodosContatos.Groups) {
				clist.AppendFormat ("[{0}] - {1} Contatos\n",grp.Name, grp.Contacts.Count);
				clist.AppendLine ("================================================");

				foreach (Contact ctt in grp.Contacts) {
					clist.AppendFormat ("{0} - {1}, {2}\n", ctt.Fullname, ctt.City, ctt.Country);
				}
				clist.AppendLine ("  ");
			}

			this.textview1.Buffer.Text = clist.ToString ();
		}

	}
}

