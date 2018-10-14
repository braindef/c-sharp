/*
 * Created by SharpDevelop.
 * User: Marc Jr. Landolt
 * Date: 03.09.2006
 * Time: 20::47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace LamBib
{
	/// <summary>
	/// Description of primFaktoren.
	/// </summary>
	public class primFaktoren
	{
		public primFaktoren()
		{
		}
		
		public static bool debug=true;
		
		public static bool istPrim(int a)
		{
			if (a==1) return false;	// 1 ist als nicht-Primzahl definiert
			for (int i=2; i<a; i++)
				if (a%i==0) return false;
			return true;
		}
	
		public static int[] primfaktoren(int a)
		{
			System.Collections.ArrayList faktoren = new System.Collections.ArrayList();
			for (int i=2; i<=a; i++)
			{
				if (a%i==0)
				{
					if (debug) Console.Write(i + " ");
					faktoren.Add(i);
					a/=i;
					i=1;
				}
			}
			if (debug) Console.WriteLine();
			
			int[] intFaktoren = new int[faktoren.Count];
			
			for(int i=0; i<faktoren.Count; i++)
				intFaktoren[i]=(int)faktoren[i];
			
			return intFaktoren;
		}

		
		public System.Collections.ArrayList teilerArray = new System.Collections.ArrayList();
		
		public void teiler(int produkt, int[] restFaktoren)		//Listet alle Teiler (auch doppelte) auf
		{
			teilerArray.Add(1);
			for(int i=0;i<restFaktoren.Length; i++)
			{
				if (restFaktoren[i]>0)
				{
					teilerArray.Add(produkt*restFaktoren[i]);
					restFaktoren[i]*=-1;	//das Glied, mit negativem Vorzeichen wird beim nächsten Rekursion nicht berücksichtigt
					int[] neueRestFaktoren=new int[restFaktoren.Length];
					restFaktoren.CopyTo(neueRestFaktoren,0);
					teiler(produkt*restFaktoren[i]*(-1), neueRestFaktoren);
					restFaktoren[i]*=-1;	//damit das glied bei auf der selben Stufe weiter benutzt wird wird es wieder als positiv bezeichnet
				}
				
			}
		}
		
		public System.Collections.ArrayList gekuerzteTeiler(int Zahl)
		{
			this.teiler(1, primfaktoren(Zahl));
			
			
			for (int i=0; i<this.teilerArray.Count; i++)
				for (int j=i+1; j<this.teilerArray.Count; j++)
					if((int)this.teilerArray[i]==(int)this.teilerArray[j])
					{
						this.teilerArray.RemoveAt(j);
						j--;
					}
			
			this.teilerArray.Sort();				//TODO : Vorsicht bei mehreren instanzen...
			
			for (int i=0; i<this.teilerArray.Count; i++) if (debug) Console.WriteLine(this.teilerArray[i] /*+ " " + Zahl/(int)this.teilerArray[i]*/);
			if (debug) Console.WriteLine();
			
			
			
			return this.teilerArray;
		}	
	}
}
