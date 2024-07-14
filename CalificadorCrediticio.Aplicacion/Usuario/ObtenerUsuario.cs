using CalificadorCrediticio.Dominio;
using CalificadorCrediticio.Dominio.Usuario;

namespace CalificadorCrediticio.Aplicacion.Usuario
{
	public class ObtenerUsuario
	{
        public IUsuarioRepositorio UsuarioRepositorio;

        public ObtenerUsuario(IUsuarioRepositorio UsuarioRepositorio)
        {
            this.UsuarioRepositorio = UsuarioRepositorio;
        }

        public void Guardar(string Nombre)
        {
            UsuarioModelo Usuario = new UsuarioModelo(Nombre);
            this.UsuarioRepositorio.Obtener(Usuario);

        }
    }
}

