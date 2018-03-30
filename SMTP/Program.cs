using System;
using MailKit.Net.Smtp;
using MimeKit;
using System.Collections.Generic;

namespace SMTP
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> listaEmails = new List<string>();
            List<string> listaNomes = new List<string>();

			listaEmails.Add("rls.end95@gmail.com");
            listaEmails.Add("riallis.franca@gmail.com");
			listaEmails.Add("mylenaitmyle@gmail.com");
			listaNomes.Add("Riallis Franca2");
            listaNomes.Add("Riallis Franca");
			listaNomes.Add("Mylena Itmyle");

            try
            {
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("Gabriel Tamura", "gabrieltamura17@gmail.com"));

                for (int i = 0; i < listaEmails.Count; i++){
                    message.To.Add(new MailboxAddress(listaNomes[i], listaEmails[i]));
                    
                }

                message.Subject = "Hello ?";

                var bodyBuilder = new BodyBuilder();

                bodyBuilder.HtmlBody = "<h1> AEHO!</h1>";

                message.Body = bodyBuilder.ToMessageBody();

                //message.Body = new TextPart("Plain")
                //{
                //    Text = @"Hey Chandler,

                //    I just wanted to let you know that Monica and I were going to go play some paintball, you in?

                //    -- Joey"
                //};

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("smtp.gmail.com", 587, false);

                    client.Authenticate("email", "senha");

                    client.Send(message);
                    client.Disconnect(true);
                }
                Console.WriteLine("Enviei!");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
