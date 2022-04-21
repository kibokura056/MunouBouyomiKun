using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace VoiceTextWebAPIClient
{
    public class VoiceTextClient
    {
        public Speaker Speaker { get; set; }

        public Emotion Emotion { get; set; }

        public EmotionLevel EmotionLevel { get; set; }

        public int Pitch { get; set; }

        public int Speed { get; set; }

        public int Volume { get; set; }

        public Format Format { get; set; }

        public string APIKey { get; set; }

        public Uri APIEndPoint { get; set; }

        public string AltText { get; set; }

        public VoiceTextClient()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
            this.APIEndPoint = new Uri("https://api.voicetext.jp/v1/tts");
            this.Speaker = Speaker.Haruka;
            this.Emotion = Emotion.Default;
            this.EmotionLevel = EmotionLevel.Default;
            this.Pitch = 100;
            this.Speed = 100;
            this.Volume = 100;
            this.Format = Format.WAV;
            this.AltText = "";
            this.APIKey = "";
        }

        private string ShapeText(string text)
        {
            if (text.Length > 200)
            {
                if(AltText.Length > 0)
                {
                    return new StringBuilder().Append(text.Substring(0, 200 - AltText.Length - 1)).Append("、").Append(AltText).ToString();
                }
                else
                {
                    return text.Substring(0, 200);
                }

            }
            return text;
        }

        public byte[] GetVoice(string text)
        {
            text = ShapeText(text);
            var httpClinet = CreateHttpClient();
            var content = BuildHttpRequestContent(text);
            var response = httpClinet.PostAsync(this.APIEndPoint, content).Result;
            if (response.StatusCode != HttpStatusCode.OK) return null;
            var bytes = response.Content.ReadAsByteArrayAsync().Result;

            return bytes;
        }

        private HttpClient CreateHttpClient()
        {
            var httpClinet = new HttpClient();
            httpClinet.DefaultRequestHeaders.Add(
                "Authorization",
                "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(this.APIKey)));
            return httpClinet;
        }

        private FormUrlEncodedContent BuildHttpRequestContent(string text)
        {
            var param = new Dictionary<string, string> {
                {"text", text},
                {"speaker", this.Speaker.ToString().ToLower()},
                {"pitch", this.Pitch.ToString()},
                {"speed", this.Speed.ToString()},
                {"volume", this.Volume.ToString()},
                {"format", this.Format.ToString().ToLower()},
            };
            if (this.Emotion != Emotion.Default)
            {
                param.Add("emotion", this.Emotion.ToString().ToLower());
            }
            if (this.EmotionLevel != EmotionLevel.Default)
            {
                param.Add("emotion_level", ((int)this.EmotionLevel).ToString());
            }

            var content = new FormUrlEncodedContent(param);
            return content;
        }
    }

    public enum Emotion
    {
        Default,
        Happiness,
        Anger,
        Sadness
    }

    public enum EmotionLevel
    {
        Low = 1,
        Default = 2,
        MediumHigh = 3,
        High = 4
    }

    public enum Format
    {
        WAV,
        OGG,
        MP3
    }

    public enum Speaker
    {
        Show,
        Haruka,
        Hikari,
        Takeru,
        Santa,
        Bear
    }

    public class VoiceTextException : InvalidOperationException
    {
        public HttpStatusCode StatusCode { get; set; }

        public VoiceTextException()
            : base()
        {
        }

        public VoiceTextException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}
