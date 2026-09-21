using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApiDotNet.Data.Entities;
using WebApiDotNet.Models.Account;

namespace WebApiDotNet.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController(UserManager<UserEntity> userManager) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody]LoginModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
        {
            var token = "Сало - це смачно і ситно!";
            return Ok(new { Token = token });
        }
        return Unauthorized("Не вірно вказані дані");
    }
}
