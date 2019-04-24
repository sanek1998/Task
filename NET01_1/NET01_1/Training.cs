using System;
using NET01_1.Enums;
using NET01_1.Interface;
using NET01_1.Materials;

namespace NET01_1
{
    public class Training : Entity, IVersionable, ICloneable
    {
        private const int ByteLength = 8;
        private Material[] _materials = new Material[0];
        private byte[] _version = new byte[ByteLength];

        public Training(string description = null) : base(description)
        {
        }

        public byte[] GetVersion()
        {
            return _version;
        }

        public void SetVersion(byte[] b)
        {
            for (var i = 0; i < _version.Length; i++)
            {
                _version[i] = b[i];
            }
        }

        public void Add(Material obj)
        {
            Array.Resize(ref _materials, _materials.Length + 1);
            _materials[_materials.Length - 1] = obj;
            
        }

        public Lesson TypeLessons()
        {
            foreach (var t in _materials)
            {
                if (t is Video)
                {
                    return Lesson.VideoLesson;
                }

            }

            return Lesson.TextLesson;
        }

        public object Clone()
        {
            var materials = new Material[_materials.Length];

            for (var i = 0; i < _materials.Length; i++)
            {
                materials[i] = _materials[i].Copy();
            }

            var copyVersion = new byte[_version.Length];

            for (var i = 0; i < _version.Length; i++)
            {
                copyVersion[i] = _version[i];
            }

            var clone = new Training {_materials = materials, Description = Description, Id = Id, _version=copyVersion};
            return clone;
        }
    }
}