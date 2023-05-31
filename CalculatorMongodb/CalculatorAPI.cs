
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CalculatorMongodb
{
    internal class CalculatorAPI
    {
        private readonly IMongoCollection<CalculationHistory> collection;


        public CalculatorAPI()
        {
            MongoClient client = new MongoClient("mongodb://127.0.0.1:27017");
            IMongoDatabase database = client.GetDatabase("calculatorMongoDB");
            collection = database.GetCollection<CalculationHistory>("history");

        }

        public double OperationPerform(double firstNumber, double secondNumber, string operation)
        {
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                default:
                    throw new ArgumentException("Enter valid operation");
                   

            }
            CalculationHistory history = new CalculationHistory
            {
                FirstNumber = firstNumber,
                SecondNumber = secondNumber,
                Operation = operation,
                Result = result,
                CreatedOn = DateTime.Now

            };

            collection.InsertOne(history);
            return result;
        }
    }

    class CalculationHistory
    { 
    public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Operation{ get; set; }
        public double Result { get; set; }
        public DateTime CreatedOn { get; set; }


    }
}
