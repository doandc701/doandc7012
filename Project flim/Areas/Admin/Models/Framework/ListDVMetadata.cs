using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Project_flim.Areas.Admin.Models.Framework
{
    public class ListDVMetadata
    {
        [Display(Name = "Mã diễn viên")]
        [Required(ErrorMessage = "Vui lòng nhập mã")]
        public int ID { get; set; }
        [Display(Name = "Tên diễn viên")]
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string NameDV { get; set; }

        [Display(Name = "Ảnh")]
        public string ImageDV { get; set; }

        [Display(Name ="Mã phim")]
        public Nullable<int> PhimID { get; set; }

        [Display(Name = "Ngày sinh")]
        public string Date_of_birth { get; set; }

        [Display(Name = "Công việc")]
       
        public string Job { get; set; }

        [Display(Name = "Chiều cao")]
        public string Height { get; set; }
        [Display(Name ="Lượt xem")]
        public Nullable<int> View { get; set; }

        [Display(Name = "Phim tham gia")]
        public string Related_movies { get; set; }

        [Display(Name = "Tiểu sử")]
        public string Story { get; set; }

        [Display(Name = "Tên phim")]
        public string NamePhim { get; set; }
    }
}