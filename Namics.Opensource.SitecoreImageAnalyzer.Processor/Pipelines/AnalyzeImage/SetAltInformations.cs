using System;
using System.IO;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.Upload;
using Sitecore.SecurityModel;

namespace Namics.Opensource.SitecoreImageAnalyzer.Processor.Pipelines.AnalyzeImage
{
    public class SetAltInformations : UploadProcessor
    {
        public void Process(UploadArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            using (new SecurityDisabler())
            {
                foreach (var uploadedItem in args.UploadedItems)
                {
                    try
                    {
                        var mediaItem = new MediaItem(uploadedItem);
                        if (string.IsNullOrEmpty(mediaItem.MediaPath) || !string.IsNullOrEmpty(mediaItem.Alt) || !mediaItem.MimeType.StartsWith("image", StringComparison.InvariantCultureIgnoreCase))
                        {
                            continue;
                        }

                        var ms = new MemoryStream();
                        mediaItem.GetMediaStream().CopyTo(ms);

                        // Analyze the image
                        var result = AnalyzeImage.MakeRequest(ms.ToArray());

                        mediaItem.BeginEdit();
                        mediaItem.Alt = result?.Description?.Captions?.FirstOrDefault()?.Text;
                        mediaItem.EndEdit();
                    }
                    catch (Exception ex)
                    {
                        Log.Warn($"Could not analyze image with GUID {uploadedItem.ID} on upload", ex);
                    }
                }
            }
        }
    }
}
