using MedicineApi.Domain;

namespace MedicineApi.Infrastructure.Data.HospitalModel
{
    public interface IHospitalRepository
    {
        List<Hospital> GetAll();
        Hospital GetById(int id);
        int Create(Hospital hospital);
        void Update(Hospital hospital);
        void Delete(Hospital hospital);
    }
}
