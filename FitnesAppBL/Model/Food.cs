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
        public int Id { get; set; }

        public string Name { get; set; }
        
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жыры
        /// </summary>

        public double Fats { get; set; }
        /// <summary>
        /// углеводи
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// калории на 100 грам
        /// </summary>
        public double Calories { get; set; }

        private double CaloriesOneGram { get { return Calories / 100.0; } }
        private double ProteinsOneGram { get { return Proteins / 100.0; } }
        private double FatsOneGram { get { return Fats / 100.0; } }
        private double CarbohydratesOneGram { get { return Carbohydrates / 100.0; } }

        public virtual ICollection<Eating> Eatings { get; set; }

        public Food() { }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name,double calories,double proteins,double fats,double carbohydrate)
        {
            #region Проверка
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым или равен null", nameof(name));
            }
            if (calories <= 0)
            {
                throw new ArgumentNullException("Калорийность не мжет быть равен иле меньше null", nameof(calories));
            }
            if (proteins <= 0)
            {
                throw new ArgumentNullException("Количество билков не мжет быть равено иле меньше null", nameof(proteins));
            }
            if (fats <= 0)
            {
                throw new ArgumentNullException("Количество жиров не мжет быть равено иле меньше null", nameof(fats));
            }
            if (carbohydrate <= 0)
            {
                throw new ArgumentNullException("Количество углеводов не мжет быть равено иле меньше null", nameof(carbohydrate));
            }
            #endregion

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
