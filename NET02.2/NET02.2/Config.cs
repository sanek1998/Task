using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NET02._2
{
    public class Config : IEnumerable<User>
    {
        private readonly List<User> _users;

        public Config()
        {
            _users = new List<User>();
        }

        public IEnumerable<string> GetInvalidLogins()
        {
            foreach (var user in _users)
            {
                if (user.GetInvalidLogins() != null)
                {
                    yield return user.GetInvalidLogins();
                }
            }
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public IEnumerator<User> GetEnumerator()
        {
            return _users.GetEnumerator();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var user in _users)
            {
                result.AppendLine(user.ToString());
            }

            return result.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}