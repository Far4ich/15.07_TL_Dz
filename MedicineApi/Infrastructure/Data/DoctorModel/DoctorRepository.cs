using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using MedicineApi.Domain;

namespace MedicineApi.Infrastructure.Data.DoctorModel
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly MedicineContext _dbContext;

        public DoctorRepository(MedicineContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Doctor> GetAll()
        {
            return _dbContext.Doctor.ToList();
        }

        public int Create(Doctor doctor)
        {
            return _dbContext.Doctor.Add(doctor).Entity.Id;
        }

        public void Delete(Doctor doctor)
        {
            _dbContext.Doctor.Remove(doctor);
        }

        public Doctor GetById(int id)
        {
            return _dbContext.Doctor.SingleOrDefault(doctor => doctor.Id == id);
        }

        public void Update(Doctor doctor)
        {
            _dbContext.Doctor.Update(doctor);
        }
    }
}
