using System;
using NET01_1.Enums;


namespace NET01_1.Materials
{
    public class Reference : Material
    {
        private string _content;
        public ReferenceType TypeRef { get; set; }

        public string Content
        {
            get => _content;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(" You didn't enter conten");
                }
                _content = value;
            }
        }

        public Reference(ReferenceType refType) : base()
        {
            TypeRef = refType;
        }

        public Reference(string content, ReferenceType refType, string description = null) : base(description)
        {
            Content = content;
            TypeRef = refType;
        }

        public override Material Copy()
        {
            var reference = new Reference(Content,TypeRef,Description){Id = this.Id};
            return reference;
        }
    }
}
