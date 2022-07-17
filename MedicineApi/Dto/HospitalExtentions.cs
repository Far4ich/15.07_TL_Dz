using MedicineApi.Domain;

namespace MedicineApi.Dto
{
    public static class HospitalExtentions
    {
        public static HospitalDto ConvertToHospitalDto(this Hospital hospital)
        {
            return new HospitalDto
            {
                Id = hospital.Id,
                Name = hospital.Name,
                Address = hospital.Address,
                TelephoneNumber = hospital.TelephoneNumber
            };
        }
        public static Hospital ConvertToHospital(this HospitalDto hospital)
        {
            return new Hospital(hospital.Id, hospital.Name, hospital.Address, hospital.TelephoneNumber);
        }
    }
}
