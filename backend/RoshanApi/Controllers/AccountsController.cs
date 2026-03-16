using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoshanAPI.Data;
using RoshanAPI.Models;
using RoshanAPI.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace RoshanAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AccountsController(AppDbContext context, IMapper mapper) { _context = context; _mapper = mapper; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var accounts = await _context.Accounts.ToListAsync();
                return Ok(accounts);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var acc = await _context.Accounts.FindAsync(id);
            if (acc == null) return NotFound();
            return Ok(_mapper.Map<AccountDto>(acc));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountDto dto)
        {
            var acc = _mapper.Map<Account>(dto);
            _context.Accounts.Add(acc);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = acc.Id }, _mapper.Map<AccountDto>(acc));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AccountDto dto)
        {
            var acc = await _context.Accounts.FindAsync(id);
            if (acc == null) return NotFound();
            acc.Name = dto.Name;
            acc.Type = dto.Type;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var acc = await _context.Accounts.FindAsync(id);
            if (acc == null) return NotFound();
            _context.Accounts.Remove(acc);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
