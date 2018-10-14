using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    class Tree
    {

 /*       static int[,] toSolve = new int[,] {    {0, 0, 2, 0, 7, 0, 1, 0, 0},
                                            {6, 0, 0, 0, 0, 0, 0, 0, 5},
                                            {0, 0, 3, 0, 4, 0, 8, 0, 0},
                                            {0, 7, 0, 0, 0, 0, 0, 3, 0},
                                            {3, 0, 0, 5, 9, 8, 0, 0, 7},        //1. 3 / 2. 4 / 3. 1
                                            {0, 9, 0, 0, 0, 0, 0, 4, 0},
                                            {0, 0, 4, 0, 1, 0, 6, 0, 0},
                                            {8, 0, 0, 0, 0, 0, 0, 0, 2},
                                            {0, 0, 0, 0, 3, 0, 7, 0, 0} }; */
        // EXPERTE 2

        static int[,] toSolve = new int[,] {    {8, 1, 0, 0, 0, 6, 3, 0, 0},        
                                                {0, 0 ,0, 9, 0, 2, 0, 0, 0},            //mitte 2. Zeile ist 3 weil 1. und 3. zeile schon 3 ist
                                                {4, 0, 3, 0, 0, 0, 0, 0, 0},
                                                {0, 0, 0, 0, 0, 0, 2, 5, 3},
                                                {9, 0, 0, 8, 0, 0, 0, 0, 0},
                                                {0, 0, 0, 0, 0, 0, 7, 0, 0},
                                                {0, 0, 0, 0, 1, 0, 0, 6, 0},
                                                {0, 4, 0, 7, 0, 0, 8, 0, 0},
                                                {1, 9, 2, 0, 6, 0, 0, 0, 0} };      

        // EXPERTE 2 uschi improoved with added 8 at [2,5]

   /*         static int[,] toSolve = new int[,] {{8, 1, 9, 0, 0, 6, 3, 0, 0},        
                                                {0, 0 ,0, 9, 3, 2, 0, 0, 0},            //mitte 2. Zeile ist 3 weil 1. und 3. zeile schon 3 ist
                                                {4, 0, 3, 0, 8, 0, 0, 0, 0},
                                                {0, 0, 0, 0, 0, 0, 2, 5, 3},
                                                {9, 0, 0, 8, 2, 0, 0, 0, 0},
                                                {2, 0, 0, 0, 0, 0, 7, 0, 0},
                                                {0, 0, 0, 2, 1, 0, 0, 6, 0},
                                                {0, 4, 0, 7, 0, 0, 8, 0, 0},
                                                {1, 9, 2, 0, 6, 8, 0, 0, 0} };  */
        

  /*        static int[,] toSolve = new int[,] {     {0, 2, 0, 9, 3, 0, 0, 0, 0},
                                                {8, 0, 6, 0, 0, 0, 0, 0, 0},
                                                {0, 5, 0, 4, 0, 0, 1, 0, 0},
                                                {1, 0, 2, 0, 6, 0, 0, 0, 0},
                                                {6, 0, 0, 3, 0, 8, 0, 0, 7},
                                                {0, 0, 0, 0, 2, 0, 4, 0, 5},
                                                {0, 0, 9, 0, 0, 1, 0, 4, 0},
                                                {0, 0, 0, 0, 0, 0, 6, 0, 2},
                                                {0, 0, 0, 0, 7, 9, 0, 8, 0} };  */




        public static bool exitSignal = false;

        public int[,] s;
        public ReturnData mRData;


        public Tree(int[,] sudoku, int i, int j, int number, int depth)
        {
            if ((depth < 0) || (exitSignal)) return;

            

            System.Console.Out.WriteLine("NEW TREE, Level: " + depth);
            //System.Threading.Thread.Sleep(500);
            this.mRData = new ReturnData();
            
            this.s = copySudoku(sudoku);

            
            this.s[i, j] = number;

            
            solve(this.s, mRData);

            if (mRData.trap) return;
            
            if (mRData.noSolution == false)
            {
                System.Console.Out.WriteLine("Found Solution!");
                Tree.exitSignal = true;
                printSudoku(this.s);
                System.Console.In.Read();
                return;
            }

            

            mRData.noSolution = false;
            findBest(this.s, mRData);
            int[] possibilities = testAll(s, mRData.i, mRData.j);
            if (possibilities[0] == 0)          //falsch es müsste die schlechteste abfragen nicht die beste
            {
                System.Console.Out.WriteLine("Closing Tree");
                System.Console.In.Read();
                //System.Threading.Thread.Sleep(5000);
                printSudoku(this.s);
                return;
            }
            for (int k = 0; k < possibilities[0]; k++)
                new Tree(sudoku, mRData.i, mRData.j, possibilities[k+1], depth-1);
        }


        public static bool hasEmpty(int[,] sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    if (sudoku[i, j] == 0)
                        return true;
            }
            return false;
        }

        public static void printSudoku(int[,] sudoku)
        {
            System.Console.Out.WriteLine("");
            for (int i = 0; i < 9; i++)
            {
                System.Console.Out.Write("¦");
                if (i % 3 == 0)
                {
                    System.Console.Out.WriteLine("--------------------|");
                    System.Console.Out.Write("|");
                }

                for (int j = 0; j < 9; j++)
                {
                    System.Console.Out.Write(sudoku[i, j] + " ");
                    if ((j % 3 == 2) && (j < 8))
                    {
                        System.Console.Out.Write("|");
                    }
                }
                System.Console.Out.WriteLine("¦");

            }
            System.Console.WriteLine("|--------------------|");
        }

        public static int findRow(int[,] sudoku, int i, int j)
        {
            int count = 0;
            for (int k = 0; k < 9; k++)
                if (sudoku[k, j] != 0) count++;
            return count;
        }

        public static int findCol(int[,] sudoku, int i, int j)
        {
            int count = 0;
            for (int k = 0; k < 9; k++)
                if (sudoku[i, k] != 0) count++;
            return count;
        }

        public static int findField(int[,] sudoku, int i, int j)
        {
            int count = 0;
            for (int k = 3 * (i / 3); k < (3 * (i / 3) + 3); k++)
                for (int l = 3 * (j / 3); l < (3 * (j / 3) + 3); l++)
                {
                    if (sudoku[k, l] != 0) count++;
                }
            return count;
        }

        //public static

        public static void findBest(int[,] sudoku, ReturnData rData)
        {
            int count = 0;
            int bestCount = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (sudoku[i, j] == 0)
                    {
                        count = findCol(sudoku, i, j) + findRow(sudoku, i, j) + findField(sudoku, i, j);
                        if (count > bestCount)
                        {
                            bestCount = count;
                            rData.i = i;
                            rData.j = j;
                        }
                    }
                }
        }


        public static void testRow(bool[] solveData, int[,] sudoku, int x, int y)
        {
            for (int i = 0; i < 9; i++)
                solveData[sudoku[x, i]] = true;
        }

        public static void testCol(bool[] solveData, int[,] sudoku, int x, int y)
        {
            for (int i = 0; i < 9; i++)
                solveData[sudoku[i, y]] = true;
        }

        public static void testField(bool[] solveData, int[,] sudoku, int x, int y)
        {
            for (int i = 3 * (x / 3); i < (3 * (x / 3) + 3); i++)
                for (int j = 3 * (y / 3); j < (3 * (y / 3) + 3); j++)
                {
                    //System.Console.Out.Write(i + "/" + j + " ");
                    solveData[sudoku[i, j]] = true;
                }
        }

        public static int[] testAll(int[,] sudoku, int x, int y)
        {
            bool[] solveData = new bool[] { false, false, false, false, false, false, false, false, false, false };

            int[] possibilities = new int[10];      //[0] anzahl        [1] 1. Möglichkeit      [2] 2. Möglichkeit ...

            testRow(solveData, sudoku, x, y);
            testCol(solveData, sudoku, x, y);
            testField(solveData, sudoku, x, y);

            for (int i = 0; i < 10; i++)
                if (solveData[i] == false)
                {
                    possibilities[0]++;
                    possibilities[possibilities[0]] = i;
                }

            return possibilities;
        }

        public static int[,] copySudoku(int[,] src)
        {
            int[,] dst = new int[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    dst[i, j] = src[i, j];
            return dst;
        }

        public static bool tryToPut(int[,] sudoku)
        {
            bool noSolution = true;
            int[] single = new int[3];
            
                for (int x = 0; x < 9; x += 3)
                    for (int y = 0; y < 9; y += 3)
                    {
                        for (int n = 0; n < 9; n++)
                        {
                            for (int i = 3 * (x / 3); i < (3 * (x / 3) + 3); i++)
                                for (int j = 3 * (y / 3); j < (3 * (y / 3) + 3); j++)
                                {
                                    if (sudoku[i, j] == 0)
                                        if (possible(sudoku, n, i, j))
                                        {
                                            single[0]++;
                                            single[1]=i;
                                            single[2]=j;
                                            //bei count>2 abbruch
                                        }
                                }
                            if(single[0]==1) sudoku[single[1],single[2]]=n;
                            if(single[0]==1) System.Console.Out.WriteLine("Found Number by exclusion");
                            if(single[0] == 1) noSolution = false;
                            single[0]=0;
                            single[1]=0;
                            single[2]=0;
                        }
                    }
                return noSolution;
        }

        public static bool possible(int[, ] sudoku, int n, int x, int y)
        {
            for(int line=0; line<9; line++)
                if(sudoku[line,y]==n) return false;

            for(int col=0; col<9; col++)
                if(sudoku[x,col]==n) return false;

            for (int i = 3 * (x / 3); i < (3 * (x / 3) + 3); i++)
                for (int j = 3 * (y / 3); j < (3 * (y / 3) + 3); j++)
                    if(sudoku[i,j]==n) return false;
            
            return true;
        }

        public static void FieldExclusion(int[,] sudoku, ReturnData rData)              //(c) by U. Landolt     //kann es n-1 orten nicht plaziert werden plaziere es am ort n-1    an zwei orten, dann nächstes
        {
            int[] exclusion = new int[] { -1, -1, -1 };        //anzahl, x, y


        

        }

        public static void solve(int[,] sudoku, ReturnData rData)
        {
            int[] resultList;
            int maxResults=99;

            bool noSolution2 = false;

            while (hasEmpty(sudoku) && !(rData.noSolution && noSolution2) && !rData.trap)
            {
                
                rData.noSolution = true;
                noSolution2 = tryToPut(sudoku);

                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (sudoku[i, j] == 0)                               //Feld nach Lerfelder durchsuchen und Möglichkeiten ermitteln
                        {
                            resultList = (testAll(sudoku, i, j));

                            if (resultList[0] == 0)
                            {
                                rData.trap = true;
                                System.Console.Out.WriteLine("Trap at: " + i + "/" + j);
                            }
                            
                            if (resultList[0] < 2)                      //wenn simpel lösbar
                            {
                                rData.noSolution = false;
                                sudoku[i, j] = resultList[1];
                            }
                            else
                            {
                                if (rData.resultList[0] > resultList[0])
                                {
                                    for (int k = 0; k < 10; k++) rData.resultList[k] = resultList[k];
                                    rData.i = i;
                                    rData.j = j;
                                }
                            }
                            //printSudoku(sudoku);
                        }


                    }
                //System.Threading.Thread.Sleep(100);
                System.Console.Out.WriteLine(rData.noSolution);
                //System.Console.Clear();
                printSudoku(sudoku);
            }
        }

        static void Main(string[] args)
        {
            
            //printSudoku(toSolve);
            //tryToPut(toSolve);
            //printSudoku(toSolve);
            //System.Console.In.Read();
            Tree myTree = new Tree(toSolve, 0, 0, toSolve[0, 0], 13);
            System.Console.Out.WriteLine(" -------RESULT-------");
            System.Console.Out.WriteLine(" ====================");

            System.Console.In.Read(); System.Console.In.Read();
        }

    }
}
