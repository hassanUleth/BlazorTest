using BlazorDeploymentTest.Shared.Helpers;
using BlazorDeploymentTest.Shared.Resources;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlazorDeploymentTest.Shared.Enumerations
{
    
    public enum Languages
    {
        [Display(Name = "EnumEnglish", ResourceType=typeof(ProgramStrings))]
        English,

        [Display(Name = "EnumFrench", ResourceType=typeof(ProgramStrings))]
        French
    }
}
