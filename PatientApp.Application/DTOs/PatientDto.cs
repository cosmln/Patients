namespace PatientApp.Application.DTOs;

public class PatientDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<AppointmentDto> Appointments { get; set; }
}