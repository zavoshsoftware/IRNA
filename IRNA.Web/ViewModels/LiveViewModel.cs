using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRNA.Web.ViewModels
{
    public class LiveViewModel
    {




        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class ChannelVM
        {
            public string logo { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public object genres { get; set; }
            public bool radio { get; set; }
            public bool timeShift { get; set; }
            public string decoderType { get; set; }
            public bool cctv { get; set; }
            public object current { get; set; }
            public object next { get; set; }
            public object previous { get; set; }
            public int number { get; set; }
            public int epgChannelId { get; set; }
            public bool hd { get; set; }
        }

        public class ChannelRootVM
        {
            public int code { get; set; }
            public string status { get; set; }
            public List<ChannelVM> data { get; set; }
            public string message { get; set; }
        }




        public class StreamList
        {
            public string id { get; set; }
            public string type { get; set; }
            public string rootType { get; set; }
            public string link { get; set; }
            public object source { get; set; }
            public bool hw { get; set; }
            public object server { get; set; }
            public int card { get; set; }
            public int serviceId { get; set; }
            public object audios { get; set; }
            public int row { get; set; }
            public int column { get; set; }
            public bool defaultStream { get; set; }
        }

        public class StreamListMore
        {
            public List<StreamList> list { get; set; }
        }

        public class StreamRoot
        {
            public int code { get; set; }
            public string message { get; set; }
            public string type { get; set; }
            public StreamListMore more { get; set; }
        }









    }
}