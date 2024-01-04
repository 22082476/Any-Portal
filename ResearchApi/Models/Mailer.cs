using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace ResearchApi;
    public class Emailer
    {
        private string Email;
        private string password;
        private List<string> destination;

        public void StuurMail(string onderwerp, string bericht)
        {
            SmtpClient smtpServer = new SmtpClient("smtp-mail.outlook.com");
            smtpServer.Credentials = new NetworkCredential(Email, password);
            smtpServer.EnableSsl = true;
            smtpServer.Port = 587;

            foreach (string ontvanger in destination)
            {
                try
                {
                    MailMessage mail = new MailMessage(Email, ontvanger);
                    mail.Subject = onderwerp;
                    mail.Body = bericht;
                    smtpServer.Send(mail);
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fout bij verzenden naar {ontvanger}: {ex.Message}");
                }
            }
        }
    }
