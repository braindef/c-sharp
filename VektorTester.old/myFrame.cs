/*
 * Created by SharpDevelop.
 * User: Marc Jr. Landolt
 * Date: 13.08.2006
 * Time: 13::20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;




namespace VektorTester
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class myFrame : System.Windows.Forms.Form
	{
		Microsoft.DirectX.Direct3D.Device device = null;
		Microsoft.DirectX.Direct3D.VertexBuffer vb = null;
		
		public myFrame()
		{
			this.ClientSize = new System.Drawing.Size(640, 480);
			this.Text="Vektor Tester";
		}
		
		
		public void OnCreateVertexBuffer(object sender, System.EventArgs e)
		{
			Microsoft.DirectX.Direct3D.VertexBuffer vb = (Microsoft.DirectX.Direct3D.VertexBuffer)sender;
			Microsoft.DirectX.GraphicsStream gs = vb.Lock(0,0,0);
			Microsoft.DirectX.Direct3D.CustomVertex.TransformedColored[] verts = new Microsoft.DirectX.Direct3D.CustomVertex.TransformedColored[6];
			
			verts[0].X = 50;
			verts[0].Y = 50;
			verts[0].Z = 0.5f;
			verts[0].Rhw = 1;
			verts[0].Color = System.Drawing.Color.Red.ToArgb();
			
			verts[1].X = 250;
			verts[1].Y = 50;
			verts[1].Z = 0.5f;
			verts[1].Rhw = 1;
			//verts[1].Color = System.Drawing.Color.Lime.ToArgb();

			verts[2].X = 250;
			verts[2].Y = 50.1f;
			verts[2].Z = 0.5f;
			verts[2].Rhw = 1;
			//verts[2].Color = System.Drawing.Color.Red.ToArgb();
			
			verts[3].X = 250;
			verts[3].Y = 50;
			verts[3].Z = 0.5f;
			verts[3].Rhw = 1;
			//verts[3].Color = System.Drawing.Color.Red.ToArgb();
			
			verts[4].X = 250;
			verts[4].Y = 250;
			verts[4].Z = 0.5f;
			verts[4].Rhw = 1;
			//verts[4].Color = System.Drawing.Color.Red.ToArgb();
			
			verts[5].X = 50;
			verts[5].Y = 250;
			verts[5].Z = 0.5f;
			verts[5].Rhw = 1;
			//verts[5].Color = System.Drawing.Color.Red.ToArgb();
			
			gs.Write(verts);
			vb.Unlock();
		}
			
		public bool InitializeGraphics()
		{
			try {
				Microsoft.DirectX.Direct3D.PresentParameters presentParams = new Microsoft.DirectX.Direct3D.PresentParameters();
				presentParams.Windowed=true;
				presentParams.SwapEffect=Microsoft.DirectX.Direct3D.SwapEffect.Discard; //TODO
				
				device = new Microsoft.DirectX.Direct3D.Device(0, Microsoft.DirectX.Direct3D.DeviceType.Hardware, this, Microsoft.DirectX.Direct3D.CreateFlags.SoftwareVertexProcessing, presentParams);
				
				Console.WriteLine("Device inizialisiert");
				
				vb = new Microsoft.DirectX.Direct3D.VertexBuffer(typeof(Microsoft.DirectX.Direct3D.CustomVertex.TransformedColored), 6 ,this.device, 0, Microsoft.DirectX.Direct3D.CustomVertex.TransformedColored.Format, Microsoft.DirectX.Direct3D.Pool.Default);
				vb.Created += new System.EventHandler(this.OnCreateVertexBuffer);
				this.OnCreateVertexBuffer(vb, null);
				
				
				device.DeviceLost += new EventHandler(this.InvalidateDeviceObjects);
				device.DeviceReset += new EventHandler(this.restoreDeviceObjects);
				device.Disposing += new EventHandler(this.deleteDeviceObjects);
				device.DeviceResizing +=new System.ComponentModel.CancelEventHandler(this.EnvironmentResizing);
				
				
				
				
				return true;
			} catch (Microsoft.DirectX.DirectXException) {
				return false;
			}
		}
		protected virtual void InvalidateDeviceObjects(object sender, System.EventArgs e)
		{
			Console.WriteLine("DeviceLost");
		}
		
		protected virtual void restoreDeviceObjects(object sender, System.EventArgs e)
		{
			Console.WriteLine("DeviceReset");
		}
		
		protected virtual void deleteDeviceObjects(object sender, System.EventArgs e)
		{
			Console.WriteLine("Disposing");
		}
		
		protected virtual void EnvironmentResizing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Console.WriteLine("DeviceResizing");
		}
		
		protected virtual void FrameMove()
		{
			//TODO : Frame movement
		}
		
		protected virtual void Render()
		{
			if (device != null) {
				device.Clear(Microsoft.DirectX.Direct3D.ClearFlags.Target, System.Drawing.Color.Blue, 1.0f, 0);
				device.BeginScene();
				
				//sprite.Begin(SpriteFlags.None);
   				//sprite.Draw(texture, Vector3.Empty, new Vector3(10, 10, 0), 0x00ffffff);
    			//sprite.End();
    			//Microsoft.DirectX.Vector3.
    			//Microsoft.DirectX.Matrix
    			
    			device.SetStreamSource(0, vb, 0);
    			device.VertexFormat = Microsoft.DirectX.Direct3D.CustomVertex.TransformedColored.Format;
    			device.DrawPrimitives(Microsoft.DirectX.Direct3D.PrimitiveType.TriangleList, 0, 2);
    			
				//TODO : Scene rendering
				

    				
				device.EndScene();
				device.Present();
			}
		}
		
		public void Run()
		{
			while(this.Created)
			{
				FrameMove();
				Render();
				System.Windows.Forms.Application.DoEvents();
				
			}
		}
		
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			this.Render();
		}
		
		protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			if ((int)e.KeyChar == (int)System.Windows.Forms.Keys.Escape)
				this.Close();
		}
		
		
		static void Main3()
		{
			myFrame miisFrame = new myFrame();
			{
				if (!miisFrame.InitializeGraphics())
				{
					System.Windows.Forms.MessageBox.Show("Error wärend des Inizialisierens von Direct3D");
				}
			miisFrame.Show();
			miisFrame.Run();
			}
			
			
			       
		}
	}
}
