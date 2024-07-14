using CalificadorCrediticio.Dominio;
using CalificadorCrediticio.Dominio.Usuario;

namespace CalificadorCrediticio.Infraestructura.Usuario
{
	public class UsuarioRepositorio: IUsuarioRepositorio
    {
        //Inyectas el contexto - EF
        //Context Context = new Context()

        public UsuarioRepositorio(
            //Context Context
        ) { }

        public void Guardar(UsuarioModelo Usuario)
		{
            //Se guarda el usuario EF - MONGO DB
            //this.Context.Usuario.SaveChanges(Usuario);
        }

        public void Obtener(UsuarioModelo Usuario)
        {
            //Se guarda el usuario EF - MONGO DB

        }
    }
}

