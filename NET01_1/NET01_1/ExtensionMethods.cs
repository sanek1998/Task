using System;

namespace NET01_1
{
    public static class ExtensionMethods
    {
        public static void NewId(this Entity id)=>id.Id = Guid.NewGuid();
    }
}