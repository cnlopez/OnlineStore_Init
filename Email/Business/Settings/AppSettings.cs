using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Settings
{
    public class AppSettings
    {
        public const string SectionName = "AppSettings";
        [Required]
        public string SmtpHost { get; set; }
        [Required]
        public int SmtpPort { get; set; }
        [Required]
        public string SmtpUsername { get; set; }
        [Required]
        public string SmtpPassword { get; set; }
        [Required]
        public string SenderEmail { get; set; }
        [Required]
        public string RecipientEmail { get; set; }
    }
}
