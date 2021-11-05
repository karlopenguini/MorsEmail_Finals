using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MorsEmail.Models
{
    public class Messenger
    {
        public static void Send(string senderEmail, string receiverEmail, string encryptedMessage)
        {

            string pathReceiver = $@".\accounts\{receiverEmail}\inbox\{senderEmail}";
            try
            {
                if (!Directory.Exists(pathReceiver))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathReceiver);
                }
            } catch (Exception)
            {
                return;
            }

            string pathSender = $@".\accounts\{senderEmail}\outbox\{receiverEmail}";
            try
            {
                if (!Directory.Exists(pathSender))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathSender);
                }
            }
            catch (Exception)
            {
                return;
            }

            string generatedName = Guid.NewGuid().ToString()+".txt";

            string PATH = $@".\accounts\{receiverEmail}\inbox\{senderEmail}\{generatedName}";
            File.Create(PATH).Close();
            using (StreamWriter wr = File.CreateText(PATH))
            {
                wr.Write(encryptedMessage);
            }

            PATH = $@".\accounts\{senderEmail}\outbox\{receiverEmail}\{generatedName}";
            using (StreamWriter wr = File.CreateText(PATH))
            {
                wr.Write(encryptedMessage);
            }

        }
    }
}
