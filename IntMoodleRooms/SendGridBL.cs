using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace IntMoodleRooms
{
    public class SendGridBL
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static string Asunto = ConfigurationManager.AppSettings["asunto"];
        private static string From = ConfigurationManager.AppSettings["from"];
        private static string FromName = ConfigurationManager.AppSettings["from.name"];
        private static string Html = ConfigurationManager.AppSettings["html"];
        private static string Cc = ConfigurationManager.AppSettings["cc.error"];
        private static string ApiKey = ConfigurationManager.AppSettings["api.key"];
        private static string To = ConfigurationManager.AppSettings["to.error"];

        public static async Task SendMail(string asunto, string mensaje)
        {
            try
            {

                string htmlBody = IntMoodleRooms.Properties.Resources.bodyTemplate;
                string subjectmessage = "Estimado equipo del Instituto Semi Presencial y distancia,";
                string encabezado = " Se comunica que ocurri&oacute; un error al realizar " + asunto + ".";

                byte[] bytesBody = Encoding.Default.GetBytes(htmlBody);

                htmlBody = Encoding.UTF8.GetString(bytesBody);

                StringBuilder emailBodyHtml = new StringBuilder(htmlBody);

                emailBodyHtml.Replace("#SUBJECT#", subjectmessage);
                emailBodyHtml.Replace("#HEADER#", encabezado);
                emailBodyHtml.Replace("#BODY#", mensaje);
                var htmlBodyContent = emailBodyHtml.ToString();
                string Body = htmlBodyContent;

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                string[] toList = To.Split(';', ',');
                string[] ccList = Cc.Split(';', ',');

                var client = new SendGridClient(ApiKey);
                var from = new EmailAddress(From, FromName);
                var subject = Asunto.ToString();
                var to = new EmailAddress(To, "");
                var plainTextContent = Body;

                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, Body);

                if (!String.IsNullOrEmpty(To))
                {
                    foreach (var too in toList)
                    {
                        msg.AddTo(too);
                    }
                }
                if (!String.IsNullOrEmpty(Cc))
                {
                    foreach (var cc in ccList)
                    {
                        msg.AddCc(cc);
                    }
                }

                var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
                logger.Info("Estado del correo notificando error: " + response.StatusCode);

            }
            catch (Exception e)
            {
                logger.Error("*****Error al enviar el correo*****");
                logger.Error(e.ToString());
            }

        }
    }
}
