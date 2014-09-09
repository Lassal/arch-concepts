using System;

namespace br.com.lassal.Agenda.GtkApp
{
	public partial class Window : Gtk.Window
	{
		public Window () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

