using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class Handler
    {
        private static string usersPath = "../../Resources/users.json";
        private static string messagesPath = "../../Resources/messages.json";

        // Статусы ответов.
        enum StatusCodes
        {
            ok = 200,
            created = 201,
            badRequest = 400,
            unauthorized = 401,
            notFound = 404,
            badUserName = 422,
            alreadyExist = 423
        }

        // Функция увеличивает количество просмотров сообщения выбранного по Id на 1.
        public static int PostMsgView(ref string responseBody, string[] userToken, string messageId)
        {
            // Если запрос пришел с неаутентифицированного клиента.
            if (!FindUserById(userToken[0]))
            {
                responseBody = "Неавторизированный доступ";
                return (int)StatusCodes.unauthorized;
            }

            // Считываем все сообщения.
            var jArray = ReadFromJsonFile(messagesPath);

            // Проверяем есть ли сообщение с таким Id.
            if (!FindMessageById(messageId))
            {
                responseBody = "Сообщение с таким ID не найдено";
                return (int)StatusCodes.notFound;
            }

            if (jArray == null)
            {
                jArray = new JArray();
            }

            // Увеличиваем количество просмотров.
            JObject jo = (JObject)jArray[Convert.ToInt32(messageId)];
            string view = jo.Value<string>("view");
            jo.Remove("view");
            int temp = (Convert.ToInt32(view));
            temp++;
            jo.Add("view", temp);

            jo = new JObject();

            // Очищаем файл в который произведем запись.
            using (var fs = new FileStream(messagesPath, FileMode.Truncate))
            {
                fs.Close();
            }

            //Запись измененных данных в файл.
            WriteToJsonFile(messagesPath, jArray);

            // Заполняем тело ответа.
            jo.Add("count", temp);
            responseBody = jo.ToString();

            return (int)StatusCodes.created;
        }

        // Функция получения сообщения определенного по Id.
        public static int GetMsgById(ref string responseBody, string[] userToken, string messageId)
        {
            // Если запрос пришел с неаутентифицированного клиента.
            if (!FindUserById(userToken[0]))
            {
                responseBody = "Неавторизированный доступ";
                return (int)StatusCodes.unauthorized;
            }

            // Считываем все сообщения.
            var jArray = ReadFromJsonFile(messagesPath);

            // Проверяем есть ли сообщение с таким Id.
            if(!FindMessageById(messageId))
            {
                responseBody = "Сообщение с таким ID не найдено";
                return (int)StatusCodes.notFound;
            }

            if (jArray == null)
            {
                jArray = new JArray();
            }

            // Записываем в тело ответа нужное сообщение.
            responseBody = jArray[Convert.ToInt32(messageId)].ToString();

            return (int)StatusCodes.ok;
        }

        // Функция получения всех сообщений.
        public static int GetMsg(ref string responseBody, ref string statusDescrition, string[] userToken)
        {
            // Если запрос пришел с неаутентифицированного клиента.
            if (!FindUserById(userToken[0]))
            {
                responseBody = "Неавторизированный доступ";
                return (int)StatusCodes.unauthorized;
            }

            // Считываем все сообщения.
            var jArray = ReadFromJsonFile(messagesPath);

            if (jArray == null)
            {
                jArray = new JArray();
            }

            // Записываем в тело ответа все сообщения.
            responseBody = jArray.ToString();

            return (int)StatusCodes.ok;
        }

        // Функция записи сообщения в базу данных сообщений в виде json файла.
        public static int PostMsg(JObject reqBodyDeserialized, ref string responseBody, ref string statusDescrition, string[] userToken)
        {
            if (reqBodyDeserialized == null)
            {
                responseBody = "Проблема аутентификации";
                return (int)StatusCodes.badRequest;
            }

            // Если в пришедшем запросе не введен какой то параметр.
            if (reqBodyDeserialized.GetValue("author").ToString().Equals("") ||
                reqBodyDeserialized.GetValue("message").ToString().Equals(""))
            {
                responseBody = "Проблема аутентификации";
                return (int)StatusCodes.badRequest;
            }

            // Если размер имени автора больше 30 символов.
            if (reqBodyDeserialized.GetValue("author").ToString().Length>30)
            {
                responseBody = "Ошибка валидации";
                return (int)StatusCodes.badUserName;
            }

            // Если запрос пришел с неаутентифицированного клиента.
            if (!FindUserById(userToken[0]))
            {
                responseBody = "Неавторизированный доступ";
                return (int)StatusCodes.unauthorized;
            }

            // Считываем все сообщения.
            var jArray = ReadFromJsonFile(messagesPath);

            if (jArray == null)
            {
                jArray = new JArray();
            }

            // Добавляем новое сообщение в базу.
            reqBodyDeserialized.Add("id", jArray.Count.ToString());
            reqBodyDeserialized.Add("view", 0);
            jArray.Add(reqBodyDeserialized);

            // Сохраняем дополненный список.
            WriteToJsonFile(messagesPath, jArray);

            statusDescrition = "Message created";
            responseBody = reqBodyDeserialized.ToString();

            return (int)StatusCodes.created;
        }

        // Функция авторизации (получения токена пользователя).
        public static int LoginUser(JObject reqBodyDeserialized, ref string responseBody, ref string statusDescrition)
        {
            if (reqBodyDeserialized == null)
            {
                responseBody = "Проблема аутентификации";
                return (int)StatusCodes.badRequest;
            }

            // Если в пришедшем запросе не введен какой то параметр.
            if (reqBodyDeserialized.GetValue("email").ToString().Equals("") ||
                reqBodyDeserialized.GetValue("password").ToString().Equals(""))
            {
                responseBody = "Проблема аутентификации";
                return (int)StatusCodes.badRequest;
            }

            // Считываем зарегестрированных пользователей.
            var jArray = ReadFromJsonFile(usersPath);

            if (jArray == null)
            {
                jArray = new JArray();
            }

            int userIndex = 0;

            // Смотрим, не зарегестрирован ли уже такой пользователь.
            if (!FindUser(reqBodyDeserialized, jArray, ref userIndex))
            {
                responseBody = "Проблема аутентификации";

                return (int)StatusCodes.badRequest;
            }

            statusDescrition = "Authentication successfully";
            JObject jo = new JObject();
            jo.Add("token", userIndex.ToString());
            responseBody = jo.ToString();

            return (int)StatusCodes.ok;
        }

        // Функция регистрации пользователя.
        public static int ReqUser(JObject reqBodyDeserialized, ref string responseBody)
        {
            JToken jtoken;

            // Если в пришедшем запросе ничего нет.
            if (reqBodyDeserialized == null)
            {
                responseBody = "Неправильные входные данные";
                return (int)StatusCodes.badRequest;
            }

            // Если в пришедшем запросе не введен какой то параметр.
            if (reqBodyDeserialized.GetValue("email").ToString().Equals("") ||
                reqBodyDeserialized.GetValue("password").ToString().Equals("") ||
                reqBodyDeserialized.GetValue("firstName").ToString().Equals("") ||
                reqBodyDeserialized.GetValue("lastName").ToString().Equals(""))
            {
                responseBody = "Неправильные входные данные";
                return (int)StatusCodes.badRequest;
            }

            reqBodyDeserialized.TryGetValue("firstName", out jtoken);

            // Если размер имени больше 30 символов.
            if (jtoken.Value<string>().Length > 30)
            {
                responseBody = "Имя не должно превышать 30 символов!";
                return (int)StatusCodes.badUserName;
            }

            // Считываем зарегестрированных пользователей.
            var jArray = ReadFromJsonFile(usersPath);

            if (jArray == null)
            {
                jArray = new JArray();
            }

            // Смотрим, не зарегестрирован ли уже такой пользователь.
            if (FindUser(reqBodyDeserialized, jArray))
            {
                responseBody = "Пользователь уже существует!";

                return (int)StatusCodes.alreadyExist;
            }
            else
            {
                // Добавляем токен пользователю.
                reqBodyDeserialized.Add("Token", jArray.Count.ToString());
                jArray.Add(reqBodyDeserialized);
            }

            // Добавляем пользователя в импровизированную базу данных в виде json файла.
            WriteToJsonFile(usersPath, jArray);

            responseBody = "Успешная регистрация";
            return (int)StatusCodes.ok;
        }

        // Функция для чтения из json файла.
        private static JArray ReadFromJsonFile(string path)
        {
            string text = string.Empty;

            using (var reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
                reader.Close();
            }

            return JsonConvert.DeserializeObject<JArray>(text);
        }

        // Функция для записи в json файл.
        private static bool WriteToJsonFile(string path, JArray jArray)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, jArray);
            }

            return true;
        }

        // Поиск пользователя по файлу зарегестрированных пользователей для проверки его существования.
        private static bool FindUser(JObject jo, JArray ja)
        {
            foreach(JObject item in ja) 
            {
                if ((item.GetValue("email").ToString() == jo.GetValue("email").ToString()) &&
                    (item.GetValue("password").ToString() == jo.GetValue("password").ToString()) &&
                    (item.GetValue("firstName").ToString() == jo.GetValue("firstName").ToString()) &&
                    (item.GetValue("lastName").ToString() == jo.GetValue("lastName").ToString()))
                    return true;
            }

            return false;
        }

        // Поиск пользователя по файлу зарегестрированных пользователей для получения его токена.
        private static bool FindUser(JObject jo, JArray ja, ref int userIndex)
        {
            foreach (JObject item in ja)
            {
                if ((item.GetValue("email").ToString() == jo.GetValue("email").ToString()) &&
                    (item.GetValue("password").ToString() == jo.GetValue("password").ToString()))
                    return true;

                userIndex++;
            }

            return false;
        }

        // Поиск пользователя по файлу зарегестрированных пользователей для получения его токена.
        private static bool FindUserById(string userIndex)
        {
            JArray ja = ReadFromJsonFile(usersPath);

            if (ja == null) 
                return false;

            foreach (JObject item in ja)
            {
                if (item.GetValue("Token").ToString() == userIndex)
                    return true;
            }

            return false;
        }

        // Поиск сообщения по файлу со всеми сообщениями.
        private static bool FindMessageById(string messageIndex)
        {
            JArray ja = ReadFromJsonFile(messagesPath);

            if (ja == null) 
                return false;

            foreach (JObject item in ja)
            {
                if (item.GetValue("id").ToString() == messageIndex)
                    return true;
            }

            return false;
        }
    }
}
