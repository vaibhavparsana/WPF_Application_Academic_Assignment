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
    /// Interaction logic for SportsTeamUpdateWindow.xaml
    /// </summary>
    public partial class SportsTeamUpdateWindow : Window
    {
        public SportsTeam sportsTeam;
        public ObservableCollection<ComboBoxItem> PersonIds { get; set; }
        public List<Person> personList;
        public ComboBoxItem SelectedPersonId { get; set; }
        public SportsTeamUpdateWindow(SportsTeam sportsTeam, List<Person> personList)
        {
            this.sportsTeam = sportsTeam;
            this.personList = personList;
            InitializeComponent();
            txtId.Text = sportsTeam.ID.ToString();
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
                if (person.pID == sportsTeam.PersonID)
                {
                    SelectedPersonId = newpersonID;
                }
                PersonIds.Add(newpersonID);
            }
            txtSportTeam.Text = sportsTeam.SportTeam;
            txtCity.Text = sportsTeam.City;
        }

        private void UpdateSportsTeam_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != "" &&
                txtPersonId.Text != "" &&
                txtSportTeam.Text != "" &&
                txtCity.Text != "" )
            {
                sportsTeam = new SportsTeam()
                {
                    ID = int.Parse(txtId.Text),
                    PersonID = int.Parse(txtPersonId.Text),
                    SportTeam = txtSportTeam.Text,
                    City = txtCity.Text
                };
            }
            else
            {
                MessageBox.Show("All text boes should be filled.");
            }

            Close();
        }

        private void CancelUpdateSportsTeam_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
