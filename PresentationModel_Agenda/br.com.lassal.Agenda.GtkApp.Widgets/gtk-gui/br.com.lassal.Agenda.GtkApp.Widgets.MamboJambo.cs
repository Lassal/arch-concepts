
// This file has been generated by the GUI designer. Do not modify.
namespace br.com.lassal.Agenda.GtkApp.Widgets
{
	public partial class MamboJambo
	{
		private global::Gtk.VBox vbox8;
		
		private global::Gtk.Button button3;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget br.com.lassal.Agenda.GtkApp.Widgets.MamboJambo
			global::Stetic.BinContainer.Attach (this);
			this.Name = "br.com.lassal.Agenda.GtkApp.Widgets.MamboJambo";
			// Container child br.com.lassal.Agenda.GtkApp.Widgets.MamboJambo.Gtk.Container+ContainerChild
			this.vbox8 = new global::Gtk.VBox ();
			this.vbox8.Name = "vbox8";
			this.vbox8.Spacing = 6;
			// Container child vbox8.Gtk.Box+BoxChild
			this.button3 = new global::Gtk.Button ();
			this.button3.CanFocus = true;
			this.button3.Name = "button3";
			this.button3.UseUnderline = true;
			this.button3.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.vbox8.Add (this.button3);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox8 [this.button3]));
			w1.Position = 1;
			w1.Expand = false;
			w1.Fill = false;
			this.Add (this.vbox8);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
