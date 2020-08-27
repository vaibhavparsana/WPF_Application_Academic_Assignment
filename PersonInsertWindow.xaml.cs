using System;
using System.Collections.Generic;
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
    /// Interaction logic for PersonInsertWindow.xaml
    /// </summary>
    public partial class PersonInsertWindow : Window
    {
        public Person newPerson =null;
        public List<Person> personList;
        public PersonInsertWindow(List<Person> PersonList)
        {
            this.personList = PersonList;
            InitializeComponent();
        }

        private void CancelPerson_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            int age,personID;
            bool ageValid = int.TryParse(txtAge.Text, out age);
            bool personIDValid = int.TryParse(txtId.Text, out personID);
            string message = "";
            if (!ageValid)
            {
                message += "Age Should Be Interger. \n";
            }

            if (!personIDValid)
            {
                message += "Id Should Be Interger \n";
            }

            if (txtId.Text != "" &&
                txtName.Text != "" &&
                txtAddress.Text != "" &&
                txtEmail.Text != "" &&
                txtAge.Text != "" &&
                txtBirthday.Text != "")
            {
                if (personIDValid && ageValid)
                {
                    if (personList.Exists((person) => person.pID == personID) == true)
                    {
                        message += "This Id already exists. Please Change Id. \n";
                    }
                    else
                    {

                        newPerson = new Person()
                        {
                            pID = personID,
                            Name = txtName.Text,
                            Address = txtAddress.Text,
                            Email = txtEmail.Text,
                            Age = age,
                            Birthday = txtBirthday.Text
                        };
                    }
                }
            }else
            {
                message += "All Text Boxes Should Be Filed";
            }
            if (message.Length > 0)
            {
                MessageBox.Show(message);
            }
            Close();
        }
    }
}
