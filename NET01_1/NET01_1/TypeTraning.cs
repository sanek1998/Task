using System;

namespace NET01_1
{
    class TypeTraning : Traning
    {
        public TypeTraning(string desc = null) : base(desc)
        {
        }

        public object ObjectsType { get; set; }

        public void AddType(object obj)
        {
            if (obj is Text)
                ObjectsType = (Text) obj;
            else if (obj is Reference)
                ObjectsType = (Reference) obj;
            else if (obj is Video)
                ObjectsType = (Video) obj;
        }

        public override string ToString()
        {
            return base.ToString() + ObjectsType;
        }
    }
}
