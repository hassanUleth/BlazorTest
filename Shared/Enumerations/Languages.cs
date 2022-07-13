using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlazorDeploymentTest.Shared.Enumerations
{
    
    public enum Languages
    {
        [Display(Name = "English Language")]
        English,

        [Display(Name = "French Language")]
        French
    }
}
