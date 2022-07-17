using MedicineApi.Domain;
using MedicineApi.Dto;
using MedicineApi.Repositories;

namespace MedicineApi.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository repository)
        {
            _doctorRepository = repository;
        }
        public int CreateDoctor(DoctorDto doctor)
        {
            if (doctor == null)
            {
                throw new Exception($"{nameof(Doctor)} not found");
            }

            Doctor doctorEntity = doctor.ConvertToDoctor();

            return _doctorRepository.Create(doctorEntity);
        }

        public void DeleteDoctor(int doctorId)
        {
            Doctor hospital = _doctorRepository.GetById(doctorId);
            if (hospital == null)
            {
                throw new Exception($"{nameof(Doctor)} not found, #Id - {doctorId}");
            }

            _doctorRepository.Delete(hospital);
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

        public int UpdateDoctor(DoctorDto doctorDto)
        {
            Doctor hospital = _doctorRepository.GetById(doctorDto.Id);
            if (hospital == null)
            {
                throw new Exception($"{nameof(Hospital)} not found, #Id - {doctorDto.Id}");
            }

            return _doctorRepository.Update(doctorDto.ConvertToDoctor());
        }
    }
}
