﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnesAppBL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnesAppBL.Model;

namespace FitnesAppBL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
      
        

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            string gender = "man";
            var weight = 70;
            var height = 180;
            var controller = new UserController(userName);

            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);

            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}