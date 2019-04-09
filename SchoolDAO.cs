using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0704_1ToN_SQL
{
    class SchoolDAO : ISchoolDAO
    {
        static SQLiteConnection connection;
        public static string dbName = @"D:\HackerU\HW0704_OneToN.db";

        static SchoolDAO()
        {
            connection = new SQLiteConnection($"Data Source = {dbName}; Version=3;");
            connection.Open();
        }
        public static void Close()
        {
            connection.Close();
        }

        public List<Class> GetAllClasses()
        {
            List<Class> classes = new List<Class>();

            using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Class", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Class CurrentCountry = new Class
                        {
                            Id = (Int64)reader["ID"],
                            Name = (string)reader["NAME"],
                            Code = (Int64)reader["CODE"],
                            NumberOfStudents = (Int64)reader["NUMBER_OF_STUDENTS"],
                            NumberOfVip = (Int64)reader["NUMBER_OF_VIP"],
                            AgeAverage = (Int64)reader["AGE_AVERAGE"],
                            MostPopularCity = (string)reader["MOST_POPULAR_CITY"],
                            OldestVip = (Int64)reader["OLDEST_VIP"],
                            YoungestVip = (Int64)reader["YOUNGEST_VIP"]                            
                        };

                        classes.Add(CurrentCountry);
                    }
                }
            }

            return classes;
        }

        public List<Students> GetStudentsFromClass(Int64 ClassId)
        {
            List<Students> studentsInClassId = new List<Students>();
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM Students WHERE CLASS_ID == {ClassId}", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Students CurrentCountry = new Students
                        {
                            Id = (Int64)reader["ID"],
                            Name = (string)reader["NAME"],
                            Age = (Int64)reader["AGE"],
                            Address_City = (string)reader["ADDRESS_CITY"],
                            Vip = (string)reader["VIP"],
                            Class_Id = (Int64)reader["CLASS_ID"],
                        };

                        studentsInClassId.Add(CurrentCountry);
                    }
                }
            }

            return studentsInClassId;
        }

        public Dictionary<Class, List<Students>> GetMapClassToStudentsDictionary()
        {
            Dictionary<Class, List<Students>> MapClassToStudents = new Dictionary<Class, List<Students>>();
            List<Class> classes = GetAllClasses();
            int index = 1;
            foreach (Class c in classes)
            {
                List<Students> studentsInClass = GetStudentsFromClass(index);
                MapClassToStudents.Add(c, studentsInClass);
                index++;
            }            

            return MapClassToStudents;
        }

        public object GetAllKindOfListsFromHW(List<Students> students)
        {
            List<Class> classes = GetAllClasses();
            //Q.5
            //UPDATE Class SET AGE_AVERAGE = (SELECT avg(AGE) FROM Students WHERE Students.Class_ID = Class.ID);
            var result_StudentsAvg =
                (from stud in students
                 select stud.Age).Average();
                

            //Q.6
            //UPDATE Class SET MOST_POPULAR_CITY = (SELECT max(ADDRESS_CITY) FROM Students WHERE Students.Class_ID = Class.ID);
            var result_MostPopularCity =
                (from stud in students
                 select stud.Address_City).Max();

            //Q.7
            //UPDATE Class SET OLDEST_VIP = (SELECT max(AGE) FROM Students WHERE Students.Class_ID = Class.ID);
            var result_OldestVip =
                (from stud in students
                 select stud.Age).Max();

            //Q.8
            //UPDATE Class SET YOUNGEST_VIP = (SELECT min(AGE) FROM Students WHERE Students.Class_ID = Class.ID);
            var result_YongestVip =
                (from stud in students
                 select stud.Age).Min();

            return new { result_StudentsAvg, result_MostPopularCity , result_OldestVip , result_YongestVip };
        }
    }
}
