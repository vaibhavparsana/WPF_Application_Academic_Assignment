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
    /// Interaction logic for PersonalityInsertWindow.xaml
    /// </summary>
    public partial class PersonalityInsertWindow : Window
    {
        public Personality newPersonality = null;
        public List<Personality> personalityList;
        public List<Person> personList;
        public ObservableCollection<ComboBoxItem> PersonIds { get; set; }
        public ComboBoxItem SelectedPersonId { get; set; }
        public PersonalityInsertWindow(List<Personality> PersonalityList, List<Person> PersonList)
        {
            this.personalityList = PersonalityList;
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

        private void AddPersonality_Click(object sender, RoutedEventArgs e)
        {
            int id, personID,shoeSize;
            bool idValid = int.TryParse(txtId.Text, out id);
            bool personIDValid = int.TryParse(txtPersonId.Text, out personID);
            bool shoeSizeValid = int.TryParse(txtShoeSize.Text, out shoeSize);
            string message = "";
            if (!idValid)
            {
                message += "Id Should be Interger. \n";
            }

            if (!personIDValid)
            {
                message += "Person Id Should Be Selected \n";
            }

            if (!shoeSizeValid)
            {
                message += "Shoe Size Should be Interger \n";
            }

            if (txtId.Text != "" &&
                txtPersonId.Text != "" &&
                txtShoeSize.Text != "" &&
                txtFavouriteMovie.Text != "" &&
                txtFavouriteActor.Text != "")
            {
                if (personIDValid && idValid && shoeSizeValid)
                {
                    if (personalityList.Exists((personality) => personality.ID == id) == true)
                    {
                        message += "This Id already exists. Please Change Id. \n";
                    }
                    else
                    {

                        newPersonality = new Personality()
                        {
                            ID = id,
                            PersonID = personID,
                            ShoeSize = int.Parse(txtShoeSize.Text),
                            FavouriteMovie = txtFavouriteMovie.Text,
                            FavouriteActor = txtFavouriteActor.Text
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

        private void CancelPersonality_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
