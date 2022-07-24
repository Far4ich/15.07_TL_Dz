using MedicineApi.Domain;

namespace MedicineApi.Infrastructure.Data.DoctorModel
{
    public interface IDoctorRepository
    {
        List<Doctor> GetAll();
        Doctor GetById(int id);
        int Create(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
    }
}
