using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace Zadanie_3_binding_do_klas_C_
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<MediaItem> MediaItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MediaItems = new ObservableCollection<MediaItem>();
            MediaListBox.ItemsSource = MediaItems;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newItem = new MediaItem();
            var editWindow = new EditWindow(newItem);
            if (editWindow.ShowDialog() == true)
            {
                MediaItems.Add(newItem);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (MediaListBox.SelectedItem is MediaItem selectedItem)
            {
                var editWindow = new EditWindow(selectedItem);
                editWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybierz element do edycji.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MediaListBox.SelectedItem is MediaItem selectedItem)
            {
                MediaItems.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Wybierz element do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == true)
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                var importedItems = JsonSerializer.Deserialize<ObservableCollection<MediaItem>>(json);
                if (importedItems != null)
                {
                    MediaItems.Clear();
                    foreach (var item in importedItems)
                    {
                        MediaItems.Add(item);
                    }
                }
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
            {
                string json = JsonSerializer.Serialize(MediaItems);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }
    }
}