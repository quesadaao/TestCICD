
using cl.Fidelitas.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace cl.Fidelitas.BL {
    public class Mantenimiento : IMantenimiento
    {
        private static Mantenimiento instancia;

        public static Mantenimiento Instancia
        {
            get {
                if (instancia == null) {
                    instancia = new BL.Mantenimiento();                        
                }
                return instancia;
            }
            set {
                if (instancia == null)
                {
                    instancia = value;
                }                
            }
        }
        public void Insertar(Persona persona)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.Mantenimiento.Instancia.Insertar(persona);                    
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public List<Persona> Mostrar()
        {
            List<Persona> lista = new List<Persona>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    lista =  DAL.Mantenimiento.Instancia.Mostrar();
                    scope.Complete();
                }
                return lista;
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        public void Actualizar(Persona persona)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.Mantenimiento.Instancia.Actualizar(persona);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public void Eliminar(Persona persona)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.Mantenimiento.Instancia.Eliminar(persona);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }
    }
}
