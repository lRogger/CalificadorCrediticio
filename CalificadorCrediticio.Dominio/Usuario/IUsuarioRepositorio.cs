using CalificadorCrediticio.Dominio.Usuario;

namespace CalificadorCrediticio.Dominio
{
	public interface IUsuarioRepositorio
	{
        public void Guardar(UsuarioModelo Usuario);
        public void Obtener(UsuarioModelo Usuario);

    }
}

