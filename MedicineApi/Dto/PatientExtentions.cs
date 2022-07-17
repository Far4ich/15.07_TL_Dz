using MedicineApi.Domain;

namespace MedicineApi.Dto
{
    public static class PatientExtentions
    {
        public static PatientDto ConvertToPatientDto(this Patient patient)
        {
            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                HealthCardNumber = patient.HealthCardNumber,
                DoctorId = patient.DoctorId
            };
        }
        public static Patient ConvertToPatient(this PatientDto patient)
        {
            return new Patient(patient.Id, patient.Name, patient.HealthCardNumber, patient.DoctorId);
        }
    }
}
