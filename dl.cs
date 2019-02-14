using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Net.Http.Formatting;
using System.Net.Http;
using Newtonsoft.Json;



namespace dl
{
    partial class Program
    {

        #region reddit

        public class RRootobject
        {
            public string kind { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public string modhash { get; set; }
            public int dist { get; set; }
            public Product[] children { get; set; }
            public object after { get; set; }
            public object before { get; set; }
        }

        public class Product
        {
            public string kind { get; set; }
            public Data1 data { get; set; }
        }

        public class Data1
        {

            public string title { get; set; }
            public Secure_Media secure_media { get; set; }
            public bool is_reddit_media_domain { get; set; }
            public object category { get; set; }
            public string post_hint { get; set; }
            public object content_categories { get; set; }
            public bool is_self { get; set; }
            public Media media { get; set; }
            public bool media_only { get; set; }
            public object report_reasons { get; set; }
            public string author { get; set; }
            public string url { get; set; }
            public bool is_video { get; set; }
        }
        public class Secure_Media
        {
            public Reddit_Video reddit_video { get; set; }
        }

        public class Reddit_Video
        {
            public string fallback_url { get; set; }
            public int height { get; set; }
            public int width { get; set; }
            public string scrubber_media_url { get; set; }
            public string dash_url { get; set; }
            public int duration { get; set; }
            public string hls_url { get; set; }
            public bool is_gif { get; set; }
            public string transcoding_status { get; set; }
        }


        public class Image
        {
            public Source source { get; set; }
            public Resolution[] resolutions { get; set; }
            public string id { get; set; }
        }

        public class Source
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }



        public class Resolution
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Media
        {
            public Reddit_Video1 reddit_video { get; set; }
        }

        public class Reddit_Video1
        {
            public string fallback_url { get; set; }
            public int height { get; set; }
            public int width { get; set; }
            public string scrubber_media_url { get; set; }
            public string dash_url { get; set; }
            public int duration { get; set; }
            public string hls_url { get; set; }
            public bool is_gif { get; set; }
            public string transcoding_status { get; set; }
        }


        #endregion reddit

        #region github
        public class Rootobject
        {

            public string name { get; set; }
            public Asset[] assets { get; set; }
            public string tarball_url { get; set; }
            public string zipball_url { get; set; }
            public string body { get; set; }

        }



        public class Asset
        {
            public string name { get; set; }
            public string label { get; set; }
            public string content_type { get; set; }
            public string state { get; set; }
            public int size { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string browser_download_url { get; set; }
        }

        #endregion github


        WebClient client = new WebClient();
        public int count = 0;
        static string url { get; set; }
        static string usernftp { get; set; }
        static string userpassftp { get; set; }
        static string fpath { get; set; }
        static int first = 0;
        static bool firstExe = first == 0;
        static bool validImplicit { get; set; }
        static string masterDownload = "";
        static bool WebException = false;
        public static string githubAPI = "http://api.github.com/repos/:owner/:repo/releases";

        readonly List<string> programmingLangEx = new List<string>() { ".c", ".cc", ".class", ".clj", ".cpp", ".cs", ".cxx", ".el", ".go", ".h", ".java", ".lua", ".m", ".h", ".m4", ".php", ".pas", ".po", ".py", ".rb", ".rs", ".sh", ".sh", ".swift", ".vb", ".vcxproj", ".xcodeproj", ".xml", ".diff", ".patch", ".exe" };


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

        public string GetName()
        {
            int pos = url.LastIndexOf("/") + 1;

            string name = url.Substring(pos, url.Length - pos).ToString();

            return name;
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
                WebException = true;
            }

        }

        private static int GetIndex(string str, char c, int n)
        {
            int stringPosition = -1;

            for (int i = 0; i < n; i++)
            {
                stringPosition = str.IndexOf(c, stringPosition + 1);

                if (stringPosition == -1) break;
            }
            return stringPosition;
        }

