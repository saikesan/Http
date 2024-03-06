using System.IO;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server
{
    public class Program
    {
        private static string urlBase = "http://127.0.0.1:8000";

        private static string messagePath = "/api/messages";
        private static string authPath = "/api/auth";

        static void Main(string[] args)
        {
            Server();
        }

        private static void Server()
        {
            HttpListener server = new HttpListener();

            // Указываем запросы на какие адреса будет прослушавать сервер.
            server.Prefixes.Add(urlBase + messagePath +"/");
            server.Prefixes.Add(urlBase + authPath+"/");

            server.Start(); // старт сервера.

            // Цикл обработки сообщений.
            while (true) 
            {
                var context = server.GetContext(); // Функция блокирует выполнение программы до тех пор пока не получит какой то запрос, после получения обработает его.

                var request = context.Request; // получаем данные запроса.

                var requestBody = new StreamReader(request.InputStream).ReadToEnd();
                
                var response = context.Response;
                
                JObject reqBodyDeserialized = new JObject();

                if (!requestBody.Equals(""))
                    reqBodyDeserialized = JObject.Parse(requestBody);

                string responseBody = string.Empty;

                if (request.Url.AbsolutePath.Contains(messagePath))
                {
                    if (request.Url.AbsolutePath.Equals(messagePath))
                    {
                        if(request.HttpMethod.Equals("GET")) // Обработка GetMsg запроса
                        {
                            string statusDescription = string.Empty;
                            int statusCode = Handler.GetMsg(ref responseBody, ref statusDescription, request.Headers.GetValues(1));

                            response.StatusDescription = statusDescription;
                            response.StatusCode = statusCode;
                        }
                        else if (request.HttpMethod.Equals("POST")) // Обработка PostMsg запроса
                        {
                            string statusDescription = string.Empty;
                            int statusCode = Handler.PostMsg(reqBodyDeserialized, ref responseBody, ref statusDescription, request.Headers.GetValues(3));

                            response.StatusDescription = statusDescription;
                            response.StatusCode = statusCode;
                        }
                    }
                    else
                    {
                        if(request.Url.Segments.Length.Equals(4)) // Обработка GetMsgById запроса
                        {
                            int statusCode = Handler.GetMsgById(ref responseBody, request.Headers.GetValues(1), request.Url.Segments.GetValue(3).ToString());

                            response.StatusCode = statusCode;
                        }
                        else if (request.Url.Segments.Length.Equals(5)) // Обработка PostMsgView запроса
                        {
                            int statusCode = Handler.PostMsgView(ref responseBody, request.Headers.GetValues(3), request.Url.Segments.GetValue(3).ToString().Substring(0, request.Url.Segments.GetValue(3).ToString().Length-1));

                            response.StatusCode = statusCode;
                        }
                    }
                }
                else if (request.Url.AbsolutePath.Contains(authPath))
                {
                    if (request.Url.AbsolutePath.Equals(authPath+"/login")) // Обработка аутентификации.
                    {
                        string statusDescription = string.Empty;

                        int statusCode = Handler.LoginUser(reqBodyDeserialized, ref responseBody, ref statusDescription);

                        response.StatusDescription = statusDescription;
                        response.StatusCode = statusCode;
                    }
                    else if (request.Url.AbsolutePath.Equals(authPath + "/register")) // Обработка регистрации.
                    {
                        int statusCode = Handler.ReqUser(reqBodyDeserialized, ref responseBody);

                        response.StatusCode = statusCode;
                    }
                }

                byte[] buffer = Encoding.UTF8.GetBytes(responseBody);
                // получаем поток ответа и пишем в него ответ
                response.ContentLength64 = buffer.Length;
                using Stream output = response.OutputStream;
                
                // отправляем данные
                output.WriteAsync(buffer, 0, buffer.Length);
                output.FlushAsync();
            }


            server.Stop(); // остановка сервера.
            server.Close(); // полное закрытие сервера.
        }
    }
}
