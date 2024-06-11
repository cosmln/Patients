namespace PatientApp.Domain.Entities;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}