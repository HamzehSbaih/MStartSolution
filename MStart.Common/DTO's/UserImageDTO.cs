using MStart.Common.App_LocalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.Common.DTO_s
{
    public class UserImageDTO
    {
        public int Id { get; set; }
        [Display(Name = "file_stream", ResourceType = typeof(Resource))]
        public byte[] file_stream { get; set; }

        public int EmployeeId { get; set; }
        public string ContentType { get; set; }
        public string FileNameWithExtension { get; set; }

    }
}
