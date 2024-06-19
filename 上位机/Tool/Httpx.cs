using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CqustRfidSystem.Tool
{
    internal class Httpx
    {
        public static Dictionary<string, object> Post(string url, Dictionary<string, object> postData)
        {
            using (var httpClient = new HttpClient())
            {
             
                try
                {
                    // 将字典转换为JSON字符串
                    string jsonString = JsonConvert.SerializeObject(postData);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    httpClient.DefaultRequestHeaders.Add("X-University", "CQUST");


                    // 发送POST请求并获取响应
                    HttpResponseMessage response = httpClient.PostAsync(url, content).Result;

                    // 确认响应成功
                    response.EnsureSuccessStatusCode();

                    // 读取响应内容
                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    // 将响应内容反序列化为字典并返回
                    var responseData = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);
                    return responseData;
                }
                catch (Exception ex)
                {
      
     
                    return null;
                }
            }
        }
    }
}
