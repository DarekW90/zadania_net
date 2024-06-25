using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace VehicleApp
{
    public partial class MainWindow : Window
    {
        public Vehicles VehicleData { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            CategoryList.ItemsSource = VehicleData?.Categories;
        }

        private void LoadData()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vehicles.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(Vehicles));
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    VehicleData = (Vehicles)serializer.Deserialize(fs);
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Nie można znaleźć pliku 'vehicles.xml'. Szczegóły: {ex.Message}", "Błąd ładowania danych", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0); // Wymuś wyjście z aplikacji przy braku pliku
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił nieoczekiwany błąd podczas ładowania danych z pliku 'vehicles.xml'. Szczegóły: {ex.Message}", "Błąd ładowania danych", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0); // Wymuś wyjście z aplikacji przy nieoczekiwanym błędzie
            }
        }

        private void CategoryList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CategoryList.SelectedItem is Category selectedCategory)
            {
                CategoryWindow categoryWindow = new CategoryWindow(selectedCategory);
                categoryWindow.Show();
            }
        }
    }
}