        public static string GetProjectName(string url)
        {
            int pos = GetIndex(url, '/', 3) + 1;

            string name = url.Substring(pos, (GetIndex(url, '/', 4)) - pos);

            return name;
        }

        public static string GetRepo(string url)
        {
            int pos = GetIndex(url, '/', 4) + 1;

            int last = (GetIndex(url, '/', 5) > -1) ? (GetIndex(url, '/', 5)) : url.Length;

            string repo = url.Substring(pos, last - pos);
            return repo;
        }

        public string GetExt()
        {

            int extPos = url.LastIndexOf(".") + 1;
            string foundExtension = "";
            foundExtension = Path.GetExtension(url);
            bool ExtensioninURL = (foundExtension != "") ? true : false;
            //"." + url.Substring(extPos, url.Length - extPos).ToString();
            //string inList = null;
            //inList = extensionList.SingleOrDefault(s => s.Equals(foundExtension));
            //bool MatchesExtension = inList!=null;

            if (ExtensioninURL)
            {
                return foundExtension;
            }

            return "";
        }

        public void ShowElements(List<int> positions)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                Console.WriteLine($"Element in  Position {positions[i]} {extensionList[positions[i]]}");
            }
        }

        public List<int> FindExtensionPos(HttpWebResponse result)
        {
            return mimeList.Select((value, index) => new { value, Index = index }).Where(x => x.value.Equals(Path.GetFileName(result.Headers["Content-Type"]))).Select(x => x.Index).ToList();
        }

        public string giturl(string url)
        {
            string ext = "";

            ext = GetExt();

            string urlFileName = url.Substring(url.LastIndexOf("/") + 1, url.Length - (url.LastIndexOf("/") + 1));

            StringBuilder AddtoURL = new StringBuilder(url);

            int masterDirIndex = 0;
            Console.WriteLine("Download Master? ");
            masterDownload = Console.ReadLine().ToLower();

            masterDirIndex = GetIndex(url, '/', 5);
            bool isCompleted = masterDirIndex > -1;
            if (!isCompleted && (masterDownload == "yes" || masterDownload == "y"))
            {
                url += '/';
                masterDirIndex = GetIndex(url, '/', 5);
            }

            if (url.Contains("/blob/") && ext != "" && (programmingLangEx.Any(element => element.Contains(ext))) && masterDownload != "y" && masterDownload != "yes")
            {
                url = AddtoURL.Replace("/blob/", "/").ToString();
                url = AddtoURL.Replace("github", "raw.githubusercontent").ToString();
                return url;
            }
            else if (url.Contains("/blob/") && ext == "" && masterDownload != "y" && masterDownload != "yes")
            {

                url = AddtoURL.Replace("/blob/", "/").ToString();
                url = AddtoURL.Replace("github", "raw.githubusercontent").ToString();

                return url;
            }
            else if ((!url.Contains("/blob/") && ext == "" && ((masterDownload == "yes") || masterDownload == "y")) && (masterDirIndex >= -1))
            {
                url = AddtoURL.Replace("github.com", "codeload.github.com").ToString();

                if (GetIndex(url, '/', 5) == -1)
                {
                    url += "/zip/master";
                    return url;
                }

                url = url.Substring(0, GetIndex(url, '/', 5));
                url += "/zip/master";
                return url;
            }
            else if ((url.Contains("/blob/") && ext != "" && ((masterDownload == "yes") || masterDownload == "y")) && (masterDirIndex >= -1))
            {
                url = AddtoURL.Replace("github.com", "codeload.github.com").ToString();

                url = url.Substring(0, GetIndex(url, '/', 5));

                url += "/zip/master";
                return url;


            }

            return url;
        }
        public string GetReleaseUrl()
        {
            StringBuilder addurl = new StringBuilder(githubAPI);
            addurl.Replace(":owner", GetProjectName(url));
            addurl.Replace(":repo", GetRepo(url));
            githubAPI = addurl.ToString();


            Rootobject results = new Rootobject();

            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(githubAPI);
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.80 Safari/537.36");
                HttpResponseMessage response = client.PostAsJsonAsync(githubAPI, results).Result;

                response.EnsureSuccessStatusCode();

                var compressedFiles = response.Content.ReadAsAsync<IEnumerable<Rootobject>>().GetAwaiter().GetResult();

                List<Rootobject> downloadElements = compressedFiles.ToList();



                Console.WriteLine("Do you want to Download zip/tar/other files? write the option to show a list of Releases ");

                string fileTypeToShow = Console.ReadLine().ToLower();

                Console.WriteLine($"Description:  {downloadElements[0].body}  \n\nSelect one Option:");
                int Selection = -1;
                if (fileTypeToShow == "zip")
                {
                    for (int i = 0; i < downloadElements.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {GetRepo(url)}-{Path.GetFileName(downloadElements[i].zipball_url)}.zip");
                    }
                    Console.WriteLine("Select Number: ");
                    Selection = int.Parse(Console.ReadLine());
                    return downloadElements[Selection - 1].zipball_url;
                }
                else if (fileTypeToShow == "tar")
                {
                    for (int i = 0; i < downloadElements.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {GetRepo(url)}-{Path.GetFileName(downloadElements[i].tarball_url)}.tar");
                    }
                    Console.WriteLine("Select Number: ");
                    Selection = int.Parse(Console.ReadLine());
                    return downloadElements[Selection - 1].tarball_url;
                }
                else if (fileTypeToShow == "other")
                {
                    List<string> urlList = new List<string>();
                    for (int i = 0; i < downloadElements.Count; i++)
                    {
                        foreach (Asset File in downloadElements[i].assets)
                        {
                            Console.WriteLine($"{i + 1}) {Path.GetFileName(File.browser_download_url)}       {File.size / 1048576} MB");
                            urlList.Add(File.browser_download_url);
                        }
                    }
                    Console.WriteLine("Select Number: ");
                    Selection = int.Parse(Console.ReadLine());
                    return urlList[Selection - 1];
                }
                fileTypeToShow = "";


            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                WebException = true;
                return null;
            }
            return null;
        }

        public void OpenFolder()
        {

            Console.WriteLine($"\nYour file has been saved: {fpath}"); string opn = "";
            Console.WriteLine("Open File Directory?"); opn = Console.ReadLine();
            string selectedFile = "/select, \"" + fpath + "\"";
            if (opn.Contains("y") || opn.Contains("yes")) Process.Start("explorer.exe", selectedFile);
            WebException = false;
        }

        public void DownloadFile()
        {
            string filePath = "";



            if (url == String.Empty)
            {
                Console.WriteLine("Enter a URL");
                url = Console.ReadLine();
            }

            if (!url.Contains("http://") || !url.Contains("https://") && url.Contains("www."))
            {
                StringBuilder Addinurl = new StringBuilder(url);
                url = Addinurl.Replace("www.", "https://").ToString(); ;
            }
            int protocolWordlength = url.IndexOf(':');
            string protocol = (protocolWordlength > 0) ? url.Substring(0, protocolWordlength) : "";

            while (!(protocol == "http" || protocol == "https" || protocol == "ftp" /*|| protocol == ""*/))
            {
                Console.WriteLine("Enter a valid URL");
                url = Console.ReadLine();
            }


            int pos = 0;

            if (url.Contains("github"))
            {
                url = (GetIndex(url, '/', 5) > -1) ? url : url += '/';

                string releasesInUrl = url.Substring((GetIndex(url, '/', 5) + 1), ((GetIndex(url, '/', 6) > -1) ? (GetIndex(url, '/', 6) + 1) : url.Length) - (GetIndex(url, '/', 5) + 1)).ToString().ToLower();
                string resultingurl = "";
                if (!(releasesInUrl == "releases"))
                {
                    string projectName = "";
                    string releaseFiles = "";

                    if (url.Contains("/blob/"))
                    {
                        url = giturl(url);

                        filePath = Path.GetFileName(url);

                        if (filePath != "")
                        {
                            filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + GetRepo(url) + "-" + filePath;
                        }
                        else
                        {
                            filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + GetRepo(url) + filePath;
                        }
                    }
                    else
                    {

                        Console.WriteLine("Do you want to Download Latest Release? Yes/No");
                        releaseFiles = Console.ReadLine().ToLower();

                        if (releaseFiles == "yes" || releaseFiles == "yes")
                        {
                            resultingurl = GetReleaseUrl();
                            if (resultingurl == "" || resultingurl == null)
                            {
                                Console.WriteLine("No Releases were found");

                                Console.WriteLine("Downloading Master.");

                                url = giturl(url);
                            }
                            else
                            {
                                url = resultingurl;
                            }

                            int maxprojectIndex = 0;

                            if (!(GetIndex(url, '/', 5) > -1))
                            {
                                url += '/';
                                maxprojectIndex = GetIndex(url, '/', 5);
                            }

                            int minprojectIndex = GetIndex(url, '/', 4);
                            maxprojectIndex = GetIndex(url, '/', 5);


                            maxprojectIndex = maxprojectIndex - (minprojectIndex + 1);


                            projectName = url.Substring(minprojectIndex + 1, maxprojectIndex).ToString();

                            filePath = Path.GetFileName(url);

                            if (filePath != "")
                            {
                                filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + projectName + "-" + filePath + ".zip";
                            }
                            else
                            {
                                filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + projectName + "-master.zip";
                            }

                            //DownloadRelease
                        }
                        else
                        {
                            url = giturl(url);

                            if (masterDownload == "yes" || masterDownload == "y")
                            {

                                int maxprojectIndex = 0;

                                if (!(GetIndex(url, '/', 5) > -1))
                                {
                                    url += '/';
                                    maxprojectIndex = GetIndex(url, '/', 5);
                                }

                                int minprojectIndex = GetIndex(url, '/', 4);
                                maxprojectIndex = GetIndex(url, '/', 5);


                                maxprojectIndex = maxprojectIndex - (minprojectIndex + 1);


                                projectName = url.Substring(minprojectIndex + 1, maxprojectIndex).ToString();

                                filePath = GetName();

                                if (filePath != "")
                                {
                                    filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + projectName + "-" + filePath + ".zip";
                                }
                                else
                                {
                                    filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + projectName + "-master.zip";
                                }
                            }
                            else if ((!(masterDownload == "yes") || !(masterDownload == "y")))
                            {
                                pos = url.LastIndexOf("/") + 1;
                                filePath = url.Substring(pos, url.Length - pos).ToString();
                                filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + filePath;

                            }

                        }
                        releaseFiles = "";
                    }
                }
                else
                {

                    resultingurl = GetReleaseUrl();
                    if (resultingurl == "" || resultingurl == null)
                    {
                        Console.WriteLine("No Releases were found");
                    }
                    else
                    {
                        url = resultingurl;
                    }
                    int maxprojectIndex = 0;

                    if (!(GetIndex(url, '/', 6) > -1))
                    {
                        url += '/';
                        maxprojectIndex = GetIndex(url, '/', 6);
                    }

                    int minprojectIndex = GetIndex(url, '/', 5);
                    maxprojectIndex = GetIndex(url, '/', 6);




                    maxprojectIndex = maxprojectIndex - (minprojectIndex + 1);

                    string projectName = "";
                    projectName = url.Substring(minprojectIndex + 1, maxprojectIndex).ToString();

                    filePath = Path.GetFileName(url);

                    if (filePath != "")
                    {
                        filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + projectName + "-" + filePath + ".zip";
                    }
                    else
                    {
                        filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + projectName + "-master.zip";
                    }

                    //DownloadRelease
                }

                resultingurl = "";
                masterDownload = "";
                releasesInUrl = "";
            }
            else if (url.Contains("reddit"))
            {
                var jsonurl = url;

                if (GetIndex(jsonurl, '/', 8) == -1)
                {
                    jsonurl += "/.json";
                }
                else
                {
                    jsonurl += ".json";
                }

                var redditJsonpath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\redditfile.json";
                client.DownloadFile(jsonurl, redditJsonpath);
                var jsonString = File.ReadAllText(redditJsonpath);

                var deserializedStr = JsonConvert.DeserializeObject<IList<RRootobject>>(jsonString);

                List<RRootobject> foundElements = deserializedStr.ToList();

                Product dataObject = new Product();
                dataObject.data.secure_media.reddit_video.fallback_url = "";

                
                    foreach (Product _object in foundElements[0].data.children)
                    {
                        dataObject.data.secure_media.reddit_video.fallback_url = _object.data.secure_media.reddit_video.fallback_url + "/";
                        dataObject.data.url = _object.data.url + "/";
                        dataObject.data.is_video = _object.data.is_video;
                        
                    }
               
                   if (dataObject.data.secure_media.reddit_video.fallback_url!="")
                   {
                        var mediaURL = dataObject.data.secure_media.reddit_video.fallback_url;

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(mediaURL);
                        request.Method = WebRequestMethods.Http.Get;
                        HttpWebResponse result = (HttpWebResponse)request.GetResponse();
                   


                        var first = GetIndex(url, '/', 7);
                        var last = (GetIndex(url, '/', 8) > -1) ? (GetIndex(url, '/', 8)) : url.Length;

                        var mediaPath = "";


                        List<int> extensionPos = FindExtensionPos(result);
                        bool hasMIMEtype = extensionPos.Any();


                        if (dataObject.data.is_video==true)
                        {
                            if (extensionPos.Count > 1)
                            {
                                ShowElements(extensionPos);
                                Console.WriteLine("Select the extension of the video");
                                int position = int.Parse(Console.ReadLine());
                                mediaPath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + url.Substring(first, last - first).ToString() + extensionList[position];
                            }
                            else if (extensionPos.Count == 1)
                            {
                                mediaPath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + url.Substring(first, last - first).ToString() + extensionList[extensionPos[0]];
                            }
                            else
                            {
                                mediaPath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + url.Substring(first, last - first).ToString() + ".mp4";
                            }
                            Console.WriteLine("Downloading Video");
                            client.DownloadFile(mediaURL, mediaPath);



                            StringBuilder addtourl = new StringBuilder(mediaURL);
                            int start = GetIndex(mediaURL, '/', 4) + 1;
                            int end = GetIndex(mediaURL, '?', 1);

                            var audioURL = addtourl.Replace(mediaURL.Substring(start, end - start).ToString(), "audio").ToString();
                            Console.WriteLine("Downloading Audio");
                            var audioPath = "";
                            audioPath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + url.Substring(first, last - first).ToString() + ".mp4";
                            client.DownloadFile(audioURL, audioPath);
                        }
                        else
                        {


                            url = dataObject.data.url;

                            var imagefirst = GetIndex(url, '/', 7);
                            var imagelast = (GetIndex(url, '/', 8) > -1) ? (GetIndex(url, '/', 8)) : url.Length;

                            filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + url.Substring(imagefirst, imagelast - imagefirst).ToString() + GetExt();

                            //other format gif/image
                        }


                    }
                    else
                    {
                        url = dataObject.data.url;
                    
                        var imagefirst = GetIndex(url, '/', 7);
                        var imagelast = (GetIndex(url, '/', 8) > -1) ? (GetIndex(url, '/', 8)) : url.Length;

                        filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + url.Substring(imagefirst, imagelast - imagefirst).ToString() + GetExt();


                    }

            }
            else
            {
                string ext = "";

                ext = GetExt();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Http.Get;
                HttpWebResponse result = (HttpWebResponse)request.GetResponse();

                bool hasMIMEtype = false;

                List<int> indexes = FindExtensionPos(result);

                hasMIMEtype = indexes.Any();

                if ((hasMIMEtype) && (ext == ""))
                {
                    int posList = -1;

                    if (indexes.Count > 1)
                    {
                        ShowElements(indexes);
                        Console.WriteLine("Enter the number which extension belongs to the file:");
                        posList = int.Parse(Console.ReadLine());
                    }
                    else if (indexes.Count == 1)
                    {
                        posList = indexes[0];
                    }
                    filePath = GetName() + extensionList[posList];
                    filePath = "C:\\Users\\" + Environment.UserName.ToString() + "\\Downloads" + "\\" + filePath;
                    indexes.Clear();
                }
                else if (hasMIMEtype && ext != "")
                {
                    filePath = GetName();
                    filePath = "C:\\Users\\" + Environment.UserName.ToString() + "\\Downloads" + "\\" + filePath;
                }

                hasMIMEtype = false;
                ext = "";
            }

            if (File.Exists(filePath))
            {
                filePath = Rename(filePath);
            }

            fpath = filePath;
            Console.WriteLine($"Downloading File");
            if (url.Contains("ftp"))
            {
                DownloadFTP(filePath);
            }
            else
            {
                try
                {

                    WebRequest.DefaultWebProxy = null;
                    client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.80 Safari/537.36");

                    client.DownloadFile(url, filePath);
                    WebException = false;

                }
                catch (WebException ex)
                {
                    string exception = ex.ToString();
                    //    ex.InnerException.ToString();   
                    Console.WriteLine(exception);
                    WebException = true;
                }
            }

            url = String.Empty;

            if (!WebException && File.Exists(filePath))
            {
                OpenFolder();
            }
            WebException = false;
            Console.WriteLine("Do you want to download another file?");

        }

        public static void Main(string[] args)
        {
            Program Download = new Program();
            Console.WriteLine($"Welcome {Environment.UserName}");
            string cont = "";

            String[] arguments = Environment.GetCommandLineArgs();
            var implicitURL = "";
            implicitURL = String.Join(" ", arguments);
            bool validation1 = implicitURL.Contains("http");
            bool validation2 = implicitURL.Contains("www");
            bool validation3 = implicitURL.Contains("ftp");

            if (firstExe && (validation1 || validation2 || validation3))
            {

                if (implicitURL != "")
                {
                    try
                    {
                        if (firstExe && (validation1 || validation2 || validation3))
                        {

                            if (validation1 || validation2 || validation3)
                            {
                                if ((implicitURL.Contains("http") && implicitURL.Contains("www")) || (implicitURL.Contains("http") && !implicitURL.Contains("www")))
                                {
                                    int start = implicitURL.IndexOf('h');
                                    int last = implicitURL.Length;
                                    url = implicitURL.Substring(start, last - start).ToString();
                                }
                                else if (implicitURL.Contains("www") && !implicitURL.Contains("http"))
                                {
                                    int start = implicitURL.IndexOf('w');
                                    int last = implicitURL.Length;
                                    url = implicitURL.Substring(start, last - start).ToString();
                                }

                                if (validation3)
                                {
                                    int start = implicitURL.IndexOf('f');
                                    int last = implicitURL.Length;
                                    url = implicitURL.Substring(start, last - start).ToString();
                                }


                                validImplicit = true;
                            }
                            else
                            {
                                Console.WriteLine($" URL you enter is not valid URL:\n{url}");
                                Console.WriteLine("\nEnter URL:");
                                url = Console.ReadLine();
                                validImplicit = false;
                            }

                        }
                        if (validImplicit)
                        {
                            Download.DownloadFile();
                        }
                        ++first;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        url = String.Empty;
                        ++first;
                    }
                }
                else
                {
                    Console.WriteLine("\nEnter URL:");
                    url = Console.ReadLine();
                    Download.DownloadFile();
                    ++first;
                }


            }
            else if (firstExe && !validation1 && !validation2 && !validation3)
            {

                while (!cont.Contains("no"))
                {
                    url = String.Empty;
                    Download.DownloadFile();

                    cont = Console.ReadLine();
                    WebException = false;
                    cont = cont.ToLower();
                }
            }

        }
    }
}
