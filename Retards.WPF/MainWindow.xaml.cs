using Newtonsoft.Json;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Retards.WPF
{
    public partial class MainWindow : Window
    {
        public DateTime DateDebut { get; set; } = DateTime.Now;
        public DateTime DateFin { get; set; } = DateTime.Now;
        

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            RemplirComboBox(hourPickerDebut, 24);
            RemplirComboBox(hourPickerFin, 24);
            RemplirComboBox(minutePickerDebut, 60);
            RemplirComboBox(minutePickerFin, 60);
            LoadStatisticsHistory();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Centrer la fenêtre
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void RemplirComboBox(ComboBox comboBox, int max)
        {
            foreach (var i in Enumerable.Range(0, max))
                comboBox.Items.Add(i.ToString("00"));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateDebut = datePickerDebut.SelectedDate.Value.Date + new TimeSpan(Convert.ToInt32(hourPickerDebut.SelectedValue), Convert.ToInt32(minutePickerDebut.SelectedValue), 0);
            DateTime dateFin = datePickerFin.SelectedDate.Value.Date + new TimeSpan(Convert.ToInt32(hourPickerFin.SelectedValue), Convert.ToInt32(minutePickerFin.SelectedValue), 0);
            new StatistiquesWindow(dateDebut, dateFin).Show();
        }

        private async void LoadStatisticsHistory()
        {
            try
            {
                string statisticsJson = await GetAllStatisticsJson();
                if (!string.IsNullOrEmpty(statisticsJson))
                {
                    historiqueListBox.Items.Clear();
                    foreach (var stat in JsonConvert.DeserializeObject<dynamic[]>(statisticsJson))
                    {
                        DateTime dateDebut;
                        DateTime dateFin = default(DateTime); // Initialisation à une valeur par défaut
                        
                        // recuperer l'ID de la statistique
                        int id = stat.id;

                        if (DateTime.TryParse(stat.dateDebut.ToString(), out dateDebut) &&
                            DateTime.TryParse(stat.dateFin.ToString(), out dateFin))
                        {
                            historiqueListBox.Items.Add($"Du {dateDebut} au {dateFin}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}");
            }
        }


        private async Task<string> GetAllStatisticsJson()
        {
            try
            {
                return JsonConvert.SerializeObject(new Client().GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}");
                return null;
            }
        }

        private void historiqueListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedStat = historiqueListBox.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedStat))
            {
                string[] dates = selectedStat.Substring(3).Split(new string[] { " au " }, StringSplitOptions.RemoveEmptyEntries);
                if (dates.Length == 2)
                {
                    if (DateTime.TryParse(dates[0], out DateTime dateDebut) && DateTime.TryParse(dates[1], out DateTime dateFin))
                    {
                        new StatistiquesWindow(dateDebut, dateFin).Show();
                    }
                    else MessageBox.Show("Erreur lors de la conversion des dates.");
                }
                else MessageBox.Show("Format de date invalide dans la sélection.");
            }
        }
        
        // fonction pour le bouton rafrachir
        private void Button_refresh(object sender, RoutedEventArgs e)
        {
            LoadStatisticsHistory();
            
        }
        
        
    }
}
