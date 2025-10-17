using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal static class GuessGame
    {
        public static int Attempts = 1;
        public static double Answer;
        public static int A;
        public static int B;
        public static bool IsAnswerCorrect;

        public static bool _isFilled;
       // public static bool IsFilled { set { _isFilled = IsFilled; } get { return _isFilled; } }
       // public static int Attempts { set { _attempts = Attempts; } get { return _attempts; } }
       // public static double Answer { set { _answer = Answer; } get { return _answer; } }

        public static void CalculateFunction()
        {
            Answer = -4 * Math.Pow(Math.Sin(3 * A), 3) + (Math.Sqrt(B) / Math.Log(B + 2));

        }
        /*
        public static bool IsTextBoxsFilled()
        {
            if(A != 0 && B != 0 && _attempts != 1)
            {
                return true;
            }
            return false;
        }
        */

        public static void Restart()
        {
          IsAnswerCorrect = false;
            A = 0;
            B = 0;
            
            
        }
        
        
        
    }
}
