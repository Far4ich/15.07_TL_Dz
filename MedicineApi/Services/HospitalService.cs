using MedicineApi.Domain;
using MedicineApi.Dto;
using MedicineApi.Repositories;

namespace MedicineApi.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _hospitalRepository;

        public HospitalService(IHospitalRepository repository)
        {
            _hospitalRepository = repository;
        }

        public int CreateHospital(HospitalDto hospital)
        {
            if (hospital == null)
            {
                throw new Exception($"{nameof(Hospital)} not found");
            }

            Hospital hospitalEntity = hospital.ConvertToHospital();

            return _hospitalRepository.Create(hospitalEntity);
        }

        public void DeleteHospital(int hospitalId)
        {
            Hospital hospital = _hospitalRepository.GetById(hospitalId);
            if (hospital == null)
            {
                throw new Exception($"{nameof(Hospital)} not found, #Id - {hospitalId}");
            }

            _hospitalRepository.Delete(hospital);
        }

        public Hospital GetHospital(int hospitalId)
        {
            Hospital hospital = _hospitalRepository.GetById(hospitalId);
            if (hospital == null)
            {
                throw new Exception($"{nameof(Hospital)} not found, #Id - {hospitalId}");
            }

            return hospital;
        }

        public List<Hospital> GetHospitals()
        {
            List<Hospital> result = new();
            result.AddRange(_hospitalRepository.GetAll());
            return result;
        }

        public int UpdateHospital(HospitalDto hospitalDto)
        {
            Hospital hospital = _hospitalRepository.GetById(hospitalDto.Id);
            if (hospital == null)
            {
                throw new Exception($"{nameof(Hospital)} not found, #Id - {hospitalDto.Id}");
            }

            return _hospitalRepository.Update(hospitalDto.ConvertToHospital());
        }
    }
}
