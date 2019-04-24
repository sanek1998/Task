using System;

namespace NET01_1.Material
{
    public class Text : Materials 
    {
        private string _textArr;

        public Text()
        {
        }

        public Text(string txt, string desc ) : base(desc)
        {
            if (txt.Length > 10000)
                throw new ArgumentOutOfRangeException(nameof(txt), "Length greater than 10,000 characters");

            _textArr = txt;
        }

        public new Text Copy()
        {
            var text = new Text
            {
                _textArr = _textArr,
                NumId = NumId,
                Description = Description
            };
            return text;
        }
    }
}
