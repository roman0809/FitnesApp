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
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingConroller = new EatingController(userController.CurrentUser);
            var food = new Food (foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            // Act
            eatingConroller.Add(food, 100);

            // Assert
            Assert.AreEqual(food.Name, eatingConroller.Eating.Foods.First().Key.Name);
       
        }

       
    }
}