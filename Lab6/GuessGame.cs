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
        private static int _attempts = 1;
        private static double _answer;
        private static bool _isFilled;
        private static int _time = 60;
        public static int A;
        public static int B;
       

        public static bool IsRestart;
        public static bool IsAnswerCorrect;

       
       public static bool IsFilled { set { _isFilled = value; } get { return _isFilled; } }
        public static int Time { get { return _time; } }
       public static int Attempts { set { _attempts = value; } get { return _attempts; } }
       public static double Answer { set { _answer = value; } get { return _answer; } }

        public static void CalculateFunction()
        {
            Answer = -4 * Math.Pow(Math.Sin(3 * A), 3) + (Math.Sqrt(B) / Math.Log(B + 2));

        }
        public static void Tick()
        {
            _time--;
        }
        public static void Restart()
        {
           IsAnswerCorrect = false;
            IsFilled = false;
            IsRestart = true;
            A = 0;
            B = 0;
            _time = 60;
            
        }
        
        
        
    }
}
