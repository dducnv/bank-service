using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bank_client.Models
{
    public class Account
    {
        [DisplayName("Tên")]
        [Required(ErrorMessage = "Vui Lòng Nhập Tên")]
        public string FistName { get; set; }
        [DisplayName("Họ và Tên Đệm")]
        [Required(ErrorMessage = "Vui Lòng Nhập Họ Và Tên Đệm")]
        public string LastName { get; set; }
        [DisplayName("Mật Khẩu")]
        [Required(ErrorMessage = "Vui Lòng Nhập Mật Khẩu")]
        public string Password { get; set; }
        [DisplayName("Xác Nhận Mật Khẩu")]
        [Required(ErrorMessage = "Vui Lòng Nhập Lại Mật Khẩu")]
        [Compare("Password", ErrorMessage = "Mật Khẩu Không Trùng Khớp.")]
        public string PasswordConfirm { get; set; }
        [DisplayName("Số Điện Thoại")]
        [Required(ErrorMessage = "Vui Lòng Nhập Số Điện Thoại")]
        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Số Điện Thoại Không Hợp Lệ.")]
        public string PhoneNumber { get; set; }
        [DisplayName("Địa Chỉ")]
        [Required(ErrorMessage = "Vui Lòng Nhập Địa Chỉ")]
        public string Address { get; set; }
        [DisplayName("Địa Chỉ E-mail")]
        [Required(ErrorMessage = "Vui Lòng Nhập Địa Chỉ E-mail")]
        public string Email { get; set; }
        [DisplayName("Giấy Tờ Tuỳ Thân")]
        [Required(ErrorMessage = "Vui Lòng Nhập Số Giấy Tờ Tuỳ Thân")]
        public string IndetityNumber { get; set; }
        [DisplayName("Ngày Sinh")]
        [Required(ErrorMessage = "Vui Lòng Nhập Ngày Sinh")]
        public DateTime Birthday { get; set; }
    }
}