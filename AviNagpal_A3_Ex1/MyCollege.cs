using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace AviNagpal_A3_Ex1
{
    public partial class MyCollege : Form
    {
        public MyCollege()
        {
            InitializeComponent();
        }

        ArrayList departments = new ArrayList();
        Hashtable courses = new Hashtable();
        Hashtable students = new Hashtable();


        private void button1_Click(object sender, EventArgs e)
        {
            String error = "";
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                error += "The field can't be empty.\n";

            }
            else
            {
                foreach (Department d in departments)
                {
                    if (d.getDepartmentId() == Convert.ToInt32(textBox1.Text))
                    {
                        error += "Department Id is unavailable\n";

                        break;
                    }
                }

                if (error == "")
                {
                    Department d1 = new Department(Convert.ToInt32(textBox1.Text), textBox2.Text);

                    departments.Add(d1);
                    String text = "Department " + textBox1.Text + " added";
                    MessageBox.Show(text);
                    comboBox1.Items.Add(textBox1.Text);
                }
                else
                {
                    MessageBox.Show(error);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
           if (textBox1.Text=="")
            {
                MessageBox.Show("Enter Department ID");
            }


            else          {
                textBox7.Text = "";

                // search department in ArrayList
                foreach (Department dept in departments)
                {
                    if (dept.getDepartmentId() == (Convert.ToInt32(textBox1.Text)))
                    {
                        Hashtable c = dept.getCourses();
                        foreach (Course course in c.Values)
                        {
                            textBox7.Text = textBox7.Text +"\n"+ course.getCourseId();
                        }
                       
                    }
                }

                if (textBox7.Text=="")
                {
                    MessageBox.Show("Department not found.");
                }
            }
        
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String error = "";
            if (textBox9.Text.Equals("") || textBox10.Text.Equals("") || textBox11.Text.Equals("") || textBox12.Text.Equals(""))
            {
                error += "The field can't be empty.\n";
            }
            else
            {
                foreach (Student s in students)
                {
                    if (s.getStudentId() == Convert.ToInt32(textBox11.Text))
                    {
                        error += "\n-Student Id Already exists.";
                        break;
                    }

                }
                if (error == "")
                {
                    Student s1 = new Student(Convert.ToInt32(textBox11.Text), textBox10.Text, textBox12.Text, textBox9.Text);
                    students.Add(s1.getStudentId(), s1);
                    String text = "Student " + textBox11.Text + " added";
                    MessageBox.Show(text);

                }
                else
                {
                    MessageBox.Show(error);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string message="";
            string id = (textBox11.Text);
            if (id == "")
                MessageBox.Show("Enter student ID ");
            else
            {

                if (students.ContainsKey((Convert.ToInt32(textBox11.Text))))
                {
                    Student s = (Student)students[(Convert.ToInt32(textBox11.Text))];
                    message += "First Name: " + s.getFirstName() + "\n";
                    message += "Last Name: " + s.getLastName() + "\n";
                    message += "Email: " + s.getEmail() + "\n";
                    MessageBox.Show(message);
                }
                else
                    MessageBox.Show("Course not found");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String error = "";
            if (textBox6.Text.Equals("") || comboBox2.SelectedIndex < 0)
            {
                error += "The field can't be empty.\n";
            }


            if (error == "")
            {
                foreach (Course c in courses.Values)
                {
                    if (c.getCourseId() == Convert.ToInt32(comboBox2.SelectedItem.ToString()))
                    {

                        Student s = (Student)students[Convert.ToInt32(textBox6.Text)];
                        if (s == null)
                        {
                            MessageBox.Show("Student not found.");
                            break;

                        }

                        if (c.findStudent(s) == 1)
                        {
                            MessageBox.Show("Student already exists.");
                        }

                        if (c.findStudent(s) == 0)
                        {

                            c.AddStudent(s);
                            MessageBox.Show("Student: " + s.getFirstName() + " " + s.getLastName() + " added into course: " + c.getCourseName());

                        }


                    }


                }
            }
        }





        private void button2_Click(object sender, EventArgs e)
        {
            String error = "";
            if (textBox4.Text.Equals("") || textBox3.Text.Equals("") || textBox5.Text.Equals(""))
            {
                error += "The field can't be empty.\n";
                MessageBox.Show(error);
            }
            else
            {
                foreach (String course in courses.Keys)
                {
                    if (course == textBox4.Text)
                    {
                        error += "Course Id alerady exists\n";
                        MessageBox.Show(error);
                    }
                }
                if (error == "")
                {
                    Course c1 = new Course(Convert.ToInt32(textBox4.Text), textBox3.Text, textBox5.Text);


                    courses.Add(c1.getCourseId(), c1);
                    String text = "Course " + textBox4.Text + " added";
                    MessageBox.Show(text);
                    comboBox2.Items.Add(textBox4.Text);
                    comboBox3.Items.Add(textBox4.Text);
                }
                else
                {
                    MessageBox.Show(error);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message="";
            if (textBox4.Text == "")
                MessageBox.Show("Course ID must be entered");
            else
            {

                if (courses.ContainsKey((Convert.ToInt32(textBox4.Text))))
                {
                    Course c = (Course)courses[(Convert.ToInt32(textBox4.Text))];
                    message += "Name: " + c.getCourseName() + "\n";
                    message += "Sequence: " + c.getCourseSequence() + "\n";
                   
                    MessageBox.Show(message);
                }
                else
                    MessageBox.Show("Course not found");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String error = "";
            if (comboBox3.SelectedIndex < 0 || comboBox1.SelectedIndex < 0)
            {
                error += "The field can't be empty.\n";
                MessageBox.Show("Error");
            }


            else
            {
                foreach (Department dept in departments)
                {

                    if (dept.getDepartmentId() == (Convert.ToInt32(comboBox1.SelectedItem.ToString())))
                    {

                        Course c = (Course)courses[(Convert.ToInt32(comboBox3.SelectedItem.ToString()))];
                        if (c == null)
                            {
                                MessageBox.Show("Course not found");
                            }
                        
                        else
                        {
                            if (dept.findCourse(c) == 1)
                            {
                                MessageBox.Show("Course already exists.");
                            }
                            else
                            {
                                dept.AddCourse(c);
                                MessageBox.Show("course: " + c.getCourseName() + " added into department: " + dept.getDepartmentName());
                            }

                        }
                        break;

                    }
                    else
                    {
                        MessageBox.Show("Department not available");
                    }
                }
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void MyCollege_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            foreach (Department dept in departments)
            {
                comboBox1.Items.Add(dept.getDepartmentId());
            }
        }
        private void comboBox2_Enter(object sender, EventArgs e)
        {
            Course c;
            foreach (DictionaryEntry de in courses)
            {
                c = (Course)de.Value;
                comboBox2.Items.Add(c.getCourseId());
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
