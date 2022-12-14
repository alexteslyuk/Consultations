using AutoMapper;
using AutoMapper.QueryableExtensions;
using Consultations.DTOs;
using Consultations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Consultations.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public PatientController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PatientDTO>> GetAll() {
            return await _context.Patients.ProjectTo<PatientDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet]
        public async Task<PatientDTO> Get(int id, bool withConsultations = false)
        {
            var result = _mapper.Map<PatientDTO>(await _context.Patients.SingleOrDefaultAsync(i => i.Id == id));
            if (result != null && withConsultations)
            {
                var consultations = await _context.Consultations.Where(c => c.Patient.Id == id).ProjectTo<ConsultationDTO>(_mapper.ConfigurationProvider).ToListAsync();
                result.Consultations = consultations;
            }
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PatientDTO patient)
        {
            var result = await _context.Patients.AddAsync(_mapper.Map<Patient>(patient));
            await _context.SaveChangesAsync();
            return Ok(result.Entity);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, [FromBody] PatientDTO newValues)
        {
            var patient = await _context.Patients.SingleOrDefaultAsync(i => i.Id == id);
            patient.Edit(newValues.Surname, newValues.Name, newValues.Patronymic, newValues.BirthDate, newValues.Gender, newValues.SNILS, newValues.Weight, newValues.Height);
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(patient);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var patient = await _context.Patients.SingleOrDefaultAsync(i => i.Id == id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
