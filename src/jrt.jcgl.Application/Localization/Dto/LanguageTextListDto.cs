using Abp.Application.Services.Dto;

namespace jrt.jcgl.Localization.Dto
{
    public class LanguageTextListDto : IDto
    {
        public string Key { get; set; }
        
        public string BaseValue { get; set; }
        
        public string TargetValue { get; set; }
    }
}