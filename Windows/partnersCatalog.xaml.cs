using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media;

namespace DEMO.Windows
{
    public class Partner
    {
        public string PartnerName { get; set; }
        public string PartnerType { get; set; }
        public string DirectorName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string INN { get; set; }
        public int Rating { get; set; }
    }

    public partial class partnersCatalog : Page
    {
        public partnersCatalog()
        {
            InitializeComponent();
            LoadPartners();
        }

        private string connectionString = "Server=ReFlex;Database=DEMO;Integrated Security=True;";

        // Синхронный метод для загрузки данных из базы данных
        private List<Partner> LoadPartnersFromDatabase()
        {
            List<Partner> partners = new List<Partner>();
            string query = "SELECT PartnerName, PartnerType, DirectorName, Email, Phone, Address, INN, Rating FROM Partners";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Partner partner = new Partner
                        {
                            PartnerName = reader["PartnerName"].ToString(),
                            PartnerType = reader["PartnerType"].ToString(),
                            DirectorName = reader["DirectorName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Address = reader["Address"].ToString(),
                            INN = reader["INN"].ToString(),
                            Rating = (int)reader["Rating"]
                        };
                        partners.Add(partner);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }

            return partners;
        }

        private void LoadPartners()
        {
            List<Partner> partners = LoadPartnersFromDatabase();

            // Очищаем StackPanel перед загрузкой данных
            PartnersStackPanel.Children.Clear();

            // Создаем карточки для каждого партнёра
            foreach (var partner in partners)
            {
                Border partnerCard = new Border
                {
                    BorderBrush = new SolidColorBrush(Colors.Gray),
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(10, 10, 10, 10),
                    CornerRadius = new CornerRadius(10),
                    Background = new SolidColorBrush(Colors.White)
                };

                StackPanel cardContent = new StackPanel
                {
                    Margin = new Thickness(10)
                };

                // Добавление данных партнёра на карточку
                cardContent.Children.Add(new TextBlock
                {
                    Text = partner.PartnerName,
                    FontWeight = FontWeights.Bold,
                    FontSize = 16,
                    Margin = new Thickness(0, 0, 0, 5)
                });

                cardContent.Children.Add(new TextBlock { Text = "Тип: " + partner.PartnerType });
                cardContent.Children.Add(new TextBlock { Text = "Директор: " + partner.DirectorName });
                cardContent.Children.Add(new TextBlock { Text = "Email: " + partner.Email });
                cardContent.Children.Add(new TextBlock { Text = "Телефон: " + partner.Phone });
                cardContent.Children.Add(new TextBlock { Text = "Адрес: " + partner.Address });
                cardContent.Children.Add(new TextBlock { Text = "ИНН: " + partner.INN });
                cardContent.Children.Add(new TextBlock { Text = "Рейтинг: " + partner.Rating });

                partnerCard.Child = cardContent;

                // Добавляем карточку в StackPanel
                PartnersStackPanel.Children.Add(partnerCard);
            }
        }
    }
}