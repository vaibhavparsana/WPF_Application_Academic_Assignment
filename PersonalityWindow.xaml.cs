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
    /// Interaction logic for PersonalityWindow.xaml
    /// </summary>
    public partial class PersonalityWindow : Window
    {
        public List<Person> PersonList;
        public List<Personality> PersonalityList;
        PersonalityInsertWindow window1PersonalityInsert;
        PersonalityUpdateWindow window1PersonalityUpdate;
        public PersonalityWindow(List<Personality> personalityList, List<Person> personList)
        {
            this.PersonalityList = personalityList;
            this.PersonList = personList;
            InitializeComponent();
            listPersonality.ItemsSource = this.PersonalityList;
        }

        private void InsertPersonality_Click(object sender, RoutedEventArgs e)
        {
            window1PersonalityInsert = new PersonalityInsertWindow(PersonalityList, PersonList);
            window1PersonalityInsert.ShowDialog();
            if (window1PersonalityInsert.newPersonality != null)
            {
                PersonalityList.Add(window1PersonalityInsert.newPersonality);
                listPersonality.ItemsSource = PersonalityList;
                listPersonality.Items.Refresh();
            }
        }

        private void DeletePersonality_Click(object sender, RoutedEventArgs e)
        {
            int indexOfSelectedItem = listPersonality.Items.IndexOf(listPersonality.SelectedItem);

            if (indexOfSelectedItem >= 0)
            {
                PersonalityList.RemoveAt(indexOfSelectedItem);
                listPersonality.ItemsSource = PersonalityList;
                listPersonality.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please Select Item");
            }
        }

        private void UpdatePersonality_Click(object sender, RoutedEventArgs e)
        {
            int indexOfSelectedItem = listPersonality.Items.IndexOf(listPersonality.SelectedItem);
            if (indexOfSelectedItem >= 0)
            {


                Personality personalityToBeUpdated = PersonalityList.ElementAt(indexOfSelectedItem);
                window1PersonalityUpdate = new PersonalityUpdateWindow(personalityToBeUpdated, PersonList);
                window1PersonalityUpdate.ShowDialog();
                if (window1PersonalityUpdate.personality != null)
                {
                    personalityToBeUpdated.ID = window1PersonalityUpdate.personality.ID;
                    personalityToBeUpdated.PersonID = window1PersonalityUpdate.personality.PersonID;
                    personalityToBeUpdated.ShoeSize = window1PersonalityUpdate.personality.ShoeSize;
                    personalityToBeUpdated.FavouriteMovie = window1PersonalityUpdate.personality.FavouriteMovie;
                    personalityToBeUpdated.FavouriteActor = window1PersonalityUpdate.personality.FavouriteActor;
                    
                    listPersonality.ItemsSource = PersonalityList;
                    listPersonality.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select Item");
            }
        }
    }
}
