using FitnesApp.CMD;
using FitnesAppBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesAppBL.Controller
{
    class DataBaseDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T:class
        {
            using(var db= new FitnesConntext())
            {
                var result = db.Set<T>().Where(t => true).ToList();
                return result;
            }
        }

        public List<T> Load<T>(string fileName) where T : class
        {
            throw new NotImplementedException();
        }

        public void Save<T>(List<T> item)where T:class
        {
            using(var db=new FitnesConntext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
