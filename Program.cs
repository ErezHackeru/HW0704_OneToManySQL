using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0704_1ToN_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            ISchoolDAO schoolDAO = new SchoolDAO();
            List<Students> students1 = schoolDAO.GetStudentsFromClass(1);
            List<Students> students2 = schoolDAO.GetStudentsFromClass(2);
            List<Students> students3 = schoolDAO.GetStudentsFromClass(3);
            object result = new
            {
                students1R = schoolDAO.GetAllKindOfListsFromHW(students1),
                students2R = schoolDAO.GetAllKindOfListsFromHW(students2),
                students3R = schoolDAO.GetAllKindOfListsFromHW(students3)
            };

            SchoolDAO.Close();
        }
    }
}
