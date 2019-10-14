using System;
namespace dl
{
    partial class Program
    {
        
         public class SingleImageImgur
        {
            public SingleImgurData data { get; set; }
            public bool success { get; set; }
            public int status { get; set; }
        }

        public class SingleImgurData
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
            public int bandwidth { get; set; }
            public object vote { get; set; }
            public bool favorite { get; set; }
            public bool nsfw { get; set; }
            public object section { get; set; }
            public object account_url { get; set; }
            public object account_id { get; set; }
            public bool is_ad { get; set; }
            public bool in_most_viral { get; set; }
            public bool has_sound { get; set; }
            public object[] tags { get; set; }
            public int ad_type { get; set; }
            public string ad_url { get; set; }
            public string edited { get; set; }
            public bool in_gallery { get; set; }
            public string link { get; set; }
            public Ad_Config ad_config { get; set; }
        }

        public class Ad_Config
        {
            public string[] safeFlags { get; set; }
            public string[] highRiskFlags { get; set; }
            public object[] unsafeFlags { get; set; }
            public bool showsAds { get; set; }
        }

        public class GistRootobject
        {
            public string url { get; set; }
            public string forks_url { get; set; }
            public string commits_url { get; set; }
            public string id { get; set; }
            public string node_id { get; set; }
            public string git_pull_url { get; set; }
            public string git_push_url { get; set; }
            public string html_url { get; set; }
            public Files files { get; set; }
            public bool _public { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string description { get; set; }
            public int comments { get; set; }
            public object user { get; set; }
            public string comments_url { get; set; }
            public Owner owner { get; set; }
            public object[] forks { get; set; }
            public History[] history { get; set; }
            public bool truncated { get; set; }
        }

        public class Files
        {
            public ProgramclcCpp programclccpp { get; set; }
        }

        public class ProgramclcCpp
        {
            public string filename { get; set; }
            public string type { get; set; }
            public string language { get; set; }
            public string raw_url { get; set; }
            public int size { get; set; }
            public bool truncated { get; set; }
            public string content { get; set; }
        }

        public class Owner
        {
            public string login { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

        public class History
        {
            public User user { get; set; }
            public string version { get; set; }
            public string committed_at { get; set; }
            public Change_Status change_status { get; set; }
            public string url { get; set; }
        }

        public class User
        {
            public string login { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

        public class Change_Status
        {
            public int total { get; set; }
            public int additions { get; set; }
            public int deletions { get; set; }
        }
        
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


         bool rContentDownloaded { get; set; }
        #endregion reddit

        #region github

        bool gitTreeDownload { get; set; }

        #region Gist
        public class GistObject
        {
            public string url { get; set; }
            public string forks_url { get; set; }
            public string commits_url { get; set; }
            public string id { get; set; }
            public string node_id { get; set; }
            public string git_pull_url { get; set; }
            public string git_push_url { get; set; }
            public string html_url { get; set; }
            public FilesObject files { get; set; }
            public bool _public { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string description { get; set; }
            public int comments { get; set; }
            public object user { get; set; }
            public string comments_url { get; set; }
            public Owner owner { get; set; }
            public object[] forks { get; set; }
            public History[] history { get; set; }
            public bool truncated { get; set; }
        }

        public class FilesObject
        {
            public FileType FileNames { get; set; }
        }

        public class FileType
        {
            public string filename { get; set; }
            public string type { get; set; }
            public string language { get; set; }
            public string raw_url { get; set; }
            public int size { get; set; }
            public bool truncated { get; set; }
            public string content { get; set; }
        }

        public class Owner
        {
            public string login { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

        public class History
        {
            public User user { get; set; }
            public string version { get; set; }
            public DateTime committed_at { get; set; }
            public Change_Status change_status { get; set; }
            public string url { get; set; }
        }

        public class User
        {
            public string login { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

        public class Change_Status
        {
            public int total { get; set; }
            public int additions { get; set; }
            public int deletions { get; set; }
        }




        #endregion Gist


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

        bool imgurContentDownloaded { get; set; }

        #endregion imgur
    }
}
