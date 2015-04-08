using System;

namespace br.com.lassal.Agenda.GtkApp.Widgets
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class EntryErrorValidation : Gtk.Bin
	{
		public EntryErrorValidation ()
		{
			this.Build ();
			Gtk.Style ss = new Gtk.Style ();

		}

		private Gdk.Color ErrorBckColor = new Gdk.Color (255, 229, 229);

		public String Text
		{
			get
			{
				return this.TextEntry.Text;
			}
			set 
			{
				this.TextEntry.Text = value;
			}
		}

		public String Error
		{
			get 
			{
				return this.ErrorImage.TooltipText;
			}
			set 
			{
				this.ErrorImage.TooltipText = value;
				if (String.IsNullOrWhiteSpace (value)) {
					this.ErrorImage.Hide ();
					this.TextEntry.ModifyBase (Gtk.StateType.Normal);
				} 
				else 
				{
					this.ErrorImage.Show();
					this.TextEntry.ModifyBase(Gtk.StateType.Normal, this.ErrorBckColor);
				}
			}

		}

	}
}

