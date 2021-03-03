using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CD_Telefonos
    {
        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        public DataTable Mostrar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from Telefonos where PersonaID="+id+";";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string telefono, int id_persona)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "insert into Telefonos values('"+telefono+"', (select ID from Personas where ID="+id_persona+"));";
            comando.ExecuteNonQuery();
        }

        public void Editar(string telefono, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Update telefonos set Numero_Telefono='"+telefono+"' where TelefonoID="+id+";";
            comando.ExecuteNonQuery();

        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "delete from Telefonos where TelefonoID="+id+";";
            comando.ExecuteNonQuery();
        }
    }
}
