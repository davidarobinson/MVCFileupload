using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace FileUpload.Models
{
    public class FileUploadViewModel
    {
        [Display(Name = "File To Upload")]
        [Required(ErrorMessage = "Please select a file to upload")]
        public HttpPostedFileBase UploadFilePath { get; set; }
        public string Url { get; set; }
    }
}