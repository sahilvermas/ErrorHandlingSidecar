
using System.Text;

const string port = "4001";
const string errorCode = "1002";

using var client = new HttpClient();
client.BaseAddress = new Uri($"https://localhost:{port}/api/");


var content = Newtonsoft.Json.JsonConvert.SerializeObject(new { ErrorCode = errorCode });
var data = new StringContent(content, Encoding.UTF8, "application/json");

var response = await client.PostAsync("ErrorHandler", data);

if (!response.IsSuccessStatusCode)
    Console.WriteLine($"Error occurred with code {response.StatusCode}");

var result = await response.Content.ReadAsStringAsync();
Console.WriteLine("######################################");
Console.WriteLine(result);
Console.WriteLine("######################################");

