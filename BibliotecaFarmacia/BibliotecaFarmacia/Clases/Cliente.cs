using System;

namespace BibliotecaFarmacia.Clases
{
    public class Cliente : Persona
    {
        private uint total_gastado;
        private string ptos;

        public uint Total_gastado
        {
            get => total_gastado;
            set => total_gastado = value;
        }

        public string Ptos
        {
            get => ptos;
            set => ptos = value ?? "0";
        }

        public Cliente(string nombre_persona, string cc, string telefono_persona, uint total_gastado, string ptos)
            : base(nombre_persona, cc, telefono_persona)
        {
            Total_gastado = total_gastado;
            Ptos = ptos;
        }
    }
}