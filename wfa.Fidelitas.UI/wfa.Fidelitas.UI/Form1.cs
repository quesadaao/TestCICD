using cl.Fidelitas.BL;
using cl.Fidelitas.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfa.Fidelitas.UI {
    public partial class Form1 : Form {

        #region Variables
        Persona persona;
        #endregion

        #region Eventos
        public Form1() {
            InitializeComponent();
        }

        // Funcionalidad:
        // 1- Debe ir a base de datos y mostrar toda la informacion que existe
        private void btnMostrar_Click(object sender, EventArgs e) {
            try
            {
                dgvPersonas.DataSource = Mantenimiento.Instancia.Mostrar();
            }
            catch (Exception ee)
            {
                throw;
            }
            
        }

        // Funcionalidad: 
        // 1- Todos los datos son obligatorios 
        // 2- Insertar los datos en base de datos
        // 3- Debe refrescar los datos del grid con este nuevo valor
        // 4- El valor de Edad debe calcularse automaticamente ** 
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validaInsertarDatos().Equals(string.Empty)) {                    
                    GetValues();
                    Mantenimiento.Instancia.Insertar(persona);
                    dgvPersonas.DataSource = Mantenimiento.Instancia.Mostrar();
                } else {
                    // DATOS ERRONEOS y mostrar el detalle de que paso ? 
                }

            }
            catch (Exception ee)
            {
                throw;
            }
        }

        // Funcionalidad: 
        // 1- la persona llena datos del formulario para actualizar datos
        // 2- la persona selecciona algun dato del grid y este row se carga en formulario
        //      -- La persona modifica cualquier dato y da click en actualizar
        // 3- Para actualizar la persona debe modificar algun datos a excepcion del ID 
        //      -- Si no hay diferencia en los datos entonces devolver un mensaje 
        // 4- Si el valor fecha de nacimiento se modifca debe actualizar la edad (LINQ to DataSet or LINQ to List)
        // 5- EL CAMPO MUERTO , si la persona lo selecciona invocar el proceso eliminar 
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validaActualizar().Equals(string.Empty))
                {
                    GetValues();
                    Mantenimiento.Instancia.Actualizar(persona);
                    dgvPersonas.DataSource = Mantenimiento.Instancia.Mostrar();
                }
                else {
                    // DATOS ERRONEOS y mostrar el detalle de que paso ?
                }
                
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        // Funcionalidad:
        // 1- Cuando la persona selecciona algun dato del grid y este row se carga en formulario por tanto el ID es el usado para dar por muerta la persona
        // 2- Si no hay datos seleccionados debe mostrar mensaje
        // 3- Si la persona pone un numero en el label y esta persona no existe debe mostrarse un mensaje ** para verificar (LINQ to DataSet or LINQ to List)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                GetValues();
                Mantenimiento.Instancia.Eliminar(persona);
                dgvPersonas.DataSource = Mantenimiento.Instancia.Mostrar();
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        private void dgvPersonas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                validarDataGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error SelectionChanged: " + ee.ToString());
            }
        }

        #endregion

        #region Metodos

        private string validaInsertarDatos() {
            string mensaje = string.Empty;


            // hacerle un mensaje==string.Emptysignifica que todos los datos han sido completados. 

            return mensaje;
        }

        private string validaActualizar()
        {
            string mensaje = string.Empty;


            // hacerle un mensaje==string.Emptysignifica que todos los datos han sido completados para ACTUALIZAR. 

            return mensaje;
        }

        private void GetValues()
        {
            persona = new Persona
            {
                Cedula = Convert.ToInt32(nUDCedula.Value),
                Nombre = txtNombre.Text,
                Muerto = cbMuerto.Checked,
                Edad = Convert.ToInt32(nUDEdad.Value),
                Email = txtEmail.Text,
                Nacimiento = dtpNacimiento.Value
            };
        }

        private void validarDataGrid()
        {
            try
            {
                if (dgvPersonas.SelectedRows.Count != 0)
                {
                    if (dgvPersonas.AreAllCellsSelected(true))
                    {

                    }
                    else
                    {
                        DataGridViewRow row = dgvPersonas.SelectedRows[0];
                        nUDCedula.Value = Convert.ToInt32(row.Cells[0].Value);
                        txtNombre.Text = row.Cells[1].Value.ToString();
                        cbMuerto.Checked = Convert.ToBoolean(row.Cells[2].Value);
                        dtpNacimiento.Value = Convert.ToDateTime(row.Cells[3].Value);
                        nUDEdad.Value = Convert.ToInt32(row.Cells[4].Value);
                        txtEmail.Text = row.Cells[5].Value.ToString();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error ValidarDataGrid: " + ee.ToString());
            }
        }
        #endregion

       
    }
}
