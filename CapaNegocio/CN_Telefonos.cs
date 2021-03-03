using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Telefonos
    {
        private CD_Telefonos objetoCD = new CD_Telefonos();

        public DataTable MostrarTel(string id)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar(Convert.ToInt32(id));
            return tabla;
        }

        public void InsertarTel(string telefono, string persona_id)
        {
            objetoCD.Insertar(telefono, Convert.ToInt32(persona_id));
        }

        public void EditarTel(string telefono, string id)
        {
            objetoCD.Editar(telefono, Convert.ToInt32(id));
        }

        public void EliminarTel(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
