using System;

namespace NET01_1.Materials
{
    public class Text : Material
    {
        private const int Length = 10000;
        private string _textArr;

        public string Texts
        {
            get => _textArr;
            set
            {
                if (value.Length > Length || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Length greater than 10,000 characters or is null");
                }
                
                _textArr = value;
            }
        }

        public Text(string txt, string description = null) : base(description)
        {
            Texts = txt;
        }
        
        public override Material Copy()
        {
            var text = new Text(Texts,Description)
            {
                Id = Id,
            };
            return text;
        }
    }
}