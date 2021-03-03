using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;

namespace CapaNegocio
{
    public class CN_Personas
    {
        private CD_Personas objetoCD = new CD_Personas();

        public DataTable MostrarPer()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarPer (string nombre, string fecha, string credito)
        {
            objetoCD.Insertar(nombre, fecha, Convert.ToDouble(credito));
        }

        public void EditarPer(string nombre, string fecha, string credito, string id)
        {
            objetoCD.Editar(nombre, fecha, Convert.ToDouble(credito), Convert.ToInt32(id));
        }

        public void EliminarPer(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
