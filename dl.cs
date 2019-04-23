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
using System.IO.Compression;


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
            public int? dist { get; set; }
            public Child[] children { get; set; }
            public object after { get; set; }
            public object before { get; set; }
        }

        public class Child
        {
            public string kind { get; set; }
            public Data1 data { get; set; }
        }

        public class Data1
        {

            public string title { get; set; }
            public object[] link_flair_richtext { get; set; }
            public string subreddit_name_prefixed { get; set; }
            public bool hidden { get; set; }
            public object pwls { get; set; }
            public object link_flair_css_class { get; set; }
            public string name { get; set; }
            public string domain { get; set; }
            public Media_Embed media_embed { get; set; }
            public Secure_Media secure_media { get; set; }
            public bool is_reddit_media_domain { get; set; }
            public bool is_meta { get; set; }
            public object category { get; set; }
            public Secure_Media_Embed secure_media_embed { get; set; }
            public object[] author_flair_richtext { get; set; }
            public Gildings gildings { get; set; }
            public string post_hint { get; set; }
            public object content_categories { get; set; }
            public bool is_self { get; set; }
            public object mod_note { get; set; }
            public float created { get; set; }
            public object wls { get; set; }
            public bool contest_mode { get; set; }
            public object selftext_html { get; set; }
            public object suggested_sort { get; set; }
            public bool is_crosspostable { get; set; }
            public Preview preview { get; set; }
            public Media media { get; set; }
            public bool media_only { get; set; }
            public bool can_gild { get; set; }
            public bool spoiler { get; set; }
            public bool locked { get; set; }
            public object distinguished { get; set; }
            public string id { get; set; }
            public bool is_robot_indexable { get; set; }
            public bool send_replies { get; set; }
            public bool author_patreon_flair { get; set; }
            public object author_flair_text_color { get; set; }
            public string permalink { get; set; }
            public object whitelist_status { get; set; }
            public string url { get; set; }
            public bool is_video { get; set; }
            public string link_id { get; set; }
            public string parent_id { get; set; }
            public string body { get; set; }
            public bool is_submitter { get; set; }
            public object collapsed_reason { get; set; }
            public string body_html { get; set; }
            public bool collapsed { get; set; }
            public int depth { get; set; }
        }

        public class Media_Embed
        {
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
            public int duration { get; set; }
            public string hls_url { get; set; }
            public bool is_gif { get; set; }
            public string transcoding_status { get; set; }
        }

        public class Secure_Media_Embed
        {
        }

        public class Gildings
        {
            public int gid_1 { get; set; }
            public int gid_2 { get; set; }
            public int gid_3 { get; set; }
        }

        public class Preview
        {
            public Image[] images { get; set; }
            public bool enabled { get; set; }
        }

        public class Image
        {
            public Source source { get; set; }
            public Resolution[] resolutions { get; set; }
            public Variants variants { get; set; }
            public string id { get; set; }
        }

        public class Source
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Variants
        {
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


        static bool rContentDownloaded { get; set; }
        #endregion reddit

        #region github
      
        public class GitHubRootobject
        {
            public string url { get; set; }
            public string assets_url { get; set; }
            public string upload_url { get; set; }
            public string html_url { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string tag_name { get; set; }
            public string target_commitish { get; set; }
            public string name { get; set; }
            public bool draft { get; set; }
            public bool prerelease { get; set; }
            public DateTime created_at { get; set; }
            public DateTime published_at { get; set; }
            public Asset[] assets { get; set; }
            public string tarball_url { get; set; }
            public string zipball_url { get; set; }
            public string body { get; set; }
        }

        public class Asset
        {
            public string url { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string name { get; set; }
            public object label { get; set; }
            public string content_type { get; set; }
            public string state { get; set; }
            public int size { get; set; }
            public int download_count { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string browser_download_url { get; set; }
        }

        #endregion github

        #region imgur

        public class ImgrRootobject
        {
            public ImgrData data { get; set; }
            public bool success { get; set; }
            public int status { get; set; }
        }

        public class ImgrData
        {
            public string id { get; set; }
            public string title { get; set; }
            public object description { get; set; }
            public int datetime { get; set; }
            public string cover { get; set; }
            public int cover_width { get; set; }
            public int cover_height { get; set; }
            public string account_url { get; set; }
            public int account_id { get; set; }
            public string privacy { get; set; }
            public string layout { get; set; }
            public int views { get; set; }
            public string link { get; set; }
            public int ups { get; set; }
            public int downs { get; set; }
            public int points { get; set; }
            public int score { get; set; }
            public bool is_album { get; set; }
            public object vote { get; set; }
            public bool favorite { get; set; }
            public bool nsfw { get; set; }
            public string section { get; set; }
            public int comment_count { get; set; }
            public int favorite_count { get; set; }
            public string topic { get; set; }
            public int topic_id { get; set; }
            public int images_count { get; set; }
            public bool in_gallery { get; set; }
            public bool is_ad { get; set; }
            public ImgrTag[] tags { get; set; }
            public int ad_type { get; set; }
            public string ad_url { get; set; }
            public bool in_most_viral { get; set; }
            public bool include_album_ads { get; set; }
            public ImgrImage[] images { get; set; }
            public ImgrAd_Config ad_config { get; set; }
        }

        public class ImgrAd_Config
        {
            public string[] safeFlags { get; set; }
            public object[] highRiskFlags { get; set; }
            public object[] unsafeFlags { get; set; }
            public bool showsAds { get; set; }
        }

        public class ImgrTag
        {
            public string name { get; set; }
            public string display_name { get; set; }
            public int followers { get; set; }
            public int total_items { get; set; }
            public bool following { get; set; }
            public string background_hash { get; set; }
            public object thumbnail_hash { get; set; }
            public string accent { get; set; }
            public bool background_is_animated { get; set; }
            public bool thumbnail_is_animated { get; set; }
            public bool is_promoted { get; set; }
            public string description { get; set; }
            public object logo_hash { get; set; }
            public object logo_destination_url { get; set; }
            public ImgrDescription_Annotations description_annotations { get; set; }
        }

        public class ImgrDescription_Annotations
        {
        }

        public class ImgrImage
        {
            public string id { get; set; }
            public object title { get; set; }
            public object description { get; set; }
            public int datetime { get; set; }
            public string type { get; set; }
            public bool animated { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public int size { get; set; }
            public int views { get; set; }
            public long bandwidth { get; set; }
            public object vote { get; set; }
            public bool favorite { get; set; }
            public object nsfw { get; set; }
            public object section { get; set; }
            public object account_url { get; set; }
            public object account_id { get; set; }
            public bool is_ad { get; set; }
            public bool in_most_viral { get; set; }
            public bool has_sound { get; set; }
            public object[] tags { get; set; }
            public int ad_type { get; set; }
            public string ad_url { get; set; }
            public bool in_gallery { get; set; }
            public string link { get; set; }
            public int mp4_size { get; set; }
            public string mp4 { get; set; }
            public string gifv { get; set; }
            public string hls { get; set; }
            public Processing processing { get; set; }
            public object comment_count { get; set; }
            public object favorite_count { get; set; }
            public object ups { get; set; }
            public object downs { get; set; }
            public object points { get; set; }
            public object score { get; set; }

        }

        public class Processing
        {
            public string status { get; set; }
        }


        #endregion imgur

        WebClient client = new WebClient();
        public int count = 0;
        static string url { get; set; }
        static string usernftp { get; set; }
        static string userpassftp { get; set; }
        static string fpath { get; set; }
        static string newFile { get; set; }
        static int first = 0;
        static bool firstExe = first == 0;
        static bool validImplicit { get; set; }
        static string filePath { get; set; }
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


            GitHubRootobject results = new GitHubRootobject();

            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(githubAPI);
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.80 Safari/537.36");
                HttpResponseMessage response = client.PostAsJsonAsync(githubAPI, results).Result;

                response.EnsureSuccessStatusCode();

                var compressedFiles = response.Content.ReadAsAsync<IList<GitHubRootobject>>().GetAwaiter().GetResult();

                List<GitHubRootobject> downloadElements = compressedFiles.ToList();
                

                Console.WriteLine("Do you want to Download zip/tar/other files? write the option to show a list of Releases ");

                string fileTypeToShow = Console.ReadLine().ToLower();

                Console.WriteLine($"\n\nSelect one Option:");
                int Selection = -1;
                

                if (fileTypeToShow == "zip")
                {
                    for (int i = 0; i < downloadElements.Count(); i++)
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
            if (File.Exists(filePath))
            {
                Console.WriteLine($"\nYour file has been saved: {filePath}"); string opn = "";
                Console.WriteLine("Open File Directory?"); opn = Console.ReadLine();
                string selectedFile = "/select, \"" + filePath + "\"";
                if (opn.Contains("y") || opn.Contains("yes")) Process.Start("explorer.exe", selectedFile);
            }
            else if (File.Exists(newFile))
            {
                Console.WriteLine($"\nYour file has been saved: {newFile}"); string opn = "";
                Console.WriteLine("Open File Directory?"); opn = Console.ReadLine();
                string selectedFile = "/select, \"" + newFile + "\"";
                if (opn.Contains("y") || opn.Contains("yes")) Process.Start("explorer.exe", selectedFile);
            }
            
            WebException = false;
        }

        public void DownloadFile()
        {
             filePath = "";



            if (url == String.Empty)
            {
                Console.WriteLine("Enter a URL");
                url = Console.ReadLine();
            }

            if ((!url.Contains("http") && url.Contains("www.")) || (!url.Contains("https") && url.Contains("www.")))
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
                    jsonurl += ".json";
                }
                else
                {
                    jsonurl = jsonurl.Substring(0, jsonurl.Length).ToString();
                    jsonurl += ".json";
                }

                var redditJsonpath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\redditfile.json";
                using (WebClient localclient = new WebClient())
                {
                    localclient.DownloadFile(jsonurl, redditJsonpath);
                }
                var jsonString = File.ReadAllText(redditJsonpath);

                var deserializedStr = JsonConvert.DeserializeObject<IList<RRootobject>>(jsonString);

                List<RRootobject> foundElements = deserializedStr.ToList();

                var dataObjectvideoURL = new Reddit_Video();
                var dataObject = new Data1();


                dataObjectvideoURL.fallback_url = String.Empty;

                foreach (Child _objectData in foundElements[0].data.children)
                {
                    if (!String.IsNullOrEmpty(_objectData.data.secure_media.reddit_video.fallback_url))
                        dataObjectvideoURL.fallback_url = _objectData.data.secure_media.reddit_video.fallback_url;

                    if (_objectData.data.is_video != null)
                        dataObject.is_video = _objectData.data.is_video;

                    if (_objectData.data.url != null)
                        dataObject.url = _objectData.data.url;

                }
                File.Delete(redditJsonpath);

                if (dataObject.is_video)
                {
                    if (dataObjectvideoURL.fallback_url != String.Empty && dataObjectvideoURL.fallback_url != null)
                    {
                        var mediaURL = dataObjectvideoURL.fallback_url;

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(mediaURL);
                        request.Method = WebRequestMethods.Http.Get;
                        HttpWebResponse result = (HttpWebResponse)request.GetResponse();



                        //var first = GetIndex(url, '/', 7);
                        //var last = (GetIndex(url, '/', 8) > -1) ? (GetIndex(url, '/', 8)) : url.Length;

                        var mediaPath = "";
                        


                        List<int> extensionPos = FindExtensionPos(result);
                        bool hasMIMEtype = extensionPos.Any();


                        if (extensionPos.Count > 1)
                        {
                            ShowElements(extensionPos);
                            Console.WriteLine("Select the extension of the video");
                            int position = int.Parse(Console.ReadLine());
                            mediaPath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads\" + dataObject.title + extensionList[position - 1];
                        }
                        else if (extensionPos.Count == 1)
                        {
                            mediaPath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads\" + dataObject.title + extensionList[extensionPos[0]];
                        }
                        else
                        {
                            mediaPath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads\" + "video.mp4";
                        }

                        if (File.Exists(mediaPath))
                        {
                            mediaPath = Rename(mediaPath);
                        }


                        Console.WriteLine("Downloading Video");
                        WebRequest.DefaultWebProxy = null;
                        client.DownloadFile(mediaURL, mediaPath);

                        Console.WriteLine("Video Downloaded");
                        try
                        {
                            StringBuilder addtourl = new StringBuilder(mediaURL);
                            int start = GetIndex(mediaURL, '/', 4) + 1;
                            int end = GetIndex(mediaURL, '?', 1);

                            var audioURL = addtourl.Replace(mediaURL.Substring(start, end - start).ToString(), "audio").ToString();
                            Console.WriteLine("Downloading Audio");
                            var audioPath = "";
                            audioPath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads\" + dataObject.title + "_audio.mp4";
                            if (File.Exists(mediaPath))
                            {
                                audioPath = Rename(audioPath);
                            }
                            client.DownloadFile(audioURL, audioPath);
                            Console.WriteLine("Audio Downloaded\n");
                            string ffmpegfolder = String.Empty;
                            string ffmegFilename = string.Empty;
                            string dirExtract = string.Empty;

                            using (var tempDownloadclient = new WebClient())
                            {
                                string ffmpegURL = "https://ffmpeg.zeranoe.com/builds/win64/static/ffmpeg-20190227-85051fe-win64-static.zip";
                                int ffmpegurlStarts = ffmpegURL.LastIndexOf('/') + 1;
                                int ffmpegurlEnds = ffmpegURL.LastIndexOf('.');
                                ffmpegfolder = ffmpegURL.Substring(ffmpegurlStarts, ffmpegurlEnds - ffmpegurlStarts).ToString();
                                dirExtract = @"C:\Users\" + Environment.UserName.ToString() + @"\Desktop\" + ffmpegfolder;

                                if (!Directory.Exists(dirExtract))
                                {
                                    Directory.CreateDirectory(dirExtract);
                                }

                                ffmegFilename = ffmpegURL.Substring(ffmpegURL.LastIndexOf('/') + 1, ffmpegURL.Length - (ffmpegURL.LastIndexOf('/') + 1));
                                ffmpegfolder = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads\" + ffmpegfolder + ".zip";
                                if (!File.Exists(ffmpegfolder))
                                {
                                    tempDownloadclient.DownloadFile(ffmpegURL, ffmpegfolder);
                                }
                            }
                            Console.WriteLine("FFMPEG Downloaded \nMerging Video to audio");

                            if (!dirExtract.EndsWith(Path.DirectorySeparatorChar.ToString()))
                                dirExtract += Path.DirectorySeparatorChar;


                            if (Directory.GetFileSystemEntries(dirExtract).Length == 0)
                            {
                                ZipFile.ExtractToDirectory(ffmpegfolder, dirExtract);
                            }

                            ffmpegfolder = dirExtract + "ffmpeg-20190227-85051fe-win64-static\\bin\\ffmpeg.exe";


                            newFile = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads\" + dataObject.title + "RedditVideo.mp4";

                            if (File.Exists(newFile))
                            {
                                newFile = Rename(newFile);
                            }

                            string ffmpegArgs = "/c ffmpeg " + " -i " + mediaPath + " -i " + audioPath + " -shortest " + newFile;
                            string outputPath = ffmpegfolder.Substring(0, ffmpegfolder.LastIndexOf('\\')).ToString();



                            ProcessStartInfo SI = new ProcessStartInfo();
                            SI.CreateNoWindow = false;
                            SI.FileName = "cmd.exe";
                            SI.WorkingDirectory = @"" + outputPath;
                            SI.Arguments = ffmpegArgs;
                            using (var FFMPEG = Process.Start(SI))
                            {
                                FFMPEG.WaitForExit();
                            }

                            File.Delete(mediaPath);
                            
                            if(File.Exists(audioPath))
                                File.Delete(audioPath);
                            
                            Directory.Delete(dirExtract, true);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Video doesnt contains audio");
                        }
                       if(Directory.Exists(mediaPath)) File.Delete(mediaPath);
                        
                        rContentDownloaded = true;
                    }

                }
                else
                {


                    if (dataObject.media.reddit_video.is_gif)
                    {
                        url = dataObject.media.reddit_video.fallback_url;
                        filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + dataObject.title + ".gif";

                    }
                    else
                    {
                        url = dataObject.url;
                        filePath = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + dataObject.title + GetExt();

                    }
                }

            }
            else if (url.Contains("imgur"))
            {
                int start = 0;
                int end = 0;
                if (url.LastIndexOf('/') == 5)
                {
                    start = GetIndex(url, '/', 5);
                    end = GetIndex(url, '/', 6) > -1 ? GetIndex(url, '/', 6) : url.Length;
                }
                if (url.LastIndexOf('/') == 4)
                {
                    start = GetIndex(url, '/', 4);
                    end = GetIndex(url, '/', 5) > -1 ? GetIndex(url, '/', 5) : url.Length;
                }
                start = url.LastIndexOf('/');
                end = GetIndex(url, '/', start + 1) > -1 ? GetIndex(url, '/', start + 1) : url.Length;

                var imgID = url.Substring(start, end - start);
                var imgurAPI = "https://api.imgur.com/3/gallery/id/";
                StringBuilder addtourl = new StringBuilder(imgurAPI);
                url = addtourl.Replace("/id/", imgID).ToString();
                Console.WriteLine(url);


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("Authorization", "Client-ID eefdff21d10f81b");
                request.Timeout = 5000;
                request.Method = WebRequestMethods.Http.Get;
                var response = request.GetResponse().GetResponseStream();
                StreamReader rd = new StreamReader(response);
                var responseStr = rd.ReadToEnd();
                Console.WriteLine(responseStr);
                rd.Close();
                rd.Dispose();

                Console.WriteLine(responseStr);

                var result = JsonConvert.DeserializeObject<ImgrRootobject>(responseStr);
                List<string> imgurResultImages = new List<string>();
                Console.WriteLine("Found Images");
                if (result.data.is_album)
                {
                    Console.WriteLine("Select items"); int i = 0;
                    foreach (ImgrImage image in result.data.images)
                    {
                        Console.WriteLine($"{i + 1} {image.link}"); i++;
                        imgurResultImages.Add(image.link);
                    }
                }
                int countSelection = -1;

                if (imgurResultImages.Count > 1)
                {
                    Console.WriteLine("How Many Images do you wish to download? if you want to download the full Album Enter 0");
                    countSelection = int.Parse(Console.ReadLine());
                }
                else if (imgurResultImages.Count == 1)
                {
                    countSelection = 0;
                }
                List<int> selection = new List<int>();
                List<string> selectedItem = new List<string>();

                if (countSelection != 0)
                {
                    Console.WriteLine("Enter the images index you want to download, to finish selection enter -1");
                    while (!selection.Any().Equals(-1) && selection.Count <= imgurResultImages.Count)
                    {
                        Console.WriteLine("Enter number index to select");
                        int choice = int.Parse(Console.ReadLine());
                        selection.Add(choice);
                    }
                    for (int i = 0; i < selection.Count; i++)
                    {
                        selectedItem.Add(imgurResultImages[selection[i]]);
                    }
                }
                else if (countSelection == 0)
                {
                    selectedItem = imgurResultImages;
                }


                WebClient imgurdownloadclient = new WebClient();
                if (selectedItem.Count > 1)
                {
                    for (int i = 0; i < selectedItem.Count; i++)
                    {
                        imgurdownloadclient.DownloadFile(selectedItem[i], @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + Path.GetFileName(selectedItem[i]));
                    }
                }
                else if (selectedItem.Count == 1)
                {
                    imgurdownloadclient.DownloadFile(selectedItem[0], @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads" + @"\" + Path.GetFileName(selectedItem[0]));
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
                else 
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
            else if ((url.Contains("http") && rContentDownloaded.Equals(false))  || ((url.Contains("https")) && rContentDownloaded.Equals(false)) )
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
            newFile = "";
            rContentDownloaded = false;

            if (!WebException &&   (File.Exists(filePath)  || File.Exists(newFile)))
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
            else if (firstExe && !validation1 && !validation2 && !validation3 || !firstExe && !validation1 && !validation2 && !validation3)
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



