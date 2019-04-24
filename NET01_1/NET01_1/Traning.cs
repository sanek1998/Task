using System;

namespace NET01_1
{
    public abstract class Traning
    {
        private string _desc = null;
        private Guid _id;

        public Guid NumId
        {
            get => _id;
            set => _id = value;
        }

        public string DescriptText
        {
            get => _desc;
            set
            {
                try
                {
                    if (value != null && value.Length > 256)
                    {
                        throw new ArgumentException(
                            "ERROR!!!\nThe index of an array or collection is out of range\n\n ");
                    }

                    _desc = value;
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Traning()
        {
            NumId = ExtensionMethods.NewIdem(this);
        }

        public Traning(string desc = null) : this()
        {
            DescriptText = desc;
        }

        public override string ToString()
        {
            return $"Description: {DescriptText}\nID:{_id}";
        }


        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case TraningOccup _:
                {
                    TraningOccup t = (TraningOccup) obj;
                    if (NumId == t.NumId)
                    {
                        return true;
                    }

                    break;
                }

                case Text _:
                {
                    Text t = (Text) obj;
                    if (NumId == t.NumId)
                    {
                        return true;
                    }

                    break;
                }

                case Reference _:
                {
                    Reference r = (Reference) obj;
                    if (NumId == r.NumId)
                    {
                        return true;
                    }

                    break;
                }
                case Video _:
                {
                    Video v = (Video) obj;
                    if (NumId == v.NumId)
                    {
                        return true;
                    }

                    break;
                }
                case TypeTraning _:
                {
                    TypeTraning tt = (TypeTraning) obj;
                    if (NumId == tt.NumId)
                    {
                        return true;
                    }

                    break;
                }
            }

            return false;
        }
    }
}
