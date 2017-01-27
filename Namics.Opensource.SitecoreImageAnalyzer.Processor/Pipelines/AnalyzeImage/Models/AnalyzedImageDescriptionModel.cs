using System.Collections.Generic;

namespace Namics.Opensource.SitecoreImageAnalyzer.Processor.Pipelines.AnalyzeImage.Models
{
    public class AnalyzedImageDescriptionModel
    {
        public List<string> Tags { get; set; }
        public List<AnalyzedImageDescriptionCaptionsModel> Captions { get; set; }
    }
}
