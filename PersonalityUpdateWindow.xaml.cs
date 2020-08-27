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
    /// Interaction logic for PersonalityUpdateWindow.xaml
    /// </summary>
    public partial class PersonalityUpdateWindow : Window
    {
        public Personality personality;
        public ObservableCollection<ComboBoxItem> PersonIds { get; set; }
        public List<Person> personList;
        public ComboBoxItem SelectedPersonId { get; set; }
        public PersonalityUpdateWindow(Personality personality, List<Person> personList)
        {
            this.personality = personality;
            this.personList = personList;
            InitializeComponent();
            txtId.Text = personality.ID.ToString();
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
                if (person.pID == personality.PersonID)
                {
                    SelectedPersonId = newpersonID;
                }
                PersonIds.Add(newpersonID);
            }
            txtShoeSize.Text = personality.ShoeSize.ToString();
            txtFavouriteMovie.Text = personality.FavouriteMovie;
            txtFavouriteActor.Text = personality.FavouriteActor;
        }


        private void UpdatePersonality_Click(object sender, RoutedEventArgs e)
        {

            if (txtId.Text != "" &&
                txtPersonId.Text != "" &&
                txtShoeSize.Text != "" &&
                txtFavouriteMovie.Text != "" &&
                txtFavouriteActor.Text != "")
            {
                personality = new Personality()
                {
                    ID = int.Parse(txtId.Text),
                    PersonID = int.Parse(txtPersonId.Text),
                    ShoeSize = int.Parse(txtShoeSize.Text),
                    FavouriteMovie = txtFavouriteMovie.Text,
                    FavouriteActor = txtFavouriteActor.Text
                };
            }
            else
            {
                MessageBox.Show("All text boes should be filled.");
            }

            Close();
        }

        private void CancelUpdatePersonality_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
