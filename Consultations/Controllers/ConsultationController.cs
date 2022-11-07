using AutoMapper;
using Consultations.DTOs;
using Consultations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Consultations.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public ConsultationController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ConsultationDTO> Get(int id)
        {
            return _mapper.Map<ConsultationDTO>(await _context.Consultations.Include(c => c.Patient).SingleOrDefaultAsync(i => i.Id == id));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ConsultationDTO dto)
        {
            var consultation = _mapper.Map<Consultation>(dto);
            consultation.Patient = _context.Patients.Single(p => p.Id == dto.PatientId);
            var result = await _context.Consultations.AddAsync(consultation);
            await _context.SaveChangesAsync();
            return Ok(result.Entity);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, [FromBody] ConsultationDTO newValues)
        {
            var consultation = await _context.Consultations.SingleOrDefaultAsync(i => i.Id == id);
            consultation.Edit(newValues.StartDate, newValues.EndDate, newValues.Symptoms);
            _context.Entry(consultation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(consultation);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var consultation = await _context.Consultations.SingleOrDefaultAsync(i => i.Id == id);
            _context.Consultations.Remove(consultation);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
