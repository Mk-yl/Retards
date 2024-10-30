
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
using System.Windows.Shapes;
using System.Net.Http;
using System.Text.Json;
using LiveCharts;
using LiveCharts.Wpf;

namespace Retards.WPF

{
    /// <summary>
    /// Logique d'interaction pour StatistiquesWindow.xaml
    /// </summary>
    public partial class StatistiquesWindow : Window
    {
        public DateTime DateDebut { get; }
        public DateTime DateFin { get; }
        
        
         // graphique  des statistiques int
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        
        // graphique  des statistiques des comptes postant le plus
        
        public SeriesCollection SeriesCollection1 { get; set; }
        public string[] Labels1 { get; set; }
        public Func<double, string> Formatter1 { get; set; } 
        
        // graphique  des statistiques des comptes commentant le plus
        
        public SeriesCollection SeriesCollection2 { get; set; }
        public string[] Labels2 { get; set; }
        public Func<double, string> Formatter2 { get; set; }
        
        // graphique  des statistiques des villes actives
        
        public SeriesCollection SeriesCollection3 { get; set; }
        public string[] Labels3 { get; set; }
        public Func<double, string> Formatter3 { get; set; }
        
        // graphique  des statistiques des postes les plus likés
        public SeriesCollection SeriesCollection4 { get; set; }
        public string[] Labels4 { get; set; }
        public Func<double, string> Formatter4 { get; set; }
        
        
        // graphique  des statistiques des postes les plus superlikés
        public SeriesCollection SeriesCollection5 { get; set; }
        public string[] Labels5 { get; set; }
        public Func<double, string> Formatter5 { get; set; }
        
        // graphique  des statistiques des postes les plus commentés
        public SeriesCollection SeriesCollection6 { get; set; }
        public string[] Labels6 { get; set; }
        public Func<double, string> Formatter6 { get; set; }
        
        // graphique  des statistiques des postes les plus vus
        public SeriesCollection SeriesCollection7 { get; set; }
        public string[] Labels7 { get; set; }
        public Func<double, string> Formatter7 { get; set; }
        
        
        
        
        public StatistiquesWindow(DateTime dateDebut, DateTime dateFin)
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

            DateDebut = dateDebut;
            DateFin = dateFin;

            // Convertir les DateTime en chaînes de caractères
            textBlockTitreDateDebut.Text = DateDebut.ToString("dd/MM/yyyy");
            textBlockTitreDateFin.Text = DateFin.ToString("dd/MM/yyyy");
            
            // Utilisez les dates pour récupérer les statistiques et afficher les résultats
            LoadStatistics(dateDebut, dateFin);
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Centrer la fenêtre
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        // Méthode pour récupérer et afficher les statistiques
        private async void LoadStatistics(DateTime dateDebut, DateTime dateFin)
        {
            // On recupere les statistiques entre les deux date avec GetByDates du Client
            Client apiClient = new Client();
            Stats_DTO statistic = apiClient.GetStats(dateDebut, dateFin);
            DisplayStatistics(statistic);
        }

        // Méthode pour afficher les statistiques dans l'interface utilisateur
        private void DisplayStatistics(Stats_DTO statistic)
        {
            // Affichez les statistiques dans les TextBlocks de votre interface utilisateur
            textBlockId.Text = $"ID : {statistic.Id}";
            textBlockDateDebut.Text = $"Date de début : {statistic.DateDebut}";
            textBlockDateFin.Text = $"Date de fin : {statistic.DateFin}";
            textBlockNombreCreationsComptes.Text = $"Nombre de comptes créés : {statistic.NbrCreaCmpt}";
            textBlockNombreConnexionsComptes.Text = $"Nombre de connexions : {statistic.NbrConnCmpt}";
            textBlockNombreCreationsPosts.Text = $"Nombre de posts créés : {statistic.NbrCreaPost}";
            textBlockNombreCreationsCommentaires.Text = $"Nombre de commentaires moyen postés : {statistic.NbrCommMpost}";
            textBlockNombreVuesMoyennesPosts.Text = $"Nombre de vues moyen par post: {statistic.NbrVueMpost}";
            textBlockNombreCreationsLikes.Text = $"Nombre de likes moyen par post: {statistic.NbrLikeMpost}";
            
            // Affichez les comptes commentant le plus dans le DataGrid
            textBlocktitre2.Text = "Comptes commentant le plus";
            CompteCommentantLePlus.ItemsSource = statistic.ComptesCommentantLePlus;
            
            // Affichez les comptes postant le plus dans le DataGrid
            textBlocktitre1.Text = "Comptes postant le plus";
            ComptePostantLePlus.ItemsSource = statistic.ComptesPostantLePlus;
            
            // Affichez les villes actives dans le DataGrid
            textBlocktitre3.Text = "Villes actives";
            VilleActive.ItemsSource = statistic.VillesActives;
            
            // afficher poste les plus likés
            textBlocktitre4.Text = "Poste les plus likés";
            PosteLePlusLike.ItemsSource = statistic.PostsLesPlusLikes;
            
            //afficher les post les plus superlikés
            textBlocktitre6.Text = "Poste les plus superlikés";
            PosteLePlusSuperLike.ItemsSource = statistic.PostsLesPlusSuperlikes;
            
            // afficher poste les plus commentés
            textBlocktitre5.Text = "Poste les plus commentés";
            PosteLePlusCommente.ItemsSource = statistic.PostsLesPlusCommentes;
            
            // afficher poste les plus vus
            textBlocktitre7.Text = "Poste les plus vus";
            PosteLePlusVue.ItemsSource = statistic.PostsLesPlusVus;
            
            
            
            // Créer les entrées pour le graphique pour les ints
            
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = $"{statistic.DateDebut.ToString("dd/MM/yyyy")} - {statistic.DateFin.ToString("dd/MM/yyyy")}",
                    Values = new ChartValues<double> { statistic.NbrCreaCmpt, statistic.NbrConnCmpt, statistic.NbrCreaPost, statistic.NbrCommMpost, statistic.NbrVueMpost, statistic.NbrLikeMpost},
                    Fill = Brushes.Gold  // Couleur des barres
                }
            };
            Labels = new[] { "Nbr de comptes créés","Nbr de connections" ,"Nbr de Posts créés", "Nbr de Commentaires moyen",  "Nbr de vues Moyen" , "Nbr de Likes moyen"  };

