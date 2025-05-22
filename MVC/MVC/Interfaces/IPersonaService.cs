using BibliotecaFarmacia.Clases;

namespace MVC.Interfaces
{
    public interface IPersonaService
    {
        public List<Persona> ListarPersonas()
        {
            List<Persona> listado_total = Farmacia.l_personas;
            return listado_total;
        }

        public void CrearUsuario(Usuario usuario)
        {
            Farmacia.l_personas.Add(usuario);
        }

        public void CrearCliente(Cliente cliente)
        {
            Farmacia.l_personas.Add(cliente);
        }

        public void ActualizarPersona(string cc, string nombre, string telefono)
        {
            Persona persona = Farmacia.l_personas.FirstOrDefault(p => p.CC == cc);

            persona.Nombre_persona = nombre;
            persona.Telefono_persona = telefono;
        }

        public List<Persona> BuscarPorNombre(string nombreParcial)
        {
            var personasEncontradas = Farmacia.l_personas
                .Where(p => p.Nombre_persona.ToLower().Contains(nombreParcial.ToLower()))
                .ToList();

            return personasEncontradas;
        }

        public List<Persona> BuscarPorCC(string cc)
        {
            var personasEncontradas = Farmacia.l_personas
                .Where(p => p.CC.Contains(cc.ToLower()))
                .ToList();

            return personasEncontradas;
        }

        public List<Persona> ListarTipo(string tipo)
        {
            return Farmacia.l_personas
                .Where(p => p.Tipo.ToLower() == tipo.ToLower())
                .ToList();
        }

    }
}
