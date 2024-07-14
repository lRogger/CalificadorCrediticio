
using CalificadorCrediticio.Dominio.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalificadorCrediticio.API.Controllers.v0
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioControlador : ControllerBase
    {
        private IGuardarUsuario GuardarUsuario;
        public UsuarioControlador(IGuardarUsuario GuardarUsuario)
        {
            this.GuardarUsuario = GuardarUsuario;
        }

        [HttpPost]
        [Route("Guardar")]
        public void Guardar(string Nombre, string Correo)
        {
            this.GuardarUsuario.Guardar(Nombre, Correo);
        }

        [HttpPost]
        [Route("Obtener")]
        [Authorize(Roles = "Admin1")]
        public ActionResult<string> Obtener()
        {
            return "oka";
        }

    }
}

