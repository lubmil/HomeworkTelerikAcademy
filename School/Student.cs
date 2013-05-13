using System;

public class Student
{
    private string name;
    private int numberID;

    public Student(string name, int numberID)
    {
        this.Name = name;
        this.NumberID = numberID;
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (value != null && value != string.Empty)
            {
                this.name = value;
            }
            else
            {
                throw new ArgumentNullException("Name cannot be null!");
            }
        }
    }

    public int NumberID
    {
        get
        {
            return this.numberID;
        }

        set
        {
            if (value >= 10000 && value <= 99999)
            {
                this.numberID = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The ID number should be between 10000 and 99999!");
            }
        }
    }

    public override string ToString()
    {
        return string.Format("Student:{0}\r\nID:{1}", this.Name, this.NumberID);
    }
}