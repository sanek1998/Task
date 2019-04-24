using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NET02._2
{
    public class User : IEnumerable<Window>
    {
        public string Name { get; set; }
        private readonly List<Window> _window;

        public User(string name)
        {
            Name = name;
            _window = new List<Window>();
        }

        public void Add(Window windows)
        {
            _window.Add(windows);
        }

        public List<Window> GetWindows()
        {
            return _window;
        }

        public string GetInvalidLogins()
        {
            var flag = false;
            var haveMain = false;

            foreach (var window in _window)
            {
                if (window.Title == "main")
                {
                    haveMain = true;
                    if (window.Top == null || window.Left == null
                        || window.Width == null || window.Height == null)
                    {
                        flag = true;
                    }
                }
            }
            return flag || haveMain == false ? Name : null;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Login: {Name}");
            foreach (var window in _window)
            {
                result.AppendLine(window.ToString());
            }

            return result.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Window> GetEnumerator()
        {
            return _window.GetEnumerator();
        }
    }
}