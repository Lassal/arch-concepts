using System;

namespace br.com.lassal.Agenda.GtkApp
{
	public partial class AgendaWindow : Gtk.Window
	{
		public AgendaWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			//this.vbox4.Add (new ContactDetailEditCtrl ());
		}
	}
}

