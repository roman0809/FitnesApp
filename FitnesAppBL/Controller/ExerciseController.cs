using FitnesApp.CMD;
using FitnesAppBL.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesAppBL.Controller
{
    public class ExerciseController:ControllerBase
    {
        
        private readonly User user;

        public List<Exercise> Exercises;
        public List<Activity> Activities;



        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }
        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if(act==null)
            {

                var exercice = new Exercise(begin, end, activity, user);
                Exercises.Add(exercice);
                Activities.Add(activity);

            }
            else
            {
                var exercice = new Exercise(begin, end, act, user);
                Exercises.Add(exercice);
            }
            Save();
        }
        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }
        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }

    }
}
