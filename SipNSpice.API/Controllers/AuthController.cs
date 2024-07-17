using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SipNSpice.API.Models.DTO;
using SipNSpice.API.Repositories.Interface;

namespace SipNSpice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        //POST: {apibaseurl}/api/auth/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequest)
        {
            if (ModelState.IsValid)
            {
                //check if email exists
                var emailExists = await userManager.FindByEmailAsync(registerRequest.Email);
                if (emailExists != null)
                {
                    return BadRequest("Email already exists! Please register with the new email or login using the same");
                }
                //Create IdentityUser Object
                var user = new IdentityUser
                {
                    UserName = registerRequest.Email?.Trim(),
                    Email = registerRequest.Email?.Trim()
                };

                //Create User in db
                var identityResult = await userManager.CreateAsync(user, registerRequest.Password);
                if (identityResult.Succeeded)
                {
                    //Add the default role to the user (Reader)
                    identityResult = await userManager.AddToRoleAsync(user, "Reader");
                    if (identityResult.Succeeded)
                    {
                        //return Ok(identityResult);
                        //This code is used to login as soon as the user registers
                        //Check the email entered
                        var identityUser = await userManager.FindByEmailAsync(registerRequest.Email);
                        if (identityUser != null)
                        {
                            //Check Password
                            var checkPasswordResult = await userManager.CheckPasswordAsync(identityUser, registerRequest.Password);
                            if (checkPasswordResult)
                            {
                                var roles = await userManager.GetRolesAsync(identityUser);

                                //Once the initial checks are done. Create a token
                                var jwtToken = tokenRepository.CreateJwtToken(identityUser, roles.ToList());
                                var response = new LoginResponseDto()
                                {
                                    Email = registerRequest.Email,
                                    Roles = roles.ToList(),
                                    Token = jwtToken
                                };
                                return Ok(response);
                            }
                        }
                    }
                }
            }
            return BadRequest("Please enter a valid email address");
        }

        //POST: {apibaseurl}/api/auth/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            //Check the email entered
            var identityUser = await userManager.FindByEmailAsync(loginRequest.Email);
            if(identityUser != null)
            {
                //Check Password
                var checkPasswordResult = await userManager.CheckPasswordAsync(identityUser, loginRequest.Password);
                if(checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(identityUser);

                    //Once the initial checks are done. Create a token
                    var jwtToken = tokenRepository.CreateJwtToken(identityUser, roles.ToList());
                    var response = new LoginResponseDto()
                    {
                        Email = loginRequest.Email,
                        Roles = roles.ToList(),
                        Token = jwtToken
                    };
                    return Ok(response);
                }
            }
            return BadRequest("Email or password entered is incorrect!");
        }
    }
}
