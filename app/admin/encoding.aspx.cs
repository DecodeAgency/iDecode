using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.IO;

public partial class app_admin_encoding : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sConsumerKey = "qZiQkW4Ul6FkV6APm1m2mIOze";
        string sConsumerSecretKey = "FfmwwIRFgNpY6Kycyb313M4VeEk9R4CLtrqIGIBw1BxENou6V0";
        string sEncodedConsumerKey = Uri.EscapeDataString(sConsumerKey);
        string sEncodedSecretKey = Uri.EscapeDataString(sConsumerSecretKey);

        string sEncoded = sEncodedConsumerKey + ":" + sEncodedSecretKey;

        litEncodedConsumerKey.Text = EncodeTo64(sEncoded);

        //WebRequest request = WebRequest.Create("https://api.twitter.com/oauth2/token");
 
        //request.Method = "POST";
        //request.Headers.Add("Authorization", "Basic " + EncodeTo64(sEncoded));

        //request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

        //string postData = "grant_type=client_credentials";
        //byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        //request.ContentLength = byteArray.Length;
        ////Stream dataStream = request.GetRequestStream();
        ////dataStream.Write(byteArray, 0, byteArray.Length);
        ////dataStream.Close();

        //WebResponse response = request.GetResponse();

        //litBearerToken.Text = response.ToString();
        String key = "qZiQkW4Ul6FkV6APm1m2mIOze";
        String secret = "FfmwwIRFgNpY6Kycyb313M4VeEk9R4CLtrqIGIBw1BxENou6V0";

        String bearerCredentials = HttpUtility.UrlEncode(key) + ":" + HttpUtility.UrlEncode(secret);
        bearerCredentials = EncodeTo64(bearerCredentials);

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.twitter.com/oauth2/token");
        request.Method = "POST";
        request.Headers.Add("Authorization", "Basic " + bearerCredentials);
        request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
        string postData = "grant_type=client_credentials";
        byte[] data = System.Text.Encoding.UTF8.GetBytes(postData);
        request.ContentLength = data.Length;
        request.GetRequestStream().Write(data, 0, data.Length);
        WebResponse response = request.GetResponse();
        String responseString = "";
        using (Stream stream = response.GetResponseStream())
        {
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            responseString = reader.ReadToEnd();
        }
        litBearerToken.Text = responseString;

        //Getting Tweets
        GetTweets();
    }

    static public string EncodeTo64(string toEncode)
    {
        byte[] toEncodeAsBytes
              = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
        string returnValue
              = System.Convert.ToBase64String(toEncodeAsBytes);
        return returnValue;
    }

    public void GetTweets() {
        string sBearer = "AAAAAAAAAAAAAAAAAAAAAEhjewAAAAAA6%2B3HZJ5tpzcHEXobNTo%2F7%2BYT7Oc%3D06JMFvVxeHslrlLo5azQ5tmOBfiAo0eyCgHebQSfmgl3dtQY4a";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.twitter.com/1.1/statuses/user_timeline.json?count=100&screen_name=KarimaBrown");
        request.Method = "GET";
        request.Headers.Add("Authorization", "Bearer " + sBearer);
        //request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
        //string postData = "grant_type=client_credentials";
        //byte[] data; //= System.Text.Encoding.UTF8.GetBytes(postData);
        //request.ContentLength = data.Length;
        //request.GetRequestStream().Write(data, 0, data.Length);
        WebResponse response = request.GetResponse();
        String responseString = "";
        using (Stream stream = response.GetResponseStream())
        {
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            responseString = reader.ReadToEnd();
        }
        litTweets.Text = responseString;
    }
}
