using CalificadorCrediticio.Aplicacion.Autenticacion;

namespace CalificadorCrediticio.API.Controllers.v1.Autenticacion
{
	public class ValidarCredenciales
	{
		private GenerardorToken GenerardorToken;
        public ValidarCredenciales(GenerardorToken GenerardorToken)
		{
			this.GenerardorToken = GenerardorToken;

        }

		public string Generar(LoginRequest login)
		{
			string usuarioBase = "chris";
			string contrasenaBase = "123";

			if (usuarioBase == login.usuario && contrasenaBase == login.contrasena)
			{
				return GenerardorToken.Generar(login);

            }


			throw new Exception("Credenciales incorrectas");
		}
	}
}

