using System.ComponentModel.DataAnnotations;

namespace Business.Settings
{
    public class AppSettings
    {
        public const string SectionName = "AppSettings";

        [Required]
        public string SenderEmail { get; set; }
        [Required]
        public string RecipientMail { get; set; }
    }
}
