using System.Security.Cryptography.X509Certificates;
using BibliotecaFarmacia.Clases;
using MVC.Interfaces;

namespace MVC.Services
{
    public class PersonaService: IPersonaService
    {
        public int limite_usuario = 1000000;

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


        public void Pasar_A_Cliente(string cc)
        {
            Persona persona = Farmacia.l_personas.FirstOrDefault(p => p.CC == cc);

            if (persona == null)
            {
                Console.WriteLine("No se encontró la persona.");
                return;
            }

            if (persona.Tipo.ToLower() == "usuario")
            {
                if (persona.Total_gastado >= limite_usuario)
                {

                    Cliente cliente = new Cliente(persona.CC, persona.Nombre_persona, persona.Telefono_persona);
                                    
                    Farmacia.l_personas.Remove(persona);
                    Farmacia.l_personas.Add(cliente);

                    Console.WriteLine("Usuario promovido a Cliente exitosamente.");
                }
                else
                {
                    Console.WriteLine("El usuario aún no es elegible para ser cliente.");
                }
            }
            else
            {
                Console.WriteLine("Ya es cliente.");
            }
        }


    }
}
