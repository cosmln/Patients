namespace PatientApp.Application.DTOs;

public class AppointmentDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int MeetingTypeId { get; set; }
    public string MeetingTypeDescription { get; set; }
}