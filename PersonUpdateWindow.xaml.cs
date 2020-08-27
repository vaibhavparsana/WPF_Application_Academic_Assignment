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
    /// Interaction logic for PersonUpdateWindow.xaml
    /// </summary>
    public partial class PersonUpdateWindow : Window
    {
        public Person person;
        public PersonUpdateWindow(Person person)
        {
            this.person = person;
            InitializeComponent();
            txtId.Text = person.pID.ToString();
            txtName.Text = person.Name;
            txtAddress.Text = person.Address;
            txtEmail.Text = person.Email;
            txtAge.Text = person.Age.ToString();
            txtBirthday.Text = person.Birthday;
        }

        private void CancelUpdatePerson_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdatePerson_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" &&
                txtAddress.Text != "" &&
                txtEmail.Text != "" &&
                txtAge.Text != "" &&
                txtBirthday.Text != "") {
                person = new Person()
                {
                    pID = int.Parse(txtId.Text),
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    Age = int.Parse(txtAge.Text),
                    Birthday = txtBirthday.Text
                };
            }
            else
            {
                MessageBox.Show("All text boes should be filled.");
            }
            Close();
        }
    }
}
