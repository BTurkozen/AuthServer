using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace App2.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        public IActionResult GetStoct()
        {
            var userName = HttpContext.User.Identity.Name;

            var userId = User.Claims.FirstOrDefault(x =>x.Type == ClaimTypes.NameIdentifier);

            return Ok($"Invoice işlemleri => UserName:{userName}\nUserId: {userId.Value}");
        }
    }
}
