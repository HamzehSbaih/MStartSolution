using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MStart.Common.DTO_s
{
    public class Attachment
    {
        public int AttachmentID { get; set; }
        public int EmployeeId { get; set; }
        public string FileName { get; set; }

        public string Caption { get; set; }

        public string ContentType { get; set; }
        public string FileNameWithExtension { get; set; }
        public byte[] Data { get; set; }
        public int ImageID { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }


        public HttpPostedFileBase ImageFile { get; set; }

        public int AttachmentId { get; set; }

        public int ElementId { get; set; }
        public override string ToString()
        {
            string urlToDownload = string.Empty;

            string template = "DownloadAttachment?id={0}";
            urlToDownload = string.Format(template, AttachmentId);

            return urlToDownload;
        }


    }
}
