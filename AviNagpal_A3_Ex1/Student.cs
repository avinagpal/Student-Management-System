using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace AviNagpal_A3_Ex1
{
    class Student
    {
        public int studentID;
        public string firstName;
        public string lastName;
        public string email;
        public Hashtable courses = new Hashtable();

        public Student(int studentId, String firstName, String lastName, String email)
        {
            this.studentID = studentId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }
        public void RegisterCourse(Course course)
        {
            courses.Add(courses.Keys, course);
        }

        public string GetStudentInfo()
        {
            string String = "studentId:" + studentID.ToString() + "\n first name:" + firstName + "\n  Last name:" + lastName + "\n email" + email;
            return String;
        }
        public int getStudentId()
        {
            return this.studentID;
        }

        public String getFirstName()
        {
            return this.firstName;
        }

        public String getLastName()
        {
            return this.lastName;
        }

        public String getEmail()
        {
            return this.email;
        }
    }
}
