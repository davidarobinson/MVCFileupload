using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileUpload.Models
{
    public class MultipleFileUploadViewModel
    {
        public List<HttpPostedFileBase> UploadFilePaths { get; set; }
        public List<string> Urls { get; set; }
    }
}