using Project_sushi.Enums;
using Project_sushi.Validations;
using System;

namespace Project_sushi
{
    public class Client
    {
        public delegate void ComplaintHandler();
        public event ComplaintHandler Notify;              // Определение события

        static FeedbackScore _clientScore;
        public string Name { get; set; }
        public string Email { get; set; }
        [Phone(NumberLength = 9)]
        public string PhoneNumber { get; set; }
        public FeedbackScore ClientScore
        {
            get { return _clientScore; }
            set
            {
                if (Enum.IsDefined(typeof(FeedbackScore), value))
                {
                    _clientScore = value;
                }
                else
                {
                    _clientScore = default;
                }
            }
        }
        public void Introduction()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Greetings.ShowTimeOfTheDay();
            Console.WriteLine("Как Вас зовут?");
            Console.ResetColor();
            Name = Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Name + ", Сделайте Ваш Заказ. Ниже перечень и стоимость в BYN:");
            Console.ResetColor();
        }

        public void EnterPhoneNumber()
        {
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Введите свой номер телефона: +375");
            Console.ResetColor();
            PhoneNumber = Console.ReadLine();
        }

        public void InputFeedback()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Пожалуйста, оцените работу сервиса от 1 до 5 (где 1 - очень плохо, 5 - отлично):");
            Console.ResetColor();
            string ClientScoreInput = Console.ReadLine();
            try
            {
                ClientScore = (FeedbackScore)Enum.Parse(typeof(FeedbackScore), ClientScoreInput);
            }
            catch (Exception)
            {
                ClientScore = default;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Вы оценили нашу работу как '{ClientScore}'.");

            switch (ClientScore)
            {
                case FeedbackScore.Ужасно:
                case FeedbackScore.Плохо:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Нам очень жаль.С Вами свяжется оператор, чтобы урегулировать ситуацию.");
                    Console.ResetColor();
                    Notify?.Invoke();
                    break;

                case FeedbackScore.Нормально:
                    Console.WriteLine($"Спасибо за честный отзыв.");
                    break;
                case FeedbackScore.Хорошо:
                case FeedbackScore.Отлично:
                    Console.WriteLine($"Спасибо, что воспользовались нашей службой. Ждем Ваших слудующих заказов!");
                    break;
            }
            Console.ResetColor();
        }
       

    }
}
