using FitnesAppBL.Controller;
using FitnesAppBL.Model;
using System;
using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices;

namespace FitnesApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourseManager = new ResourceManager("FitnesApp.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourseManager.GetString("Hallo",culture));

            Console.WriteLine(resourseManager.GetString("EnterName",culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate;
                double weight = ParseDouble("Вес");
                double height = ParseDouble("Рост");
                birthDate = ParseDateTime();

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            while (true)
            {

                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести прием пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выход ");


                var key = Console.ReadKey();

                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:

                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key}-{item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }

                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                }


                Console.ReadLine();
            }
        }

        private static (DateTime Begin,DateTime End,Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();
            var energy = ParseDouble("Росход енергии в минуту");
            var begin = ParseDateTime();
            var end = ParseDateTime();
            var activity = new Activity(name, energy);
            return (begin,end,activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, prots, fats, carbs);


            return (Food: product,Weight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату рождения (dd.mm.yyyy): ");
               if (DateTime.TryParse(Console.ReadLine(), out birthDate)) 
                {
                    break;
                }
               else
                {
                    Console.WriteLine("Неверный формат даты рождения");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while(true)
            {
                Console.WriteLine($"Введите {name}: ");
                if(double.TryParse(Console.ReadLine(),out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный фомат {name}");
                }
            }
        }
    }
}
