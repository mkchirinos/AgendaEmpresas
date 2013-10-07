using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaEmpresas
{
    class Persona
    {
        string Nombre, Apellido, Direccion;
        int ID, Edad, Telefono;

        public Persona()
        {
            ID = 0;
            Nombre = "";
            Apellido = "";
            Direccion = "";
            Edad = 0;
            Telefono = 0;

        }
        public Persona(int id, string nombre, string apellido, string direccion, int edad, int telefono)
        {
            ID = id;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Edad = edad;
            Telefono = telefono;

        }
        ~Persona()
        {

        }
        public int id
        {
            get { return ID; }
            set { ID = value; }
        }
        
        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string apellido
        {
            get { return Apellido; }
            set { Apellido = value; }
        }

        public string direccion
        {
            get { return Direccion; }
            set { Direccion = value; }
        }

        public int edad
        {
            get { return Edad; }
            set { Edad = value; }
        }

        public int telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }

    }
}
