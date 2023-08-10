using System;
using HelloMessagesLib;
using LowLevelMathematicsLib;

namespace LessonOneALevel
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            HelloMessagesLib.HelloMessages.HelloMessageNameFunction();
            HelloMessagesLib.HelloMessages.HelloWorldFunction();
            LowLevelMathematicsLib.LowLevelMath.TwoPlusTwo();
            LowLevelMathematicsLib.LowLevelMath.TwoMinusTwo();

            Console.WriteLine("Enter any key to exit");
            Console.ReadKey(true);
        }
    }
}