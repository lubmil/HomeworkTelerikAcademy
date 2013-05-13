namespace TestSchool
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Course name cannot be null value")]
        public void CourseName_ThrowsExceptionWhenNull()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Course name cannot be empty")]
        public void CourseName_ThrowsExceptionWhenEmptyString()
        {
            Course course = new Course(String.Empty);
        }

        [TestMethod]
        public void Course_ConstructorTestName()
        {
            string name = "JavaScript";
            Course course = new Course(name);
            Assert.AreEqual(course.Name, "JavaScript");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Student does not exist")]
        public void Course_RemoveStudentThrowsExceptionOnNotFound()
        {
            Student student = new Student("Petar Ivanov", 10001);
            Course course = new Course(".NET");
            course.RemoveStudent(student);
        }

        [TestMethod]
        public void Course_TestAddingOfStudents()
        {
            string name = "Javascript";
            Student firstStudent = new Student("Angel Angelov", 10001);
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            course.AddStudent(firstStudent);
            Assert.IsTrue(course.Students.Contains(firstStudent));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Max count of students in course is reached")]
        public void Course_AddingStudentsOutOfMaxValue()
        {
            Course course = new Course(".NET");
            string name = "Ivan Ivanov";
            int numberID = 10000;
            
            for (int i = 0; i < Course.MaxStudentsInCourse + 2; i++)
            {
                Student student = new Student(name, numberID + i);
                course.AddStudent(student);
            }
        }

        [TestMethod]
        public void Course_AddingStudentsAtMaxValue()
        {
            Course course = new Course(".NET");
            string name = "Ivan Ivanov";
            int numberID = 10000;

            for (int i = 0; i < Course.MaxStudentsInCourse; i++)
            {
                Student student = new Student(name, numberID + i);
                course.AddStudent(student);
                Assert.IsTrue(course.Students.Contains(student));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot add a student twice in one course")]
        public void Course_AddSameStudentTwice()
        {
            string name = "Javascript";
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            Student firstStudent = new Student("Ivan Ivanov", 10001);
            course.AddStudent(firstStudent);
            course.AddStudent(firstStudent);
        }

        [TestMethod]
        public void Course_RemoveStudents()
        {
            Course course = new Course(".NET");
            string name = "Ivan Ivanov";
            int numberID = 10000;

            for (int i = 0; i < Course.MaxStudentsInCourse - 10; i++)
            {
                Student student = new Student(name, numberID + i);
                course.AddStudent(student);
            }

                course.RemoveStudent(new Student("Ivan Ivanov", 10002));
                Assert.IsFalse(course.Students.Contains(new Student("Ivan Ivanov", 10002)));
        }

        [TestMethod]
        public void Course_ToStringTestOfOneStudent()
        {
            string name = "Javascript";
            Student firstStudent = new Student("Ivan Ivanov", 10002);
            IList<Student> students = new List<Student>();
            Course javascriptCourse = new Course(name, students);
            javascriptCourse.AddStudent(firstStudent);
            string expected = "Course name:Javascript\r\nStudent:Ivan Ivanov\r\nID:10002\r\n";
            string actual;
            actual = javascriptCourse.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Course_ToStringTestOfTwoStudents()
        {
            string name = "Javascript";
            Student firstStudent = new Student("Ivan Ivanov", 10002);
            Student secondStudent = new Student("Ivan Ivanov", 10003);
            IList<Student> students = new List<Student>();
            Course javascriptCourse = new Course(name, students);
            javascriptCourse.AddStudent(firstStudent);
            javascriptCourse.AddStudent(secondStudent);
            string expected = "Course name:Javascript\r\nStudent:Ivan Ivanov\r\nID:10002\r\nStudent:Ivan Ivanov\r\nID:10003\r\n";
            string actual;
            actual = javascriptCourse.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
