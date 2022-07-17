using MedicineApi.Domain;
using MedicineApi.Dto;

namespace MedicineApi.Services
{
    public interface IHospitalService
    {
        List<Hospital> GetHospitals();
        Hospital GetHospital(int hospitalId);
        int UpdateHospital(HospitalDto hospital);
        int CreateHospital(HospitalDto hospital);
        void DeleteHospital(int hospitalId);
    }
}
