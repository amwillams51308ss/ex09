using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Student
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }

        public override string ToString()
        {
            return $"{this.StudentID}{this.StudentName}";
        }
    }
}
