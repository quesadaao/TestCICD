using cl.Fidelitas.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cl.Fidelitas.BL
{
    public interface IMantenimiento
    {
        void Insertar(Persona persona);
        List<Persona> Mostrar();
        void Actualizar(Persona persona);
        void Eliminar(Persona persona);
    }
}
