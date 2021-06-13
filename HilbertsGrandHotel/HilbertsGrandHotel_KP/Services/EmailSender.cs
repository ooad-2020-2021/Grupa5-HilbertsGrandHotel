using MimeKit;
using System;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Services
{
    public static class EmailSender
    {
        public static async Task PosaljiEmail(string email, string subject, string poruka, string imeIPrezime)
        {
            var mailMessage = new MimeMessage();

            mailMessage.From.Add(new MailboxAddress("Hilbert's Grand Hotel", "hilbertsgrandhotel@gmail.com"));
            mailMessage.To.Add(new MailboxAddress(imeIPrezime, email));
            mailMessage.Subject = subject;
            mailMessage.Body = new TextPart("html")
            {
                Text = poruka
            };

            using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("hilbertsgrandhotel@gmail.com", "Hilbert321");
            await smtpClient.SendAsync(mailMessage);
            smtpClient.Disconnect(true);

        }

        public static async Task PrimiEmail(string email, string subject, string poruka, string imeIPrezime)
        {
            var mailMessage = new MimeMessage();

            mailMessage.From.Add(new MailboxAddress(imeIPrezime, email));
            mailMessage.To.Add(new MailboxAddress("Hilbert's Grand Hotel", "hilbertsgrandhotel@gmail.com"));
            mailMessage.Subject = subject;
            mailMessage.Body = new TextPart("html")
            {
                Text = poruka
            };

            using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("hilbertsgrandhotel@gmail.com", "Hilbert321");
            await smtpClient.SendAsync(mailMessage);
            smtpClient.Disconnect(true);

        }

        //internal static Task PosaljiEmail(string email, string predmet, string poruka, string imeIPrezime)
        //{
        //    var mailMessage = new MimeMessage();
        //    mailMessage.From.Add(new MailboxAddress("Hilbert's Grand Hotel", "hilbertsgrandhotel@gmail.com"));
        //    mailMessage.To.Add(new MailboxAddress(imeIPrezime, email));
        //    mailMessage.Subject = subject;
        //    mailMessage.Body = new TextPart("plain")
        //    {
        //        Text = poruka
        //    };

        //    using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
        //    {
        //        smtpClient.Connect("smtp.gmail.com", 587, false);
        //        smtpClient.Authenticate("hilbertsgrandhotel@gmail.com", "Hilbert321");
        //        smtpClient.Send(mailMessage);
        //        smtpClient.Disconnect(true);
        //    }
        //}
    }
}