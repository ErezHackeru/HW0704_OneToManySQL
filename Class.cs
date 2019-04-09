using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0704_1ToN_SQL
{
    class Class
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public Int64 Code { get; set; }
        public Int64 NumberOfStudents { get; set; }
        public Int64 NumberOfVip { get; set; }
        public Int64 AgeAverage { get; set; }
        public string MostPopularCity { get; set; }
        public Int64 OldestVip { get; set; }
        public Int64 YoungestVip { get; set; }

        public static bool operator ==(Class c1, Class c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;

            return (c1.Id == c2.Id);
        }
        public static bool operator !=(Class c1, Class c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Class c = obj as Class;
            if (ReferenceEquals(c, null))
                return false;

            return this.Id == c.Id;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(this.Id);
        }

        public override string ToString()
        {
            return $"Country Id {Id}, Name {Name}, Code {Code}, NumberOfStudents {NumberOfStudents}, NumberOfVip {NumberOfVip}, AgeAverage {AgeAverage}, MostPopularCity {MostPopularCity}, OldestVip {OldestVip}, YoungestVip {YoungestVip}";
        }
    }
}
