using System.ComponentModel.DataAnnotations;

namespace ArkiaIdentity.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}