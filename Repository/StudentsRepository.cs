using TabStudents.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TabStudents.Repository
{    
    public class StudentsRepository 
    {
        public readonly ObservableCollection<StudentsModel> students;

        public IEnumerable<StudentsModel> Peoples
        {
            get { return students; }
        }
        public StudentsRepository()
        {
            students = new ObservableCollection<StudentsModel>();

            try
            {
                CRUD.con.Open();

                CRUD.adp = new NpgsqlDataAdapter("SELECT CONCAT(firstname, ' ', lastname) AS full_name, " +
                    "id, firstname, lastname,TO_CHAR(dob,'dd.MM.yyyy.') dob FROM students ORDER BY firstname ", CRUD.con);


                DataTable dt = new DataTable();
                CRUD.adp.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    students.Add(new StudentsModel()
                    {
                        Id = (int)row["id"],
                        FullName = (string)row["full_name"],
                        FirstName = (string)row["firstname"],
                        LastName = (string)row["lastname"]
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CRUD.con.Close();

            }
        }

        public bool Add(StudentsModel student)
        {
            if (students.IndexOf(student) < 0)
            {
                students.Add(student);
                return true;
            }
            return false;
        }
        public bool Remove(StudentsModel osobeModel)
        {
            if (students.IndexOf(osobeModel) >= 0)
            {
                students.Remove(osobeModel);
                return true;
            }
            return false;
        }

        private static string GetValueOrDefault(XContainer el, string propertyName)
        {
            return el.Element(propertyName) == null ? string.Empty : el.Element(propertyName).Value;
        }

    }
}