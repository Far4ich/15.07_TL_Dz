using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using MedicineApi.Domain;

namespace MedicineApi.Repositories
{
    public class SqlPatientRepository : IPatientRepository
    {
        private readonly string _connectionString;

        public SqlPatientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IReadOnlyList<Patient> GetAll()
        {
            var result = new List<Patient>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [HealthCardNumber], [DoctorId] from [Patient]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Patient(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToInt32(reader["HealthCardNumber"]),
                    Convert.ToInt32(reader["DoctorId"])
                ));
            }

            return result;
        }

        public Patient GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [HealthCardNumber], [DoctorId] from [Patient] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Patient(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToInt32(reader["HealthCardNumber"]),
                    Convert.ToInt32(reader["DoctorId"])
                );
            }
            else
            {
                return null;
            }
        }

        public int Update(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Patient] set [Name] = @name, [HealthCardNumber] = @healthCardNumber, [DoctorId] = @doctorId where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = patient.Id;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = patient.Name;
            sqlCommand.Parameters.Add("@healthCardNumber", SqlDbType.Int).Value = patient.HealthCardNumber;
            sqlCommand.Parameters.Add("@doctorId", SqlDbType.Int).Value = patient.DoctorId;

            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }
        public void Delete(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete [Patient] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = patient.Id;
            sqlCommand.ExecuteNonQuery();
        }

        public List<Tuple<int, int>> GetDoctorsByCountPatients()
        {
            var result = new List<Tuple<int, int>>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [DoctorId], count(*) as [PatientCount] from [Patient] group by [DoctorId]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add( new (
                    Convert.ToInt32(reader["DoctorId"]),
                    Convert.ToInt32(reader["PatientCount"])
                ));
            }
            return result;
        }

        public int Create(Patient patient)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "insert into [Patient] (Name, HealthCardNumber, DoctorId) values (@name, @healthCardNumber, @doctorId)";
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = patient.Name;
            sqlCommand.Parameters.Add("@doctorId", SqlDbType.Int).Value = patient.DoctorId;
            sqlCommand.Parameters.Add("@healthCardNumber", SqlDbType.Int).Value = patient.HealthCardNumber;

            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }
    }
}
