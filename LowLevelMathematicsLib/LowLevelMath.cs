namespace LowLevelMathematicsLib
{
    public class LowLevelMath
    {
        public static void TwoPlusTwo()
        {
            Console.WriteLine($"2 + 2 = {2 + 2}");
        }

        public static void TwoMinusTwo()
        {
            const int staticInt = 2;
            Console.WriteLine($"2 - 2 = {staticInt - staticInt}");
        }
    }
}