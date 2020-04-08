using System;

namespace Kovaleva_lab_sem6
{
    public class NumberSign
    {
        public NumberSign(int R1, int R2)
        {
            this.R1 = R1;
            this.R2 = R2;
        }

        public int R1 { get; }

        public int R2 { get; }

        public bool Checker(int testR1, int testR2)
        {
            if (R1 == testR1 && R2 == testR2)
                return true;
            else
                return false;
        }

        public int CalculateDelta(int R)
        {
            int delta;
            if (R == 1)
                delta = 1;
            else
                delta = -1;
            return delta;
        }
    }
}
