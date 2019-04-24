using System;

namespace NET02._1
{
    public class Author
    {
        private string _firstName;
        private string _lastName;
        private const int SizeLength = 200;

        public string FirstName
        {
            get => _firstName;
            set
            {
                Check(value);
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                Check(value);
                _lastName = value;
            }
        }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " ";
        }

        public override bool Equals(object obj)
        {
            return obj is Author temp && string.Equals(FirstName, temp.FirstName,
                                          StringComparison.CurrentCultureIgnoreCase)
                                      && string.Equals(LastName, temp.LastName,
                                          StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).ToLower().GetHashCode();
        }

        private void Check(string str)
        {
            if(str == null || str.Length >= SizeLength)
            {
                throw new ArgumentException("The length than 200 characters or null");
            }
        }
    }
}