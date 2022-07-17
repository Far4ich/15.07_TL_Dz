using MedicineApi.Domain;

namespace MedicineApi.Dto
{
    public static class DoctorExtentions
    {
        public static DoctorDto ConvertToDoctorDto(this Doctor doctor)
        {
            return new DoctorDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                HospitalId = doctor.HospitalId,
                TelephoneNumber = doctor.TelephoneNumber
            };
        }
        public static Doctor ConvertToDoctor(this DoctorDto doctor)
        {
            return new Doctor(doctor.Id, doctor.Name, doctor.TelephoneNumber, doctor.HospitalId);
        }
    }
}
