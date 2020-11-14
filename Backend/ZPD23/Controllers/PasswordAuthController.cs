using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Contracts.Models;
namespace ZPD23.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PasswordAuthController : ControllerBase
    {
        IPasswordAuthenticationService _authenticationService;
        public PasswordAuthController(IPasswordAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException($"No instance of {nameof(IPasswordAuthenticationService)} provided.");
        }
        
        [HttpPost]
        public async Task<IActionResult> Authenticate(PasswordAuthModel authModel)
        {
            UserTicketModel ticket =
                await _authenticationService.AuthenticateAsync(authModel);
            if (ticket.Id == 0)
            {
                return BadRequest();
            }
            return Ok(ticket);
        }


    }
}
