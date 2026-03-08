using System.ComponentModel.DataAnnotations;

namespace Portfoliowebsite.Models;

public class ContactFormModel
{
    [Display(Name = "Naam")]
    [Required(ErrorMessage = "Vul uw naam in.")]
    [StringLength(50, ErrorMessage = "De naam mag maximaal {1} tekens zijn!")]
    public string Name { get; set; }
    
    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "Vul uw e-mailadres in.")]
    [StringLength(50, ErrorMessage = "Uw e-mailadres mag maximaal {1} tekens zijn!")]
    [EmailAddress(ErrorMessage = "Vul een geldig e-mailadres in.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Display(Name = "Onderwerp")]
    [Required(ErrorMessage = "Vul uw onderwerp in.")]
    [StringLength(30, ErrorMessage = "Uw onderwerp mag maximaal {1} tekens zijn!")]
    public string Subject { get; set; }
    
    [Display(Name = "Bericht")]
    [Required(ErrorMessage = "Vul het bericht in.")]
    [StringLength(500, ErrorMessage = "Uw bericht mag maximaal {1} tekens zijn!")]
    [DataType(DataType.MultilineText)]
    public string Message { get; set; }
    
    public string? MiddleName { get; set; }
}