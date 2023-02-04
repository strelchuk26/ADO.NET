using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace hospital
{
	public class Examination
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class Doctor
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public decimal Salary { get; set; }
		public decimal Premium { get; set; }
	}

	public class HospitalManager
	{ 
		const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital_Test;Integrated Security=True;";
		SqlConnection connection;

		public HospitalManager()
		{
			connection = new SqlConnection(connectionString);
			connection.Open();
		}

		~HospitalManager()
		{
			connection.Close();
		}

		// 1. Отримати кількість місць у певному відділенні по імені
		public int GetCountOfPlaces(string dep_name)
		{
			SqlCommand command = connection.CreateCommand();
			command.CommandText = $"select w.Places " +
								  $"from Wards as w join Departments as d on w.DepartmentId = d.Id " +
								  $"where d.Name = '{dep_name}'";

			return (int)command.ExecuteScalar();
		}


		// 2. Отримати список всіх обстежень
		public List<Examination> GetAllExaminations()
		{
			SqlCommand command = connection.CreateCommand();
			command.CommandText = $"select * " +
								  $"from Examinations " +
								  $"order by Id";

			SqlDataReader reader = command.ExecuteReader();

			List<Examination> examinations = new List<Examination>();

			while (reader.Read())
			{
				examinations.Add(new Examination() 
				{
					Id = (int)reader["Id"],
					Name = (string)reader["Name"]
				});
			}

			return examinations;
		}


		// 3. Видалити обстеження, які були проведені раніше певної дати
		public void DeleteExaminations(string time)
		{
			SqlCommand command = connection.CreateCommand();
			command.CommandText = $"delete from DoctorsExaminations where StartTime < '{time}'";

			command.ExecuteNonQuery();
		}


		// 4. Отримати всії докторів, які мають ЗП більшу за певне значення 
		public List<Doctor> GetAllDoctorsAboveSalary(float salary)
		{
			SqlCommand command = connection.CreateCommand();
			command.CommandText = $"select * " +
								  $"from Doctors " +
								  $"where Salary > {salary}";

			SqlDataReader reader = command.ExecuteReader();

			List<Doctor> list = new List<Doctor>();

			while (reader.Read())
			{
				list.Add(new Doctor()
				{
					Id = (int)reader["Id"],
					Name = (string)reader["Name"],
					Surname = (string)reader["Surname"],
					Salary = (decimal)reader["Salary"],
					Premium = (decimal)reader["Premium"]
				});
			}

			return list;
		}


		// 5. Отримати найбільший донат по сумі пожертви
		public decimal GetBiggestDonation()
		{
			SqlCommand command = connection.CreateCommand();
			command.CommandText = $"select top 1 Amount " +
								  $"from Donations " +
								  $"order by Amount desc";

			return Convert.ToDecimal(command.ExecuteScalar());
		}


		// 6. Додати нове обстеження вказавши всі необхідні параметри
		public void AddExamination(string name)
		{
			SqlCommand command = connection.CreateCommand();
			command.CommandText = $"insert into Examinations (Name) values ('{name}')";

			command.ExecuteNonQuery();
		}


		// 7. *Видалити спонсорів, які не зробили жодної пожертви за весь період.
		public void DeleteSponsors()
		{ 
			SqlCommand command = connection.CreateCommand();
			command.CommandText = $"delete from Sponsors " +
								  $"where Id NOT IN(select SponsorId from Donations)";

			command.ExecuteNonQuery();
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			HospitalManager manager = new HospitalManager();

			//foreach (var d in manager.GetAllDoctorsAboveSalary(5000))
			//{
			//	Console.WriteLine($"[{d.Id}] {d.Name} {d.Surname} - {d.Salary} + {d.Premium}");
			//}

			//Console.WriteLine(manager.GetBiggestDonation());

			//manager.GetCountOfPlaces("Rim Lichen");
		}
	}
}
