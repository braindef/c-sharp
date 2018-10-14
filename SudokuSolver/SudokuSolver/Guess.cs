using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    class Guess
    {
        public int numbers;
        public int actualNumber;
        int[,] BackupSudoku;
        public System.Collections.ObjectModel.Collection<Guess> Children;

    }
}
