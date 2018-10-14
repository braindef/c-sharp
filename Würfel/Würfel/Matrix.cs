/*
 * Created by SharpDevelop.
 * User: Marc Jr. Landolt
 * Date: 07.09.2006
 * Time: 21::05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Visitenkarte
{
    /// <summary>
    /// Description of Matrix.
    /// </summary>
    public class Matrix
    {
        protected static bool debug = false;
        protected double[][] matrix;

        public Matrix(double[][] m1)
        {
            matrix = new double[m1.Length][];	// WICHTIG, SO WIRD EIN 2-Dimensonales Array inizialisiert...
            for (int i = 0; i < m1.Length; i++)	/* oder so: int[][] matrix2 = { new int[] {1,2,3}, new int[] {2,3,4}, new int[] {3,4,5};*/
            {
                this.matrix[i] = new double[m1[i].Length];
                for (int j = 0; j < m1[i].Length; j++)
                    this.matrix[i][j] = m1[i][j];
            }
        }

        public static void ToConsole(double[][] m1)
        {
            if (m1 == null)
            {
                Console.WriteLine("NULL");
                return;
            }
            for (int i = 0; i < m1.Length; i++)
            {
                for (int j = 0; j < m1[i].Length; j++)
                {
                    Console.Write(" {0,3}", Math.Round(m1[i][j], 10));
                }
                Console.WriteLine();
            }

        }

        public static double[][] addieren(double[][] m1, double[][] m2)
        {
            if (m1.Length != m2.Length) return null;
            for (int i = 0; i < m1.Length; i++) if (m1[i].Length != m2[i].Length) return null;
            double[][] resultat = new double[m1.Length][];
            for (int i = 0; i < m1.Length; i++)
            {
                resultat[i] = new double[m1[i].Length];
                for (int j = 0; j < m1[i].Length; j++)
                {
                    if (debug) Console.WriteLine(i + " " + j + " " + m1[i][j] + m2[i][j] + " " + m1[i][j] + " " + +m2[i][j]);
                    resultat[i][j] = m1[i][j] + m2[i][j];
                }
            }
            return resultat;
        }

        public static double[][] subtrahieren(double[][] m1, double[][] m2)
        {
            if (m1.Length != m2.Length) return null;
            for (int i = 0; i < m1.Length; i++) if (m1[i].Length != m2[i].Length) return null;
            double[][] resultat = new double[m1.Length][];
            for (int i = 0; i < m1.Length; i++)
            {
                resultat[i] = new double[m1[i].Length];
                for (int j = 0; j < m1[i].Length; j++)
                {
                    if (debug) Console.WriteLine(i + " " + j + " " + m1[i][j] + m2[i][j] + " " + m1[i][j] + " " + +m2[i][j]);
                    resultat[i][j] = m1[i][j] - m2[i][j];
                }
            }
            return resultat;
        }

        public static double[][] skalarMultiplizieren(double[][] m1, double skalar)
        {
            double[][] resultat = new double[m1.Length][];
            for (int i = 0; i < m1.Length; i++)
            {
                resultat[i] = new double[m1[i].Length];
                for (int j = 0; j < m1[i].Length; j++)
                {
                    if (debug) Console.WriteLine(m1[i][j] * skalar);
                    resultat[i][j] = m1[i][j] * skalar;
                }
            }
            return resultat;
        }

        public static double[][] multiplizieren(double[][] A, double[][] B)
        {
            if (A[0].Length != B.Length) return null;
            double[][] resultat = new double[A.Length][];
            for (int i = 0; i < A.Length; i++)
            {
                resultat[i] = new double[B[0].Length];
                for (int j = 0; j < B[0].Length; j++)
                    for (int k = 0; k < B.Length; k++)
                        resultat[i][j] += A[i][k] * B[k][j];
            }
            return resultat;
        }

        public static double[][] transponieren(double[][] m1) //TODO Ungleiche Transponieren
        {
            if (m1.Length != m1[0].Length) return null;
            double[][] resultat = new double[m1.Length][];
            for (int i = 0; i < m1.Length; i++)
            {
                resultat[i] = new double[m1[0].Length];
                for (int j = 0; j < m1[0].Length; j++)
                    resultat[i][j] = m1[j][i];
            }
            return resultat;

        }

        public static double determinieren(double[][] m1)
        {
            if (m1.Length != m1[0].Length) throw new System.Exception("Determinante nicht Quadratisch");

            if (m1.Length < 3)
            {
                return m1[0][0] * m1[1][1] - m1[0][1] * m1[1][0];
            }

            double a = 0;

            double resultat = new double();
            for (int i = 0; i < m1[0].Length; i++)
            {
                a = (double)Math.Pow(-1, i + 0) * m1[0][i];
                resultat += a * determinieren(Unterdeterminante(m1, i, 0));
            }
            return resultat;
        }

        public static double[][] Unterdeterminante(double[][] s1, int xPos, int yPos)
        {
            int k = 0;
            int l = 0;
            double[][] resultat = new double[s1.Length - 1][];
            for (int i = 0; i < s1.Length; i++)
            {
                if (i != yPos)
                {
                    resultat[l++] = new double[s1[0].Length - 1];
                    for (int j = 0; j < s1[0].Length; j++)
                        if (j != xPos)
                        {
                            resultat[l - 1][k++] = s1[i][j];
                        }
                    k = 0;
                }
            }

            if (debug) ToConsole(resultat);
            return resultat;
        }

        public static double[][] Adjunkte(double[][] s1)
        {
            double[][] resultat = new double[s1.Length][];
            for (int i = 0; i < s1.Length; i++)
            {
                resultat[i] = new double[s1[0].Length];
                for (int j = 0; j < s1[0].Length; j++)
                {
                    resultat[i][j] = (double)Math.Pow(-1, i + j) * determinieren(Unterdeterminante(s1, i, j));
                }

            }
            return resultat;
        }

        public static double[][] Inverse(double[][] m1)
        {
            return skalarMultiplizieren(Adjunkte(m1), 1 / determinieren(m1));
        }

        public static double[][] einheitsmatrix(int spalten)
        {
            double[][] resultat = new double[spalten][];
            for (int i = 0; i < spalten; i++)
            {
                resultat[i] = new double[spalten];
                resultat[i][i] = 1;
            }
            return resultat;
        }

        public static double[][] xDrehen(double Winkel)
        {
            double[][] drehmatrix = {new double[] {1,0,0},
									 new double[] {0,Math.Cos(Winkel),-Math.Sin(Winkel)},
									 new double[] {0,Math.Sin(Winkel),Math.Cos(Winkel)}};
            return drehmatrix;
        }


        public static double[][] yDrehen(double Winkel)
        {
            double[][] drehmatrix = {new double[] {Math.Cos(Winkel),0,Math.Sin(Winkel)},
									 new double[] {0,1,0},
									 new double[] {-Math.Sin(Winkel),0,Math.Cos(Winkel)}};
            return drehmatrix;
        }

        public static double[][] zDrehen(double Winkel)
        {
            double[][] drehmatrix = {new double[] {Math.Cos(Winkel),-Math.Sin(Winkel),0},
									 new double[] {Math.Sin(Winkel), Math.Cos(Winkel),0},
									 new double[] {0,0,1},};
            return drehmatrix;
        }

        public static void meinli()
        {
            System.Threading.Thread.Sleep(1000);

            double[][] m1 = { new double[] { 1, 0, -1, 0.5 }, new double[] { -8, 4, 1, 323 }, new double[] { -2, 1, 0, -0.342 }, new double[] { 2, 1, -4, -0.2 } };
            Console.WriteLine("=====Ausgangsmatrix======");
            ToConsole(m1);
            Console.WriteLine("========Adjunkte=========");
            ToConsole(Adjunkte(m1));
            Console.WriteLine("=========Inverse=========");
            ToConsole(Inverse(m1));
            Console.WriteLine("====Ausgang * Inverse====");
            ToConsole(multiplizieren(m1, Inverse(m1)));
            Console.WriteLine("=====Einheitsmatrix=====");
            ToConsole(einheitsmatrix(5));
        }
    }
}
