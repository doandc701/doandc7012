using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Project_flim.Areas.Admin.Models.Framework
{
    public class DanhMucMetadata
    {
       
        [Display (Name = "Mã danh mục")]
        [Required(ErrorMessage ="Vui lòng nhập mã danh mục")]
        public int ID { get; set; }
        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]

        public string Name { get; set; }
        [Display(Name = "Tên viết tắt")]
        public string Alias { get; set; }
        [Display(Name = "Danh mục cha")]
        [Required(ErrorMessage = "Vui lòng nhập danh mục cha")]
        public Nullable<int> ParentID { get; set; }
        [Display(Name = "Thứ tự")]
        [Required(ErrorMessage = "Vui lòng chọn thứ tự")]
        public Nullable<int> Order { get; set; }
        [Display(Name = "Cấp độ")]
        [Required(ErrorMessage = "Vui lòng nhập cấp độ")]

        public string Level { get; set; }
        [Display(Name = "Trạng thái")]
        public Nullable<bool> Active { get; set; }
    }
}