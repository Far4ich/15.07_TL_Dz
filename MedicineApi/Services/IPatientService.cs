using MedicineApi.Domain;
using MedicineApi.Dto;

namespace MedicineApi.Services
{
    public interface IPatientService
    {
        List<Patient> GetPatients();
        Patient GetPatient(int patientId);
        List<Tuple<int, int>> GetDoctorsByCountPatients();
        int UpdatePatient(PatientDto patient);
        int CreatePatient(PatientDto patient);
        void DeletePatient(int patientId);
    }
}
