using MedicineApi.Domain;

namespace MedicineApi.Repositories
{
    public interface IPatientRepository
    {
        IReadOnlyList<Patient> GetAll();
        Patient GetById(int id);
        int Create(Patient patient);
        int Update(Patient patient);
        void Delete(Patient patient);
        List<Tuple<int, int>> GetDoctorsByCountPatients();
    }
}
