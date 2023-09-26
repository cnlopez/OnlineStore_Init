using System.ComponentModel.DataAnnotations;

namespace Business.Settings
{
    public class AppSettings
    {
        public const string SectionName = "AppSettings";

        [Required, EmailAddress]
        public string SenderEmail { get; set; }
        [Required, EmailAddress]
        public string RecipientEmail { get; set; }
        [Required]
        public string SmtpHost { get; set; }
        [Required]
        public int SmtpPort { get; set; }
        [Required, EmailAddress]
        public string SmtpUsername { get; set; }
        [Required]
        public string SmtpPassword { get; set; }        
    }
}
