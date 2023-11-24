using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService(string smtpHost, int smtpPort, string smtpUsername, string smtpPassword)
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            server.EnableSsl = true;
            server.Port = smtpPort;
            server.Host = smtpHost;
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@cocohealth.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.Body = cuerpo;

            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EnviarCorreoConfirmacion(string emailDestino, string asunto, string cuerpo)
        {
            try
            {
                MailMessage email = new MailMessage();
                email.From = new MailAddress("noresponder@cocohealth.com");
                email.To.Add(emailDestino);
                email.Subject = asunto;
                email.Body = cuerpo;

                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ObtenerEmailUsuario(int idUsuario)
        {
            
            return "correo_ejemplo@example.com";
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
