using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Record
    {
        public Student SelectedStudent { get; set; }
        public Course SelectedCourse { get; set; }

        public bool Equals(Record record)
        {
            if(SelectedStudent.StudentID == record.SelectedStudent.StudentID && SelectedCourse.CourseName == record.SelectedCourse.CourseName)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return $"選擇紀錄:{SelectedStudent.StudentName}\\{SelectedCourse.CourseName}";
        }
    }
}
