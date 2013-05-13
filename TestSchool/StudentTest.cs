namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name cannot be empty")]
        public void StudentName_ThrowExceptionForEmptyString()
        {
            string name = string.Empty;
            int numberID = 10001;
            Student student = new Student(name, numberID);
        }

        [ExpectedException(typeof(ArgumentNullException), "Name cannot be null value")]
        public void StudentName_ThrowExceptionForNull()
        {
            string name = null;
            int numberID = 10001;
            Student student = new Student(name, numberID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Student ID not in range (10000;99999)")]
        public void StudentID_ThrowExceptionForNumberIsBelowRange()
        {
            string name = "Maria";
            int numberID = 9999;
            Student student = new Student(name, numberID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Student ID not in range (10000;99999)")]
        public void StudentID_ThrowExceptionForNumberIsOutRange()
        {
            string name = "Maria";
            int numberID = 100000;
            Student student = new Student(name, numberID);
        }

        [TestMethod]
        public void Student_ToStringTest()
        {
            string name = "Ivan Ivanov";
            int numberID = 10001;
            Student student = new Student(name, numberID);
            string expected = "Student:Ivan Ivanov\r\nID:10001";
            string actual;
            actual = student.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
