using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLL;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string sql = @"select SName, Age from student";
            //MySqlDataReader reader =  MySQLHelper.GetReader(sql);
            //List<Student> list = new List<Student>();
            //while(reader.Read())
            //{
            //    string name = reader["SName"].ToString();
            //    int? age;
            //    if (reader["Age"] == DBNull.Value)
            //    {
            //        age = null;
            //    }
            //    else
            //    {
            //        age = int.Parse(reader["Age"].ToString());
            //    }
            //    Student student = new Student(name, age);
            //    list.Add(student);
            //}
            //foreach (var student in list)
            //{
            //    Console.WriteLine(student);
            //}

            
            Console.ReadKey();
        }        
    }
    [Serializable]
    class Student
    {       
        public string Name { get; set; }
        public int? Age { get; set; }
        public int Num
        {
            get;
        }
        public Student(string name, int? age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"姓名：{Name}， 年龄：{Age}";
        }
    }
}
