using Avalonia.Controls;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Diagnostics;
using System.IO;
using System;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace moduleApp {
    public partial class ManualWindow : Window
    {
        public ManualWindow()
        {
            InitializeComponent();  
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public async void DeleteAllEvents(object sender, RoutedEventArgs e) {
            var db = new MySqlConnection("Server=localhost;Port=3306;Database=ramappdb;Uid=ssofixd;Pwd=290805;");
            db.Open();
            var cmd = new MySqlCommand("DELETE FROM ProgramStart", db);
            await cmd.ExecuteNonQueryAsync();
            db.Close();
        
        }

        public async void DisplayEventsForUser(object sender, RoutedEventArgs e)
        {
            var resultsListBox = this.FindControl<ListBox>("ResultsListBox");
            List<string> items = new List<string>();

            string userName = "ssofixd";

            string connectionString = "Server=localhost;Port=3306;Database=ramappdb;Uid=ssofixd;Pwd=290805;";
            string selectQuery = " SELECT * from Users full join ProgramStart on @user_started = user_name ";

            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@user_started", userName);

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Формируем строку для отображения
                                string displayText = $"{reader["datetime"]} | {reader["started_app"]} | {reader["start_group"]} | {reader["MB_count"]}";
                                items.Add(displayText);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Обработка ошибок
                        items.Add("Ошибка: " + ex.Message);
                    }
                }
            }

            // Здесь используем ItemsSource
            resultsListBox.ItemsSource = items;
        }

    }
}
