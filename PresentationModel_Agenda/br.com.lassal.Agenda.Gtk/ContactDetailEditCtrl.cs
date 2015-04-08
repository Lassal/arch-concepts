using System;
using Gtk;

namespace br.com.lassal.Agenda.GtkApp
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class ContactDetailEditCtrl : Gtk.Bin
	{
		public ContactDetailEditCtrl ()
		{
			this.Build ();
			Alignment halign1 = new Alignment (0, 0, 0, 0);
			Label testeLabel = new Label ("Testando ABC");
		}
	}
}

