using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0704_1ToN_SQL
{
    class Students
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public Int64 Age { get; set; }
        public string Address_City { get; set; }
        public string Vip { get; set; }
        public Int64 Class_Id { get; set; }

        public static bool operator ==(Students c1, Students c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;

            return (c1.Id == c2.Id);
        }
        public static bool operator !=(Students c1, Students c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Students c = obj as Students;
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
            return $"Country Id {Id}, Name {Name}, Age {Age}, Address_City {Address_City}, Vip {Vip}, Class_Id {Class_Id}";
        }
    }
}
