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
    /// Interaction logic for EducationInsertWindow.xaml
    /// </summary>
    public partial class EducationInsertWindow : Window
    {
        public Education newEducation = null;
        public List<Education> educationList;
        public List<Person> personList;
        public ObservableCollection<ComboBoxItem> PersonIds { get; set; }
        public ComboBoxItem SelectedPersonId { get; set; }
        public EducationInsertWindow(List<Education> EducationList, List<Person> PersonList)
        {
            this.educationList = EducationList;
            this.personList = PersonList;
            InitializeComponent();

            DataContext = this;
            PersonIds = new ObservableCollection<ComboBoxItem>();
            var personId = new ComboBoxItem
            {
                Content = "<--Select-->"
            };
            SelectedPersonId = personId;
            PersonIds.Add(personId);
            foreach (var person in this.personList)
            {
                PersonIds.Add(new ComboBoxItem { Content = person.pID });
            }
        }

        private void AddEducation_Click(object sender, RoutedEventArgs e)
        {
            int id, personID;
            double courseGrade;
            bool idValid = int.TryParse(txtId.Text, out id);
            bool personIDValid = int.TryParse(txtPersonId.Text, out personID);
            bool courseGradeValid = Double.TryParse(txtCourseGrade.Text, out courseGrade);
            string message = "";
            if (!idValid)
            {
                message += "Id Should be Interger. \n";
            }

            if (!courseGradeValid)
            {
                message += "Course Grade Should be number. \n";
            }

            if (!personIDValid)
            {
                message += "Person Id Should Be Selected \n";
            }

            if (txtId.Text != "" &&
                txtPersonId.Text != "" &&
                txtCourseName.Text != "" &&
                txtCourseGrade.Text != "" &&
                txtComments.Text != "")
            {
                if (personIDValid && idValid)
                {
                    if (educationList.Exists((sportTeam) => sportTeam.ID == id) == true)
                    {
                        message += "This Id already exists. Please Change Id. \n";
                    }
                    else
                    {

                        newEducation = new Education()
                        {
                            ID = id,
                            PersonID = personID,
                            CourseName = txtCourseName.Text,
                            CourseGrade = double.Parse(txtCourseGrade.Text),
                            Comments = txtComments.Text
                        };
                    }
                }
            }
            else
            {
                message += "All Text Boxes Should Be Filed";
            }
            if (message.Length > 0)
            {
                MessageBox.Show(message);
            }
            Close();
        }

        private void CancelEducation_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
