using CalificadorCrediticio.Dominio.Helper;

namespace CalificadorCrediticio.Aplicacion.Autenticacion
{
	public class GenerardorToken
	{
		private IGenerarToken GenerarToken;
		public GenerardorToken(IGenerarToken GenerarToken)
		{
			this.GenerarToken = GenerarToken;

		}

		public string Generar(LoginRequest login)
		{
			return GenerarToken.Generar(login.usuario);

        }
	}
}

