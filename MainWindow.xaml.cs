using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManageCategoriesApp1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnInsert_Click(object sender, RoutedEventArgs e)
		{
			var category = new Category { CategoryName = txtCategoryName.Text };
			ManageCategories.Instance.InsertCategory(category);
			LoadCategories();
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			var category = new Category
			{
				CategoryID = int.Parse(txtCategoryID.Text),
				CategoryName = txtCategoryName.Text
			};
			ManageCategories.Instance.UpdateCategory(category); LoadCategories();
			
		
		}

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			var category = new Category { CategoryID = int.Parse(txtCategoryID.Text) };
			ManageCategories.Instance.DeleteCategory(category);
			LoadCategories();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadCategories();
		}
		public void LoadCategories()
		{
			var categories = ManageCategories.Instance.GetCategories();
			lvCategories.ItemsSource = categories;
			
		}
	}
}