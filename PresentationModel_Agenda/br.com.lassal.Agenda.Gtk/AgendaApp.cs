using System;
using Gtk;

namespace br.com.lassal.Agenda.GtkApp
{
	public class AgendaApp
	{
		public static void Main()
		{
			Application.Init();

			AgendaWindow mainWindow = new AgendaWindow ();
			mainWindow.DeleteEvent += OnCloseWindow;	 
			mainWindow.Show();

			Application.Run();
		}

		protected static void OnCloseWindow (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
	}
}

