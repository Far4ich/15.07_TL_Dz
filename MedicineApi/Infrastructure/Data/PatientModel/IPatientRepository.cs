using MedicineApi.Domain;

namespace MedicineApi.Infrastructure.Data.PatientModel
{
    public interface IPatientRepository
    {
        List<Patient> GetAll();
        Patient GetById(int id);
        int Create(Patient patient);
        void Update(Patient patient);
        void Delete(Patient patient);
    }
}
