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
        public async Task<IEnumerable<ConsultationDTO>> GetAll(int patientId)
        {
            return await _context.Consultations.Where(c => c.Patient.Id == patientId).ProjectTo<ConsultationDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet]
        public async Task<ConsultationDTO> Get(int id)
        {
            return _mapper.Map<ConsultationDTO>(await _context.Consultations.SingleOrDefaultAsync(i => i.Id == id));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ConsultationDTO consultation)
        {
            var result = await _context.Consultations.AddAsync(_mapper.Map<Consultation>(consultation));
            await _context.SaveChangesAsync();
            return Ok(result.Entity);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, [FromBody] ConsultationDTO newValues)
        {
            var consultation = await _context.Consultations.SingleOrDefaultAsync(i => i.Id == id);
            consultation.Edit(newValues.Date, newValues.Symptoms);
            _context.Entry(consultation).State = EntityState.Modified;
            return Ok(consultation);
        }

        [HttpPost]
        public async Task<ActionResult> Delete([FromBody] int id)
        {
            var consultation = await _context.Consultations.SingleOrDefaultAsync(i => i.Id == id);
            _context.Consultations.Remove(consultation);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
