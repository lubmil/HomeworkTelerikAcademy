using System;
using System.Collections.Generic;
using System.Text;

public class Course
{
    public const byte MaxStudentsInCourse = 29;

    private string name;

    public Course(string name, IList<Student> students = null)
    {
        this.Students = new List<Student>();
        this.Name = name;
    }

    public List<Student> Students { get; set; }

    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (!String.IsNullOrEmpty(value))
            {
                this.name = value;
            }
            else
            {
                throw new ArgumentNullException("Name cannot be null!");
            }
        }
    }

    public void AddStudent(Student student)
    {
        bool studentExists = this.CheckIfStudentExists(student);

        if (studentExists)
        {
            throw new ArgumentException("This student exists!");
        }

        if (this.Students.Count + 1 <= MaxStudentsInCourse)
        {
            this.Students.Add(student);
        }
        else
        {
            throw new ArgumentOutOfRangeException("More students cannot be added because the course does not have free places!");
        }
    }

    public void RemoveStudent(Student student)
    {
        bool studentExists = this.CheckIfStudentExists(student);

        if (!studentExists)
        {
            throw new ArgumentException("The student cannot be removed because it does not exist!");
        }

        this.Students.Remove(student);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(string.Format("Course name:{0}\r\n", this.Name));

        for (int i = 0; i < this.Students.Count; i++)
        {
            result.Append(this.Students[i]);
            result.Append("\r\n");
        }

        return result.ToString();
    }

    private bool CheckIfStudentExists(Student student)
    {
        bool studentExists = false;
        for (int i = 0; i < this.Students.Count; i++)
        {
            if (this.Students[i].NumberID == student.NumberID)
            {
                studentExists = true;
            }
        }

        return studentExists;
    }
}