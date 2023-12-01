using System;

namespace Program
{
    internal class Program
    {
        private static void CheckLength(string[] number)
        {
            if (number.Length != 2)
            {
                throw new FormatException("Введiть два числа через пробiл!");
            }
        }
        
        public static void Main()
        {
            Console.Write("Перший дрiб:\nВведiть чисельник та знаменник другого дробу через пробiл: ");
            string[] firstFraction = Console.ReadLine().Trim().Split();

            CheckLength(firstFraction);
            
            int firstNumerator = Convert.ToInt32(firstFraction[0]);
            int firstDenominator = Convert.ToInt32(firstFraction[1]);
            
            MyFrac fracOfFirst = new MyFrac(firstNumerator, firstDenominator);
            
            Console.Write("\nДругий дрiб:\nВведiть чисельник та знаменник другого дробу через пробiл: ");
            string[] secondFraction = Console.ReadLine().Trim().Split();
            
            CheckLength(secondFraction);

            int secondNumerator = Convert.ToInt32(secondFraction[0]);
            int secondDenominator = Convert.ToInt32(secondFraction[1]);
            
            MyFrac fracOfSecond = new MyFrac(secondNumerator, secondDenominator);
            
            Console.WriteLine($"\nДрiб з цiлою частиною:{fracOfFirst.ToStringWithIntegerPart()}");
            Console.WriteLine($"Десяткове значення дробу: {fracOfFirst.DoubleValue()}");
            Console.WriteLine($"Додавання дробiв: {fracOfFirst.Plus(fracOfSecond)}");
            Console.WriteLine($"Вiднiмання дробiв: {fracOfFirst.Minus(fracOfSecond)}");
            Console.WriteLine($"Множення дробiв: {fracOfFirst.Multiply(fracOfSecond)}");
            Console.WriteLine($"Дiлення дробiв: {fracOfFirst.Divide(fracOfSecond)}");
            Console.WriteLine($"Сума першого ряду дробiв (10 членiв): {fracOfFirst.CalcSumFirst(10)}");
            Console.WriteLine($"Сума другого ряду дробiв (10 членiв): {fracOfFirst.CalcSumSecond(10)}");
        }
    }
}