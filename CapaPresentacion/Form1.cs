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
    public partial class Personas : Form
    {
        CN_Personas objetoCN = new CN_Personas();
        private string IdPersona = null;
        private bool Editar = false;
        string fecha = null;
        public Personas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarPersonas();
   
        }

        private void MostrarPersonas()
        {
            CN_Personas objeto = new CN_Personas();
            dataGridView1.DataSource = objeto.MostrarPer();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Equals("") || txtDia.Text.Equals("") || txtCredito.Text.Equals(""))
            {
                MessageBox.Show("No podés dejar los cuadros de texto en blanco.");
            }
            else
            {
                if (this.Editar == false)
                {
                    try
                    {
                        this.fecha = txtMes.Text + "/" + txtDia.Text + "/" + txtAnio.Text;
                        objetoCN.InsertarPer(txtNombre.Text, this.fecha, txtCredito.Text);
                        MessageBox.Show("Se creó con éxito a la nueva persona.");
                        MostrarPersonas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo crear la persona debido a: " + ex);
                    }
                }

                if (this.Editar == true)
                {
                    try
                    {
                        this.fecha = txtMes.Text + "/" + txtDia.Text + "/" + txtAnio.Text;
                        objetoCN.EditarPer(txtNombre.Text, this.fecha, txtCredito.Text, this.IdPersona);
                        MessageBox.Show("Se editó correctamente la persona.");
                        MostrarPersonas();
                        txtNombre.Text = "";
                        txtDia.Text = "";
                        txtMes.Text = "";
                        txtAnio.Text = "";
                        txtCredito.Text = "";
                        this.Editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudieron editar los campos debido a: " + ex);
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                String fecha = dataGridView1.CurrentRow.Cells["FechaNacimiento"].Value.ToString();
                String[] fechaArray = fecha.Split('/');
                this.Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDia.Text = fechaArray[0];
                txtMes.Text = fechaArray[1];
                txtAnio.Text = fechaArray[2].Substring(0,4);
                txtCredito.Text = dataGridView1.CurrentRow.Cells["CreditoMaximo"].Value.ToString();
                this.IdPersona = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccioná una fila para poder editarla.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                this.IdPersona = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                objetoCN.EliminarPer(this.IdPersona);
                MessageBox.Show("Eliminaste correcamente a la persona y sus teléfonos.");
                MostrarPersonas();
            }
            else
            {
                MessageBox.Show("Seleccioná una fila para poder eliminarla.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Telefonos telefono = new Telefonos();
            telefono.lblId.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            this.Visible = false;
            telefono.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.CurrentRow.Cells["FechaNacimiento"].Value.ToString());
        }

        private void txtMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
