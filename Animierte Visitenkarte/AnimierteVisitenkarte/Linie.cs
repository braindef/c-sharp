/*
 * Created by SharpDevelop.
 * User: Marc Jr. Landolt
 * Date: 16.08.2006
 * Time: 14::01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace VektorTester
{
	/// <summary>
	/// Description of Linie.
	/// </summary>
	public class Linie
	{
		public Vektor a;
		public Vektor b;
		public Linie(Vektor a, Vektor b)
		{
			this.a=a;
			this.b=b;
		}
		
		public Linie(Vektor a)
		{
			this.b=a;
		}
		
		public Linie()
		{
			Console.WriteLine("Konstruktor Linie");
			this.a = new Vektor(0,0,0);
			this.b = new Vektor(0,0,0);
		}
		
	}
}
