using PedidosGO.Entidades;
using Reglas;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class UsuarioNeg
    {
        UsuarioReg objUsuarioReg;

        public UsuarioNeg()
        {
            objUsuarioReg = new UsuarioReg();
            
        }

        public void create(Usuario objUsuario)
        {
            bool verificacion = true;
            //begin validar codigo retorna estado=1
            string Cedula = objUsuario.cedula.ToString();
            long id = 0;
            if (Cedula == null)
            {
                objUsuario.Estado = 10;
                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objUsuario.cedula);
                    verificacion = Cedula.Length <= 20 && Cedula.Length > 0; ;


                    if (!verificacion)
                    {
                        objUsuario.Estado = 1;
                        return;
                    }
                }
                catch (Exception e)
                {
                    objUsuario.Estado = 100;
                    return;
                }

            }
            //end validar codigo

            //begin validar nombre retorna estado=2
            string nombre = objUsuario.nombre.ToString();
            if (nombre == null)
            {
                objUsuario.Estado = 20;
                return;
            }
            else
            {
                nombre = objUsuario.cedula.ToString().Trim();
                verificacion = nombre.Length <= 30 && nombre.Length > 0;
                if (!verificacion)
                {
                    objUsuario.Estado = 2;
                    return;
                }

            }
            //end validar nombre

            //begin validar apellido retorna estado=3
            string apellido = objUsuario.apellido;
            if (apellido == null)
            {
                objUsuario.Estado = 30;
                return;
            }
            else
            {
                apellido = objUsuario.apellido.Trim();
                verificacion = apellido.Length <= 30 && apellido.Length > 0;
                if (!verificacion)
                {
                    objUsuario.Estado = 3;
                    return;
                }

            }
            //end validar apellido

            //begin validar edad retorna estado=4
            string edad = objUsuario.edad.ToString();
            if (edad == null)
            {
                objUsuario.Estado = 40;
                return;
            }
            else
            {
                edad = objUsuario.edad.ToString().Trim();
                verificacion = edad.Length <= 100 && edad.Length > 0;
                if (!verificacion)
                {
                    objUsuario.Estado = 4;
                    return;
                }

            }
            //end validar edad

            //begin validar direccion retorna estado=5
            string direccion = objUsuario.direccion;
            if (direccion == null)
            {
                objUsuario.Estado = 50;
                return;
            }
            else
            {
                direccion = objUsuario.direccion.Trim();
                verificacion = direccion.Length < 100 && direccion.Length > 10;
                if (!verificacion)
                {
                    objUsuario.Estado = 5;
                    return;
                }

            }
            //end validar dni

            //begin validar telefono retorna estado=6
            string telefono = objUsuario.telefono.ToString();
            if (telefono == null)
            {
                objUsuario.Estado = 60;
                return;
            }
            else
            {
                telefono = objUsuario.telefono.ToString().Trim();
                verificacion = telefono.Length <= 50 && telefono.Length > 0;
                if (!verificacion)
                {
                    objUsuario.Estado = 6;
                    return;
                }

            }
            //end validar direccion

            //begin validar celular retorna estado=7
            string celular = objUsuario.celular.ToString();
            if (celular == null)
            {
                objUsuario.Estado = 70;
                return;
            }
            else
            {
                celular = objUsuario.celular.ToString().Trim();
                verificacion = celular.Length <= 20 && celular.Length > 6;
                if (!verificacion)
                {
                    objUsuario.Estado = 7;
                    return;
                }

            }
            //end validar telefono

            //begin validar celular retorna estado=9
            string correo = objUsuario.correo_electronico;
            if (correo == null)
            {
                objUsuario.Estado =80;
                return;
            }
            else
            {
                correo = objUsuario.correo_electronico.ToString().Trim();
                verificacion = correo.Length <= 25 && correo.Length > 6;
                if (!verificacion)
                {
                    objUsuario.Estado = 8;
                    return;
                }

            }
            //end validar telefono


            //begin verificar duplicidad dni retorna estado=8
            Usuario objUsuario1 = new Usuario();
            objUsuario1.cedula = objUsuario.cedula;
            if (!verificacion)
            {
                objUsuario.Estado = 9;
                return;
            }
            //end validar duplicidad

            //si no hay error
            objUsuario.Estado = 99;
            objUsuarioReg.create(objUsuario);
            return;
        }

    }
}
