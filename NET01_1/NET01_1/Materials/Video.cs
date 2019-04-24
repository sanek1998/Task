using System;
using NET01_1.Enums;
using NET01_1.Interface;

namespace NET01_1.Materials
{
    public class Video : Material, IVersionable
    {
        private const int ByteLength = 8;
        private byte[] _version = new byte[ByteLength];
        private string _video;
        public VideoType TypeVideo { get; }
        public string Pictures { get; set; }

        public string VideoContent
        {
            get => _video;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value),"You didn't enter content");
                }
                _video = value;
            }
        }

        public Video(VideoType type, string videoContent, string pictures = null, string description = null) : base(
            description)
        {
            TypeVideo = type;
            VideoContent = videoContent;
            Pictures = pictures;
        }

        public byte[] GetVersion()
        {
            return _version;
        }

        public void SetVersion(byte[] b)
        {
            if (b == null || b.Length < ByteLength)
            {
                throw new ArgumentException($"The array in not correctly transferred");
            }

            for (var i = 0; i < _version.Length; i++)
            {
                _version[i] = b[i];
            }
        }

        public override Material Copy()
        {
            var copyVersion = new byte[_version.Length];

            for (var i = 0; i < _version.Length; i++)
            {
                copyVersion[i] = _version[i];
            }
            var video = new Video(TypeVideo, VideoContent, Pictures,Description)
            {
                _version = copyVersion,
                Id = Id,
            };
            return video;
        }
    }
}