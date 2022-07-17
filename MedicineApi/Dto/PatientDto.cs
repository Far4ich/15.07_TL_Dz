namespace MedicineApi.Dto
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HealthCardNumber { get; set; }
        public int DoctorId { get; set; }
    }
}
