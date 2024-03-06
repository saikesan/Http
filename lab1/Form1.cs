using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class ClientForm : Form
    {
        private static string IPAddress = "82.209.104.81";

        private HttpClient httpClient;

        public static string userToken = "no";

        public ClientForm()
        {
            InitializeComponent();
            
            ChangeIp();

            httpClient = new HttpClient();
        }
        
        // Отправка Get запроса
        private async Task<string> SendGetRequest(string url)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(userToken);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            
            HttpResponseMessage response = await httpClient.GetAsync(url);

            MessageBox.Show("Status code : " + response.StatusCode.ToString() +
                "\n" + response.Content.ReadAsStringAsync().Result, "Response");

            //response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        // Отправка Post запроса
        private async Task<string> SendPostRequest(string url, string data)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(userToken);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            StringContent httpContent = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);

            MessageBox.Show("Status code : " + response.StatusCode.ToString() +
                "\n" + response.Content.ReadAsStringAsync().Result, "Response");

            return await response.Content.ReadAsStringAsync();
        }

        private async void OnButtonGetMsgClick(object sender, EventArgs e)
        {
            try
            {
                string result = await SendGetRequest("http://" + IPAddress + "/api/messages");
            }
            catch (Exception ex)
            {
            }
        }

        private async void OnButtonGetMsgByIdClick(object sender, EventArgs e)
        {
            try
            {
                string messageId = textBoxMsgId.Text;

                string url = "http://" + IPAddress + $"/api/messages/{messageId}";

                string result = await SendGetRequest(url);
            }
            catch (Exception ex)
            {

            }
        }

        private async void OnButtonPostMsgClick(object sender, EventArgs e)
        {
            try
            {
                string author = textBoxAuthor.Text;
                string message = textBoxMsg.Text;

                JObject jo = new JObject();
                jo.Add("author", author);
                jo.Add("message", message);

                string httpBody = jo.ToString();

                string result = await SendPostRequest("http://" + IPAddress + "/api/messages", httpBody);
            }
            catch (Exception ex)
            {

            }
        }

        private async void OnButtonPostMsgViewClick(object sender, EventArgs e)
        {
            try
            {
                string messageId = textBoxMsgId.Text;

                string url = "http://" + IPAddress + $"/api/messages/{messageId}/view";

                string result = await SendPostRequest(url, "");
            }
            catch (Exception ex)
            {
            }
        }

        private async void OnButtonRegUserClick(object sender, EventArgs e)
        {
            try
            {
                string email = textBoxEmail.Text;
                string password = textBoxPwd.Text;
                string firstName = textBoxFName.Text;
                string lastName = textBoxLName.Text;

                string url = "http://" + IPAddress + "/api/auth/register";

                JObject jo = new JObject();
                jo.Add("email", email);
                jo.Add("password", password);
                jo.Add("firstName", firstName);
                jo.Add("lastName", lastName);

                //string httpBody = HttpBodyTamplates.GetPostAuthRegisterBody(email, password, firstName, lastName);
                string httpBody = jo.ToString();

                string result = await SendPostRequest(url, httpBody);
            }
            catch (Exception ex)
            {
            }
        }

        private async void OnButtonLoginClick(object sender, EventArgs e)
        {
            try
            {
                // Получение значений с текстовых полей
                string email = textBoxEmail.Text;
                string password = textBoxPwd.Text;

                // Ссылка на сайт
                string url = "http://" + IPAddress + "/api/auth/login";

                JObject jo = new JObject();
                jo.Add("email", email);
                jo.Add("password", password);

                string httpBody = jo.ToString();

                // Отправка запроса и получение ответа
                string result = await SendPostRequest(url, httpBody);

                jo = JObject.Parse(result);

                userToken = jo.GetValue("token").ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void OnButtonChangeIpClick(object sender, EventArgs e)
        {
            ChangeIp();
        }

        private void ChangeIp()
        {
            if (IPAddress.Equals("localhost:8000"))
            {
                IPAddress = "82.209.104.81";
            }
            else
            {
                IPAddress = "localhost:8000";
            }

            tbIpAddress.Text = IPAddress;
        }
    }
}