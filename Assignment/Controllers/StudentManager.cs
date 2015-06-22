using Assignment.Models;
using Assignment.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Controllers
{
    public class StudentManager
    {
       
            private DataContext ds = new DataContext();
        
            // This function will create new student
            public Student createStudent(AddStudent newItem)
            {
                //using auto mapper to create new student from AddStudent view
                Student student = Mapper.Map<Student>(newItem);

                ds.Student.Add(student);
                ds.SaveChanges();

                return student;
            }

            public StudentBase getStudentById(int Id)
            {
                //fetch ONE Student from collection
                // if student id is null . function will return null
                // other wise fine matching id from collection and return my using auto mapping
                var fetchedStudent = ds.Student.Find(Id);

                if (fetchedStudent == null)
                {
                    return null;
                }
                else
                {
                    return Mapper.Map<StudentBase>(fetchedStudent);
                }
            }


            public IEnumerable<StudentList> getAllStudents()
            {
                //fetch ALL student from collection
                //return collection of student by using auto mapper
                var fetchedStudent = ds.Student.ToList();
                return Mapper.Map<IEnumerable<StudentList>>(fetchedStudent);
            }


            public bool DeleteStudentById(int id)
            {
                /*
                 * This fuction will find mathing id from collection
                 * if there is matching id in DB
                 * function will remove that student from DB and return true
                 * other wise it will return flase
                 * this function will only return ture / or false
                 */
                var fetchedStudent = ds.Student.Find(id);

                if (fetchedStudent== null)
                {
                    return false;
                }
                else
                {
                    ds.Student.Remove(fetchedStudent);
                    ds.SaveChanges();

                    return true;
                }
            }


            public StudentBase EditStudent(StudentBase newItem)
            {
                /*
                 * this function will grant user to a edit student's info from DB
                 * this function receive a StudentBase file and find matching student 
                 * Info from DB by matching id
                 * if their is no matching student in DB it will return null
                 * other wise DB take new studentBase and saved and over write student info at DB
                 * by using auto mapper.
                 */
                var fetchedStudent = ds.Student.Find(newItem.Id);

                if (fetchedStudent == null)
                {
                    return null;
                }
                else
                { 
                    ds.Entry(fetchedStudent).CurrentValues.SetValues(newItem);
                    ds.SaveChanges();

                    return Mapper.Map<StudentBase>(fetchedStudent);
                }
            }

    }
}