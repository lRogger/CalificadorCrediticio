using Microsoft.AspNetCore.Mvc;
using CalificadorCrediticio.Aplicacion.Autenticacion;

namespace CalificadorCrediticio.API.Controllers.v1.Autenticacion
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class LoginController : ControllerBase
    {
        private ValidarCredenciales ValidarCredenciales;
        public LoginController(ValidarCredenciales ValidarCredenciales)
        {
            this.ValidarCredenciales = ValidarCredenciales;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<string> Login([FromBody] LoginRequest login)
        {

            return ValidarCredenciales.Generar(login);
        }
    }
} 