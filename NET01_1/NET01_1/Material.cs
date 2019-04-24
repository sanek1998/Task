namespace NET01_1
{
    public abstract class Material : Entity
    {
        public Material(string desc = null) : base(desc)
        {
        }

        public abstract Material Copy();
    }
}