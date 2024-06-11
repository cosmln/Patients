using PatientApp.Application.Interfaces;
using PatientApp.Domain.Entities;
using PatientApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PatientApp.Application.DTOs;

namespace PatientApp.Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        private readonly PatientContext _context;
        private readonly IMapper _mapper;

        public PatientService(PatientContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<PatientDto>, int)> GetPatientsAsync(int page, int pageSize)
        {
            var now = DateTime.UtcNow;

            var totalCount = await _context.Patients
                .Where(p => p.Appointments.Any(a => a.Date > now))
                .CountAsync();

            var patients = await _context.Patients
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.MeetingType)
                .Where(p => p.Appointments.Any(a => a.Date > now))
                .OrderBy(p => p.Appointments
                    .Where(a => a.Date > now)
                    .Min(a => a.Date))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var patientDtos = _mapper.Map<IEnumerable<PatientDto>>(patients);

            return (patientDtos, totalCount);
        }

        public async Task<PatientDto> GetPatientByIdAsync(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.MeetingType)
                .FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<IEnumerable<PatientDto>> SearchPatientsAsync(string query)
        {
            var patients = await _context.Patients
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.MeetingType)
                .Where(p => p.Name.Contains(query) || p.Id.ToString() == query)
                .OrderBy(p => p.Appointments.Min(a => a.Date))
                .ToListAsync();

            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }
    }
}