            Formatter = value => value.ToString("N");
            
            DataContext = this;
            
            
            //mettre les nombres de post et nombre de commentaire dans une liste avant de les afficher dans values du graphique

            var varleursPost1 = new ChartValues<double>();
            var valeursCommentaires1 = new ChartValues<double>();
            
            List<string> pseudo1 = new List<string>();
            
            foreach (var item in statistic.ComptesPostantLePlus)
            {
               //
               varleursPost1.Add(item.NombrePosts);
               valeursCommentaires1.Add(item.NombreCommentaires);
               
               //enlever le dernier element de la liste
               
               // 
               pseudo1.Add(item.Pseudo);
            }
            
            // Mettre les nombre post dans une liste avant de les afficher dans values du graphique
            
            SeriesCollection1 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Post",
                    Values = varleursPost1,
                    Fill = Brushes.Green 
                }
            };
 
            //adding series will update and animate the chart automatically
            SeriesCollection1.Add(new ColumnSeries
            {
                Title = "Commentaires",
                Values = valeursCommentaires1,
                Fill = Brushes.SkyBlue
            });
            
            
          

            // Étiquettes pour l'axe X recupere les pseudo des comptes
            Labels1 = pseudo1.ToArray();

            // Formateur pour les valeurs de l'axe Y
            Formatter1 = value => value.ToString("N");

           // Définition du contexte des données
            DataContext = this;

            
            var varleursPost2 = new ChartValues<double>();
            var valeursCommentaires2 = new ChartValues<double>();
            
            List<string> pseudo2 = new List<string>();
            
            foreach (var item in statistic.ComptesCommentantLePlus)
            {
                //
                varleursPost2.Add(item.NombrePosts);
                valeursCommentaires2.Add(item.NombreCommentaires);
               
                //enlever le dernier element de la liste
               
                // 
                pseudo2.Add(item.Pseudo);
            }
            
            // Mettre les nombre post dans une liste avant de les afficher dans values du graphique
            
            SeriesCollection2 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Post",
                    Values = varleursPost2,
                    Fill = Brushes.Brown 
                }
            };
 
            //adding series will update and animate the chart automatically
            SeriesCollection2.Add(new ColumnSeries
            {
                Title = "Commentaires",
                Values = valeursCommentaires2,
                Fill = Brushes.Chocolate
            });
            
            
           

            // Étiquettes pour l'axe X recupere les pseudo des comptes
            Labels2 = pseudo2.ToArray();

            // Formateur pour les valeurs de l'axe Y
            Formatter2 = value => value.ToString("N");

            // Définition du contexte des données
            DataContext = this;
            
            
            
            
            // graphique 3 pour les villes actives
            
            var varleursPost3 = new ChartValues<double>();
            var valeursCommentaires3 = new ChartValues<double>();
            var valeursVues3 = new ChartValues<double>();
            var valeursLikes3 = new ChartValues<double>();
            
            List<string> Nom = new List<string>();
            
            foreach (var item in statistic.VillesActives)
            {
                //
                varleursPost3.Add(item.NombrePosts);
                valeursCommentaires3.Add(item.NombreCommentaires);
                valeursVues3.Add(item.NombreVues);
                valeursLikes3.Add(item.NombreLikes);
               
                //enlever le dernier element de la liste
               
                // 
                Nom.Add(item.Nom);
            }
            
            SeriesCollection3 = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "Post",
                    Values = varleursPost3,
                    StackMode = StackMode.Values
                },
                new StackedColumnSeries
                {
                    Title = "Commentaires",
                    Values = valeursCommentaires3,
                    StackMode = StackMode.Values
                }
            };
 
            //adding series updates and animates the chart
            SeriesCollection3.Add(new StackedColumnSeries
            {
                Title = "Vues",
                Values = valeursVues3,
                StackMode = StackMode.Values
            });
            
            SeriesCollection3.Add(new StackedColumnSeries
            {
                Title = "Likes",
                Values = valeursLikes3,
                StackMode = StackMode.Values
            });
 
          
 
            Labels3 = Nom.ToArray();
            Formatter3 = value => value.ToString("N");
 
            DataContext = this;
            
            // graphique 4 pour les postes les plus likés
            var varleursPost4 = new ChartValues<double>();
            
            List<string> Titre = new List<string>();
            
            foreach (var item in statistic.PostsLesPlusLikes)
            {
                //
                varleursPost4.Add(item.NombreLikes);
               
                //enlever le dernier element de la liste
               
                // 
                Titre.Add(item.Titre);
            }
            
            
            SeriesCollection4 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Les postes les plus likés",
                    Values = varleursPost4,
                    Fill = Brushes.CadetBlue  // Couleur des barres
                }
            };
            Labels4 = Titre.ToArray();

            Formatter4 = value => value.ToString("N");
            
            DataContext = this;
            
            // graphique 5 pour les postes les plus superlikés
            var varleursPost5 = new ChartValues<double>();
            
            List<string> Titre5 = new List<string>();
            
            foreach (var item in statistic.PostsLesPlusSuperlikes)
            {
                //
                varleursPost5.Add(item.NombreSuperlikes);
               
                //enlever le dernier element de la liste
               
                // 
                Titre5.Add(item.Titre);
            }
            
            
            SeriesCollection5 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Les postes les plus superlikés",
                    Values = varleursPost5,
                    Fill = Brushes.Goldenrod  // Couleur des barres
                }
            };
            Labels5 = Titre5.ToArray();
            
            Formatter5 = value => value.ToString("N");
            
            DataContext = this;
            
            
            // graphique 6 pour les postes les plus commentés
            var varleursPost6 = new ChartValues<double>();
            
            List<string> Titre6 = new List<string>();
            
            foreach (var item in statistic.PostsLesPlusCommentes)
            {
                //
                varleursPost6.Add(item.NombreCommentaires);
               
                //enlever le dernier element de la liste
               
                // 
                Titre6.Add(item.Titre);
            }
            
            
            
            SeriesCollection6 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Les postes les plus commentés",
                    Values = varleursPost6,
                    Fill = Brushes.DarkOliveGreen  // Couleur des barres
                }
            };
            
            Labels6 = Titre6.ToArray();
            
            Formatter6 = value => value.ToString("N");
            
            DataContext = this;
            
            // graphique 7 pour les postes les plus vus
            var varleursPost7 = new ChartValues<double>();
            
            List<string> Titre7 = new List<string>();
            
            foreach (var item in statistic.PostsLesPlusVus)
            {
                //
                varleursPost7.Add(item.NombreVues);
               
                //enlever le dernier element de la liste
               
                // 
                Titre7.Add(item.Titre);
            }
            
            
            
            SeriesCollection7 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Les postes les plus vus",
                    Values = varleursPost7,
                    Fill = Brushes.DarkSlateGray  // Couleur des barres
                }
            };
            
            Labels7 = Titre7.ToArray();
            
            Formatter7 = value => value.ToString("N");
            
            DataContext = this;
            
            
            
        }

        private void ReturnToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            // Créez une nouvelle instance de MainWindow
            

            // Fermez la fenêtre actuelle
            Close();

            // Affichez la fenêtre principale
            //mainWindow.Show();
        }
        
        
        // methode qui supprime les statistiques avec l'id selectionné
        private async void DeleteStatistics_Click(object sender, RoutedEventArgs e)
        {
            // On recupere l'id de la statistique selectionné
            int id = int.Parse(textBlockId.Text.Split(':')[1].Trim());
            
            // On recupere les statistiques entre les deux date avec GetByDates du Client
            Client apiClient = new Client();
            await apiClient.DeleteAsync(id);
            
            // On ferme la fenetre
            Close();
            
            // On affiche un message de confirmation
            MessageBox.Show("Statistiques supprimées avec succès veuillez rafraichir la fenetre principale");
            
            
            // On rafraichit la fenetre principale
            
        }
       
    }
}