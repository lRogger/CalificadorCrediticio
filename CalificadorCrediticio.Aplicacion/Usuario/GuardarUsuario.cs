using CalificadorCrediticio.Dominio;
using CalificadorCrediticio.Dominio.Usuario;

namespace CalificadorCrediticio.Aplicacion.Usuario
{
	public class GuardarUsuario: IGuardarUsuario
	{
		public IUsuarioRepositorio UsuarioRepositorio;

		public GuardarUsuario(IUsuarioRepositorio UsuarioRepositorio)
		{
			this.UsuarioRepositorio = UsuarioRepositorio;
        }

        public void Guardar(string Nombre, string Correo)
		{
            UsuarioModelo Usuario = new UsuarioModelo(Nombre);
			this.UsuarioRepositorio.Guardar(Usuario);
        }
	}
}

