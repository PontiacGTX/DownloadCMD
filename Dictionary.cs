using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dl
{
    partial class Program
    {
        #region LICENSE
        //Content used under license from
        /*
            The MIT License (MIT)

            Copyright (c) 2014 Samuel Neff

            Permission is hereby granted, free of charge, to any person obtaining a copy
            of this software and associated documentation files (the "Software"), to deal
            in the Software without restriction, including without limitation the rights
            to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
            copies of the Software, and to permit persons to whom the Software is
            furnished to do so, subject to the following conditions:

            The above copyright notice and this permission notice shall be included in all
            copies or substantial portions of the Software.

            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
            IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
            FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
            AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
            LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
            OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
            SOFTWARE.
             https://github.com/samuelneff/MimeTypeMap
             */
        #endregion


        public readonly List<string> mimeList = new List<string>()
        {
            "text/h323","video/3gpp2","video/3gpp","video/3gpp2","video/3gpp",
            "application/x-7z-compressed","audio/audible","audio/aac","application/octet-stream",
            "audio/vnd.audible.aax","audio/ac3","application/octet-stream","application/octet-stream",
            "application/msaccess.addin","application/msaccess","application/msaccess.cab","application/msaccess",
            "application/msaccess.runtime","application/msaccess","application/msaccess.webapplication","application/msaccess.ftemplate",
            "application/internet-property-stream","text/xml","application/msaccess","application/msaccess","application/x-bridge-url",
            "application/msaccess","audio/vnd.dlna.adts","audio/aac","application/octet-stream","application/postscript","audio/aiff",
            "audio/aiff","audio/aiff","application/vnd.adobe.air-application-installer-package+zip","application/mpeg","application/annodex",
            "application/vnd.android.package-archive","application/x-ms-application","image/x-jg","application/xml","application/xml","application/xml",
            "video/x-ms-asf","application/xml","application/octet-stream","text/plain","application/xml","application/xml","video/x-ms-asf",
            "video/x-ms-asf","application/atom+xml","audio/basic","video/x-msvideo","audio/annodex","application/olescript","video/annodex",
            "text/plain","application/x-bcpio","application/octet-stream","image/bmp","text/plain","application/octet-stream","audio/x-caf",
            "application/vnd.ms-office.calx","application/vnd.ms-pki.seccat","text/plain","text/plain","audio/aiff","application/x-cdf",
            "application/x-x509-ca-cert","text/plain","application/octet-stream","application/x-java-applet","application/x-msclip",
            "text/plain","image/x-cmx","text/plain","image/cis-cod","application/xml","text/x-ms-contact","application/xml",
            "application/x-cpio","text/plain","application/x-mscardfile","application/pkix-crl","application/x-x509-ca-cert","text/plain",
            "text/plain","application/x-csh","text/plain","text/css","text/csv","application/octet-stream","text/plain","application/octet-stream",
            "application/xml","text/plain","application/x-director","text/plain","application/octet-stream","application/x-x509-ca-cert","application/xml",
            "image/bmp","video/x-dv","application/x-director","text/xml","video/divx","application/x-msdownload","text/xml","text/dlm","application/msword",
            "application/vnd.ms-word.document.macroEnabled.12","application/vnd.openxmlformats-officedocument.wordprocessingml.document","application/msword",
            "application/vnd.ms-word.template.macroEnabled.12","application/vnd.openxmlformats-officedocument.wordprocessingml.template","application/octet-stream",
            "text/plain","text/xml","text/xml","video/x-dv","application/x-dvi","drawing/x-dwf","application/acad","application/octet-stream","application/x-dxf",
            "application/x-director","message/rfc822","application/octet-stream","application/vnd.ms-fontobject","application/postscript","application/ecmascript",
            "application/etl","text/x-setext","application/envoy","application/octet-stream","text/xml","application/vnd.fdf","application/fractals","application/xml",
            "application/octet-stream","audio/flac","x-world/x-vrml","video/x-flv","application/fsharp-script","application/fsharp-script","application/xml","image/gif",
            "application/gpx+xml","text/x-ms-group","audio/x-gsm","application/x-gtar","application/x-gzip","text/plain","application/x-hdf","text/x-hdml","application/x-oleobject",
            "application/octet-stream","application/octet-stream","application/winhlp","text/plain","application/mac-binhex40","application/hta","text/x-component","text/html","text/html",
            "text/webviewhtml","application/xml","application/xml","application/octet-stream","application/xml","application/xml","application/octet-stream","application/octet-stream",
            "application/xml","application/octet-stream","application/octet-stream","application/octet-stream","text/html","application/xml","application/octet-stream","text/plain","text/plain",
            "image/x-icon","application/octet-stream","text/plain","image/ief","application/x-iphone","text/plain","application/octet-stream","text/plain","text/plain","application/x-internet-signup",
            "application/x-itunes-ipa","application/x-itunes-ipg","text/plain","application/x-itunes-ipsw","text/x-ms-iqy","application/x-internet-signup","application/x-itunes-ite","application/x-itunes-itlp",
            "application/x-itunes-itms","application/x-itunes-itpc","video/x-ivf","application/java-archive","application/octet-stream","application/liquidmotion","application/liquidmotion","image/pjpeg","application/x-java-jnlp-file",
            "application/octet-stream","image/jpeg","image/jpeg","image/jpeg","application/javascript","application/json","text/jscript","text/plain","application/x-latex","application/windows-library+xml","application/x-ms-reader","application/xml",
            "application/octet-stream","video/x-la-asf","text/plain","video/x-la-asf","application/octet-stream","application/x-msmediaview","application/x-msmediaview","video/mpeg","video/vnd.dlna.mpeg-tts","video/vnd.dlna.mpeg-tts","video/mpeg",
            "audio/x-mpegurl","audio/x-mpegurl","audio/m4a","audio/m4b","audio/m4p","audio/x-m4r","video/x-m4v","image/x-macpaint","text/plain","application/x-troff-man","application/x-ms-manifest","text/plain","application/xml","application/mbox",
            "application/msaccess","application/x-msaccess","application/msaccess","application/octet-stream","application/x-troff-me","application/x-shockwave-flash","message/rfc822","message/rfc822","audio/mid","audio/mid","application/octet-stream",
            "text/plain","video/x-matroska-3d","audio/x-matroska","video/x-matroska","application/x-smaf","text/xml","application/x-msmoney","video/mpeg","video/quicktime","video/x-sgi-movie","video/mpeg","video/mpeg","audio/mpeg","video/mp4","video/mp4",
            "video/mpeg","video/mpeg","video/mpeg","video/vnd.dlna.mpeg-tts","video/mpeg","application/vnd.ms-mediapackage","application/vnd.ms-project","video/mpeg","video/quicktime","application/x-troff-ms","application/vnd.ms-outlook","application/octet-stream",
            "application/octet-stream","video/vnd.dlna.mpeg-tts","application/xml","application/x-msmediaview","application/x-miva-compiled","application/x-mmxp","application/x-netcdf","video/x-ms-asf","message/rfc822","application/octet-stream","application/oda",
            "application/vnd.oasis.opendocument.database","application/vnd.oasis.opendocument.chart","application/vnd.oasis.opendocument.formula","application/vnd.oasis.opendocument.graphics","text/plain","application/vnd.oasis.opendocument.image","text/plain",
            "application/vnd.oasis.opendocument.text-master","application/vnd.oasis.opendocument.presentation","application/vnd.oasis.opendocument.spreadsheet","application/vnd.oasis.opendocument.text","audio/ogg","audio/ogg","video/ogg","application/ogg","application/onenote",
            "application/onenote","application/onenote","application/onenote","application/onenote","application/onenote","audio/ogg","application/xml","application/opensearchdescription+xml","application/font-sfnt","application/vnd.oasis.opendocument.graphics-template",
            "application/vnd.oasis.opendocument.text-web","application/vnd.oasis.opendocument.presentation-template","application/vnd.oasis.opendocument.spreadsheet-template","application/vnd.oasis.opendocument.text-template","application/vnd.openofficeorg.extension","application/pkcs10",
            "application/x-pkcs12","application/x-pkcs7-certificates","application/pkcs7-mime","application/pkcs7-mime","application/x-pkcs7-certreqresp","application/pkcs7-signature","image/x-portable-bitmap","application/x-podcast","image/pict","application/octet-stream","application/octet-stream",
            "application/pdf","application/octet-stream","application/octet-stream","application/x-pkcs12","image/x-portable-graymap","image/pict","image/pict","text/plain","text/plain","application/vnd.ms-pki.pko","audio/scpls","application/x-perfmon","application/x-perfmon","application/x-perfmon",
            "application/x-perfmon","application/x-perfmon","image/png","image/x-portable-anymap","image/x-macpaint","image/x-macpaint","image/png","application/vnd.ms-powerpoint","application/vnd.ms-powerpoint.template.macroEnabled.12","application/vnd.openxmlformats-officedocument.presentationml.template",
            "application/vnd.ms-powerpoint","application/vnd.ms-powerpoint.addin.macroEnabled.12","image/x-portable-pixmap","application/vnd.ms-powerpoint","application/vnd.ms-powerpoint.slideshow.macroEnabled.12","application/vnd.openxmlformats-officedocument.presentationml.slideshow","application/vnd.ms-powerpoint",
            "application/vnd.ms-powerpoint.presentation.macroEnabled.12","application/vnd.openxmlformats-officedocument.presentationml.presentation","application/pics-rules","application/octet-stream","application/octet-stream","application/postscript","application/PowerShell","application/octet-stream","application/xml",
            "application/octet-stream","application/octet-stream","application/vnd.ms-outlook","application/x-mspublisher","application/vnd.ms-powerpoint","text/x-html-insertion","text/x-html-insertion","video/quicktime","image/x-quicktime","image/x-quicktime","application/x-quicktimeplayer","application/octet-stream",
            "audio/x-pn-realaudio","audio/x-pn-realaudio","application/x-rar-compressed","image/x-cmu-raster","application/rat-file","text/plain","text/plain","text/plain","application/xml","text/plain","application/xml","image/vnd.rn-realflash","image/x-rgb","text/plain","application/vnd.rn-realmedia","audio/mid",
            "application/vnd.rn-rn_music_package","application/x-troff","audio/x-pn-realaudio-plugin","text/x-ms-rqy","application/rtf","text/richtext","application/octet-stream","application/xml","text/plain","application/x-safari-safariextz","application/x-msschedule","text/plain","text/scriptlet","audio/x-sd2",
            "application/sdp","application/octet-stream","application/windows-search-connector+xml","application/set-payment-initiation","application/set-registration-initiation","application/xml","application/x-sgimb","text/sgml","application/x-sh","application/x-shar","text/html","application/x-stuffit",
            "application/xml","application/xml","application/x-koan","application/vnd.ms-powerpoint.slide.macroEnabled.12","application/vnd.openxmlformats-officedocument.presentationml.slide","application/vnd.ms-excel","text/plain","application/x-ms-license","audio/x-smd","application/octet-stream","audio/x-smd",
            "audio/x-smd","audio/basic","application/xml","application/octet-stream","text/plain","text/plain","application/x-pkcs7-certificates","application/futuresplash","audio/ogg","application/x-wais-source","text/plain","text/xml","application/streamingmedia","application/vnd.ms-pki.certstore",
            "application/vnd.ms-pki.stl","application/x-sv4cpio","application/x-sv4crc","application/xml","image/svg+xml","application/x-shockwave-flash","application/step","application/step","application/x-troff","application/x-tar","application/x-tcl","application/xml","application/xml","application/x-tex",
            "application/x-texinfo","application/x-texinfo","application/x-compressed","application/vnd.ms-officetheme","application/octet-stream","image/tiff","image/tiff","text/plain","text/plain","application/octet-stream","application/x-troff","application/x-msterminal","application/xml","video/vnd.dlna.mpeg-tts",
            "text/tab-separated-values","application/font-sfnt","video/vnd.dlna.mpeg-tts","text/plain","application/octet-stream","text/iuls","text/plain","application/x-ustar","text/plain","text/plain","video/mpeg","text/plain","text/vbscript","text/x-vcard","application/xml","text/plain","application/xml","text/plain",
            "text/plain","text/plain","application/vnd.ms-visio.viewer","text/xml","application/xml","text/xml","application/vnd.visio","application/ms-vsi","application/vsix","text/xml","text/xml","application/xml","text/plain","application/vnd.visio","text/plain","text/xml","text/plain","application/vnd.visio","text/xml",
            "application/x-ms-vsto","application/vnd.visio","application/vnd.visio","text/vtt","application/vnd.visio","application/wasm","audio/wav","audio/wav","audio/x-ms-wax","application/msword","image/vnd.wap.wbmp","application/vnd.ms-works","application/vnd.ms-works","image/vnd.ms-photo","application/x-safari-webarchive",
            "video/webm","image/webp","application/xml","application/xml","application/msword","application/vnd.ms-works","application/wlmoviemaker","application/x-wlpg-detect","application/x-wlpg3-detect","video/x-ms-wm","audio/x-ms-wma","application/x-ms-wmd","application/x-msmetafile","text/vnd.wap.wml","application/vnd.wap.wmlc",
            "text/vnd.wap.wmlscript","application/vnd.wap.wmlscriptc","video/x-ms-wmp","video/x-ms-wmv","video/x-ms-wmx","application/x-ms-wmz","application/font-woff","application/font-woff2","application/vnd.ms-wpl","application/vnd.ms-works","application/x-mswrite","x-world/x-vrml","x-world/x-vrml","text/scriptlet","text/xml","video/x-ms-wvx",
            "application/directx","x-world/x-vrml","application/xaml+xml","application/x-silverlight-app","application/x-ms-xbap","image/x-xbitmap","text/plain","application/xhtml+xml","application/xhtml+xml","application/vnd.ms-excel","application/vnd.ms-excel.addin.macroEnabled.12","application/vnd.ms-excel","application/vnd.ms-excel",
            "application/vnd.ms-excel","application/vnd.ms-excel","application/vnd.ms-excel","application/vnd.ms-excel","application/vnd.ms-excel.sheet.binary.macroEnabled.12","application/vnd.ms-excel.sheet.macroEnabled.12","application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","application/vnd.ms-excel",
            "application/vnd.ms-excel.template.macroEnabled.12","application/vnd.openxmlformats-officedocument.spreadsheetml.template","application/vnd.ms-excel","text/xml","application/octet-stream","application/xml","x-world/x-vrml","text/plain","image/x-xpixmap","application/vnd.ms-xpsdocument","text/xml","application/xml","text/xml",
            "text/xml","text/xml","text/xml","application/octet-stream","application/xml","application/xspf+xml","application/octet-stream","image/x-xwindowdump","application/x-compress","application/zip","application/vnd.ms-excel","application/vnd.ms-powerpoint","application/vnd.ms-works","application/x-zip-compressed","audio/wav","text/scriptlet","video/x-la-asf"
        };
        public readonly List<string> extensionList = new List<string>()
        {
            ".323",".3g2",".3gp",".3gp2",".3gpp",".7z",".aa",".AAC",".aaf",".aax",".ac3",".aca",".asd",".accda",".accdb",".accdc",".accde",".accdr",".accdt",".accdw",".accft",".acx",".AddIn",".ade",".adp",".adobebridge",".adp",".ADT",".ADTS",".afm",".ai",".aif",".aifc",".aiff",".air",".amc",".anx",".apk",".application",".art",".asa",
            ".asax",".ascx",".asf",".ashx",".asi",".asm",".asmx",".aspx",".asr",".asx",".atom",".au",".avi",".axa",".axs",".axv",".bas",".bcpio",".bin",".bmp",".c",".cab",".caf",".calx",".cat",".cc",".cd",".cdda",".cdf",".cer",".cfg",".chm",".class",".clp",".cmd",".cmx",".cnf",".cod",".config",".contact",".coverage",".cpio",".cpp",
            ".crd",".crl",".crt",".cs",".csdproj",".csh",".csproj",".css",".csv",".cur",".cxx",".dat",".datasource",".dbproj",".dcr",".def",".deploy",".der",".dgml",".dib",".dif",".dir",".disco",".divx",".dll",".dll.config",".dlm",".doc",".docm",".docx",".dot",".dotm",".dotx",".dsp",".dsw",".dtd",".dtsConfig",".dv",".dvi",".dwf",".dwg",
            ".dwp",".dxf",".dxr",".eml",".emz",".eot",".eps",".es",".etl",".etx",".evy",".exe",".exe.config",".fdf",".fif",".filters",".fla",".flac",".flr",".flv",".fsscript",".fsx",".generictest",".gif",".gpx",".group",".gsm",".gtar",".gz",".h",".hdf",".hdml",".hhc",".hhk",".hhp",".hlp",".hpp",".hqx",".hta",".htc",".htm",".html",".htt",
            ".hxa",".hxc",".hxd",".hxe",".hxf",".hxh",".hxi",".hxk",".hxq",".hxr",".hxs",".hxt",".hxv",".hxw",".hxx",".i",".ico",".ics",".idl",".ief",".iii",".inc",".inf",".ini",".inl",".ins",".ipa",".ipg",".ipproj",".ipsw",".iqy",".isp",".ite",".itlp",".itms",".itpc",".IVF",".jar",".java",".jck",".jcz",".jfif",".jnlp",".jpb",".jpe",".jpeg",
            ".jpg",".js",".json",".jsx",".jsxbin",".latex",".library-ms",".lit",".loadtest",".lpk",".lsf",".lst",".lsx",".lzh",".m13",".m14",".m1v",".m2t",".m2ts",".m2v",".m3u",".m3u8",".m4a",".m4b",".m4p",".m4r",".m4v",".mac",".mak",".man",".manifest",".map",".master",".mbox",".mda",".mdb",".mde",".mdp",".me",".mfp",".mht",".mhtml",".mid",
            ".midi",".mix",".mk",".mk3d",".mka",".mkv",".mmf",".mno",".mny",".mod",".mov",".movie",".mp2",".mp2v",".mp3",".mp4",".mp4v",".mpa",".mpe",".mpg",".m2t",".mpeg",".mpf",".mpp",".mpv2",".mqv",".ms",".msg",".msi",".mso",".mts",".mtx",".mvb",".mvc",".mxp",".nc",".nsc",".nws",".ocx",".oda",".odb",".odc",".odf",".odg",".odh",".odi",".odl",
            ".odm",".odp",".ods",".odt",".oga",".ogg",".ogv",".ogx",".one",".onea",".onepkg",".onetmp",".onetoc",".onetoc2",".opus",".orderedtest",".osdx",".otf",".otg",".oth",".otp",".ots",".ott",".oxt",".p10",".p12",".p7b",".p7c",".p7m",".p7r",".p7s",".pbm",".pcast",".pct",".pcx",".pcz",".pdf",".pfb",".pfm",".pfx",".pgm",".pic",".pict",".pkgdef",
            ".pkgundef",".pko",".pls",".pma",".pmc",".pml",".pmr",".pmw",".png",".pnm",".pnt",".pntg",".pnz",".pot",".potm",".potx",".ppa",".ppam",".ppm",".pps",".ppsm",".ppsx",".ppt",".pptm",".pptx",".prf",".prm",".prx",".ps",".psc1",".psd",".psess",".psm",".psp",".pst",".pub",".pwz",".qht",".qhtm",".qt",".qti",".qtif",".qtl",".qxd",".ra",".ram",
            ".rar",".ras",".rat",".rc",".rc2",".rct",".rdlc",".reg",".resx",".rf",".rgb",".rgs",".rm",".rmi",".rmp",".roff",".rpm",".rqy",".rtf",".rtx",".rvt",".ruleset",".s",".safariextz",".scd",".scr",".sct",".sd2",".sdp",".sea",".searchConnector-ms",".setpay",".setreg",".settings",".sgimb",".sgml",".sh",".shar",".shtml",".sit",".sitemap",".skin",
            ".skp",".sldm",".sldx",".slk",".sln",".slupkg-ms",".smd",".smi",".smx",".smz",".snd",".snippet",".snp",".sol",".sor",".spc",".spl",".spx",".src",".srf",".SSISDeploymentManifest",".ssm",".sst",".stl",".sv4cpio",".sv4crc",".svc",".svg",".swf",".step",".stp",".t",".tar",".tcl",".testrunconfig",".testsettings",".tex",".texi",".texinfo",".tgz",
            ".thmx",".thn",".tif",".tiff",".tlh",".tli",".toc",".tr",".trm",".trx",".ts",".tsv",".ttf",".tts",".txt",".u32",".uls",".user",".ustar",".vb",".vbdproj",".vbk",".vbproj",".vbs",".vcf",".vcproj",".vcs",".vcxproj",".vddproj",".vdp",".vdproj",".vdx",".vml",".vscontent",".vsct",".vsd",".vsi",".vsix",".vsixlangpack",".vsixmanifest",".vsmdi",
            ".vspscc",".vss",".vsscc",".vssettings",".vssscc",".vst",".vstemplate",".vsto",".vsw",".vsx",".vtt",".vtx",".wasm",".wav",".wave",".wax",".wbk",".wbmp",".wcm",".wdb",".wdp",".webarchive",".webm",".webp",".webtest",".wiq",".wiz",".wks",".WLMP",".wlpginstall",".wlpginstall3",".wm",".wma",".wmd",".wmf",".wml",".wmlc",".wmls",".wmlsc",".wmp",
            ".wmv",".wmx",".wmz",".woff",".woff2",".wpl",".wps",".wri",".wrl",".wrz",".wsc",".wsdl",".wvx",".x",".xaf",".xaml",".xap",".xbap",".xbm",".xdr",".xht",".xhtml",".xla",".xlam",".xlc",".xld",".xlk",".xll",".xlm",".xls",".xlsb",".xlsm",".xlsx",".xlt",".xltm",".xltx",".xlw",".xml",".xmp",".xmta",".xof",".XOML",".xpm",".xps",".xrm-ms",".xsc",
            ".xsd",".xsf",".xsl",".xslt",".xsn",".xss",".xspf",".xtp",".xwd",".z",".zip",".xls",".ppt",".wks",".zip",".wav",".wsc",".lsf"
        };


    }

}
