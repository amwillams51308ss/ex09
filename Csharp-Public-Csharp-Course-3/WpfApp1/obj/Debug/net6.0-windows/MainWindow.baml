   M S B A M L   `   `   `  ????B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $
??1000??6)    ? WindowStartupLocation$ CenterScreen=?66   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $??50 ?6   ?? 5      $
??500* ?6   ?? 5      $??50 ?6    ? ColumnDefinitions 5   
   ?? 5      $
??500* ?6   ?? 5      $	??100 ?6   ?? 5      $
??500* ?6   .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   .+?5      ?? $??學生??6   $
??Left=?6!   $??Center=?6<   $??	100,0,0,0q?6W   ?? 5      -   5         ??Name$ 
cmbStudent??5      $	??200??6+   $??30??67   $
??Left=?6C   $??Center=?6^   6y   5      ?? 5   
   $??1??6   .@?5      ?? $??以教師分類課程??6   .??5      R? -   5         R?Name$ 
trvteacher??5      ???	#FFF9F9E1 ? 	Resources 5       ?? DataType  WpfApp1.Teacher	 ?? ItemsSource  WpfApp1.Course??%_  (??       5   3   *, +)(?? u    5%   '   *, +)?? 5      "  63   	 6U   ?? *TeachingCourses+.R?5      ?? $ 
Horizontal=?6)   .+?5   "   ?? $??18??6(   $??18??63   $??/teacher.png??6?   ?? 5   "   $
??Bold"?6I   ??6,   ?? *TeacherName+6I   ?? 5    "   $??(??6,   ?? 5!   "   
???  ????6,   ?? *TeachingCourses.Count+6S   ?? 5"   "   $??)??6,   5#      5$      ?? 5%      "  6'   .R?5&      ?? $ 
Horizontal=?6)   .+?5'   "   ?? $??18??6(   $??18??64   $??	/book.png??6?   ?? 5(   "   ???	#FF00841A$??	Underline{?6_   ??6,   ?? *
CourseName+6_   ?? 5)   "   $??(??6,   ?? 5*   "   ??6,   ?? *OpeningClass+?? 5+   "   $??/??6,   ?? 5,   "   ??6,   ?? *Type+?? 5-   "   ??6,   ?? *Point+?? 5.   "   $??學分)??6,   5/      50      51      52      53      ?? 54      $??所有課程??6   .??55      ?? -   5        
 ??Name$
 lbCourse??55       56      ??%?  (??       57   '   *, +)?? 6   "  6'   .R?58      ?? $ Vertical=?6)   .+?59   "   ?? $ 
Horizontal=?6-   .+?5:   &   ?? $??授課教師：??60   ?? 5;   &   $
??Bold"?6S   ??60   ?? *Tutor.TeacherName+6S   5<   #   ? 5=   "    5>   &   ?? 5?   *   $	??150 ?6;   ?? 5@   *   $	??120 ?6;   ?? 5A   *   $	??120 ?6;   .+?5C   &   ?? $??0??6L   $
??Bold"?6\   
????  ?$
??Left=?6?   ??60   ?? *
CourseName+6?   ?? 5D   &   $??1??6N   ??60   ?? *OpeningClass+6N   ?? 5E   &   $ 
Horizontal=?61   $??2??6J   .+?5F   *   ?? $??(??64   ?? 5G   *   ??64   ?? *Type+?? 5H   *   ??64   ?? *Point+?? 5I   *   $??學分)??64   5J   '   5K   #   5L      5M      5N      5O      5P      5Q      ?? 5R   
   $??2??6   $??3??6!   .@?5S      ?? .??5T      ?? -   5         ??Name$ statusLabel??5T      $??status??6-   $	??400??6>   5U      5V      ?? 5W   
   -   5         ??Name$ lvRecord??5W      $??2??6%   $??1??65    ?? View 5X      ?? 5Y      .P?5Z      ?? $??學號??6%    ?? DisplayMemberBinding 61   ?? *SelectedStudent.StudentID+?? 5[      $??學生姓名??6%    63   ?? *SelectedStudent.StudentName+?? 5\      $??授課教師??6%    63   ?? *" SelectedCourse.Tutor.TeacherName+?? 5]      $??科目名稱??6%    63   ?? *SelectedCourse.CourseName+?? 5^      $??	必選修??6%    62   ?? *SelectedCourse.Type+?? 5_      $??	學分數??6%    62   ?? *SelectedCourse.Point+?? 5`      $??開課班級??6%    63   ?? *SelectedCourse.OpeningClass+5a      5c      ?? 5d   
   -   5        $??80??5d      $??40??6   $??1??6(   $??->??68   $??Center=?6E   $??0,55,0,0q?6b   $??1??6t   $	??Top=?6?   6?   ?? 5e   
   -   5        $??80??5e      $??40??6   $??1??6)   $??<-??69   $??Center=?6I   $??	0,125,0,0q?6f   $??1??6y   $	??Top=?6?   6?   ?? 5f   
   -   5        $??80??5f      $??40??6   $??1??6)   $??存檔??69   $??Center=?6F   $??	0,195,0,0q?6c   $??1??6v   $	??Top=?6?   6?   5g      5h      