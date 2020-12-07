using MStart.Common.App_LocalResources;
using MStart.Common.DTO_s;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MStart.Models
{
    public class UsersViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Server_Date_Time", ResourceType = typeof(Resource))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Server_Date_Time { get; set; }
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "DateTime_UTC", ResourceType = typeof(Resource))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateTime_UTC { get; set; }
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Update_DateTime_UTC", ResourceType = typeof(Resource))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Update_DateTime_UTC { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "First_Name", ResourceType = typeof(Resource))]
        public string First_Name { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Last_Name", ResourceType = typeof(Resource))]
        public string Last_Name { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Mobile_Number", ResourceType = typeof(Resource))]
        public string Mobile_Number { get; set; }
     
        [Display(Name = "Gender", ResourceType = typeof(Resource))]
        public string Gender { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Address", ResourceType = typeof(Resource))]
        public string Address { get; set; }
        //[Required]
        [Display(Name = "PhotoId", ResourceType = typeof(Resource))]
        public int? PhotoId { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "AspNetUserId", ResourceType = typeof(Resource))]
        public string AspNetUserId { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "First_Name_AR", ResourceType = typeof(Resource))]
        public string First_Name_AR { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Last_Name_AR", ResourceType = typeof(Resource))]
        public string Last_Name_AR { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Address_AR", ResourceType = typeof(Resource))]
        public string Address_AR { get; set; }
        public UserImageDTO image { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public int GenderId { get; set; }
        public int[] empids { get; set; }

        public string EmployeeImage { get; set; }
        public IEnumerable<MStart.Common.DTO_s.LookupsDTO> genders { get; set; }
    }
}