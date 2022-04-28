using System.Runtime.Serialization.Json;
using System.Text;

namespace Server.Application.Utilities;

public static class FormatUtil
{
    public static T? Deserialize<T>(string body)
    {
        using var stream = new MemoryStream();
        using var writer = new StreamWriter(stream);
        writer.Write(body);
        writer.Flush();
        stream.Position = 0;
        var response = new DataContractJsonSerializer(typeof(T)).ReadObject(stream);
        return response == null ? default : (T)response;
    }

    public static string Serialize<T>(T item)
    {
        using var ms = new MemoryStream();
        new DataContractJsonSerializer(typeof(T)).WriteObject(ms, item);
        return Encoding.Default.GetString(ms.ToArray());
    }
}