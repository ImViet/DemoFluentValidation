using DemoFluentValidation.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoFluentValidation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly List<LoginRequest> listUser = new List<LoginRequest>()
        {
            new LoginRequest {UserName = "abc", Password="123456"},
            new LoginRequest {UserName = "xyz", Password="987654"},
        };
        private readonly List<RegisterRequest> listRegister = new List<RegisterRequest>();

        [HttpPost]
        public ActionResult Login([FromForm]LoginRequest request)
        {
            var user = listUser.Where(x => x.UserName == request.UserName && x.Password == request.Password).FirstOrDefault();
            if (user == null) return BadRequest();
            return Ok(user);
        }
        [HttpPost]
        public ActionResult Register([FromForm]RegisterRequest request)
        {
            var userRegister = new RegisterRequest()
            {
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email,
            };
            listRegister.Add(userRegister);
            return Ok(listRegister);
        }
    }
}
