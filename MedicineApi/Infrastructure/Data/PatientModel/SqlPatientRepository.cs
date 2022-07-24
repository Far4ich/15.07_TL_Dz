using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using MedicineApi.Domain;

namespace MedicineApi.Infrastructure.Data.PatientModel
{
    public class SqlPatientRepository : IPatientRepository
    {
        private readonly MedicineContext _dbContext;

        public SqlPatientRepository(MedicineContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Patient> GetAll()
        {
            return _dbContext.Patient.ToList();
        }

        public int Create(Patient patient)
        {
            return _dbContext.Patient.Add(patient).Entity.Id;
        }

        public void Delete(Patient patient)
        {
            _dbContext.Patient.Remove(patient);
        }

        public Patient GetById(int id)
        {
            return _dbContext.Patient.SingleOrDefault(patient => patient.Id == id);
        }

        public void Update(Patient patient)
        {
            _dbContext.Patient.Update(patient);
        }
    }
}
