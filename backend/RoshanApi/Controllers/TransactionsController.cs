using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoshanAPI.Data;
using RoshanAPI.Models;
using RoshanAPI.DTOs;
using AutoMapper;
using RoshanApi.Services;
using RoshanApi.DTOs;

namespace RoshanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITransactionsService _service;
        public TransactionsController(AppDbContext context, ITransactionsService service) { 
            _context = context;
            _service = service;
        }

        [HttpPost("SaveBill")]
        public async Task<IActionResult> SaveBill([FromBody] BillDto bill)
        {
            if (bill == null)
                return BadRequest("No transactions provided.");

            var createdTransactions = await _service.SaveBillAsync(bill);
            return Ok(createdTransactions);
        }

    }
}
