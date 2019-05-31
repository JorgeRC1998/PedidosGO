using Negocio;
using PedidosGO.Entidades;
using PedidosGO.Models;
using Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PedidosGO.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioNeg objUsuarioNeg;

        public UsuarioController()
        {
            objUsuarioNeg = new UsuarioNeg();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Usuario objUsuario)
        {
            objUsuarioNeg.create(objUsuario);
            MensajeErrorRegistrar(objUsuario);
            ModelState.Clear();
            return View("Create");
        }

        //mensaje de error
        public void MensajeErrorRegistrar(Usuario objUsuario)
        {

            switch (objUsuario.Estado)
            {
                case 10://campo codigo vacio
                    ViewBag.MensajeError = "Ingrese cedula";
                    break;
                case 1000://campo nombre vacio
                    ViewBag.MensajeError = "Error cedula, ha ingresado letras";
                    break;
                case 20://campo nombre vacio
                    ViewBag.MensajeError = "Ingrese Nombre";
                    break;

                case 2://error de nombre
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Nombre";
                    break;

                case 30://campo Apellido Paterno vacio
                    ViewBag.MensajeError = "Ingrese Apellido";
                    break;

                case 3://error de Apellido Paterno
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo apellido";
                    break;

                case 40://campo Apellido Paterno vacio
                    ViewBag.MensajeError = "Ingrese edad";
                    break;

                case 4://error de Apellido Paterno
                    ViewBag.MensajeError = "verifique los caracteres en el campo edad";
                    break;

                case 50://campo dni vacio
                    ViewBag.MensajeError = "Ingrese direccion";
                    break;

                case 5://error de dni
                    ViewBag.MensajeError = "Ingrese una direccion valida";
                    break;

                case 60://campod direccion vacio
                    ViewBag.MensajeError = "Ingrese telefono";
                    break;

                case 6://error de direccion
                    ViewBag.MensajeError = "verifique los caracteres en al campo telefono";
                    break;

                case 70://campo telefono vacio
                    ViewBag.MensajeError = "Ingrese celular";
                    break;
                case 7://error de direccion
                    ViewBag.MensajeError = "ingrese un numero de celular válido";
                    break;

                case 80://error de duplicidad
                    ViewBag.MensajeError = "Ingrese un correo electronico";
                    break;

                case 8://error de duplicidad
                    ViewBag.MensajeError = "Ingrese un correo valido";
                    break;

                case 9://error de duplicidad
                    ViewBag.MensajeError = "Numero de cedula [" + objUsuario.cedula + "] ya esta asignado a un Cliente";
                    break;
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Cliente [" + objUsuario.nombre + " " + objUsuario.apellido + "] fue Registrado en el Sistema";
                    break;

            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario user)
        {
            if (!ModelState.IsValid)
            {
                if (user.IsValid(user.cedula, user.contraseña))
                {
                    FormsAuthentication.RedirectFromLoginPage(user.cedula.ToString() , false);
          
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Mensaje = "Usuario o contraseña invalido";
                    return View("Login");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EnviarCorreo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnviarCorreo(EmailModel model)
        {

            using (MailMessage mm = new MailMessage(model.Email, "dvelezmesa@gmail.com"))
            {
                mm.Subject = model.Asunto;
                mm.Body = model.Mensaje;
                mm.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential("dvelezmesa@gmail.com", "Velezmesa96/");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    ViewBag.Message = "Email Enviado";
                }
            }

            return View();
        }
    }
}