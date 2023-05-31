using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Szinkronstudio.Data;

namespace Szinkronstudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MovieContext dbContext;
        ObservableCollection<MovieModel> movies = new ObservableCollection<MovieModel>();

        public MainWindow()
        {
            InitializeComponent();
            this.dbContext = new MovieContext();

            cboCategory.DisplayMemberPath = "Name";
            cboCategory.SelectedValuePath = "Id";
            cboCategory.ItemsSource = dbContext.Set<CategoryModel>().ToList();

            dgList.ItemsSource = movies;
        }

        private void KeresesButton_Click(object sender, RoutedEventArgs e)
        {
            movies = new ObservableCollection<MovieModel>
                         (
                            dbContext.Set<MovieModel>()
                                     .Include(v => v.Category)
                                     .Where(v => v.Id.Contains(txtId.Text)
                                              && (cboCategory.SelectedIndex == -1 || v.CategoryId == (int)cboCategory.SelectedValue)
                                           )
                         );
            dgList.ItemsSource = movies;
        }

        private void FeltTorlesButton_Click(object sender, RoutedEventArgs e)
        {
            cboCategory.SelectedIndex = -1;
            txtId.Text = string.Empty;
        }

        private void UjButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new MovieWindow(dbContext, new MovieModel());
            if (w.ShowDialog() == true)
                this.movies.Add(w.Movie);
        }

        private void ModositasButton_Click(object sender, RoutedEventArgs e)
        {
            if (dgList.SelectedItem != null)
            {
                var a = (MovieModel)dgList.SelectedItem;
                var w = new MovieWindow(dbContext, a);
                if (w.ShowDialog() != true)
                {
                    dbContext.Entry(a).State = EntityState.Unchanged;
                    dgList.Items.Refresh();
                }
            }
        }

        private void TorlesButton_Click(object sender, RoutedEventArgs e)
        {
            if (dgList.SelectedItem != null)
            {
                var a = (MovieModel)dgList.SelectedItem;
                if (MessageBox.Show("Biztosan törölni akarja?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    dbContext.Set<MovieModel>().Remove(a);
                    dbContext.SaveChanges();
                    movies.Remove(a);
                    dgList.Items.Refresh();
                }
            }
        }
    }
}
