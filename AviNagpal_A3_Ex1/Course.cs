using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;


namespace AviNagpal_A3_Ex1
{
    class Course
    {
        public int courseId;
        public string courseName;
        public string courseSequence;
        Hashtable students = new Hashtable();

        public Course(int courseId, String courseName, String courseSequence)
        {
            this.courseId = courseId;
            this.courseName = courseName;
            this.courseSequence = courseSequence;
        }

        public void AddStudent(Student student)
        {
            students.Add(students.Keys, student);
        }
        
        public string GetCourseInfo()
        {
            string str = "courseId:" + courseId.ToString() + "\n course name:" + courseName + "\n course Sequence:" + courseSequence;
            return str;
        }
        public int getCourseId()
        {
            return this.courseId;
        }

        public String getCourseName()
        {
            return this.courseName;
        }

        public String getCourseSequence()
        {
            return this.courseSequence;
        }

        public int findStudent(Student p)
        {
            Student s = (Student)students[p.getStudentId()];
            if (s == null)
                return 0;

            return 1;
        }
    }
}
