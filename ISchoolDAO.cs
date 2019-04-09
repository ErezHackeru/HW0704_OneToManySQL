using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0704_1ToN_SQL
{
    interface ISchoolDAO
    {
        Dictionary<Class, List<Students>> GetMapClassToStudentsDictionary();
        List<Students> GetStudentsFromClass(Int64 ClassId);
        object GetAllKindOfListsFromHW(List<Students> students);
    }
}
