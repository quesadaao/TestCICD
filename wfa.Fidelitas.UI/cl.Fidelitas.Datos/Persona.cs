using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cl.Fidelitas.Datos
{
    public class Persona
    {

        private int cedula;

        public int Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private bool muerto;

        public bool Muerto
        {
            get { return muerto; }
            set { muerto = value; }
        }

        private DateTime nacimiento;

        public DateTime Nacimiento
        {
            get { return nacimiento; }
            set { nacimiento = value; }
        }

        private int edad;

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
