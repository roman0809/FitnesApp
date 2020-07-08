using FitnesApp.CMD;
using FitnesAppBL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesAppBL.Controller
{
    class FitnesConntext:DbContext

    {
        public FitnesConntext() : base("DbConnection") { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }




    }
}
