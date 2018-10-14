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
	public class fVektor
	{
		public bool debug=false;

			

		public static float[] Addition(float[] a, float[] b)
		{
			if (a.Length!=b.Length) return null;
			float[] resultat = new float[a.Length];
			for(int i=0; i<a.Length;i++)
				resultat[i]=a[i]+b[i];
			return resultat;
		}
		
		
		public static float[] Subtraktion(float[] a, float[] b)
		{
			if (a.Length!=b.Length) return null;
			float[] resultat = new float[a.Length];
			for(int i=0; i<a.Length;i++)
				resultat[i]=a[i]-b[i];
			return resultat;
		}
		
			
		public static float[] SkalarMultiplikation(float a, float[] b)
		{
			float[] resultat = new float[b.Length];
			for(int i=0; i<b.Length;i++)
				resultat[i]=a*b[i];
			return resultat;
		}
		
		public static float[] SkalarMultiplikation(float[] b, float a)
		{
			return SkalarMultiplikation(a, b);
		}
//TODO
		public static float[] SkalarDivision(float[] a, float b)
		{
			float[] resultat = new float[a.Length];
			for(int i=0; i<a.Length;i++)
				resultat[i]=a[i]/b;
			return resultat;
		}

//TODO
		public static float[] Einheitsvektor(float[] a)
		{
			float absA = Abs(a);
			float[] resultat = new float[a.Length];
			for(int i=0; i<a.Length;i++)
				resultat[i]=a[i]/absA;
			return resultat;
		}
		
//TODO Punkte
//TODO Vorzeichen
//TODO KGV Vektor
//TODO GGT Vektor
//TODO Surface (Rechteck, Quadrat, Dreieck, Kreis)
//TODO Volume (Würfel, Quader, Spat, Pyramide...)
//TODO Ebene
//TODO GERADE



		public static float Abs(float[] a)
		{
			float[] quadrat = new float[a.Length];

			for(int i=0; i<a.Length;i++)
				quadrat[i]=a[i]*a[i];

			float resultat=0;
			for(int i=0; i<a.Length;i++)
				resultat+=a[i];
			
			return (float)Math.Sqrt(resultat);
		}
		
		public static float Skalarprodukt(float[] a, float[] b)
		{
			if (a.Length!=b.Length) return 0;
			
			float[] produkt = new float[a.Length];
			for(int i=0; i<a.Length; i++)
				produkt[i]=a[i]*b[i];
			float resultat=0;
			for(int i=0; i<produkt.Length; i++)
				resultat+=produkt[i];
			return resultat;
		}
		
		public static float[] Vektorprodukt(float[] a, float[] b)
		{
			if((a.Length!=3)&&(b.Length!=3)) return null;
			
			float[] resultat = new float[3];

			for(int i=0; i<3; i++)											// / a.y*b.z-a.z*b.y \
				resultat[i]=a[(i+1)%3]*b[(i+2)%3]-a[(i+2)%3]*b[(i+1)%3];	// | a.z*b.x-a.x*b.z |
																			// \ a.x*b.y-a.y*b.x /
			return resultat;
		}
	
		public static float SpatproduktAlgebra(float[] a, float[] b, float[] c)
		{
			return Skalarprodukt(a, Vektorprodukt(b,c));
		}
		
		public static float Spatprodukt(float[] a, float[] b, float[] c)
		{
			if((a.Length!=3)&&(b.Length!=3)) return 0;
			
			float[] produkt = new float[3];

			for(int i=0; i<3; i++)											    // / b.y*c.z-b.z*c.y \
				produkt[i]=a[i]*(b[(i+1)%3]*c[(i+2)%3]-b[(i+2)%3]*c[(i+1)%3]);	// | b.z*c.x-b.x*c.z |
																			    // \ b.x*c.y-b.y*c.x /
			
			float resultat=0;
			for(int i=0; i<3; i++)
				resultat+=produkt[i];
			
			return resultat;
		}

		public static float Zwischenwinkel(float[] a, float[] b)
		{
			return (float)((180/Math.PI)*Math.Acos(Skalarprodukt(a, b)/(Abs(a)*Abs(b))));
		}

	}
}

