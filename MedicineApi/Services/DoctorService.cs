using MedicineApi.Domain;
using MedicineApi.Dto;
using MedicineApi.Infrastructure.Data.DoctorModel;
using MedicineApi.Infrastructure.UoW;

namespace MedicineApi.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IDoctorRepository repository, IUnitOfWork unitOfWork)
        {
            _doctorRepository = repository;
            _unitOfWork = unitOfWork;
        }
        public int CreateDoctor(DoctorDto doctor)
        {
            if (doctor == null)
            {
                throw new Exception($"{nameof(Doctor)} not found");
            }

            Doctor doctorEntity = doctor.ConvertToDoctor();

            int resultId = _doctorRepository.Create(doctorEntity);

            _unitOfWork.SaveEntitiesAsync();

            return resultId;
        }

        public void DeleteDoctor(int doctorId)
        {
            Doctor hospital = _doctorRepository.GetById(doctorId);
            if (hospital == null)
            {
                throw new Exception($"{nameof(Doctor)} not found, #Id - {doctorId}");
            }

            _doctorRepository.Delete(hospital);

            _unitOfWork.SaveEntitiesAsync();
        }

        public Doctor GetDoctor(int doctorId)
        {
            Doctor doctor = _doctorRepository.GetById(doctorId);
            if (doctor == null)
            {
                throw new Exception($"{nameof(Doctor)} not found, #Id - {doctorId}");
            }

            return doctor;
        }

        public List<Doctor> GetDoctors()
        {
            List<Doctor> result = new();
            result.AddRange(_doctorRepository.GetAll());
            return result;
        }

        public void UpdateDoctor(DoctorDto doctorDto)
        {
            Doctor doctor = _doctorRepository.GetById(doctorDto.Id);
            if (doctor == null)
            {
                throw new Exception($"{nameof(Hospital)} not found, #Id - {doctorDto.Id}");
            }

            doctor.UpdateName(doctorDto.Name);
            doctor.UpdateTelephoneNumber(doctorDto.TelephoneNumber);
            doctor.UpdateHospitalId(doctorDto.HospitalId);

            _doctorRepository.Update(doctor);

            _unitOfWork.SaveEntitiesAsync();

        }
    }
}
