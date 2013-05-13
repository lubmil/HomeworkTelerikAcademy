using System;
using System.Collections.Generic;

public class School
{
    public School(List<Course> courses = null)
    {
        this.Courses = new List<Course>();
    }

    public List<Course> Courses { get; set; }

    public void AddCourse(Course course)
    {
        bool courseExists = false;
        for (int i = 0; i < this.Courses.Count; i++)
        {
            if (this.Courses[i].Name == course.Name)
            {
                courseExists = true;
            }
        }

        if (!courseExists)
        {
            this.Courses.Add(course); 
        }
        else
        {
            throw new ArgumentException("The course cannot be removed because it already exists!");
        }
    }

    public void RemoveCourse(Course course)
    {
        bool courseExists = false;
        for (int i = 0; i < this.Courses.Count; i++)
        {
            if (this.Courses[i].Name == course.Name)
            {
                courseExists = true;
                this.Courses.Remove(course);
            }
        }

        if (!courseExists)
        {
            throw new ArgumentException("The course cannot be removed because it does not exists!");
        }
    }
}
