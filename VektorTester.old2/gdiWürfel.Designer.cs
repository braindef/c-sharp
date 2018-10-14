/*
 * Created by SharpDevelop.
 * User: Marc Jr. Landolt
 * Date: 06.09.2006
 * Time: 16::55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace VektorTester
{
	partial class gdiWürfel : System.Windows.Forms.Form
	{
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
		
		protected static int i=1;
		protected static int x=0;
		protected static int j=0;
		protected static double y=0;
		
		protected void counters()
		{
			while(!this.Created) {System.Threading.Thread.Sleep(100);}
			while(this.Created)
			{
				i = (int)(50*System.Math.Sin(0.1*x++));
				j = (int)(50*System.Math.Sin(0.14*y));
				y+=0.5;
				System.Threading.Thread.Sleep(20);
			}
		}
		
		protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			if ((int)e.KeyChar==(int)System.Windows.Forms.Keys.Escape) this.Close();
		}
		
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			System.Drawing.Graphics g = e.Graphics;
			drawBuffer(g);
		}
		
		protected static int[] center = {150,150};
		protected static double alpha = 0;
		protected static double[][] drehmatrix1grad=Matrix.yDrehen(0.03);
		
		protected static void drawBuffer(System.Drawing.Graphics g)
		{
			//base.OnPaint(e);


				g.Clear(System.Drawing.Color.Black);
				//System.Console.WriteLine(i+ " " + x);
				g.DrawLine(new System.Drawing.Pen(System.Drawing.Color.White),50,0,i+50,100);
				
				
				wuerfel.punkte = Matrix.multiplizieren(wuerfel.punkte, drehmatrix1grad);
				
				//System.Console.WriteLine(i+ " " + y);
				g.DrawLine(new System.Drawing.Pen(System.Drawing.Color.White),150,0,j+150,150);
				for(int k=0; k<8; k++)
				{
					g.DrawEllipse(new System.Drawing.Pen(System.Drawing.Color.Blue),center[0]-2+(int)wuerfel.punkte[k][0]+(int)(wuerfel.punkte[k][2]*0.1),(int)center[1]-2+(int)(wuerfel.punkte[k][1]+wuerfel.punkte[k][2]*0.1),5,5);
				}
	
				for(int l=0; l<wuerfel.W.Length; l++)
				{
					wuerfel.W[l] = Matrix.multiplizieren(wuerfel.W[l], drehmatrix1grad);
					g.DrawLine(new System.Drawing.Pen(System.Drawing.Color.Blue),(float)(center[0]+wuerfel.W[l][0][0]+wuerfel.W[l][0][2]*0.1),(float)(center[1]+wuerfel.W[l][0][1]+wuerfel.W[l][0][2]*0.1),(float)(center[0]+wuerfel.W[l][1][0]+wuerfel.W[l][1][2]*0.1),(float)(center[1]+wuerfel.W[l][1][1]+wuerfel.W[l][1][2]*0.1));
				}
				
				g.DrawLine(new System.Drawing.Pen(System.Drawing.Color.White),i+50,100,j+150,150);
				
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
			this.Text = "gdiWürfel";
			this.Name = "gdiWürfel";
			this.SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer | System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);

			System.Threading.Thread t0 = new System.Threading.Thread(animate);
			t0.Start();
			System.Threading.Thread t1 = new System.Threading.Thread(counters);
			t1.Start();
			
		}
	}
}
