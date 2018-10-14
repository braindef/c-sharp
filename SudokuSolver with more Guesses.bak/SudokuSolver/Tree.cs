using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    class Tree
    {
        public static Tree Pointer;

        public Tree Parent;
        public Tree[] Children;
        public int nextChild = 0;
        public int nextNumber;
        public ReturnData ParentrData;

        public int[,] ParentBackup;

        public Tree()
        {
            this.Parent = this;
        }

        public Tree(Tree Parent, int nextNumber)
        {
            this.Parent=Parent;
            this.nextNumber=nextNumber;
        }

        public void newLimb(Tree Parent, int[] resultList)
        {
            System.Console.Out.WriteLine("Children: " + resultList[0]);
            System.Threading.Thread.Sleep(2000);
            this.Children = new Tree[resultList[0]];
            for (int i = 0; i < resultList[0]; i++)
                this.Children[i] = new Tree(this, resultList[i+1]);         //hier fehler, die fiesen kleinen details (+1) womit klar wäre, dass man mit klassen und benennung besser fährt... (dauert zwar länger zum erstellen, ist dann jedoch viel weniger fehleranfällig)
        }
    }
}
