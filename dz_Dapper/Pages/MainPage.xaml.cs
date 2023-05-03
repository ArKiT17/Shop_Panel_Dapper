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

namespace dz_Dapper.Pages {
	/// <summary>
	/// Логика взаимодействия для MainPage.xaml
	/// </summary>
	public partial class MainPage : Page {
		public MainPage() {
			InitializeComponent();
		}

		private void Back_btn_click(object sender, RoutedEventArgs e) {
			NavigationService.GoBack();
		}

		private void Add_btn_click(object sender, RoutedEventArgs e) {
			NavigationService.Navigate(new AddItem());
		}

		private void Change_btn_click(object sender, RoutedEventArgs e) {
			NavigationService.Navigate(new ChangeItem());
		}
	}
}
