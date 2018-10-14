using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SudokuSolver
{
    class sudokuGenerator
    {


        /*    static int[,] toSolve = new int[,] {    {1, 2, 3, 4, 5, 6, 7, 8, 9},        
                                                    {4, 5, 6, 7, 8, 9, 1, 2, 3},            //mitte 2. Zeile ist 3 weil 1. und 3. zeile schon 3 ist
                                                    {7, 8, 9, 1, 2, 3, 4, 5, 6},
                                                    {2, 3, 4, 5, 6, 7, 8, 9, 1},
                                                    {5, 6, 7, 8, 9, 1, 2, 3, 4},
                                                    {8, 9, 1, 2, 3, 4, 5, 6, 7},
                                                    {3, 4, 5, 6, 7, 8, 9, 1, 2},
                                                    {6, 7, 8, 9, 1, 2, 3, 4, 5},
                                                    {9, 1, 2, 3, 4, 5, 6, 7, 8}     };      */

        static int[,] toSolve = new int[,] {    {8, 2, 4, 9, 6, 1, 3, 5, 7},
                                                {9, 6, 1, 3, 5, 7, 8, 2, 4},
                                                {3, 5, 7, 8, 2, 4, 9, 6, 1},
                                                {2, 4, 9, 6, 1, 3, 5, 7, 8},
                                                {6, 1, 3, 5, 7, 8, 2, 4, 9},
                                                {5, 7, 8, 2, 4, 9, 6, 1, 3},
                                                {4, 9, 6, 1, 3, 5, 7, 8, 2},
                                                {1, 3, 5, 7, 8, 2, 4, 9, 6},
                                                {7, 8, 2, 4, 9, 6, 1, 3, 5} };




        public static void printSudoku(int[,] sudoku)
        {
            System.Console.Out.WriteLine();
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

        public static int[,] generateSudoku()
        {
            Random rand = new Random();
            int[] numbers = new int[9];
            int src = 0;
            int dst = 0;
            int temp = 0;

            for (int i = 0; i < 9; i++) numbers[i] = i + 1;

            for (int i = 0; i < 10; i++)
            {
                src = rand.Next(9);
                dst = rand.Next(9);

                temp = numbers[dst];
                numbers[dst] = numbers[src];
                numbers[src] = temp;
            }

            for (int i = 0; i < 9; i++) System.Console.Out.WriteLine(numbers[i]);

            int[,] sudoku = new int[9, 9];


            for (int h = 0; h < 3; h++)
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 9; j++)
                        sudoku[j, h * 3 + i] = numbers[(3 * i + j + h) % 9];


            return sudoku;
        }

        public static bool testSudoku(int[,] sudoku)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    System.Console.Out.WriteLine("TESTING ROW");
                    for (int k = 0; k < 9; k++)                                      //Zeile Prüfen
                        if (sudoku[k, j] == sudoku[i, j] && i != k) return false;
                    System.Console.Out.WriteLine("TESTING COL");
                    for (int k = 0; k < 9; k++)                                      //Spalte Prüfen
                        if (sudoku[i, k] == sudoku[i, j] && j != k) return false;
                    System.Console.Out.WriteLine("TESTING Field");
                    for (int k = 3 * (i / 3); k < 3 * (i / 3) + 3; k++)
                        for (int l = 3 * (j / 3); l < 3 * (j / 3) + 3; l++)
                            if (sudoku[i, j] == sudoku[k, l] && (i != k) && (j != l)) return false;
                }
            return true;
        }

        public static void mixRow(int[,] sudoku, int row, bool vertically)
        {
            int temp = 0; ;

            if (vertically)
            {
                System.Console.Out.WriteLine("mixing Vertically");
                if (row == 0 || row == 3 || row == 6 || row == 1 || row == 4 || row == 7)
                    for (int i = 0; i < 9; i++)
                    {
                        temp = sudoku[row + 1, i];
                        sudoku[row + 1, i] = sudoku[row, i];
                        sudoku[row, i] = temp;
                    }

                if (row == 2 || row == 5 || row == 8)
                    for (int i = 0; i < 9; i++)
                    {
                        temp = sudoku[row - 2, i];
                        sudoku[row - 2, i] = sudoku[row, i];
                        sudoku[row, i] = temp;
                    }
            }
            else
            {
                System.Console.Out.WriteLine("mixing Not Vertically");
                if (row == 0 || row == 3 || row == 6 || row == 1 || row == 4 || row == 7)
                    for (int i = 0; i < 9; i++)
                    {
                        temp = sudoku[i, row + 1];
                        sudoku[i, row + 1] = sudoku[i, row];
                        sudoku[i, row] = temp;
                    }

                if (row == 2 || row == 5 || row == 8)
                    for (int i = 0; i < 9; i++)
                    {
                        temp = sudoku[i, row - 2];
                        sudoku[i, row - 2] = sudoku[i, row];
                        sudoku[i, row] = temp;
                    }
            }
        }

        public static void remove(int[,] sudoku, int i, int j)
        {
            int[] numbers = new int[9];

            bool[] rowNumbers = testRow(sudoku, i, j);
            bool[] colNumbers = testCol(sudoku, i, j);
            bool[] fieldNumbers = testField(sudoku, i, j);
            bool remove = true;

            for (int n = 0; n < 9; n++)
            {

                if (rowNumbers[n] || colNumbers[n] || fieldNumbers[n])
                    continue;
                return;
            }

            sudoku[i, j] = 0;
        }

        public static bool[] testRow(int[,] sudoku, int x, int y)
        {
            bool[] solveData = new bool[9];
            for (int i = 0; i < 9; i++)
                if (sudoku[x, i] != 0) solveData[sudoku[x, i] - 1] = true;
            return solveData;
        }

        public static bool[] testCol(int[,] sudoku, int x, int y)
        {
            bool[] solveData = new bool[9];
            for (int i = 0; i < 9; i++)
                if (sudoku[i, y] != 0) solveData[sudoku[i, y] - 1] = true;
            return solveData;
        }

        public static bool[] testField(int[,] sudoku, int x, int y)
        {
            bool[] solveData = new bool[9];
            for (int i = 3 * (x / 3); i < (3 * (x / 3) + 3); i++)
                for (int j = 3 * (y / 3); j < (3 * (y / 3) + 3); j++)
                {
                    //System.Console.Out.Write(i + "/" + j + " ");
                    if (sudoku[i, j] != 0) solveData[sudoku[i, j] - 1] = true;
                }
            return solveData;
        }


        public static void removeNumbers(int[,] sudoku)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (sudoku[i, j] != 0) remove(sudoku, i, j);


        }

        static void Main(string[] args)
        {
            
            Random rand = new Random();

            int[,] sudoku = generateSudoku();
            //System.Console.Out.WriteLine(testSudoku(sudoku));
            
            //printSudoku(sudoku);
            //System.Console.Out.WriteLine("Generate, test, print");
            //System.Console.In.Read();

            for (int i = 0; i < 900; i++)
                if (i % 3 != 1) mixRow(sudoku, i, rand.Next() % 2 == 0);

            printSudoku(sudoku);
            System.Console.Out.WriteLine("mixed");
            int[,] actualSolution = Tree.copySudoku(sudoku);
            //System.Console.Out.WriteLine(testSudoku(sudoku));
            //printSudoku(sudoku);
            removeNumbers(sudoku);
            //System.Console.Out.WriteLine("REMOVED");
            
            printSudoku(sudoku);
            //printSudoku(actualSolution);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Eingabemaske(sudoku,actualSolution));
            
            Tree myTree = new Tree(sudoku, 0, 0, sudoku[0, 0], 13);
            removeNumbers(sudoku);
            printSudoku(sudoku);

            
            
            System.Console.In.Read();
        }
    }
}
