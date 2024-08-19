using backend.Repository;
using backend.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskFlow.Dto;
using TaskFlow.Model;

namespace backend.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        public UserController(IUserRepository repository,
                                UserManager<User> userManager,
                                 SignInManager<User> signInManager,
                                 IConfiguration configuration)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpGet("{username}")]
        [Authorize]
        public IActionResult GetById(string username)
        {
            var user = _repository.GetByUsername(username);

            if (user == null)
                return NotFound(new { Message = "Not Found" });

            var userDto = new UserDto(user);
            return Ok(userDto);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var users = _repository.GetAll();
            if (users.ToList().Count == 0)
                return Ok(new { Message = "Nenhum registro encontrado" });

            return Ok(users.Select(u => new UserDto(u)));
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(LoginUserDto dto)
        {
            var user = new User(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Created("/user", user);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure: false);
            if (!result.Succeeded)
                return Unauthorized(new { message = "Invalid username or password" });

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        [HttpDelete("{username}")]
        [Authorize]
        public IActionResult Delete(string username)
        {
            var user = _repository.GetByUsername(username);

            if (user == null)
                return NotFound(new { Message = "Not Found" });

            _repository.Delete(user);
            return NoContent();
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName!)
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
