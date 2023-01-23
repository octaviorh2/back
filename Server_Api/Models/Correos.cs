using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Server_Api.Models
{
    public class Correos
    {
        public void EnviarCorreo(string mailorigen, string asuntoDelCorreo, string textoDelCorreo, string maildestino)
        {

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("oruedah@unicesar.edu.co", "Prueba Tecnica", System.Text.Encoding.UTF8);//Correo de salida
            correo.To.Add(maildestino); //Correo destino?
            correo.Subject = "Factrua  App(Prueba tecnica de Monolegal)"; //Asunto
            correo.Body = textoDelCorreo; //Mensaje del correo
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
            smtp.Port = 25; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential("oruedah@unicesar.edu.co", "khodfycsbahqfkog");//Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl
            smtp.Send(correo);
        }


        


        public string CorreoCambiosEstado( string correo , Facturas factura )
        {
            string strBody = "<HTML>";
            strBody += "<Body> ";
            strBody += "<label style='font-family: Arial, icomoon, sans-serif; font-size: 12px; color: #1F1F1F'>";
            strBody += $"<br>Señ@r {factura.Cliente} su factura con codigo:{factura.CodigoFactura} presenta un cambio de estado: {factura.Estado}<br>";
            strBody += "<br>Informacion De la factura Actualizada";
            strBody += "<br> Codigo Factura: " + factura.CodigoFactura+ "";
            strBody += "<br> Cliente: " + factura.Cliente+ "";
            strBody += "<br> Ciudad: " + factura.Ciudad + "";
            strBody += "<br> Nit:"+factura.Nit+"";
            strBody += "<br> Total Factura: " + factura.TotalFactura + "";
            strBody += "<br> Subtotal " + factura.Subtotal + "";
            strBody += "<br> Iva: " + factura.Iva + "";
            strBody += "<br> Retencion: " + factura.Retencion + "";
            strBody += "<br> Fecha de Creacion: " + factura.FechaCreacion + "";
            strBody += "<br> Estado : " + factura.Estado + "";
            strBody += "<img src=\"https://cdn3.f-cdn.com//files/download/144611224/Logo-Monolegal-Digital-RGB_Mesa%20de%20trabajo%201.jpg?width=780&height=448&fit=crop\" width= \"428\" height=\"100\" alt=\"logo\">";
            strBody += "<br><br>";
            strBody += "<br><br>";
            strBody += "</label>";
            strBody += "</Body>";
            strBody += "</HTML>";
            return strBody;
        }
    }
}
