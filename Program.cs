using System;
using System.Threading;
using GetCursorState;

namespace TestCursor
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Press any key to exit...");
            while (!Console.KeyAvailable)
            {
                GetCursorState();
                Thread.Sleep(200); // 2000 milliseconds = 2 seconds
            }
        }

        private static void GetCursorState()
        {
            GetCursorStateMethods.CheckCursorType();
        }
    }
}
