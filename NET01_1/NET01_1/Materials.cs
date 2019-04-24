namespace NET01_1
{
    public class Materials : Entity
    {
        public Materials(string desc = null) : base(desc)
        {
        }

        public Materials Copy()
        {
            var mat = new Materials
            {
                NumId = NumId,
                Description = Description
            };
            return mat;
        }
    }
}