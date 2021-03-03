using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Telefonos : Form
    {
        CN_Telefonos objetoCN = new CN_Telefonos();
        private string IdTelefono = null;
        private bool Editar = false;
        public Telefonos()
        {
            InitializeComponent();
        }

        private void MostrarTelefonos()
        {
            CN_Telefonos objeto = new CN_Telefonos();
            telefonosGrid.DataSource = objeto.MostrarTel(lblId.Text);
            
        }

        private void Telefonos_Load(object sender, EventArgs e)
        {
            lblId.Visible = false;
            MostrarTelefonos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (telefonosGrid.SelectedRows.Count > 0)
            {
                this.Editar = true;
                txtTel.Text = telefonosGrid.CurrentRow.Cells["Numero_Telefono"].Value.ToString();
                this.IdTelefono = telefonosGrid.CurrentRow.Cells["TelefonoID"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccioná una fila para poder editarla.");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtTel.Text.Equals(""))
            {
                MessageBox.Show("No podés dejar el cuadro de texto en blanco.");
            }
            else
            {
                if (this.Editar == false)
                {
                    try
                    {
                        objetoCN.InsertarTel(txtTel.Text, lblId.Text);
                        MessageBox.Show("Se creó con éxito el teléfono.");
                        MostrarTelefonos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo crear el teléfono debido a: " + ex);
                    }
                }

                if (this.Editar == true)
                {
                    try
                    {
                        objetoCN.EditarTel(txtTel.Text, this.IdTelefono);
                        MessageBox.Show("Se editó correctamente el teléfono.");
                        txtTel.Text = "";
                        this.Editar = false;
                        MostrarTelefonos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudieron editar los campos debido a: " + ex);
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (telefonosGrid.SelectedRows.Count > 0)
            {
                this.IdTelefono = telefonosGrid.CurrentRow.Cells["TelefonoID"].Value.ToString();
                objetoCN.EliminarTel(this.IdTelefono);
                MessageBox.Show("Eliminaste correcamente el teléfono.");
                MostrarTelefonos();
            }
            else
            {
                MessageBox.Show("Seleccioná una fila para poder eliminarla.");
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Personas personas = new Personas();
            personas.Visible = true;
        }
    }
}
