using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    class ReturnData
    {
        public int i;
        public int j;
        public bool noSolution;
        public bool Reload;
        public bool solved;
        public int[] resultList;

        
        public ReturnData()
        {
            Reset();
        }

        public void Reset()
        {
            i = 99;
            j = 99;
            noSolution = false;
            Reload = false;
            resultList = new int[] { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 };
            solved = false;
        }

        public static ReturnData copy(ReturnData src)
        {
            ReturnData dst = new ReturnData();
            dst.i = src.i;
            dst.j = src.j;
            dst.noSolution = src.noSolution;
            dst.Reload = src.Reload;
            dst.resultList = src.resultList;
            dst.solved = src.solved;

            return dst;
        }
        
    }
}
