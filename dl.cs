using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace dl
{
    class Program
    {
        WebClient client = new WebClient();
        public int count = 0;
        static string url { get; set; }
        static string usernftp { get; set; }
        static string userpassftp { get; set; }

        public string Rename(string path)
        {
            string tmpname = Path.GetFileName(path);
            string name = "(" + count.ToString() + ")" + tmpname;
            StringBuilder addNew = new StringBuilder(path);
            while (Path.GetFileName(path) == name)
            {
                count += 1;
                name = "(" + count.ToString() + ")" + tmpname;
            }
            addNew.Replace(tmpname, name);
            path = addNew.ToString();
            count += 1;
            return path;

        }

        public void DownloadFTP(string path)
        {
            string localpath = "";
            string requirement = "";
            if (File.Exists(path))
            {
                localpath = Rename(path);
            }
            else
            {
                localpath = path;
            }

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            Console.WriteLine("Does FTP access require user/passsword?");
            if (requirement.Contains("y") || requirement.Contains("yes"))
            {
                Console.WriteLine("Enter a username for ftp"); usernftp = Console.ReadLine();
                Console.WriteLine("Enter password for ftp"); userpassftp = Console.ReadLine();
                request.Credentials = new NetworkCredential(usernftp, userpassftp);
            }
            request.Credentials = new NetworkCredential(usernftp, userpassftp);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            Console.WriteLine($"Downloading File");
            using (Stream ftpStream = request.GetResponse().GetResponseStream())
            using (Stream fileStream = File.Create(localpath))
            {
                ftpStream.CopyTo(fileStream);
            }

        }

        public void DownloadFile()
        {
            string filePath = "";
            Console.WriteLine("Enter a URL");
            url = Console.ReadLine();
            while ((!url.Contains("https")) || (!url.Contains("http")))
            {
                Console.WriteLine("Enter a valid URL");
                url = Console.ReadLine();
            }
            int pos = url.LastIndexOf("/") + 1;
            filePath = url.Substring(pos, url.Length - pos).ToString();
            filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + filePath;

            if (File.Exists(filePath))
            {
                filePath = Rename(filePath);
            }

            if (url.Contains("ftp"))
            {
                DownloadFTP(filePath);

            }
            else
            {
                Console.WriteLine($"Downloading File");
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36");
                client.DownloadFile(url, filePath);
            }

            Console.WriteLine($"Your file has been saved: {filePath}"); string opn = "";
            Console.WriteLine("Open File Directory?"); opn = Console.ReadLine();
            string selectedFile = "/select, \"" + filePath + "\"";
            if (opn.Contains("y") || opn.Contains("yes")) Process.Start("explorer.exe", selectedFile);
        }

        public static void Main(string[] args)
        {
            Program Download = new Program();
            Console.WriteLine($"Welcome {Environment.UserName}");
            string cont = "";


            while (!cont.Contains(" no ") || !cont.Contains("no ") || !cont.Equals("n"))
            {
                Download.DownloadFile();
                Console.WriteLine("Do you want to download another file?"); cont = Console.ReadLine();
                cont = cont.ToLower();
            }
        }
    }
}
