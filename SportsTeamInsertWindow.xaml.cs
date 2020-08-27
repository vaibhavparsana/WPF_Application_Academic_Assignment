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
    /// Interaction logic for SportsTeamInsertWindow.xaml
    /// </summary>
    public partial class SportsTeamInsertWindow : Window
    {
        public SportsTeam newSportsTeam = null;
        public List<SportsTeam> sportsTeamList;
        public List<Person> personList;
        public ObservableCollection<ComboBoxItem> PersonIds { get; set; }
        public ComboBoxItem SelectedPersonId { get; set; }
        public SportsTeamInsertWindow(List<SportsTeam> SportsTeamList, List<Person> PersonList)
        {
            this.sportsTeamList = SportsTeamList;
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
            foreach(var person in this.personList){
                PersonIds.Add(new ComboBoxItem { Content = person.pID });
            }
        }

        private void AddSportsTeam_Click(object sender, RoutedEventArgs e)
        {
            int id,personID;
            bool idValid = int.TryParse(txtId.Text, out id);
            bool personIDValid = int.TryParse(txtPersonId.Text, out personID);
            string message = "";
            if (!idValid)
            {
                message += "Id Should be Interger. \n";
            }

            if (!personIDValid)
            {
                message += "Person Id Should Be Selected \n";
            }

            if (txtId.Text != "" &&
                txtPersonId.Text != "" &&
                txtSportTeam.Text != "" &&
                txtCity.Text != "" )
            {
                if (personIDValid && idValid)
                {
                    if (sportsTeamList.Exists((sportTeam) => sportTeam.ID == id) == true)
                    {
                        message += "This Id already exists. Please Change Id. \n";
                    }
                    else
                    {

                        newSportsTeam = new SportsTeam()
                        {
                            ID = id,
                            PersonID = personID,
                            SportTeam = txtSportTeam.Text,
                            City = txtCity.Text
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

        private void CancelSportsTeam_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
