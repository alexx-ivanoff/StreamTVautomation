using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace Wrappers
{
    public static class API
    {
        public static int CreateWrestler(WrestlerEntity wrestler)
        {
            Authorize();
            var url = String.Format("{0}php/wrestler/create.php", Context.Settings.HostLink);

            var serizalizer = new DataContractJsonSerializer(typeof (WrestlerEntity));
            var stream = new MemoryStream();
            serizalizer.WriteObject(stream, wrestler);
            stream.Position = 0;
            var streamReader = new StreamReader(stream);

            var response = PostReturnString(url, streamReader.ReadToEnd());
            var regex = new Regex("\"id\":([0-9]*)");
            return int.Parse(regex.Match(response).Groups[1].Value);
        }

        public static void UpdateWrestler(WrestlerEntity wrestler)
        {
            Authorize();
            var url = String.Format("{0}php/wrestler/update.php", Context.Settings.HostLink);

            var serizalizer = new DataContractJsonSerializer(typeof (WrestlerEntity));
            var stream = new MemoryStream();
            serizalizer.WriteObject(stream, wrestler);
            stream.Position = 0;
            var streamReader = new StreamReader(stream);

            var response = PostReturnString(url, streamReader.ReadToEnd());
        }

        public static List<WrestlerEntity> SearchWrestlers(string searchCriteria)
        {
            Authorize();

            var url = String.Format("{0}php/wrestler/search.php?search={1}", Context.Settings.HostLink, searchCriteria);

            var response = PostReturnString(url, "");
            var regex = new Regex(@"\[.*\]");
            response = regex.Match(response).Value;
            var byteArray = Encoding.UTF8.GetBytes(response);
            var stream = new MemoryStream(byteArray);
            var serizalizer = new DataContractJsonSerializer(typeof (List<WrestlerEntity>));
            var wrestlers = (List<WrestlerEntity>) serizalizer.ReadObject(stream);

            return wrestlers;
        }

        public static WrestlerEntity ReadWrestler(int id)
        {
            Authorize();

            var url = String.Format("{0}php/wrestler/read.php?id={1}", Context.Settings.HostLink, id);

            var response = Post(url, "");
            var serializer = new DataContractJsonSerializer(typeof (WrestlerEntity));

            WrestlerEntity wrestler = null;
            try
            {
                wrestler = (WrestlerEntity) serializer.ReadObject(response);
            }
            catch (Exception)
            {
            }

            return wrestler;
        }

        public static void DeleteWrestler(int id)
        {
            Authorize();

            var url = String.Format("{0}php/wrestler/delete.php?id={1}", Context.Settings.HostLink, id);

            Post(url, "");
        }

        public static void DeleteWrestler(string id)
        {
            DeleteWrestler(int.Parse(id));
        }

        private static void Authorize()
        {
            var url = String.Format("{0}php/login.php", Context.Settings.HostLink);
            var username = Context.Settings.UserName;
            var password = Context.Settings.UserPassword;

            var builder = new StringBuilder();
            builder.Append("{");
            builder.AppendFormat("\"{0}\":\"{1}\",", "username", username);
            builder.AppendFormat("\"{0}\":\"{1}\"", "password", password);
            builder.Append("}");

            Post(url, builder.ToString());
        }

        private static string PostReturnString(string url, string postData)
        {
            var stream = Post(url, postData);
            var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }

        private static Stream Post(string url, string postData)
        {
            var cookieContainer = new CookieContainer();
            var cookie = new Cookie("PHPSESSID", "12345");
            cookie.Domain = Context.Settings.Domain;
            cookieContainer.Add(cookie);

            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "POST";
            request.CookieContainer = cookieContainer;
            var byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;
            var dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            var response = request.GetResponse();
            dataStream = response.GetResponseStream();

            return dataStream;
        }
    }
}