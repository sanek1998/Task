using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace NET02._2
{
    public class JsonWriter
    {
        public void Write(Config config)
        {
            var users = new List<User>(config.GetUsers());

            foreach (var user in users)
            {
                foreach (var window in user.GetWindows())
                {
                    window.Fix();
                }
                JsonSerializer.Create(new JsonSerializerSettings());
                var output = JsonConvert.SerializeObject(user, Formatting.Indented);
                Directory.CreateDirectory(@".\Config\");
                var writeJson = new StreamWriter(new FileStream(@".\Config\" + user.Name + ".json",
                    FileMode.Create, FileAccess.Write));
                writeJson.Write(output);
                writeJson.Close();
            }
        }
    }
}