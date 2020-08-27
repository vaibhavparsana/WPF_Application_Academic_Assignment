using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MT_Vaibhav_Parsana
{
     

    public partial class MainWindow : Window
    {
      
        public List<Person> PersonList = new List<Person>();
        public List<SportsTeam> SportsTeamList = new List<SportsTeam>();
        public List<Personality> PersonalityList = new List<Personality>();
        public List<Education> EducationList = new List<Education>();
        public MainWindow()
        {
            PersonList.Add(new Person()
            {
                pID = 101,
                Name = "Smith",
                Address = "Toronto",
                Email = "smith@gmail.com",
                Age = 31,
                Birthday = "11 December 1989"
            });
            PersonList.Add(new Person()
            {
                pID = 102,
                Name = "James",
                Address = "New York",
                Email = "james@gmail.com",
                Age = 30,
                Birthday = "05 October 1990"
            });
            PersonList.Add(new Person()
            {
                pID = 103,
                Name = "Robert",
                Address = "Virginia",
                Email = "robert@gmail.com",
                Age = 29,
                Birthday = "05 October 1990"
            });
            PersonList.Add(new Person()
            {
                pID = 104,
                Name = "Steve",
                Address = "Mississuga",
                Email = "steve@gmail.com",
                Age = 28,
                Birthday = "03 November 1991"
            });
            PersonList.Add(new Person()
            {
                pID = 105,
                Name = "Bucky",
                Address = "Brampton",
                Email = "bucky@gmail.com",
                Age = 27,
                Birthday = "03 March 1992"
            });

            SportsTeamList.Add(new SportsTeam()
            {
                ID = 201,
                PersonID = 101,
                SportTeam = "Toronto-Team",
                City = "Toronto"
            });
            SportsTeamList.Add(new SportsTeam()
            {
                ID = 202,
                PersonID = 102,
                SportTeam = "New York-Team",
                City = "New York"
            });
            SportsTeamList.Add(new SportsTeam()
            {
                ID = 203,
                PersonID = 103,
                SportTeam = "Virginia-Team",
                City = "Virginia"
            });
            SportsTeamList.Add(new SportsTeam()
            {
                ID = 204,
                PersonID = 104,
                SportTeam = "Mississuga-Team",
                City = "Mississuga"
            });
            SportsTeamList.Add(new SportsTeam()
            {
                ID = 205,
                PersonID = 105,
                SportTeam = "Brampton-Team",
                City = "Brampton"
            });


            EducationList.Add(new Education()
            {
                ID = 301,
                PersonID = 101,
                CourseName = "Math",
                CourseGrade = 85,
                Comments = "Good"
            });

            EducationList.Add(new Education()
            {
                ID = 302,
                PersonID = 102,
                CourseName = "Science",
                CourseGrade = 80,
                Comments = "Good"
            });

            EducationList.Add(new Education()
            {
                ID = 303,
                PersonID = 103,
                CourseName = "Drawing",
                CourseGrade = 95,
                Comments = "Excellent"
            });

            EducationList.Add(new Education()
            {
                ID = 304,
                PersonID = 104,
                CourseName = "Language",
                CourseGrade = 75,
                Comments = "Good"
            });

            EducationList.Add(new Education()
            {
                ID = 305,
                PersonID = 105,
                CourseName = "History",
                CourseGrade = 70,
                Comments = "Average"
            });
            PersonalityList.Add(new Personality()
            {
                ID = 401,
                PersonID = 101,
                ShoeSize = 10,
                FavouriteMovie = "Avenger",
                FavouriteActor = "Robert Downey Jr."
            });
            PersonalityList.Add(new Personality()
            {
                ID = 402,
                PersonID = 102,
                ShoeSize = 9,
                FavouriteMovie = "Bloodshot",
                FavouriteActor = "Vin Diesel"
            });
            PersonalityList.Add(new Personality()
            {
                ID = 403,
                PersonID = 103,
                ShoeSize = 8,
                FavouriteMovie = "Once Upon a Time in Hollywood",
                FavouriteActor = "Leonardo Dicaprio"
            });
            PersonalityList.Add(new Personality()
            {
                ID = 404,
                PersonID = 104,
                ShoeSize = 9,
                FavouriteMovie = "Bad Boys for Life",
                FavouriteActor = "Will Smith"
            });
            PersonalityList.Add(new Personality()
            {
                ID = 405,
                PersonID = 105,
                ShoeSize = 8,
                FavouriteMovie = "Toy Story 4",
                FavouriteActor = "Keanu Reeves"
            });
            InitializeComponent();
            listSportTeam.ItemsSource = SportsTeamList;
            listSportTeam.Items.Refresh();
            listPerson.ItemsSource = PersonList;
            listPerson.Items.Refresh();
            listEducation.ItemsSource = EducationList;
            listEducation.Items.Refresh();
            listPersonality.ItemsSource = PersonalityList;
            listPersonality.Items.Refresh();
        }

        private void btnNamePerson_Click(object sender, RoutedEventArgs e)
        {
            PersonWindow windowPerson1 = new PersonWindow(PersonList);
            windowPerson1.ShowDialog();
            PersonList = windowPerson1.PersonList;
            listPerson.ItemsSource = PersonList;
            listPerson.Items.Refresh();
        }

        private void btnNameSport_Click(object sender, RoutedEventArgs e)
        {
            SportWindow windowSport1 = new SportWindow(SportsTeamList, PersonList);
            windowSport1.ShowDialog();
            SportsTeamList = windowSport1.SportsTeamList;
            listSportTeam.ItemsSource = SportsTeamList;
            listSportTeam.Items.Refresh();
        }

        private void btnNamePersonality_Click(object sender, RoutedEventArgs e)
        {
           PersonalityWindow windowPersonality1 = new PersonalityWindow(PersonalityList, PersonList);
            windowPersonality1.ShowDialog();
            PersonalityList = windowPersonality1.PersonalityList;
            listPersonality.ItemsSource = PersonalityList;
            listPersonality.Items.Refresh();
        }

        private void btnNameEducation_Click(object sender, RoutedEventArgs e)
        {
            EducationWindow windowEducation1 = new EducationWindow( EducationList , PersonList);
            windowEducation1.ShowDialog();
            EducationList = windowEducation1.EducationList;
            listEducation.ItemsSource = EducationList;
            listEducation.Items.Refresh();
        }
    }
}
