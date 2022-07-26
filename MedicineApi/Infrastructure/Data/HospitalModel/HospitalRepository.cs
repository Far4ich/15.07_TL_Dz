using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using MedicineApi.Domain;
using MedicineApi.Infrastructure.Data;

namespace MedicineApi.Infrastructure.Data.HospitalModel
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly MedicineContext _dbContext;

        public HospitalRepository(MedicineContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Hospital> GetAll()
        {
            return _dbContext.Hospital.ToList();
        }

        public int Create(Hospital hospital)
        {
            return _dbContext.Hospital.Add(hospital).Entity.Id;
        }

        public void Delete(Hospital hospital)
        {
            _dbContext.Hospital.Remove(hospital);
        }

        public Hospital GetById(int id)
        {
            return _dbContext.Hospital.SingleOrDefault(hospital => hospital.Id == id);
        }

        public void Update(Hospital hospital)
        {
            _dbContext.Hospital.Update(hospital);
        }
    }
}
