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
        static string  masterDownload = "";
        static string url { get; set; }
        static string usernftp { get; set; }
        static string userpassftp { get; set; }
        readonly List<string> programmingLangEx = new List<string>() { ".c", ".cc", ".class", ".clj", ".cpp", ".cs", ".cxx", ".el", ".go", ".h", ".java", ".lua", ".m", ".h", ".m4", ".php", ".pas", ".po", ".py", ".rb", ".rs", ".sh", ".sh", ".swift", ".vb", ".vcxproj", ".xcodeproj", ".xml", ".diff", ".patch",".exe" };

        public string Rename(string path)
        {
            string tmpname = Path.GetFileName(path);

            string name ="(" + count.ToString() + ")" + tmpname;

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
            
       try
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
          catch (WebException ftpException)
          {
                    string exception = ftpException.Response.GetResponseStream().ToString();
                    Console.WriteLine(exception);
          }

        }

        private static int GetIndexUrl(string str, char c, int n)
        {
            int s = -1;

            for (int i = 0; i < n; i++)
            {
                s = str.IndexOf(c, s + 1);

                if (s == -1) break;
            }

            return s;
        }

public string giturl(string url)
        {
            string ext = "";
            int extPos = 0; bool existExtension = false;
            extPos = url.LastIndexOf(".") + 1;
            existExtension = (url.LastIndexOf(".") > 0) ? true : false;

            if (existExtension && (programmingLangEx.Any(element => element.Contains(url.Substring(extPos, url.Length - extPos).ToString()))))
            {
                ext = "." + url.Substring(extPos, url.Length - extPos).ToString();
            }

            string urlFileName = url.Substring(url.LastIndexOf("/") + 1, url.Length - (url.LastIndexOf("/") + 1));

            StringBuilder AddtoURL = new StringBuilder(url);
            
            int masterDirIndex = 0;
            Console.WriteLine("Download Master? ");
            masterDownload = Console.ReadLine();masterDownload = masterDownload.ToLower();

            masterDirIndex = GetIndexUrl(url, '/', 5);

            if (url.Contains("/blob/") && ext != "" && (programmingLangEx.Any(element => element.Contains(ext))) && masterDownload != "y" && masterDownload != "yes")
            {
                url = AddtoURL.Replace("/blob/", "/").ToString();
                url = AddtoURL.Replace("github", "raw.githubusercontent").ToString();
                
                return url;
            }
            else if (url.Contains("/blob/") && ext == "" && masterDownload != "y" && masterDownload != "yes" )
            {
                url = AddtoURL.Replace("/blob/", "/").ToString();
                url = AddtoURL.Replace("github", "raw.githubusercontent").ToString();
                
                return url;
            }
            else if ((!url.Contains("/blob/") && ext == "" && ((masterDownload=="yes") || masterDownload=="y"))  && (masterDirIndex >=-1))
            {
                if (masterDirIndex == -1)
                {
                    url+= "/archive/master.zip";
                    return url;
                }

                url = url.Substring(0, masterDirIndex);
                url += "/archive/master.zip";
               
                return url;
            }

            return url;
        }

        public void DownloadFile()
        {

            string filePath = "";
            Console.WriteLine("Enter a URL");
            url = Console.ReadLine();
            int protocolWordlength = url.IndexOf(':');
            string protocol = (protocolWordlength > 0) ? url.Substring(0, protocolWordlength) : "";
            //without http/https/ftp missing
            while (!(protocol == "http" || protocol == "https" || protocol == "ftp" || protocol == ""))
            {
                Console.WriteLine("Enter a valid URL");
                url = Console.ReadLine();
            }

            if (url.Contains("github.com"))
            {
                url = giturl(url);
                Console.WriteLine(url);
            }

            int pos = 0;

            if (url.Contains("github"))
            {
                if (masterDownload == "yes" || masterDownload == "y")
                {
                    int minprojectIndex = GetIndexUrl(url, '/', 4);
                    int maxprojectIndex = GetIndexUrl(url, '/', 5);

                    maxprojectIndex = maxprojectIndex - (minprojectIndex + 1);
                    string projectName = "";
                    projectName = url.Substring(minprojectIndex + 1, maxprojectIndex).ToString();
                    pos = url.LastIndexOf("/") + 1;
                    filePath = url.Substring(pos, url.Length - pos).ToString();
                    
                    filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + projectName + "-" + filePath;
                  
                }
                else
                {
                    pos = url.LastIndexOf("/") + 1;
                    filePath = url.Substring(pos, url.Length - pos).ToString();
                    filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + filePath;
                    
                }
                masterDownload = "";
            }
            else
            {
                pos = url.LastIndexOf("/") + 1;
                filePath = url.Substring(pos, url.Length - pos).ToString();
                filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + filePath;
            }


            if (File.Exists(filePath))
            {
                filePath = Rename(filePath);
            }
            Console.WriteLine($"Downloading File");
            if (url.Contains("ftp"))
            {
                DownloadFTP(filePath);
            }
            else
            {
                try
                {
                    client.Headers.Add("User-Agent", "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36");
                    client.DownloadFile(url, filePath);
                }
                catch (WebException ex)
                {
                    string exception = ex.Response.GetResponseStream().ToString();
                    Console.WriteLine(exception);
                }
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


            while (!cont.Contains("no"))
            {
                Download.DownloadFile();
                Console.WriteLine("Do you want to download another file?"); cont = Console.ReadLine();
                cont = cont.ToLower();
            }
        }
    }
}
