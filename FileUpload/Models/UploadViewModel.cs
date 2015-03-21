using System.ComponentModel.DataAnnotations;
using System.Web;

namespace FileUpload.Models
{
    public class UploadViewModel
    {
        [Display(Name = "File To Upload")]
        [Required]
        [FileExtensions(Extensions=".png,.jpg,.jpeg,.gif", ErrorMessage = "The field only accepts file with the following extensions : png,jpg,jpeg,gif")]
        public string UploadFilePath { get; set; }
    }
}