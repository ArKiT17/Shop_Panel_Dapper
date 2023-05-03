using Dapper;
using dz_Dapper.DataBase;
using Microsoft.Data.SqlClient;
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
	/// Логика взаимодействия для LogIn.xaml
	/// </summary>
	public partial class LogIn : Page {
		public LogIn() {
			InitializeComponent();
			login.Focus();
		}
		private void LogIn_btn_click(object sender, RoutedEventArgs e) {
			using (var connection = new SqlConnection(Buffer.connection)) {
				connection.Open();
				if (connection.Query<Users>($"select Users.[Role] from Users where [Login] = '{login.Text}' and [Password] = '{password.Password}'").ToList().Count > 0) {
					Buffer.activeUserRole = connection.Query<Users>($"select Users.[Role] from Users where [Login] = '{login.Text}' and [Password] = '{password.Password}'").ToList()[0].Role;
					NavigationService.Navigate(new MainPage());
				}
				else
					MessageBox.Show("Користувача не знайдено");
			}
		}

		private void SignIn_btn_click(object sender, RoutedEventArgs e) {
			NavigationService.Navigate(new SignUp());
		}
	}
}
