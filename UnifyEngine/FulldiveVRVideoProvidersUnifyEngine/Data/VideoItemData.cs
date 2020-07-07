using System;

namespace FulldiveVRVideoProvidersUnifyEngine.Data
{
    public class VideoItemData
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return $"{this.Link} | {this.Image} | {this.Title}";
        }
    }
}