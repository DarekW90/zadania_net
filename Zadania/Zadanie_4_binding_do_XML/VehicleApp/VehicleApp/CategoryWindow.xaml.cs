using System.Windows;

namespace VehicleApp
{
    public partial class CategoryWindow : Window
    {
        public CategoryWindow(Category category)
        {
            InitializeComponent();
            CategoryDescription.Text = category.Description;
            SubCategoryList.ItemsSource = category.SubCategories;
        }

        private void SubCategoryList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (SubCategoryList.SelectedItem is SubCategory selectedSubCategory)
            {
                SubCategoryWindow subCategoryWindow = new SubCategoryWindow(selectedSubCategory);
                subCategoryWindow.Show();
            }
        }
    }
}
