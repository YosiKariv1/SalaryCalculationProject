using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Tests
{
    [TestClass()]
    public class EmployListFrameTests
    {
        [TestMethod()]
        public void CalculateTaxTest()
        {
            EmployListFrame employListFrame = new EmployListFrame();
            float SALARY = 32560;
            float BOX = employListFrame.CalculateTax(SALARY);
            SALARY = (SALARY * 35) / 100;
            Assert.AreEqual(SALARY, BOX);
        }

        [TestMethod()]
        public void BubbleSortTest()
        {
            EmployListFrame employListFrame = new EmployListFrame();
            MainProgramFrame mainProgramFrame = new MainProgramFrame();
            mainProgramFrame.AddAllEmploys();
            Assert.AreEqual(10000, MainProgramFrame.employs.Count);
            Assert.IsNotNull(MainProgramFrame.employs);
            Assert.IsFalse(employListFrame.sortCheck());
            Assert.AreNotEqual(9999, MainProgramFrame.employs.Count);
        }        
        
        [TestMethod()]
        public void QucikSortTest()
        {
            MainProgramFrame mainProgramFrame = new MainProgramFrame();
            EmployListFrame employListFrame = new EmployListFrame();
            mainProgramFrame.AddAllEmploys();
            employListFrame.QuickSort(0, MainProgramFrame.employs.Count - 1);
            Assert.AreEqual(10000, MainProgramFrame.employs.Count);
            Assert.IsNotNull (MainProgramFrame.employs);
            Assert.IsFalse (employListFrame.sortCheck());
            Assert.AreNotEqual(9999, MainProgramFrame.employs.Count);
        }
    }
}