using System;
using NET01_1.Enums;
using NET01_1.Interface;

namespace NET01_1.Material
{
    public class Video : Materials, IVersionable 
    {
        private byte[] _version = new byte[8];
        private string _video = "educational videos";
        public TypeVideo TypeVideo1 { get; }

        public string Pictures { get; set; }


        public string VideoContent
        {
            get => _video;
            set => _video = value ?? throw new ArgumentNullException($"You didn't enter content");
        }

        public Video()
        {
        }

        public Video(TypeVideo type, string vd, string pctrs=null , string desc=null ) : base(desc)
        {
            TypeVideo1 = type;
            VideoContent = vd;
            Pictures = pctrs;
        }

        public byte[] GetVersion()
        {
            return _version;
        }

        public void SetVersion(byte[] b)
        {
            for (var i = 0; i < _version.Length; i++) _version[i] = b[i];
        }

        public new Materials Copy()
        {
            var video = new Video
            {
                _version = _version,
                Pictures = Pictures,
                VideoContent = VideoContent,
                NumId = NumId,
                Description = Description
            };
            return video;
        }
    }
}