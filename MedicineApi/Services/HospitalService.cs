using MedicineApi.Domain;
using MedicineApi.Dto;
using MedicineApi.Infrastructure.Data.HospitalModel;
using MedicineApi.Infrastructure.UoW;

namespace MedicineApi.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HospitalService(IHospitalRepository repository, IUnitOfWork unitOfWork)
        {
            _hospitalRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public int CreateHospital(HospitalDto hospital)
        {
            if (hospital == null)
            {
                throw new Exception($"{nameof(Hospital)} not found");
            }

            Hospital hospitalEntity = hospital.ConvertToHospital();

            int resultId = _hospitalRepository.Create(hospitalEntity);

            _unitOfWork.SaveEntitiesAsync();

            return resultId;
        }

        public void DeleteHospital(int hospitalId)
        {
            Hospital hospital = _hospitalRepository.GetById(hospitalId);
            if (hospital == null)
            {
                throw new Exception($"{nameof(Hospital)} not found, #Id - {hospitalId}");
            }

            _hospitalRepository.Delete(hospital);
            _unitOfWork.SaveEntitiesAsync();
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

        public void UpdateHospital(HospitalDto hospitalDto)
        {
            Hospital hospital = _hospitalRepository.GetById(hospitalDto.Id);
            
            if (hospital == null)
            {
                throw new Exception($"{nameof(Hospital)} not found, #Id - {hospitalDto.Id}");
            }

            hospital.UpdateName(hospitalDto.Name);
            hospital.UpdateAddress(hospitalDto.Address);
            hospital.UpdateTelephoneNumber(hospitalDto.TelephoneNumber);

            _hospitalRepository.Update(hospital);

            _unitOfWork.SaveEntitiesAsync();
        }
    }
}
