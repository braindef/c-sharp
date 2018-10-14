/*
 * Created by SharpDevelop.
 * User: Marc Jr. Landolt
 * Date: 22.12.2006
 * Time: 22::15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

//Beispiel zur berechnung von int sin^2(x) 0..2Pi = Pi

namespace NummerischeIntegration
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			
			double resultat = 0;
			for(int i=0; i<2000; i++)
			{
				System.Console.Write(resultat + " ");
				System.Console.WriteLine(Math.Sin(i/1000.0));
				resultat+= 2*Math.PI/2000 * Math.Pow(Math.Sin(i/2000.0*2*Math.PI),2);
			}
			System.Console.WriteLine(resultat);
			
			System.Console.ReadKey();
			
		}
	}
}
