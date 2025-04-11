using System.Windows;
using InventorySystem.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Controls;

namespace InventorySystem
{
    public partial class LoginWindow : Window
    {
        private readonly ApplicationDbContext _db;

        public LoginWindow(ApplicationDbContext dbContext)
        {
            InitializeComponent();
            _db = dbContext;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;

            string hashedPassword = Hash(password);

            var user = _db.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Username == username && u.PasswordHash == hashedPassword);

            if (user != null)
            {
                MessageBox.Show($"Welcome, {user.Username} ({user.Role.RoleName})");

                var mainWindow = new MainWindow(); // 🔁 You can replace with a dashboard later
                mainWindow.Show();
                this.Close();
            }
            else
            {
                ErrorText.Text = "Invalid username or password.";
                ErrorText.Visibility = Visibility.Visible;
            }
        }

        private string Hash(string input)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void UsernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
