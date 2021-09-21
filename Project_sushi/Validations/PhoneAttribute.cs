using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_sushi.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneAttribute : Attribute
    {
        public int NumberLength { get; set; }
        public bool CheckNumber(string value)
        {
            if (value.Length != NumberLength)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Номер телефона должен состоять из 9 цифр");
                Console.WriteLine(String.Empty);
                Console.ResetColor();
                return false;
            }
            return OnlyDigitsCheck(value);
        }
          public bool OnlyDigitsCheck (string value)
        {
            foreach (char symbol in value)
                if (char.IsLetter(symbol))

                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Номер телефона должен состоять только из цифр");
                    Console.ResetColor();
                    Console.WriteLine(String.Empty);
                    return false;
                }
             return true;
        }
    }
}
