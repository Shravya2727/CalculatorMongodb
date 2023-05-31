using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMongodb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number: ");
            double firstNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            double secondNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter your choice(+, -, *, /): ");
            string operation= Console.ReadLine();


            //Make API Call
            CalculatorAPI calculatorAPI = new CalculatorAPI();
            double result = calculatorAPI.OperationPerform(firstNumber,secondNumber,operation);

            Console.WriteLine("Result: " +result);

            Console.ReadKey();
                

        }
    }
}
