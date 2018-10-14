/*
 * Created by SharpDevelop.
 * User: Marc Jr. Landolt
 * Date: 05.08.2006
 * Time: 13::14
 * 
 * 
 */

using System;


namespace VektorTester
{
	/// <summary>
	/// dies ist eine Klasse für Vektorrechnen,
	/// weitere informationen zu Vektorrechnen findet man in der
	/// Mathematik Formelsammlung

	/// </summary>
	public class Vektor
	{
		public bool debug=false;
		public double x;
		public double y;
		public double z;
		
		
		public Vektor(double x, double y, double z)
		{
			this.x=x;
			this.y=y;
			this.z=z;
			// this(); so nur in Java
			if (debug)
			{
				Console.WriteLine("Konstruktor");
				Console.WriteLine(this);
			}
		}
		

		public static Vektor Addition(Vektor a, Vektor b)
		{
			
			return new Vektor(a.x+b.x, a.y+b.y, a.z+b.z);
		}
		
		public static Vektor Subtraktion(Vektor a, Vektor b)
		{
			return new Vektor(a.x-b.x, a.y-b.y, a.z-b.z);
		}
		
		public static Vektor SkalarMultiplikation(double a, Vektor b)
		{
			return new Vektor(b.x*a, b.y*a, b.z*a);
		}
		
		public static Vektor SkalarMultiplikation(Vektor b, double a)
		{
			return new Vektor(b.x*a, b.y*a, b.z*a);
		}
//TODO
		public static Vektor SkalarDivision(Vektor a, double b)
		{
			return new Vektor(a.x/b, a.y/b, a.z/b);
		}

//TODO
		public static Vektor Einheitsvektor(Vektor a)
		{
			double absA = Vektor.Abs(a);
			return new Vektor(a.x/absA, a.y*absA, a.z*absA);
		}
		
//TODO Punkte
//TODO Vorzeichen
//TODO KGV Vektor
//TODO GGT Vektor
//TODO Surface (Rechteck, Quadrat, Dreieck, Kreis)
//TODO Volume (Würfel, Quader, Spat, Pyramide...)
//TODO Ebene
//TODO GERADE



		public static double Abs(Vektor a)
		{
			return Math.Sqrt(a.x*a.x+a.y*a.y+a.z*a.z);
		}
		
		public static double Skalarprodukt(Vektor a, Vektor b)
		{
			return a.x*b.x+a.y*b.y+a.z*b.z;
		}
		
		public static Vektor Vektorprodukt(Vektor a, Vektor b)
		{
			return new Vektor(a.y*b.z-a.z*b.y, a.z*b.x-a.x*b.z, a.x*b.y-a.y*b.x);
		}
	
		public static double Spatprodukt(Vektor a, Vektor b, Vektor c)
		{
			return Skalarprodukt(a, Vektorprodukt(b,c));
		}
		
		public static double Zwischenwinkel(Vektor a, Vektor b)
		{
			return (180/Math.PI)*Math.Acos(Vektor.Skalarprodukt(a, b)/(Vektor.Abs(a)*Vektor.Abs(b)));
		}
		
		// Überladen der Operatoren
		// Überladbare Operatoren:
		// new, +, %, ~, >, /=, |=, <<=, >=, --, (), delete,
		// -, ^, !, +=, %=, <<, ==, &&, ,, [], new[], *, &, =,
		// -=, ^=, >>, !=, ||, ->* delete[], /, |, <, *=, &=, >>=, <=, ++, ->
		
		public static Vektor operator +(Vektor a)
		{
			return a;
		}
		
		public static Vektor operator +(Vektor a, Vektor b)
		{
			return Vektor.Addition(a, b);
		}
		
		public static Vektor operator -(Vektor a)
		{
			return new Vektor(-a.x, -a.y, -a.z);
		}
		
		public static Vektor operator -(Vektor a, Vektor b)
		{
			return Vektor.Subtraktion(a, b);
		}
		
		public static double operator *(Vektor a, Vektor b)
		{
			return Vektor.Skalarprodukt(a, b);
		}
		
		public static Vektor operator *(double a, Vektor b)
		{
			return Vektor.SkalarMultiplikation(a, b);
		}

		public static Vektor operator *(Vektor a, double b)
		{
			return Vektor.SkalarMultiplikation(a, b);
		}

		public static Vektor operator /(Vektor a, double b)
		{
			return Vektor.SkalarDivision(a, b);
		}
		
		public override string ToString()
		{
			return "["+this.x + " " + this.y + " " + this.z + "]";
		}
		
		public static void zeichneVektor(Vektor v, Vektor Startpunkt)
		{
			
			double a = v.y/v.x;
			
			for(int i=0; i<v.x; i+=2)
			{
				Console.SetCursorPosition((int)(Startpunkt.x+i),(int)(Startpunkt.y+a*i));
				Console.Write("*");
			}
		}
	}
}

