using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using MedicineApi.Domain;

namespace MedicineApi.Repositories
{
    public class SqlDoctorRepository : IDoctorRepository
    {
        private readonly string _connectionString;

        public SqlDoctorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Create(Doctor doctor)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "insert into [Doctor] (Name, TelephoneNumber, HospitalId) values (@name, @telephoneNumber, @hospitalId)";
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = doctor.Name;
            sqlCommand.Parameters.Add("@hospitalId", SqlDbType.Int).Value = doctor.HospitalId;
            sqlCommand.Parameters.Add("@telephoneNumber", SqlDbType.NVarChar, 30).Value = doctor.TelephoneNumber;

            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }
        
        public void Delete(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete [Doctor] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = doctor.Id;
            sqlCommand.ExecuteNonQuery();
        }

        public IReadOnlyList<Doctor> GetAll()
        {
            var result = new List<Doctor>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [TelephoneNumber], [HospitalId] from [Doctor]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Doctor(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToString(reader["TelephoneNumber"]),
                    Convert.ToInt32(reader["HospitalId"])
                ));
            }

            return result;
        }

        public Doctor GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [TelephoneNumber], [HospitalId] from [Doctor] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Doctor(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToString(reader["TelephoneNumber"]),
                    Convert.ToInt32(reader["HospitalId"])
                );
            }
            else
            {
                return null;
            }
        }

        public Doctor GetFromPatient(Patient patient)
        {
            return GetById(patient.DoctorId);
        }

        public int Update(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Doctor] set [Name] = @name, [TelephoneNumber] = @telephoneNumber, [HospitalId] = @hospitalId where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = doctor.Id;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = doctor.Name;
            sqlCommand.Parameters.Add("@telephoneNumber", SqlDbType.NVarChar, 30).Value = doctor.TelephoneNumber;
            sqlCommand.Parameters.Add("@hospitalId", SqlDbType.Int).Value = doctor.HospitalId;
            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }
    }
}
