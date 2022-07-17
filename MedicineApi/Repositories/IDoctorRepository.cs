using MedicineApi.Domain;

namespace MedicineApi.Repositories
{
    public interface IDoctorRepository
    {
        IReadOnlyList<Doctor> GetAll();
        Doctor GetById(int id);
        Doctor GetFromPatient(Patient patient);
        int Create(Doctor doctor);
        int Update(Doctor doctor);
        void Delete(Doctor doctor);
    }
}
