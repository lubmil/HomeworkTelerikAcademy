namespace TestSchool
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Course cannot be added, because it already exists")]
        public void AddCourse_ThrowsExceptionWhenCourseAlreadyExists() 
        {
            School school = new School();

            school.AddCourse(new Course(".NET"));
            school.AddCourse(new Course("PHP"));
            school.AddCourse(new Course("Java"));
            school.AddCourse(new Course(".NET"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Course cannot be removed, because it does not exists")]
        public void RemoveCourse_ThrowsExceptionWhenCourseDoesNotExists()
        {
            School school = new School();

            school.AddCourse(new Course(".NET"));
            school.AddCourse(new Course("PHP"));
            school.AddCourse(new Course("Java"));

            school.RemoveCourse(new Course("HTML5"));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Course cannot be removed, because it does not exists")]
        public void RemoveCourse_ThrowsExceptionWhenRemoveNullValue()
        {
            School school = new School();

            school.AddCourse(new Course(".NET"));
            school.AddCourse(new Course("PHP"));
            school.AddCourse(new Course("Java"));

            school.RemoveCourse(null);
        }

        [TestMethod]
        public void RemoveCourse_RemoveOneCourse()
        {
            School school = new School();

            school.AddCourse(new Course(".NET"));
            school.AddCourse(new Course("PHP"));
            school.AddCourse(new Course("Java"));

            school.RemoveCourse(new Course(".NET"));
            Assert.IsFalse(school.Courses.Contains(new Course((".NET"))));
        }

        [TestMethod]
        public void AddCourseTest()
        {
            List<Course> courses = new List<Course>();
            Course javascript = new Course("Javascript");
            School school = new School(courses);
            school.AddCourse(javascript);
            Assert.AreEqual(javascript.Name, school.Courses[0].Name);
        }
    }
}
