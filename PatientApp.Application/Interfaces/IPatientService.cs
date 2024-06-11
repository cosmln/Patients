using PatientApp.Application.DTOs;
using PatientApp.Domain.Entities;

namespace PatientApp.Application.Interfaces;

public interface IPatientService
{
    Task<(IEnumerable<PatientDto>, int)> GetPatientsAsync(int page, int pageSize);
    Task<PatientDto> GetPatientByIdAsync(int id);
    Task<IEnumerable<PatientDto>> SearchPatientsAsync(string query);
}