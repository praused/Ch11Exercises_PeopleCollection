using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11Exercises_PeopleCollection
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public static bool operator >(Person p1, Person p2)
        {
            return p1.Age > p2.Age;
        }

        public static bool operator <(Person p1, Person p2)
        {
            return p1.Age < p2.Age;
        }

        public static bool operator <=(Person p1, Person p2)
        {
            return !(p1 > p2);
        }

        public static bool operator >=(Person p1, Person p2)
        {
            return !(p1 < p2);
        }
    }
}
