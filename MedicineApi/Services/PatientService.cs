using MedicineApi.Domain;
using MedicineApi.Dto;
using MedicineApi.Repositories;

namespace MedicineApi.Services
{
    public class PatientService:IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository repository)
        {
            _patientRepository = repository;
        }
        public int CreatePatient(PatientDto patient)
        {
            if (patient == null)
            {
                throw new Exception($"{nameof(Patient)} not found");
            }

            Patient patientEntity = patient.ConvertToPatient();

            return _patientRepository.Create(patientEntity);
        }

        public void DeletePatient(int patientId)
        {
            Patient patient = _patientRepository.GetById(patientId);
            if (patient == null)
            {
                throw new Exception($"{nameof(Patient)} not found, #Id - {patientId}");
            }

            _patientRepository.Delete(patient);
        }

        public List<Tuple<int, int>> GetDoctorsByCountPatients()
        {
            return _patientRepository.GetDoctorsByCountPatients();
        }

        public Patient GetPatient(int patientId)
        {
            Patient patient = _patientRepository.GetById(patientId);
            if (patient == null)
            {
                throw new Exception($"{nameof(Patient)} not found, #Id - {patientId}");
            }

            return patient;
        }

        public List<Patient> GetPatients()
        {
            List<Patient> result = new();
            result.AddRange(_patientRepository.GetAll());
            return result;
        }

        public int UpdatePatient(PatientDto patientDto)
        {
            Patient hospital = _patientRepository.GetById(patientDto.Id);
            if (hospital == null)
            {
                throw new Exception($"{nameof(Hospital)} not found, #Id - {patientDto.Id}");
            }

            return _patientRepository.Update(patientDto.ConvertToPatient());
        }
    }
}
