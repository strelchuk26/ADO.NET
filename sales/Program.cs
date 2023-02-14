using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace sales
{
	public class SalesManager
	{
		private SqlConnection connection;

		public SalesManager()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["HospitalDb"].ConnectionString;
			connection = new SqlConnection(connectionString);
			connection.Open();
		}

		~SalesManager()
		{
			connection.Close();
		}

		// 1. Додати нову продажу/покупку
		public void AddSale(int BuyerId, int SellerId, decimal SaleAmount)
		{
			SqlCommand command = connection.CreateCommand();
			var sql = $"insert Sales (BuyerId, SellerId, SaleAmount, SaleDate) " +
					  $"values ({BuyerId}, {SellerId}, {SaleAmount}, '{DateTime.Now:yyyy/MM/dd}')";
			command.CommandText = sql;

			Console.WriteLine($"{command.ExecuteNonQuery()} rows affected");
		}

		// 2. Відобразити інформацію про всі продажі за певний період
		public void ShowSales(int year)
		{
			SqlCommand command = connection.CreateCommand();
			var sql = $"select b.Name + ' ' + b.Surname as 'Buyer', " +
					  $"slr.Name + ' ' + slr.Surname as 'Seller', s.SaleAmount, s.SaleDate " +
					  $"from Sales as s join Buyers as b on s.BuyerId = b.Id " +
									  $"join Sellers as slr on s.SellerId = slr.Id " +
					  $"where YEAR(s.SaleDate) = {year}";
			command.CommandText = sql;

			SqlDataReader reader = command.ExecuteReader();

			while (reader.Read()!)
			{
				Console.WriteLine(
					$"{reader["Buyer"]}\t" +
					$"{reader["Seller"]}\t" +
					$"{reader["SaleAmount"]}$\t" +
					$"{reader["SaleDate"]}");
			}
		}

		// 3. Показати останню покупку певного покупця по імені та прізвищу
		public void ShowLastSaleOfBuyer(string name, string surname)
		{
			SqlCommand command = connection.CreateCommand();
			var sql = $"select top 1 b.Name + ' ' + b.Surname as 'Buyer', " +
					  $"slr.Name + ' ' + slr.Surname as 'Seller', s.SaleAmount, s.SaleDate " +
					  $"from Sales as s join Buyers as b on s.BuyerId = b.Id " +
									  $"join Sellers as slr on s.SellerId = slr.Id " +
					  $"where b.Name = '{name}' and b.Surname = '{surname}' " +
					  $"order by s.SaleDate desc";
			command.CommandText = sql;

			SqlDataReader reader = command.ExecuteReader();

			while (reader.Read()!)
			{
				Console.WriteLine(
					$"{reader["Buyer"]}\t" +
					$"{reader["Seller"]}\t" +
					$"{reader["SaleAmount"]}$\t" +
					$"{reader["SaleDate"]}");
			}
		}

		// 4. Видалити продавця або покупця по id
		public void DeleteUser(int id, string user)
		{
			SqlCommand command = connection.CreateCommand();
			string sql = "";

			if (user == "Buyer")
			{
				sql = $"delete Sales " +
					  $"from Sales as s inner join Buyers as b on s.BuyerId = b.Id " +
					  $"where b.Id = {id};" +
					  $"" +
					  $"delete Sales " +
					  $"where BuyerId = {id};";
			}
			else if (user == "Seller")
			{
				sql = $"delete Sales " +
					  $"from Sales as s inner join Sellers as slr on s.SellerId = slr.Id " +
					  $"where slr.Id = {id};" +
					  $"" +
					  $"delete Sales " +
					  $"where SellerId = {id};";
			}
			command.CommandText = sql;

			Console.WriteLine($"{command.ExecuteNonQuery()} rows affected");
		}


		// 5. Показати продавця, загальна сума продаж якого є найбільшою
		public void ShowBiggestSaleAmount()
		{
			SqlCommand command = connection.CreateCommand();
			var sql = $"select top 1 slr.Name, SUM(s.SaleAmount) as 'Amount' " +
					  $"from Sales as s join Sellers as slr on s.SellerId = slr.Id " +
					  $"group by slr.Name " +
					  $"order by SUM(s.SaleAmount) desc";
			command.CommandText = sql;

			SqlDataReader reader = command.ExecuteReader();

			while (reader.Read()!)
			{
				Console.WriteLine(
					$"{reader["Name"]}\t" +
					$"{reader["Amount"]}$");
			}
		}
	}


	internal class Program
	{
		static void Main(string[] args)
		{
			SalesManager manager = new SalesManager();

			

		}
	}
}
