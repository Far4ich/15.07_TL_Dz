using MedicineApi.Domain;
using MedicineApi.Dto;

namespace MedicineApi.Services
{
    public interface IPatientService
    {
        List<Patient> GetPatients();
        Patient GetPatient(int patientId);
        void UpdatePatient(PatientDto patient);
        int CreatePatient(PatientDto patient);
        void DeletePatient(int patientId);
    }
}
