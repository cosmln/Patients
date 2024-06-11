namespace PatientApp.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int MeetingTypeId { get; set; }
    public int PatientId { get; set; }
    public MeetingType MeetingType { get; set; }
    public Patient Patient { get; set; }
}