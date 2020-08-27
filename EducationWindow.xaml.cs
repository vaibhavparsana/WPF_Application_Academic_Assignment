using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for EducationWindow.xaml
    /// </summary>
    public partial class EducationWindow : Window
    {
        public List<Person> PersonList;
        public List<Education> EducationList;
        EducationInsertWindow window1EducationInsert;
        EducationUpdateWindow window1EducationUpdate;
        public EducationWindow(List<Education> educationList, List<Person> personList)
        {
            this.EducationList = educationList;
            this.PersonList = personList;
            InitializeComponent();
            listEducation.ItemsSource = this.EducationList;
        }

        private void InsertEducation_Click(object sender, RoutedEventArgs e)
        {
            window1EducationInsert = new EducationInsertWindow(EducationList, PersonList);
            window1EducationInsert.ShowDialog();
            if (window1EducationInsert.newEducation != null)
            {
                EducationList.Add(window1EducationInsert.newEducation);
                listEducation.ItemsSource = EducationList;
                listEducation.Items.Refresh();
            }
        }

        private void DeleteEducation_Click(object sender, RoutedEventArgs e)
        {
            int indexOfSelectedItem = listEducation.Items.IndexOf(listEducation.SelectedItem);

            if (indexOfSelectedItem >= 0)
            {
                EducationList.RemoveAt(indexOfSelectedItem);
                listEducation.ItemsSource = EducationList;
                listEducation.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please Select Item");
            }
        }

        private void UpdateEducation_Click(object sender, RoutedEventArgs e)
        {
            int indexOfSelectedItem = listEducation.Items.IndexOf(listEducation.SelectedItem);
            if (indexOfSelectedItem >= 0)
            {


                Education educationToBeUpdated = EducationList.ElementAt(indexOfSelectedItem);
                window1EducationUpdate = new EducationUpdateWindow(educationToBeUpdated, PersonList);
                window1EducationUpdate.ShowDialog();
                if (window1EducationUpdate.education != null)
                {
                    educationToBeUpdated.ID = window1EducationUpdate.education.ID;
                    educationToBeUpdated.PersonID = window1EducationUpdate.education.PersonID;
                    educationToBeUpdated.CourseName = window1EducationUpdate.education.CourseName;
                    educationToBeUpdated.CourseGrade = window1EducationUpdate.education.CourseGrade;
                    educationToBeUpdated.Comments = window1EducationUpdate.education.Comments;
                
                    listEducation.ItemsSource = EducationList;
                    listEducation.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select Item");
            }
        }
    }
}
