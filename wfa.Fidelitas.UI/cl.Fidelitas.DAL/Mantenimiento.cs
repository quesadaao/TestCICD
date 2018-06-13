using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cl.Fidelitas.Datos;
using System.Data.Common;
using System.Data;

namespace cl.Fidelitas.DAL
{
    public class Mantenimiento : IMantenimiento
    {
        private static Mantenimiento instancia;

        public static Mantenimiento Instancia
        {
            get {
                if (instancia == null) {
                    return new Mantenimiento();
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
            //Creamos un patron de fabrica con este codigo
            //Pasamos el proveedor que esta en el archivo de configuracion para obtener el string
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);

            //Declaramos variables y la inicializamos
            DbConnection conn = null;
            DbCommand comm = null;

            try
            {
                //Crea la conexion
                conn = factory.CreateConnection();
                conn.ConnectionString = Settings.Default.connection;
                comm = factory.CreateCommand();

                //Parametros para pasar a la base de datos (a los SP's)
                DbParameter param1 = factory.CreateParameter();
                DbParameter param2 = factory.CreateParameter();
                DbParameter param3 = factory.CreateParameter();
                DbParameter param4 = factory.CreateParameter();
                DbParameter param5 = factory.CreateParameter();
                DbParameter param6 = factory.CreateParameter();

                //Carga Parametros
                param1.ParameterName = "@iCedula";
                param1.DbType = System.Data.DbType.Int32;
                param1.Value = persona.Cedula;
                param2.ParameterName = "@vNombre";
                param2.DbType = System.Data.DbType.String;
                param2.Value = persona.Nombre;
                param3.ParameterName = "@bMuerto";
                param3.DbType = System.Data.DbType.Boolean;
                param3.Value = persona.Muerto;
                param4.ParameterName = "@iEdad";
                param4.DbType = System.Data.DbType.Int32;
                param4.Value = persona.Edad;
                param5.ParameterName = "@vEmail";
                param5.DbType = System.Data.DbType.String;
                param5.Value = persona.Email;
                param6.ParameterName = "@dtNacimiento";
                param6.DbType = System.Data.DbType.Date;
                param6.Value = persona.Nacimiento;

                //Abre conexión
                comm.Connection = conn;
                conn.Open();

                //Ejecuta el SP
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.CommandText = "sp_Insertar";
                comm.Parameters.Add(param1);
                comm.Parameters.Add(param2);
                comm.Parameters.Add(param3);
                comm.Parameters.Add(param4);
                comm.Parameters.Add(param5);
                comm.Parameters.Add(param6);
                comm.ExecuteNonQuery();

                //Las excepciones se deben capturar en la logica de negocio, por eso no esta el catch
            }
            catch (Exception ee){
                throw;
            }
            finally
            {
                //Aqui limpiamos datos siempre y cerramos conexion
                comm.Dispose();
                conn.Dispose();
            }
        }

        public List<Persona> Mostrar()
        {
            // Inicializamos 
            List<Persona> lista = new List<Persona>(); 

            //Creamos un patron de fabrica con este codigo
            //Pasamos el proveedor que esta en el archivo de configuracion para obtener el string
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);

            //Declaramos variables y la inicializamos
            DbConnection conn = null;
            DbCommand comm = null;

            try
            {
                //Crea la conexion
                conn = factory.CreateConnection();
                conn.ConnectionString = Settings.Default.connection;
                comm = factory.CreateCommand();

                //Abre conexión
                comm.Connection = conn;
                conn.Open();

                //Ejecuta el SP
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_Mostrar";

                // Referencia para usar dataReader 
                // https://msdn.microsoft.com/en-us/library/ff648253.aspx
                using (IDataReader dataReader = comm.ExecuteReader())
                {
                    // Procesar la lectura de rows                     
                    Persona persona;
                    // Vamos a recorrer los rows devuelvos en el datareader
                    while (dataReader.Read())
                    {
                        //Se carga la persona con los datos del row actual
                        persona = new Persona
                        {
                            Cedula = Convert.ToInt32(dataReader["iCedula"].ToString()),
                            Nombre = dataReader["vNombre"].ToString(),
                            Muerto = Convert.ToBoolean(dataReader["bMuerto"].ToString()),
                            Edad = Convert.ToInt32(dataReader["iEdad"].ToString()),
                            Email = dataReader["vEmail"].ToString(),
                            Nacimiento = Convert.ToDateTime(dataReader["dtNacimiento"].ToString())
                        };
                        lista.Add(persona);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //Aqui limpiamos datos siempre y cerramos conexion
                comm.Dispose();
                conn.Dispose();
            }

            return lista;
        }

        public void Actualizar(Persona persona)
        {
            //Creamos un patron de fabrica con este codigo
            //Pasamos el proveedor que esta en el archivo de configuracion para obtener el string
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);

            //Declaramos variables y la inicializamos
            DbConnection conn = null;
            DbCommand comm = null;

            try
            {
                //Crea la conexion
                conn = factory.CreateConnection();
                conn.ConnectionString = Settings.Default.connection;
                comm = factory.CreateCommand();

                //Parametros para pasar a la base de datos (a los SP's)
                DbParameter param1 = factory.CreateParameter();
                DbParameter param2 = factory.CreateParameter();
                DbParameter param3 = factory.CreateParameter();
                DbParameter param4 = factory.CreateParameter();
                DbParameter param5 = factory.CreateParameter();
                DbParameter param6 = factory.CreateParameter();

                //Carga Parametros
                param1.ParameterName = "@iCedula";
                param1.DbType = System.Data.DbType.Int32;
                param1.Value = persona.Cedula;
                param2.ParameterName = "@vNombre";
                param2.DbType = System.Data.DbType.String;
                param2.Value = persona.Nombre;
                param3.ParameterName = "@bMuerto";
                param3.DbType = System.Data.DbType.Boolean;
                param3.Value = persona.Muerto;
                param4.ParameterName = "@iEdad";
                param4.DbType = System.Data.DbType.Int32;
                param4.Value = persona.Edad;
                param5.ParameterName = "@vEmail";
                param5.DbType = System.Data.DbType.String;
                param5.Value = persona.Email;
                param6.ParameterName = "@dtNacimiento";
                param6.DbType = System.Data.DbType.Date;
                param6.Value = persona.Nacimiento;

                //Abre conexión
                comm.Connection = conn;
                conn.Open();

                //Ejecuta el SP
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.CommandText = "sp_Actualizar";
                comm.Parameters.Add(param1);
                comm.Parameters.Add(param2);
                comm.Parameters.Add(param3);
                comm.Parameters.Add(param4);
                comm.Parameters.Add(param5);
                comm.Parameters.Add(param6);
                comm.ExecuteNonQuery();

                //Las excepciones se deben capturar en la logica de negocio, por eso no esta el catch
            }
            catch (Exception ee)
            {
                throw;
            }
            finally
            {
                //Aqui limpiamos datos siempre y cerramos conexion
                comm.Dispose();
                conn.Dispose();
            }
        }

        public void Eliminar(Persona persona)
        {
            //Creamos un patron de fabrica con este codigo
            //Pasamos el proveedor que esta en el archivo de configuracion para obtener el string
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);

            //Declaramos variables y la inicializamos
            DbConnection conn = null;
            DbCommand comm = null;

            try
            {
                //Crea la conexion
                conn = factory.CreateConnection();
                conn.ConnectionString = Settings.Default.connection;
                comm = factory.CreateCommand();

                //Parametros para pasar a la base de datos (a los SP's)
                DbParameter param1 = factory.CreateParameter();

                //Carga Parametros
                param1.ParameterName = "@iCedula";
                param1.DbType = System.Data.DbType.Int32;
                param1.Value = persona.Cedula;

                //Abre conexión
                comm.Connection = conn;
                conn.Open();

                //Ejecuta el SP
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.CommandText = "sp_Eliminar";
                comm.Parameters.Add(param1);
                comm.ExecuteNonQuery();

                //Las excepciones se deben capturar en la logica de negocio, por eso no esta el catch
            }
            catch (Exception ee)
            {
                throw;
            }
            finally
            {
                //Aqui limpiamos datos siempre y cerramos conexion
                comm.Dispose();
                conn.Dispose();
            }
        }

        
    }
}
