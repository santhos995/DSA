using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class SortTest
    {
        public SortTest()
        {
            List<Employee> list = new List<Employee>();
            List<Employee> e = list.OrderBy(e => e.Name).ToList<Employee>();
            List<int> l = new List<int>();
            l.Sort((a,b)=> b-a);
        }
    }
    public class Employee
    {
        public string Name;
        public string Dep;
    }
}
