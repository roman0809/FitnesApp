﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitnesAppBL.Controller
{
   public abstract class ControllerBase
    {
        protected IDataSaver manager = new SerializeDataSaver();

        protected void Save<T>(List<T> item) where T:class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T:class
        {
            return manager.Load<T>();
           
        }


    }
}
