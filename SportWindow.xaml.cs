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
    /// Interaction logic for SportWindow.xaml
    /// </summary>
    public partial class SportWindow : Window
    {
        public List<Person> PersonList;
        public List<SportsTeam> SportsTeamList;
        SportsTeamInsertWindow window1SportsTeamInsert;
        SportsTeamUpdateWindow window1SportsTeamUpdate;
        public SportWindow(List<SportsTeam> sportsTeamList , List<Person> personList)
        {
            this.SportsTeamList = sportsTeamList;
            this.PersonList = personList;
            InitializeComponent();
            listSportTeam.ItemsSource = this.SportsTeamList;
        }

        private void InsertSport_Click(object sender, RoutedEventArgs e)
        {
            window1SportsTeamInsert = new SportsTeamInsertWindow(SportsTeamList, PersonList);
            window1SportsTeamInsert.ShowDialog();
            if (window1SportsTeamInsert.newSportsTeam != null)
            {
                SportsTeamList.Add(window1SportsTeamInsert.newSportsTeam);
                listSportTeam.ItemsSource = SportsTeamList;
                listSportTeam.Items.Refresh();
            }

        }

        private void DeleteSport_Click(object sender, RoutedEventArgs e)
        {
            int indexOfSelectedItem = listSportTeam.Items.IndexOf(listSportTeam.SelectedItem);

            if (indexOfSelectedItem >= 0)
            {
                SportsTeamList.RemoveAt(indexOfSelectedItem);
                listSportTeam.ItemsSource = SportsTeamList;
                listSportTeam.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please Select Item");
            }
        }

        private void UpdateSport_Click(object sender, RoutedEventArgs e)
        {
            int indexOfSelectedItem = listSportTeam.Items.IndexOf(listSportTeam.SelectedItem);
            if (indexOfSelectedItem >= 0)
            {


                SportsTeam sportTeamToBeUpdated = SportsTeamList.ElementAt(indexOfSelectedItem);
                window1SportsTeamUpdate = new SportsTeamUpdateWindow(sportTeamToBeUpdated, PersonList);
                window1SportsTeamUpdate.ShowDialog();
                if (window1SportsTeamUpdate.sportsTeam != null)
                {
                    sportTeamToBeUpdated.ID = window1SportsTeamUpdate.sportsTeam.ID;
                    sportTeamToBeUpdated.PersonID = window1SportsTeamUpdate.sportsTeam.PersonID;
                    sportTeamToBeUpdated.SportTeam = window1SportsTeamUpdate.sportsTeam.SportTeam;
                    sportTeamToBeUpdated.City = window1SportsTeamUpdate.sportsTeam.City;
         
                    listSportTeam.ItemsSource = SportsTeamList;
                    listSportTeam.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select Item");
            }
        }
    }
}
