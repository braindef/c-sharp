/*
 * Created by SharpDevelop.
 * User: Marc Jr. Landolt
 * Date: 13.08.2006
 * Time: 19::04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System; //Contains fundamental classes and base classes
using System.Drawing; //Provides access to GDI+ basic graphics functionality
using System.Windows.Forms; //Contains classes for creating Windows-based applications
using Microsoft.DirectX; //The DirectX class
using Microsoft.DirectX.Direct3D; //The Direct3D class 
//Our testing class named after my engine
public class Xilath
      {
	
	
	private VertexBuffer vb;
	public void createTriangle()
{
      CustomVertex.PositionColored[] triangle = new CustomVertex.PositionColored[3]; //create an array of 3 vertices
      //using the CustomVertex.PositionColored constructor to set each vertex 
      triangle[0] = new CustomVertex.PositionColored(-0.1f, 0.0f, 1.0f, Color.Blue.ToArgb()); 
      triangle[1] = new CustomVertex.PositionColored(-0.1f, 0.2f, 1.0f, Color.Red.ToArgb());
      triangle[2] = new CustomVertex.PositionColored(0.1f, 0.0f, 1.0f, Color.Green.ToArgb());
      vb = new VertexBuffer(typeof(CustomVertex.PositionColored), 3, direct3d.XilathDevice, Usage.WriteOnly, CustomVertex.PositionColored.Format, Pool.Managed);
      GraphicsStream stm; //our GraphicsStream object that we will use to access the 
      //lock the VB. Locks a range of vertex data and obtains the vertex buffer memory and stores it in the GraphicsStream object (stm) 
      stm = vb.Lock(0, 0, LockFlags.None); 
      stm.Write(triangle); //write the triangle array to the GraphicsStream Object
      vb.Unlock(); //unlock the VertexBuffer, we are finished writing the data to it.
}

      //our default constructor used to initialize the device.
      public Xilath()
      {
         direct3d = new Direct3d(); //instantiate the Direct3d object
         if(!direct3d.InitGraphics()) //if we cannot initialize the device then 
         MessageBox.Show("Device could not be created. Program quiting.."); //show an appropriate          message
      }
     
      //our Render function. This is where all the fun will happen
      public void Render()
      {
        direct3d.Clear(Color.Black); //our back buffer clear function
        direct3d.BeginScene(); //Begin drawing to the back buffer
        
      
{ 
      direct3d.BeginRender(Color.Black); //render our scene with the background as black
      direct3d.XilathDevice.SetStreamSource(0, vb, 0);
      direct3d.XilathDevice.VertexFormat = CustomVertex.PositionColored.Format;
      direct3d.XilathDevice.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 1);
      direct3d.FinishRender(); //finish rendering our scene
}
        
        direct3d.EndScene(); //End drawing to the back buffer
        direct3d.Present(); //Present whatever is in the back buffer
      }

      //main program entry point
      public static void Main()
      {
          Xilath xilath = new Xilath(); //instantiate our Xilath class
          xilath.direct3d.Show(); //show the window
          while(xilath.direct3d.Created) //while the window is created and valid
          {
              xilath.Render(); //call our render method
              Application.DoEvents(); //process the window's messages
         }
     }
     private Direct3d direct3d = null; //our Direct3d helper class
}

