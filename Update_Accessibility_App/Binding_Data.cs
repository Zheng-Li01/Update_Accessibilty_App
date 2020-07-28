﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace Update_Accessibility_App
{
    public partial class Binding_Data : Form
    {
        List<Student> studentA = new List<Student>();
        List<Student> studentB = new List<Student>();
        List<Student> studentC = new List<Student>();
        List<Student> studentD = new List<Student>();
        public Binding_Data()
        {
            InitializeComponent();
            
        }

        private void Binding_Data_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 6; i++)
            {
            studentA.Add(new Student(i, "Name 1"  + i, "Male"));
            studentB.Add(new Student(i *2, "Name 11" + i *2, "Female"));
            studentC.Add(new Student(i *3, "Name 12" + i *3, "Male"));
            studentD.Add(new Student(i *4, "Name 14" + i *4, "Female"));
            }

            // Binding Data For ListBox & ComboBox controls by using DadSource property
            listBox1.DataSource = studentA;
            comboBox1.DataSource = studentB;
            comboBox2.DataSource = studentC;
            comboBox3.DataSource = studentD;

            listBox1.DisplayMember = "StudentName";
            comboBox1.DisplayMember = "StudentName";
            comboBox2.DisplayMember = "StudentName";
            comboBox3.DisplayMember = "StudentName";

            // Binding Data For DataGridView control by using DadSource property
            dataGridView1.DataSource = new List<Student>
             {
             new Student(1, "StudentA", "Female", 12121, "1001","Basketball",false, 10, 11),
             new Student(2, "StudentB", "Male", 12122, "1002","Basketball",true, 10, 11),
             new Student(3, "StudentC", "Female", 12123, "1003","Football",false, 10, 11),
             new Student(4, "StudentD", "Male", 12124,"1004","Football",true, 10, 11),
            };


            //Binding Data For TextBox/Label control/DomianUpDown/NumericUpDown/LinkLabel/CheckBox/RadioButton/RichTextBox/MaskedTextBox/Button by using DadaBindings property
            Student stu = new Student(1, "StudentNumber", "Female", 12121, "HomeNumber","Habits" + "\n"+"Basketball"+ '\n'+ "Football",true, 10, 11);
            this.textBox1.DataBindings.Add("Text", stu, "StudentNo");
            this.domainUpDown1.DataBindings.Add("Text", stu, "Lucky_Number");
            this.numericUpDown1.DataBindings.Add("Text", stu, "Student_Count");
            this.label1.DataBindings.Add("Text", stu, "StudentName");
            this.button1.DataBindings.Add("Text", stu, "StudentSex");
            this.maskedTextBox1.DataBindings.Add("Text", stu, "StudentPhoneNum");
            this.linkLabel1.DataBindings.Add("Text", stu, "HomeNumber");
            this.richTextBox1.DataBindings.Add("Text", stu, "Student_habit");
            this.checkBox1.DataBindings.Add("Checked", stu, "Is_Student");
            this.radioButton1.DataBindings.Add("Checked", stu, "Is_Student");

            //Binding Data Fro TreeView control by using SqlServer
            BindTree();
        }

        //Binding Data Fro TreeView control by using SqlServer Eg:https://blog.csdn.net/a16496528/article/details/8290846
        private DataSet GetData()
        {
            string connstr = "server= winformssrvvm01;uid=sa;pwd='asp+rocks4u';database=Northwind;";
            SqlConnection con = new SqlConnection(connstr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select top 6 * from Customers", con);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void BindTree()
        {
            DataSet ds = GetData();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = ds.Tables[0].Rows[i]["CustomerID"].ToString();
                    node.Tag = ds.Tables[0].Rows[i]["City"].ToString();
                    this.treeView1.Nodes.Add(node);
                }
            }
        }
    }
}
