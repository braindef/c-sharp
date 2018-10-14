/*
 * Created by SharpDevelop.
 * User: Marc Jr. Landolt
 * Date: 05.08.2006
 * Time: 19::05
 * 
 * 
 */
using System;
//using System.Collections.Generic;


namespace VektorTester
{
	class MainClass
	{
		public static Vektor V = new Vektor(1,0,0);
		public static void threadProc()
		{
			for(int i=0; i<360; i++)
			{ 
				System.Threading.Thread.Sleep(100);
				V.x+=1;
			}
		}
		
		public static void GdiThread1()
		{
			Linie[] l= new Linie[1000];
			//double[][] wuerfel = new wuerfel[3][24];
			
			System.Random rnd = new System.Random();
			rnd.Next();
			for(int i=0; i<l.Length;i++)
			    {
				l[i]=new Linie(new Vektor(rnd.Next(0,400),rnd.Next(0,400),rnd.Next(0,400)), new Vektor(rnd.Next(0,400),rnd.Next(0,400),rnd.Next(0,400)));
			    }

			gdiDrawing gd = new gdiDrawing(l);
			gd.Show();
			gd.Init();
			gd.Run();
			
		}
		
		public static void GdiThread2()
		{
			Linie[] l= new Linie[50];
			//double[][] wuerfel = new wuerfel[3][24];
			
			System.Random rnd = new System.Random();
			rnd.Next();
			for(int i=0; i<l.Length;i++)
			    {
				l[i]=new Linie(new Vektor(rnd.Next(0,400),rnd.Next(0,400),rnd.Next(0,400)), new Vektor(rnd.Next(0,400),rnd.Next(0,400),rnd.Next(0,400)));
			    }
			System.Windows.Forms.Application.Run(new gdiDoubleBuffer(l));
			
		
			

		}
		
		public static void gdiThread3()
		{
			System.Windows.Forms.Application.Run(new gdiWürfel());
		}
		
		public static int Main(string[] args)
		{
			//System.Threading.Thread t1 = new System.Threading.Thread(new System.Threading.ThreadStart(GdiThread1));
			//t1.Start();
			//System.Threading.Thread t2 = new System.Threading.Thread(new System.Threading.ThreadStart(GdiThread2));
			//t2.Start();
			System.Threading.Thread t3 = new System.Threading.Thread(new System.Threading.ThreadStart(gdiThread3));
			t3.Start();
			Console.Clear();
			Console.Beep(2000,50);
			System.Threading.Thread.Sleep(30);
			Console.Beep(1000,50);
			Console.WriteLine("Beispielprogramm für simple Bruch- und Vektorbibliothek");
			Console.WriteLine("-------------------------------------------------------");
			Console.WriteLine();
			Console.WriteLine("Bereitstellen der Brüche:");
			Console.WriteLine();
			Bruch a = new Bruch(1,2);
			Bruch b = new Bruch(-1,4);
			Bruch c = new Bruch(3,10);
			Console.WriteLine("a = " + a + " b = " + b + " c = " + c);
			Console.WriteLine();
			Console.WriteLine("Rechnen mit Brüchen:");
			Bruch d = a+b;
			Console.WriteLine("a + b = " + d);
			Console.WriteLine("Das ganze gekürzt (also durch den ggT geteilt): " + Bruch.Kuerzen(a+b));
			Bruch e = a*c;
			Console.WriteLine("a * c = " + e);
			Console.WriteLine();
			Console.WriteLine("Bereitstellen der Vektoren:");
			Console.WriteLine();
			Vektor A = new Vektor(1,0,0);
			Vektor B = new Vektor(0,2,0);
			Vektor C = new Vektor(0,0,3);
			Console.WriteLine("A = " + A + " B = " + B + " C = " + C);
			Console.WriteLine("(a + b) * A = " + ((a+b)*A));
			Console.WriteLine();
			Console.WriteLine("(a * b) * (A*B)   = " + (a*b)*(A*B) );
			// Schön wäre zumindest das Vektorprodukt auch noch mit überlademem Operator zu
			// steuern, leider hat das * schon die höchste Priorität bei den operatorn
			// Alternativ müsste man einen Parser schreiben
			Console.WriteLine("(a * b) * (AxB)   = " + (a*b)* Vektor.Vektorprodukt(A,B) );
			Console.WriteLine("(a * b) * (BxA)   = " + (a*b)* Vektor.Vektorprodukt(B,A) );
			Console.WriteLine("(a * b) * <A B C> = " + (a*b)* Vektor.Spatprodukt(A,B,C) );
			Console.WriteLine("Winkel Zwischen A und B: " + Vektor.Zwischenwinkel(A, B)+"°");
			Console.WriteLine();
			Console.WriteLine("Bitte eine Taste drücken!");
			Console.ReadKey();
			Console.Clear();
			//Vektor.zeichneVektor(new Vektor(50,20,0),new Vektor(3,3,0));
			for (int i=1; i<17; i++)
				Console.WriteLine(i + " " + primFaktoren.istPrim(i));

			Console.WriteLine("----------------------------------------");
			primFaktoren pf = new primFaktoren();
			primFaktoren.primfaktoren(1230);
			Console.WriteLine("----------------------------------------");
			pf.gekuerzteTeiler(2*2*3*3*3*7);
			Console.WriteLine("----------------------------------------");
			Console.ReadKey();
			

			return 0;
			
		}
	}
}
