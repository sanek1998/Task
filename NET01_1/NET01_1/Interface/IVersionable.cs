namespace NET01_1.Interface
{
    public interface IVersionable
    {
        byte[] GetVersion();
        void SetVersion(byte[] b);
    }
}