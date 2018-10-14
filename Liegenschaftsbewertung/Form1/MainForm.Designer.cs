/*
 * Created by SharpDevelop.
 * User: Marc Jr. Landolt
 * Date: 01.10.2006
 * Time: 19::25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Form1
{
	partial class MainForm : System.Windows.Forms.Form
	{
		
		private int count=0;
		Visitenkarte.About ab;
		
		
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
			if (ab!=null) ab.Close();
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Text = "Liegenschaftsbewertung";
			this.Name = "Liegenschaftsbewertung";
			this.Height = 600;
			this.Width = 800;
			
			Hauptmenu = new System.Windows.Forms.MainMenu();
			
			Datei = new System.Windows.Forms.MenuItem();
			Datei.Text="Datei";

			Neu = new System.Windows.Forms.MenuItem();
			Neu.Text="Neu";
			Datei.MenuItems.Add(Neu);

			Öffnen = new System.Windows.Forms.MenuItem();
			Öffnen.Text="Öffnen";
			Datei.MenuItems.Add(Öffnen);

			Speichern = new System.Windows.Forms.MenuItem();
			Speichern.Text="Speichern";
			Datei.MenuItems.Add(Speichern);
			
			
			Schliessen = new System.Windows.Forms.MenuItem();
			Schliessen.Text = "Schliessen";
			Datei.MenuItems.Add(Schliessen);
			
			Drucken = new System.Windows.Forms.MenuItem();
			Drucken.Text = "Drucken";
			Drucken.Click += new System.EventHandler(this.Drucken_Click);
			Datei.MenuItems.Add(Drucken);
	
			Beenden = new System.Windows.Forms.MenuItem();
			Beenden.Text = "Beenden";
			Beenden.Click += new System.EventHandler(this.Beenden_Click);
			Datei.MenuItems.Add(Beenden);
			
			Hauptmenu.MenuItems.Add(Datei);
			
			Bearbeiten = new System.Windows.Forms.MenuItem();
			Bearbeiten.Text="Bearbeiten";
			
			Rückgängig = new System.Windows.Forms.MenuItem();
			Rückgängig.Text="Rückgängig";
			Bearbeiten.MenuItems.Add(Rückgängig);
			
			Ausschneiden = new System.Windows.Forms.MenuItem();
			Ausschneiden.Text="Ausschneiden";
			Bearbeiten.MenuItems.Add(Ausschneiden);
			
			Kopieren = new System.Windows.Forms.MenuItem();
			Kopieren.Text="Kopieren";
			Bearbeiten.MenuItems.Add(Kopieren);
			
			Einfügen = new System.Windows.Forms.MenuItem();
			Einfügen.Text="Einfügen";
			Bearbeiten.MenuItems.Add(Einfügen);
			
			Hauptmenu.MenuItems.Add(Bearbeiten);
			
			Hilfe = new System.Windows.Forms.MenuItem();
			Hilfe.Text="Hilfe";
			
			Referenz  = new System.Windows.Forms.MenuItem();
			Referenz.Text="Referenz";
			Hilfe.MenuItems.Add(Referenz);
				
			Über = new System.Windows.Forms.MenuItem();
			Über.Text="Über";
			Über.Click += new System.EventHandler(this.Über_Click);
			Hilfe.MenuItems.Add(Über);
			
			Hauptmenu.MenuItems.Add(Hilfe);
			this.Menu = Hauptmenu;
			
			
			Register = new System.Windows.Forms.TabControl();
			Register.Width=this.Width-100;
			Register.Height=this.Height-100;
			Register.Top=30;
			Register.Left=this.Width-Register.Width-50;
			Register.Multiline=true;
			Register.SizeMode=System.Windows.Forms.TabSizeMode.FillToRight;
			
			RegisterKarte1 = new System.Windows.Forms.TabPage();
			RegisterKarte1.Text = "Liegenschafts- und Auftragsdaten";
			RegisterKarte2 = new System.Windows.Forms.TabPage();
			RegisterKarte2.Text = "Liegenschaftsbeschrieb";
			RegisterKarte3 = new System.Windows.Forms.TabPage();
			RegisterKarte3.Text = "Spezifikation der Bauteile";
			RegisterKarte4 = new System.Windows.Forms.TabPage();
			RegisterKarte4.Text = "Bauneuwertberechnung";
			RegisterKarte5 = new System.Windows.Forms.TabPage();
			RegisterKarte5.Text = "Bauzeitwerberechnung";
			RegisterKarte6 = new System.Windows.Forms.TabPage();
			RegisterKarte6.Text = "Eigentumsanteilberechnung";
			RegisterKarte7 = new System.Windows.Forms.TabPage();
			RegisterKarte7.Text = "Landwertberechnung";
			RegisterKarte8 = new System.Windows.Forms.TabPage();
			RegisterKarte8.Text = "Ertragswertberechnung";
			RegisterKarte9 = new System.Windows.Forms.TabPage();
			RegisterKarte9.Text = "Real & Verkehrswertberechnung";
			RegisterKarte10 = new System.Windows.Forms.TabPage();
			RegisterKarte10.Text = "Schlussbemerkungen";
			
			
			
			InitRegister.InitRegister1(RegisterKarte1);
			
			
			
			Register.Controls.Add(this.RegisterKarte1);
			Register.Controls.Add(this.RegisterKarte2);
			Register.Controls.Add(this.RegisterKarte3);
			Register.Controls.Add(this.RegisterKarte4);
			Register.Controls.Add(this.RegisterKarte5);
			Register.Controls.Add(this.RegisterKarte6);
			Register.Controls.Add(this.RegisterKarte7);
			Register.Controls.Add(this.RegisterKarte8);
			Register.Controls.Add(this.RegisterKarte9);
			Register.Controls.Add(this.RegisterKarte10);
			
			this.Controls.Add(Register);
				
			
			
			
			//-------------------------------------------------------------------------------
			//TabControl
			
			
		}
		
		private System.Windows.Forms.MainMenu Hauptmenu;
			private System.Windows.Forms.MenuItem Datei;
				private System.Windows.Forms.MenuItem Neu;
				private System.Windows.Forms.MenuItem Öffnen;
				private System.Windows.Forms.MenuItem Speichern;
				private System.Windows.Forms.MenuItem Schliessen;
				private System.Windows.Forms.MenuItem Drucken;
				private System.Windows.Forms.MenuItem Beenden;
			
			private System.Windows.Forms.MenuItem Bearbeiten;
				private System.Windows.Forms.MenuItem Rückgängig;
				private System.Windows.Forms.MenuItem Ausschneiden;
				private System.Windows.Forms.MenuItem Kopieren;
				private System.Windows.Forms.MenuItem Einfügen;
				
			private System.Windows.Forms.MenuItem Hilfe;
				private System.Windows.Forms.MenuItem Referenz;
				private System.Windows.Forms.MenuItem Über;
		
				
		private System.Windows.Forms.TabControl Register;
		private System.Windows.Forms.TabPage RegisterKarte1;
		private System.Windows.Forms.TabPage RegisterKarte2;
		private System.Windows.Forms.TabPage RegisterKarte3;
		private System.Windows.Forms.TabPage RegisterKarte4;
		private System.Windows.Forms.TabPage RegisterKarte5;
		private System.Windows.Forms.TabPage RegisterKarte6;
		private System.Windows.Forms.TabPage RegisterKarte7;
		private System.Windows.Forms.TabPage RegisterKarte8;
		private System.Windows.Forms.TabPage RegisterKarte9;
		private System.Windows.Forms.TabPage RegisterKarte10;
		
		
		private void Beenden_Click(System.Object sender, System.EventArgs e)
		{
			// ALT-F4 abfangen
			if((int)System.Windows.Forms.MessageBox.Show("Wollen Sie wirklich Beenden?", "Beenden", System.Windows.Forms.MessageBoxButtons.YesNoCancel)==(int)System.Windows.Forms.DialogResult.Yes) 
			{
				this.Close();
				if (ab!=null) ab.Close();
			}
		}
		
		private void Drucken_Click(System.Object sender, System.EventArgs e)
		{
			//this.print()
		}
		
		private void Über_Click(System.Object sender, System.EventArgs e)
		{
			if (count==5)
			{
				ab = new Visitenkarte.About();
				ab.Show();
			}
			else System.Windows.Forms.MessageBox.Show("Liegenschaftsbewertung \n Marc Landolt\n Rombachtäli13 \n 5022 Rombach \n 079 291 07 87", "Über", System.Windows.Forms.MessageBoxButtons.OK);
			count+=1;
			
			
		}
	}
}
