using CsvHelper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Teacher> teachers = new List<Teacher>();
        List<Course> courses = new List<Course>();
        List<Student> students = new List<Student>();
        List<Record> records = new List<Record>();

        Student? selectedStudent = null;
        Teacher? selectedTeacher = null;
        Course? selectedCourse = null;
        Record? selectedRecord = null;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCourse();
            InitializeStudent(students);
        }
        private void InitializeStudent(List<Student> mystudent)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Json文件|*.json|Csv文件|*.csv|所有檔案|*.*";
            fileDialog.Title = "讀取學生檔案";

            if (fileDialog.ShowDialog() == true)
            {
                string jsonDocument = File.ReadAllText(fileDialog.FileName);
                students = JsonSerializer.Deserialize<List<Student>>(jsonDocument);
            }


            cmbStudent.ItemsSource = students;
            cmbStudent.SelectedIndex = 0;
        }
        private void InitializeCourse()
        {
            //建立測試資料
            Teacher teacher1 = new Teacher("陳定宏");
            //Course coursela = new Course(teacher1) {CourseNmae="視窗程式設計",OpeningClass="五專三甲",Point=3,Type="必修" };
            //teacher1.TeachingCourses.Add(coursela);
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "五專三甲", Point = 3, Type = "必修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技二甲", Point = 3, Type = "必修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技三乙", Point = 3, Type = "必修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技三丙", Point = 3, Type = "必修" });

            teachers.Add(teacher1);

            Teacher teacher2 = new Teacher("杜俊育");
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "行動無線通訊", OpeningClass = "碩研資工一甲等合開", Point = 3, Type = "選修" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "行動電信網路應用", OpeningClass = "四技資工三甲等合開", Point = 3, Type = "選修" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "雲端人工智慧運算實務", OpeningClass = "四技資工四甲等合開", Point = 3, Type = "選修" });

            teachers.Add(teacher2);

            Teacher teacher3 = new Teacher("許子衡");
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "網頁設計(A)", OpeningClass = "四技資工一甲等合開", Point = 3, Type = "選修" });
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "網站開發專題", OpeningClass = "四技資工四甲等合開", Point = 3, Type = "選修" });
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "網路程式設計", OpeningClass = "四技資工三甲等合開", Point = 3, Type = "選修" });

            teachers.Add(teacher3);

            trvteacher.ItemsSource = teachers;

            foreach (Teacher teacher in teachers)
            {
                foreach (Course course in teacher.TeachingCourses)
                {
                    courses.Add(course);
                }
            }

            lbCourse.ItemsSource = courses;
        }

        private void cmbStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStudent = (Student)cmbStudent.SelectedItem;
            statusLabel.Content = "選擇學生：" + selectedStudent;
        }


        private void trvteacher_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (trvteacher.SelectedItem is Teacher)
            {
                selectedTeacher = trvteacher.SelectedItem as Teacher;
                statusLabel.Content = "選擇老師：" + selectedTeacher;
            }
            if(trvteacher.SelectedItem is Course)
            {
                selectedCourse = trvteacher.SelectedItem as Course;
                statusLabel.Content = "選擇課程：" + selectedCourse;
            }
        }

        private void lbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCourse = lbCourse.SelectedItem as Course;
            statusLabel.Content = "選擇課程：" + selectedCourse;
        }

        private void registerButton(object sender, RoutedEventArgs e)
        {
            if (selectedStudent == null || selectedCourse == null)
            {
                MessageBox.Show("請選擇學生或課程", "資料不足");
            }
            else
            {
                Record currentRecord = new Record()
                {
                    SelectedStudent = selectedStudent,
                    SelectedCourse = selectedCourse
                };

                foreach (Record r in records)
                {
                    if (r.Equals(currentRecord))
                    {
                        MessageBox.Show($"{selectedStudent.StudentName}已選擇{selectedCourse.CourseName}課程了");
                        return;
                    }
                }
                records.Add(currentRecord);
                lvRecord.ItemsSource = records;
                lvRecord.Items.Refresh();
            }            
        }
        private void lvRecord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvRecord.SelectedItem != null)
            {
                selectedRecord = lvRecord.SelectedItem as Record;
                statusLabel.Content = selectedRecord;
            }
        }
        private void wuthdrawButton(object sender, RoutedEventArgs e)
        {
            if (selectedRecord != null)
            {
                records.Remove(selectedRecord);
                lvRecord.ItemsSource = records;
                lvRecord.Items.Refresh();
            }
            else
            {
                MessageBox.Show("請選擇要退選的紀錄");
            }
        }

        private void save_select(object sender, RoutedEventArgs e)
        {
            save_file(records);
        }

        private void save_file(List<Record> myrecord)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Json文件|*.json";
            fileDialog.Title = "儲存選課紀錄";

            if (fileDialog.ShowDialog() == true)
            {
                JsonSerializerOptions options = new()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                };
                string jsonDocument = JsonSerializer.Serialize<List<Record>>(records, options);
                File.WriteAllText(fileDialog.FileName, jsonDocument);
            }
        }
    }
}
