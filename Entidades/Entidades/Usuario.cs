using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosGO.Entidades
{
    public class Usuario
    {
        private int UserID;
        private long Cedula;
        private string Nombre;
        private string Apellido;
        private int Edad;
        private string Direccion;
        private int Telefono;
        private long Celular;
        private string Correo_Electronico;
        private int estado;
        private string Contraseña;

        public int Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        public int userID
        {
            get
            {
                return UserID;
            }
            set
            {
                UserID = value;
            }
        }

        [Required]
        [Display(Name = "Cedula")]
        public long cedula
        {
            get
            {
                return Cedula;
            }
            set
            {
                Cedula = value;
            }
        }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Nombre")]
        public string nombre
        {
            get
            {
                return Nombre;
            }

            set
            {
                Nombre = value;
            }
        }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Apellido")]
        public string apellido
        {
            get
            {
                return Apellido;
            }

            set
            {
                Apellido = value;
            }
        }

        [Display(Name = "Edad")]
        public int edad
        {
            get
            {
                return Edad;
            }

            set
            {
                Edad = value;
            }
        }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Direccion")]
        public string direccion
        {
            get
            {
                return Direccion;
            }

            set
            {
                Direccion = value;
            }
        }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Telefono")]
        public int telefono
        {
            get
            {
                return Telefono;
            }

            set
            {
                Telefono = value;
            }
        }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Celular")]
        public long celular
        {
            get
            {
                return Celular;
            }

            set
            {
                Celular = value;
            }
        }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Correo Electronico")]
        public string correo_electronico
        {
            get
            {
                return Correo_Electronico;
            }

            set
            {
                Correo_Electronico = value;
            }
        }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string contraseña
        {
            get
            {
                return Contraseña;
            }
            set
            {
                Contraseña = value;
            }
        }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Contraseña", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmarContraseña { get; set; }

        public Usuario()
        {

        }

        public Usuario(long Cedula)
        {
            this.Cedula = Cedula;
        }

        public Usuario(int User, long Cedula, string Nombre, string Apellido, int Edad, string Direccion, int Telefono, int Celular, string Correo_Electronico, string Contraseña)
        {
            this.Cedula = Cedula;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Edad = Edad;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Celular = Celular;
            this.Correo_Electronico = Correo_Electronico;
            this.Contraseña = Contraseña;
        }

        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_username">User name</param>
        /// <param name="_password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        public bool IsValid(long _cedula, string _contraseña)
        {
                using (var cn = new SqlConnection(
                    @"Data source=LAPTOP-VK5MQEUU\SQLEXPRESS;initial catalog=Pedidos;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework"))
                {
                    string _sql = @"SELECT Cedula FROM USERS WHERE Cedula = @Cedula AND Contraseña = @Contraseña";
                    var cmd = new SqlCommand(_sql, cn);
                    cmd.Parameters
                        .Add(new SqlParameter("@Cedula", SqlDbType.BigInt))
                        .Value = _cedula;
                    cmd.Parameters
                        .Add(new SqlParameter("@Contraseña", SqlDbType.VarChar))
                        .Value = _contraseña;
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Dispose();
                        cmd.Dispose();
                        return true;
                    }
                    else
                    {
                        reader.Dispose();
                        cmd.Dispose();
                        return false;
                    }
                } 
            
        }
    }
}
