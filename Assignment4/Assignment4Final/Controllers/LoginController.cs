using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models;
using ModelLibrary.Models.DTO.Login;

namespace Assignment4Final.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;

        // private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public LoginController(
            SignInManager<AppUser> signInManager,
            // UserManager<AppUser> userManager,
            IMapper mapper
        )
        {
            _signInManager = signInManager;
            // _userManager = userManager;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(loginDto.Username);
            if (
                user != null
                && await _signInManager.UserManager.CheckPasswordAsync(user, loginDto.Password)
            )
            {
                await _signInManager.SignInAsync(user, false);

                var userDto = _mapper.Map<UserDto>(user);

                var roles = await _signInManager.UserManager.GetRolesAsync(user);
                userDto.Roles = roles.ToList();

                return Ok(userDto);
            }

            return BadRequest("Username or password is incorrect");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return NoContent();
        }
    }
}
