using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FitnesAppBL.Model
{
     [Serializable]
    public class Food
    {
        public string Name { get; }
        
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жыры
        /// </summary>

        public double Fats { get; }
        /// <summary>
        /// углеводи
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// калории на 100 грам
        /// </summary>
        public double Calories { get; }

        private double CaloriesOneGram { get { return Calories / 100.0; } }
        private double ProteinsOneGram { get { return Proteins / 100.0; } }
        private double FatsOneGram { get { return Fats / 100.0; } }
        private double CarbohydratesOneGram { get { return Carbohydrates / 100.0; } }

        public Food (string name):this (name,0,0,0,0) { }
        
        public Food(string name,double calories,double proteins,double fats,double carbohydrate)
        {
            //TODO PROVERKA
            Name = name;
            Calories = calories/100.0;
            Proteins = proteins/100.0;
            Fats = fats/100.0;
            Carbohydrates = carbohydrate/100.0;


        }
        public override string ToString()
        {
            return Name;
        }



    }
}
