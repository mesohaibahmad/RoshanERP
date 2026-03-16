using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoshanAPI.Data;
using RoshanAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace RoshanAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
                return BadRequest("Username already exists.");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User registered.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User login)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(login.PasswordHash, user.PasswordHash))
                return Unauthorized("Invalid credentials.");

            var claims = new[]
            {
                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: creds
            );

         

            return Ok(new {user, token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [HttpGet("User")]
        [Authorize]// Only allow authenticated requests
        public async Task<ActionResult<User>> GetCurrentUser()

        {
            // Get the user ID from the JWT claims
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new {user});
        }

    }
}
