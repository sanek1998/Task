using System;


namespace NET01_1
{
    class TraningOccup : Traning, IVersionable, ICloneable
    {
        private byte[] _version = new byte[8];
        private int _count = 0;
        private int _countVer = -1;
        private TypeTraning[] _tt = new TypeTraning[1];


        private TraningOccup()
        {
        }

        public TraningOccup(string decs) : base(decs)
        {
        }

        public void Add(object obj)
        {
            Array.Resize(ref _tt, _tt.Length + 1);
            _tt[_count] = new TypeTraning();
            _tt[_count].AddType(obj);
            _count++;
        }


        public Lessons TypeLessons()
        {
            for (int i = 0; i < _count; i++)
            {
                if (_tt[i].ObjectsType is Video)
                {
                    return Lessons.VideoLessons;
                }
            }

            return Lessons.TextLessons;
        }

        public byte ReadVersion()
        {
            if (_countVer < 0)
                _countVer++;
            return _version[_countVer];
        }

        public void WriteVersion(byte b)
        {
            if (_countVer < 8)
            {
                _countVer++;
            }

            _version[_countVer] = b;
        }

        public void Display()
        {
            for (int i = 0; i < _tt.Length - 1; i++)
            {
                Console.WriteLine(_tt[i].ObjectsType);
            }
        }

        public object Clone()
        {
            TypeTraning[] tempTT = new TypeTraning[_tt.Length];
            for (int i = 0; i < _tt.Length; i++)
            {
                tempTT[i] = _tt[i];
            }

            return new TraningOccup
            {
                DescriptText = this.DescriptText,
                _tt = tempTT,
                NumId = this.NumId,
                _countVer = this._countVer,
                _version = this._version,
                _count = this._count
            };
        }
    }
}
