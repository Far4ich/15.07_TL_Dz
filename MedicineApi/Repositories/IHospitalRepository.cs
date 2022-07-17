using MedicineApi.Domain;

namespace MedicineApi.Repositories
{
    public interface IHospitalRepository
    {
        IReadOnlyList<Hospital> GetAll();
        Hospital GetById(int id);
        Hospital GetFromDoctor(Doctor doctor);
        int Create(Hospital hospital);
        int Update(Hospital hospital);
        void Delete(Hospital hospital);
    }
}
