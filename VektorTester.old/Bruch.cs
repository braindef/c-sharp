/*
 * Created by SharpDevelop.
 * User: Marc Jr. Landolt
 * Date: 12.08.2006
 * Time: 15::03
 * 
 * 
 */

using System;

namespace VektorTester
{
	/// <summary>
	/// Description of Bruch.
	/// </summary>
	public class Bruch
	{
		public static bool debug=false;
		public long Zaehler=0;
		public long Nenner=1;
		
		public Bruch(long a, long b)
		{
			this.Zaehler=a;
			this.Nenner=b;
		}
		
		
		// Moderner euklidscher Algorithmus zur Berechnung des ggT(a,b)
		public static long ggT(long a, long b)
		{
			//int zaehler = a;
			//int nenner = b;
			a=Math.Abs(a);
			b=Math.Abs(b);
			long temp = 0;
			while(a%b!=0)
			{
				temp = b;
				b = a%b;
				a = temp;	
			}
			return b;
		}
		
		// Berechnung des kgV(a,b) mit Hilfe der Formel a*b=kgV(a,b)*ggT(a,b)
		public static long kgV(long a, long b)
		{
			return (a*b)/ggT(a,b);
		}
		
		public static Bruch Addition(Bruch a, Bruch b)
		{
			return new Bruch((a.Zaehler*b.Nenner)+(b.Zaehler*a.Nenner),a.Nenner*b.Nenner);
		}
		
		public static Bruch Subtraktion(Bruch a, Bruch b)
		{
			return new Bruch((a.Zaehler*b.Nenner)-(b.Zaehler*a.Nenner),a.Nenner*b.Nenner);
		}
		
		public static Bruch Multiplikation(Bruch a, Bruch b)
		{
			return new Bruch(a.Zaehler*b.Zaehler, a.Nenner*b.Nenner);
		}
		
		public static Bruch Division(Bruch a, Bruch b)
		{
			return new Bruch(a.Zaehler*b.Nenner, a.Nenner*b.Zaehler);
		}

		public static long Exponent(long a, long b)
		{
			long a0 = a;
			for(int i=1; i<b; i++) {
				if (debug) Console.WriteLine(i + " " + a);
				a*=a0;
			}
			return a;
		}
		
		public static Bruch Potenz(Bruch a, long b)
		{
			return new Bruch(Exponent(a.Zaehler, b), Exponent(a.Nenner, b));
		}

		public static Bruch operator +(Bruch a, Bruch b)
		{
			return Bruch.Addition(a, b);
		}
		
		public static Bruch operator -(Bruch a, Bruch b)
		{
			return Bruch.Subtraktion(a, b);
		}

		public static Bruch operator *(Bruch a, Bruch b)
		{
			return Bruch.Multiplikation(a, b);
		}
		public static Bruch operator /(Bruch a, Bruch b)
		{
			return Bruch.Division(a, b);
		}
		// mit explicit müsste man jedesmal explizit casten, so castet es automatisch
		public static implicit operator double(Bruch a)
		{
			return (double)a.Zaehler/a.Nenner;
		}
		
		public override string ToString()
		{
			return this.Zaehler+"/"+this.Nenner;
		}
		
//TODO Bruch hoch Bruch
//		public static Bruch Potenz(Bruch a, Bruch b)
//		{
//			return new Bruch(a.Zaehler*b.Zaehler, a.Nenner*b.Nenner);
//		}

		
		public static Bruch Kuerzen(Bruch a)
		{
			long ggt=ggT(a.Zaehler, a.Nenner);
			return new Bruch(a.Zaehler/ggt, a.Nenner/ggt);
			                 
		}
	}
}
