using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesAppBL.Model
{/// <summary>
/// Пользователь.
/// </summary>

    [Serializable]
    public class User
    {
        #region Свойства
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Пол.
        /// </summary>
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        /// <summary>
        /// День рождения.
        /// </summary>

        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес.
        /// </summary>

        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>

        public double Height { get; set; }

        public virtual ICollection<Eating> Eatings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        
        #endregion
        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public User(string name, Gender gender, DateTime birthDate, double weight,double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым или равен null",nameof(name));
            }
            if(gender==null)
            {
                throw new ArgumentNullException(" Пол не может быть равен null",nameof(gender));
            }
            if (birthDate<DateTime.Parse("01.01.1900")|| birthDate>=DateTime.Now)
            {
                throw new ArgumentException("Невозмжно опредилить дату рождения", nameof(birthDate));
            }
            if(weight<=0)
            {
                throw new ArgumentNullException("Вес не мжет быть равен иле меньше null", nameof(weight));
            }
            if(height<=0)
            {
                throw new ArgumentNullException("Рост не мжет быть равен иле меньше null", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;

        }
        public User() { }

        public User(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или раным null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name+" "+ Age;
        }

    }
}
