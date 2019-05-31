using PedidosGO.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Reglas
{
    public class UsuarioReg : Obligatorio<Usuario>
    {
        
        private ConexionDB objConexinDB;
        private SqlCommand comando;

        public UsuarioReg()
        {
            objConexinDB = ConexionDB.saberEstado();

        } 

        public void create(Usuario objUsuario)
        {
         try
            {
                using (SqlCommand cmd = new SqlCommand("uspInsertarRegistros", objConexinDB.getCon()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Cedula", SqlDbType.BigInt).Value = objUsuario.cedula;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = objUsuario.nombre;
                    cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = objUsuario.apellido;
                    cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = objUsuario.edad;
                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = objUsuario.direccion;
                    cmd.Parameters.Add("@Telefono", SqlDbType.Int).Value = objUsuario.telefono;
                    cmd.Parameters.Add("@Celular", SqlDbType.BigInt).Value = objUsuario.celular;
                    cmd.Parameters.Add("@Correo_Electronico", SqlDbType.NVarChar).Value = objUsuario.correo_electronico;
                    cmd.Parameters.Add("@Contraseña", SqlDbType.NVarChar).Value = objUsuario.contraseña;
                    objConexinDB.getCon().Open();
                    cmd.ExecuteNonQuery();

                }     

            }
            catch (Exception e)
            {
                objUsuario.Estado = 1;
                throw new Exception(e.Message);
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }

        }

    }
}
