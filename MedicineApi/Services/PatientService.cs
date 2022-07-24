using MedicineApi.Domain;
using MedicineApi.Dto;
using MedicineApi.Infrastructure.UoW;
using MedicineApi.Infrastructure.Data.PatientModel;

namespace MedicineApi.Services
{
    public class PatientService:IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IPatientRepository repository, IUnitOfWork unitOfWork)
        {
            _patientRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public int CreatePatient(PatientDto patient)
        {
            if (patient == null)
            {
                throw new Exception($"{nameof(Patient)} not found");
            }

            Patient patientEntity = patient.ConvertToPatient();

            int resultId = _patientRepository.Create(patientEntity);

            _unitOfWork.SaveEntitiesAsync();

            return resultId;
        }

        public void DeletePatient(int patientId)
        {
            Patient patient = _patientRepository.GetById(patientId);
            if (patient == null)
            {
                throw new Exception($"{nameof(Patient)} not found, #Id - {patientId}");
            }

            _patientRepository.Delete(patient);

            _unitOfWork.SaveEntitiesAsync();

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

        public void UpdatePatient(PatientDto patientDto)
        {
            Patient patient = _patientRepository.GetById(patientDto.Id);
            if (patient == null)
            {
                throw new Exception($"{nameof(Hospital)} not found, #Id - {patientDto.Id}");
            }

            patient.UpdateName(patientDto.Name);
            patient.UpdateHealthCardNumber(patientDto.HealthCardNumber);
            patient.UpdateDoctorId(patientDto.DoctorId);

            _patientRepository.Update(patient);

            _unitOfWork.SaveEntitiesAsync();

        }
    }
}
