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
    /// Interaction logic for PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        public List<Person> PersonList;
        PersonInsertWindow window1PersonInsert;
        PersonUpdateWindow window1PersonUpdate;
        public PersonWindow(List<Person> PersonList)
        {
            this.PersonList = PersonList;
            InitializeComponent();
            listPerson.ItemsSource = this.PersonList;
        }

        private void InsertPerson_Click(object sender, RoutedEventArgs e)
        {
            window1PersonInsert = new PersonInsertWindow(PersonList);
            window1PersonInsert.ShowDialog();
            if (window1PersonInsert.newPerson != null)
            {
                PersonList.Add(window1PersonInsert.newPerson);
                listPerson.ItemsSource = PersonList;
                listPerson.Items.Refresh();
            }
            
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            int indexOfSelectedItem = listPerson.Items.IndexOf(listPerson.SelectedItem);

            if (indexOfSelectedItem >= 0)
            {
                PersonList.RemoveAt(indexOfSelectedItem);
                listPerson.ItemsSource = PersonList;
                listPerson.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please Select Item");
            }
        }

        private void UpdatePerson_Click(object sender, RoutedEventArgs e)
        {
            int indexOfSelectedItem = listPerson.Items.IndexOf(listPerson.SelectedItem);
            if (indexOfSelectedItem >= 0)
            {


                Person personToBeUpdated = PersonList.ElementAt(indexOfSelectedItem);
                window1PersonUpdate = new PersonUpdateWindow(personToBeUpdated);
                window1PersonUpdate.ShowDialog();
                if (window1PersonUpdate.person != null)
                {
                    personToBeUpdated.Name = window1PersonUpdate.person.Name;
                    personToBeUpdated.Address = window1PersonUpdate.person.Address;
                    personToBeUpdated.Email = window1PersonUpdate.person.Email;
                    personToBeUpdated.Age = window1PersonUpdate.person.Age;
                    personToBeUpdated.Birthday = window1PersonUpdate.person.Birthday;
                    listPerson.ItemsSource = PersonList;
                    listPerson.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select Item");
            }
        }
    }
}
