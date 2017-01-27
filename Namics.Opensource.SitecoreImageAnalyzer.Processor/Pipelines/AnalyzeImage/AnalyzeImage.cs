using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Namics.Opensource.SitecoreImageAnalyzer.Processor.Pipelines.AnalyzeImage.Models;
using Newtonsoft.Json;

namespace Namics.Opensource.SitecoreImageAnalyzer.Processor.Pipelines.AnalyzeImage
{
    public static class AnalyzeImage
    {
        internal static AnalyzedImageModel MakeRequest(byte[] imageBody)
        {
            AnalyzedImageModel responseJson;

            using (var client = new HttpClient())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty);

                // Request headers
                client.DefaultRequestHeaders.Add(
                    Sitecore.Configuration.Settings.GetSetting(
                        "Namics.OpenSource.SitecoreImageAnalyzer.SubscriptionKeyHeader"),
                    Sitecore.Configuration.Settings.GetSetting("Namics.OpenSource.SitecoreImageAnalyzer.SubscriptionKey"));

                // Request parameters
                queryString["visualFeatures"] =
                    Sitecore.Configuration.Settings.GetSetting(
                        "Namics.OpenSource.SitecoreImageAnalyzer.VisualFeatures", "Description");
                queryString["language"] =
                    Sitecore.Configuration.Settings.GetSetting("Namics.OpenSource.SitecoreImageAnalyzer.Language", "en");
                var uri =
                    $"{Sitecore.Configuration.Settings.GetSetting("Namics.OpenSource.SitecoreImageAnalyzer.ApiEndpoint")}?{queryString}";

                // Request body
                using (var content = new ByteArrayContent(imageBody))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    var result = client.PostAsync(uri, content).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var response = result.Content.ReadAsStringAsync().Result;
                        responseJson = JsonConvert.DeserializeObject<AnalyzedImageModel>(response);
                    }
                    else
                    {
                        responseJson = null;
                    }
                }
            }


            return responseJson;
        }
    }
}
