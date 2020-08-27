using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MT_Vaibhav_Parsana
{
    /// <summary>
    /// Interaction logic for EducationUpdateWindow.xaml
    /// </summary>
    public partial class EducationUpdateWindow : Window
    {
        public Education education;
        public ObservableCollection<ComboBoxItem> PersonIds { get; set; }
        public List<Person> personList;
        public ComboBoxItem SelectedPersonId { get; set; }
        public EducationUpdateWindow(Education education, List<Person> personList)
        {
            this.education = education;
            this.personList = personList;
            InitializeComponent();
            txtId.Text = education.ID.ToString();
            DataContext = this;
            PersonIds = new ObservableCollection<ComboBoxItem>();
            var personId = new ComboBoxItem
            {
                Content = "<--Select-->"
            };
            PersonIds.Add(personId);
            foreach (var person in this.personList)
            {
                var newpersonID = new ComboBoxItem { Content = person.pID };
                if (person.pID == education.PersonID)
                {
                    SelectedPersonId = newpersonID;
                }
                PersonIds.Add(newpersonID);
            }
            txtCourseName.Text = education.CourseName;
            txtCourseGrade.Text = education.CourseGrade.ToString();
            txtComments.Text = education.Comments;
        }

        private void UpdateEducation_Click(object sender, RoutedEventArgs e)
        {

            if (txtId.Text != "" &&
                txtPersonId.Text != "" &&
                txtCourseName.Text != "" &&
                txtCourseGrade.Text != "" &&
                txtComments.Text != "")
            {
                education = new Education()
                {
                    ID = int.Parse(txtId.Text),
                    PersonID = int.Parse(txtPersonId.Text),
                    CourseName = txtCourseName.Text,
                    CourseGrade = double.Parse(txtCourseGrade.Text),
                    Comments = txtComments.Text
                };
            }
            else
            {
                MessageBox.Show("All text boes should be filled.");
            }

            Close();
        }

        private void CancelEducation_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
