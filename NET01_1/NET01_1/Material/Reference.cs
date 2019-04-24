using System;
using NET01_1.Enums;


namespace NET01_1.Material
{
    public class Reference : Materials
    {
        private string _content;
        public TypeRef TypeRef { get; set; }

        public string Content
        {
            get => _content;
            set { _content = value ?? throw new System.ArgumentNullException($" You didn't enter conten"); }
        }


        public Reference()
        {
        }

        public Reference(TypeRef refType) : base()
        {
            TypeRef = refType;
        }

        public Reference(string cntnt, TypeRef typeR, string desc = null) : base(desc)
        {
            Content = cntnt;
            TypeRef = typeR;
        }


        public new Reference Copy()
        {
            var reference = new Reference
            {
                Content = this.Content,
                TypeRef = this.TypeRef,
                NumId = this.NumId,
                Description = this.Description
            };
            return reference;
        }
    }
}
