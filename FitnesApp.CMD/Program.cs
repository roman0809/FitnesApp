﻿using FitnesAppBL.Controller;
using System;


namespace FitnesApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует прилодение FitnesApp");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if(userController.IsNewUser)
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
            Console.ReadLine();
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
