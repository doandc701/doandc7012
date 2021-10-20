using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Project_flim.Areas.Admin.Models.Framework
{
    public class PhimMetadata
    {
        [Display(Name="Mã phim")]
        [Required(ErrorMessage ="Vui lòng nhập mã")]
        public int ID { get; set; }

        [Display(Name = "Tên phim")]
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string Name { get; set; }

        [Display(Name = "Tên tiếng anh")]
      
        public string Alias { get; set; }

        [Display(Name = "Thời lượng")]
   
        public string Time { get; set; }

        [Display(Name = "Mã danh mục")]
        [Required(ErrorMessage = "Vui lòng nhập mã")]

        public Nullable<int> CategoryID { get; set; }

        [Display(Name = "Ảnh")]
        [Required(ErrorMessage = "Vui lòng chọn ảnh")]
        public string Image { get; set; }

        [Display(Name = "Thông tin phim")]
        public string Detail { get; set; }

        [Display(Name = "Trạng thái")]

        public Nullable<bool> Active { get; set; }

        [Display(Name = "Chỉ Mục")]
        public string ChiMuc { get; set; }
        public string Video { get; set; }
    }
}