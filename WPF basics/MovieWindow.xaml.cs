using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Szinkronstudio.Data;
using Szinkronstudio.Migrations;

namespace Szinkronstudio
{
    /// <summary>
    /// Interaction logic for MovieWindow.xaml
    /// </summary>
    public partial class MovieWindow : Window
    {
        private readonly MovieContext dbContext;
        ObservableCollection<MovieModel> movies = new ObservableCollection<MovieModel>();
        public MovieModel Movie { get; set; }

        public MovieWindow(MovieContext dbContext, MovieModel model)
        {
            InitializeComponent();
            Movie = model;
            this.dbContext = dbContext;

            cboCategory.DisplayMemberPath = "Name";
            cboCategory.SelectedValuePath = "Id";
            cboCategory.ItemsSource = dbContext.Set<CategoryModel>().ToList();

            this.DataContext = Movie;
        }

        private void MentesButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> movieIds = new List<string>();
            for (int i = 0; i < movies.Count; i++)
            {
                if (!movieIds.Contains(movies[i].Id))
                    movieIds.Add(movies[i].Id);
            }
            Movie = (MovieModel)this.DataContext;
            if (KotelezoMezoEllenorzes())
            {
                try
                {
                    if (Movie.Id != "" && !movieIds.Contains(Movie.Id))
                        dbContext.Set<MovieModel>().Add(this.Movie);
                    else
                        dbContext.Entry(this.Movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbContext.SaveChanges();
                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HIBA", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool KotelezoMezoEllenorzes()
        {
            if (Movie.Id == "" || Validation.GetHasError(txtId) || string.IsNullOrWhiteSpace(txtId.Text))
                return false;
            if (string.IsNullOrWhiteSpace(Movie.Title))
                return false;
            if (string.IsNullOrWhiteSpace(Movie.DubProducer))
                return false;
            if (Movie.CategoryId == 0)
                return false;
            return true;
        }

        private void MegsemButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
