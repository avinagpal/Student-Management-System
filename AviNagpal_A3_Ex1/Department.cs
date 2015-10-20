using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace AviNagpal_A3_Ex1
{
    class Department
    {
        public int departmentId;
        public string departmentName;
        public Hashtable courses = new Hashtable();
        public static ArrayList department = new ArrayList();

        public Department(int departmentId, String departmentName)
        {
            this.departmentId = departmentId;
            this.departmentName = departmentName;
        }

        public void AddCourse(Course course)
        {
            
            courses.Add(courses.Keys, course);
        }
        public string FindCourse(Course course)
        {
            string str = "not found";

            foreach (Course c in this.courses)
            {
                if (c == course)
                    str = "found";
                break;

            }
            return str;
        }
        //public string FindCoursesBySequence(string name)
        //{

        //}
        //public string GetDepartmentInfo()
        //{

        //}
        public int findCourse(Course course)
        {

            
            if (courses.ContainsKey(course.getCourseId()))
                return 1;
            else
                return 0;
            
        }


        // getting course by sequence
        public String findCourseBySequence(String name)
        {
            return "";

        }

        // getters for department
        public int getDepartmentId()
        {
            return this.departmentId;
        }

        public String getDepartmentName()
        {
            return this.departmentName;
        }

        public Hashtable getCourses()
        {
            return this.courses;
        }
    }
}
