using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CD_Personas
    {
        private CD_Conexion conexion = new CD_Conexion();

        //Leer filas de la tabla
        SqlDataReader leer;
        //Almacenar las tablas
        DataTable tabla = new DataTable();
        //Ejecutar querys
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from Personas";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre, string fecha, double credito)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "insert into Personas values('"+nombre+"', '"+fecha+"', "+credito+")";
            comando.ExecuteNonQuery();
        }

        public void Editar(string nombre, string fecha, double credito, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Update Personas set Nombre = '"+nombre+"', FechaNacimiento = '"+fecha+"', CreditoMaximo = "+credito+" where ID = "+id+"";
            comando.ExecuteNonQuery();

        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "delete from Telefonos where PersonaID=" + id + ";";
            comando.ExecuteNonQuery();
            comando.CommandText = "delete from Personas where id="+id+";";
            comando.ExecuteNonQuery();
        }
    }
}
