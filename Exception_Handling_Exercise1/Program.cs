using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling_Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your age?");

            bool validAnswer = false;
            int userAge = 0;
            var today = DateTime.Now.Year;

            while (!validAnswer)
            {
                try
                {
                    validAnswer = int.TryParse(Console.ReadLine(), out userAge);
                    if (userAge <= 0)
                    {
                        throw new OtherException();
                    }
                    if (!validAnswer)
                    {
                        throw new Exception();
                    }
                }
                catch (OtherException)
                {
                    Console.WriteLine("Are you really a newborn or not born yet?");
                    Console.ReadLine();
                    return;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter whole numbers only.");
                    Console.ReadLine();
                    return;
                }
            }

            var yearBorn = today - userAge;
            Console.WriteLine("You were probably born in the year {0}.", yearBorn);
            Console.ReadLine();
        }

        public class OtherException : Exception
        {
            public OtherException()
                : base() { }

            public OtherException(string message)
                : base(message) { }
        }
    }
}
