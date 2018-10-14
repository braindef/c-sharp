/*
 * Created by SharpDevelop.
 * User: Marc Jr. Landolt
 * Date: 22.08.2006
 * Time: 07::46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace VektorTester
{
	/// <summary>
	/// Description of wuerfel.
	/// </summary>
	public class wuerfel
	{
		
			public static int[] P01 = {-50,-50,-50};
			public static int[] P02 = {50,-50,-50};
			public static int[] P03 = {50,50,-50};
			public static int[] P04 = {-50,50,-50};
			
			public static int[] P05 = {-50,-50,50};
			public static int[] P06 = {50,-50,50};
			public static int[] P07 = {50,50,50};
			public static int[] P08 = {-50,50,50};
			
			public static int[][] punkte = {P01, P02, P03, P04, P05, P06, P07, P08};
		public wuerfel()
		{
			/*float[] S1 = {P01, P02, P03, P04};
			float[] S2 = {P02, P12, P13, P03};
			float[] S3 = {P12, P11, P14, P13};
			float[] S4 = {P11, P01, P04, P14};
			float[] S5 = {P04, P03, P13, P14};
			float[] S6 = {P11, P12, P02, P01};
			*/
		//TODO Würfel als 
		//TODO 2.5D Environment x+=0.3*z y+=0,3*z
		//TODO Drehmatrix
		}
	
	}
}
