using MedicineApi.Domain;
using MedicineApi.Dto;

namespace MedicineApi.Services
{
    public interface IDoctorService
    {
        List<Doctor> GetDoctors();
        Doctor GetDoctor(int doctorId);
        void UpdateDoctor(DoctorDto doctor);
        int CreateDoctor(DoctorDto doctor);
        void DeleteDoctor(int doctorId);
    }
}
