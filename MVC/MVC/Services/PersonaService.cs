using System.Security.Cryptography.X509Certificates;
using BibliotecaFarmacia.Clases;
using MVC.Interfaces;

namespace MVC.Services
{
    public class PersonaService : IPersonaService
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

        public void ActualizarPersona(string cc, string nombre, string telefono, string tipo)
        {
            Persona persona = Farmacia.l_personas.FirstOrDefault(p => p.CC == cc);

            if (persona != null)
            {
                persona.Nombre_persona = nombre;
                persona.Telefono_persona = telefono;
                persona.Tipo = tipo;
            }
        }


        public List<Persona> BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return Farmacia.l_personas;

            var nombreBuscado = nombre.Trim().ToLower();

            var resultado = Farmacia.l_personas
                .Where(p => !string.IsNullOrWhiteSpace(p.Nombre_persona) &&
                            p.Nombre_persona.ToLower().Contains(nombreBuscado))
                .ToList();

            Console.WriteLine($"Buscando '{nombreBuscado}' -> {resultado.Count} resultados");
            return resultado;
        }


        public List<Persona> BuscarPorCC(string cc)
        {
            if (string.IsNullOrWhiteSpace(cc))
                return Farmacia.l_personas;

            cc = cc.Trim().ToLower();

            return Farmacia.l_personas
                .Where(p => !string.IsNullOrWhiteSpace(p.CC) &&
                            p.CC.ToLower().Contains(cc))
                .ToList();
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
