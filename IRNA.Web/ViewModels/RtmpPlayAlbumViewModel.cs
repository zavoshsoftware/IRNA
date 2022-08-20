using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRNA.Web.ViewModels
{
    public class RtmpPlayAlbumViewModel
    {
    }

    public class RtmpPlayAlbumAnswer
    {
        public bool success { get; set; }
        public string playUrl { get; set; }
        public string streamerAddress { get; set; }
        public string filename { get; set; }
        public List<string> supportedProtocols { get; set; }
        public string rtmpUrl { get; set; }
        public string rtspUrl { get; set; }
        public string hlsUrl { get; set; }
        public object adaptiveHlsUrl { get; set; }
    }

    public class RtmpPlayAlbumContentData
    {
        public string contentName { get; set; }
        public int duration { get; set; }
    }

    public class RtmpPlayAlbumList
    {
        public bool status { get; set; }
        public int code { get; set; }
        public string arg1 { get; set; }
        public string arg2 { get; set; }
        public RtmpPlayAlbumAnswer answer { get; set; }
        public RtmpPlayAlbumContentData contentData { get; set; }
    }

    public class RtmpPlayAlbumRoot
    {
        public List<RtmpPlayAlbumList> list { get; set; }
    }

}