using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationModel model)
    {
        // Handle user registration logic
        var user = new IdentityUser { Id = model.UserId, UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            // You can customize this response based on your requirements
            return Ok(new { Message = "Registration successful" });
        }

        // Registration failed, return errors
        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        // Handle user login logic
        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            var userId = _userManager.GetUserId(User);

            return Ok(new { UserId = userId });
        }
        else
        {
            return BadRequest("Invalid login attempt");
        }
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        // Handle user logout logic
        await _signInManager.SignOutAsync();

        // You can customize this response based on your requirements
        return Ok(new { Message = "Logout successful" });
    }
}

