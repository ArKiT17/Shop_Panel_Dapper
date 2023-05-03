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
	/// Логика взаимодействия для SignUp.xaml
	/// </summary>
	public partial class SignUp : Page {
		public SignUp() {
			InitializeComponent();
			login.Focus();
		}
		private void Back_btn_click(object sender, RoutedEventArgs e) {
			login.Text = string.Empty;
			password.Password = string.Empty;
			password2.Password = string.Empty;
			NavigationService.GoBack();
		}
		private void SignUp_btn_click(object sender, RoutedEventArgs e) {
			if (login.Text == "") {
				MessageBox.Show("Логін є обов'язковим!");
				return;
			}
			if (password.Password == "") {
				MessageBox.Show("Пароль є обов'язковим!");
				return;
			}
			if (password.Password != password2.Password) {
				MessageBox.Show("Паролі не співпадають");
				return;
			}
			using (var connection = new SqlConnection(Buffer.connection)) {
				connection.Open();
				if (connection.Query<Users>($"select * from Users where [Login] = '{login.Text}'").ToList().Count != 0)
					MessageBox.Show("Користувач з таким логіном вже існує, будь ласка, оберіть інший");
				else {
					if (connection.Execute($"insert into Users ([Login], [Password], [Role]) values ('{login.Text}', '{password.Password}', 'user')") > 0) {
						MessageBox.Show("Реєстрація пройшла успішно!");
						login.Text = string.Empty;
						password.Password = string.Empty;
						NavigationService.GoBack();
					}
					else
						MessageBox.Show("Помилка реєстрації");
				}

			}
		}
	}
}
