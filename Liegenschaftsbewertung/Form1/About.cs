/*
 * Created by SharpDevelop.
 * User: Marc Jr. Landolt
 * Date: 06.09.2006
 * Time: 16::55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Visitenkarte
{
	 class About : System.Windows.Forms.Form
	{
	 	
	 	
	 	
	 	//[STAThread]
		public static void AboutBox()
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
			System.Windows.Forms.Application.Run(new About());
		}
		
		public About()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
	 	
	 	
	 	
	 	
	 	
	 	
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
		}
		
		protected void animate()
		{
			while(!this.Created)
			{
				System.Threading.Thread.Sleep(100);
			}
			while(this.Created)
			{
				this.Invalidate();
				System.Threading.Thread.Sleep(20);
			}
				
		}
		
		protected void explorerThread()
		{
			System.Diagnostics.ProcessStartInfo proc = new System.Diagnostics.ProcessStartInfo("http://www.yetnet.ch/marc.landolt");
			System.Diagnostics.Process.Start(proc);
		}
		
		protected static double i=1;
		protected static double x=0;
		protected static double j=0;
		protected static double y=0;
		protected static double cursor=0;
		
		protected static System.Random rnd = new System.Random();
		
		protected void counters()
		{
			while(!this.Created) {System.Threading.Thread.Sleep(100);}
			while(this.Created)
			{
				i = 50*System.Math.Sin(0.1*x);
				j = 50*System.Math.Sin(0.14*y);
				x+=0.3;
				y+=0.1;
				cursor+=(double)(rnd.Next(1,10))/10;
				System.Threading.Thread.Sleep(20);
				faderX=(int)(150*System.Math.Cos(0.1*x))+150;
			}
		}
		
		//protected static System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
		
					
		
		protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			if ((int)e.KeyChar==(int)System.Windows.Forms.Keys.Escape) this.Hide();
			
		}
		
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			System.Drawing.Graphics g = e.Graphics;
			drawBuffer(g);
		}
		
		protected override void OnClick(System.EventArgs e)
		{
			base.OnClick(e);
			System.Threading.Thread et = new System.Threading.Thread(explorerThread);
			et.Start();

		}
				
		protected static double[] center = {70,70};
		
		protected static double[][] dmy=Matrix.yDrehen(0.03);
		protected static double[][] dmz=Matrix.zDrehen(0.02);
		protected static double[][] dmx=Matrix.xDrehen(0.025);

		protected static System.Drawing.Pen blue = new System.Drawing.Pen(System.Drawing.Color.Blue);
		protected static System.Drawing.Brush bluebrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
		protected static System.Drawing.Brush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(200,200,0,0));
		
		protected static string cur = "";
		
		protected static int last=0;
		protected static string s="Marc Landolt\nRombachtäli 13\n5022 Rombach\n079 291 07 87\nmarc.landolt@yetnet.ch\n";
		protected static string hp="www.yetnet.ch/marc.landolt";
		
		protected static int faderX=0;
		
		protected static void drawBuffer(System.Drawing.Graphics g)
		{
			//base.OnPaint(e);


				g.Clear(System.Drawing.Color.Black);
				
				//g.FillRectangle(redBrush,faderX,0,4,170);
				
				wuerfel.punkte = Matrix.multiplizieren(wuerfel.punkte, dmy);
				wuerfel.punkte = Matrix.multiplizieren(wuerfel.punkte, dmz);
				wuerfel.punkte = Matrix.multiplizieren(wuerfel.punkte, dmz);
				wuerfel.punkte = Matrix.multiplizieren(wuerfel.punkte, dmx);
				double[][] punkte = Matrix.skalarMultiplizieren(wuerfel.punkte, 1.3*System.Math.Cos(i*0.04));
				
				
				for(int k=0; k<8; k++)
				{
					g.FillEllipse(bluebrush,(int)(center[0]-2+punkte[k][0]+punkte[k][2]*0.1),(int)(center[1]-2+punkte[k][1]+punkte[k][2]*0.1),10,10);
					//g.DrawLine(blue,center[0]+(int)punkte[k][0]+(int)(punkte[k][2]*0.1),(int)center[1]+(int)(punkte[k][1]+punkte[k][2]*0.1),0,0);
					//g.DrawLine(blue,center[0]+(int)punkte[k][0]+(int)(punkte[k][2]*0.1),(int)center[1]+(int)(punkte[k][1]+punkte[k][2]*0.1),0,0);
					//g.DrawLine(blue,center[0]+(int)punkte[k][0]+(int)(punkte[k][2]*0.1),(int)center[1]+(int)(punkte[k][1]+punkte[k][2]*0.1),0,70);
					//g.DrawLine(blue,center[0]+(int)punkte[k][0]+(int)(punkte[k][2]*0.1),(int)center[1]+(int)(punkte[k][1]+punkte[k][2]*0.1),100,0);
				}
				for(int l=0; l<wuerfel.W.Length; l++)
				{
					wuerfel.W[l] = Matrix.multiplizieren(wuerfel.W[l], dmy);
					wuerfel.W[l] = Matrix.multiplizieren(wuerfel.W[l], dmz);
					wuerfel.W[l] = Matrix.multiplizieren(wuerfel.W[l], dmx);
					
					g.DrawLine(new System.Drawing.Pen(System.Drawing.Color.Aquamarine),(float)(center[0]+wuerfel.W[l][0][0]+wuerfel.W[l][0][2]*0.1),(float)(center[1]+wuerfel.W[l][0][1]+wuerfel.W[l][0][2]*0.1),(float)(center[0]+wuerfel.W[l][1][0]+wuerfel.W[l][1][2]*0.1),(float)(center[1]+wuerfel.W[l][1][1]+wuerfel.W[l][1][2]*0.1));
				}
				
				
				
				char[] sa = s.ToCharArray();
				if (cursor<s.Length) cur="";
				
				
				
				for(int l=0; l<cursor%s.Length; l++)
				{
					if (cursor<s.Length) cur+=sa[l];
				}
				
				/*if(s.Length>cursor) if(last!=cur.Length) 
				{
					last=cur.Length;
					sp.Play();
				} */
				g.DrawString(cur,new System.Drawing.Font("Arial Bold", 8), new System.Drawing.SolidBrush(System.Drawing.Color.White),143,30, new System.Drawing.StringFormat(System.Drawing.StringFormat.GenericTypographic));
				if(cursor>s.Length) g.DrawString(hp,new System.Drawing.Font("Arial Bold", 8), new System.Drawing.SolidBrush(System.Drawing.Color.Blue),143,105, new System.Drawing.StringFormat(System.Drawing.StringFormat.GenericTypographic));		
		}
		
		protected override void OnResize(System.EventArgs e)
		{
			base.OnResize(e);
			this.Height=170;
			this.Width=300;
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// gdiWürfel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Text = "Marc Landolt";
			this.Name = "Marc Landolt";
			this.Width=300;
			this.Height=170;
			this.SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer | System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
			this.MaximizeBox=false;
			
			
			System.Threading.Thread t0 = new System.Threading.Thread(animate);
			t0.Start();
			System.Threading.Thread t1 = new System.Threading.Thread(counters);
			t1.Start();
			
			//sp.SoundLocation="c:\\Tippen.wav";
			
			wuerfel.punkte=Matrix.skalarMultiplizieren(wuerfel.punkte, 0.6);
			for(int i=0; i<wuerfel.W.Length; i++)
				wuerfel.W[i]=Matrix.skalarMultiplizieren(wuerfel.W[i], 0.6);
			
		}
	}
}
