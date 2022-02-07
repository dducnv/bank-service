using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bank_client.Models
{
    public class Login
    {
        
        [DisplayName("Số Điện Thoại")]
        [Required(ErrorMessage = "Vui Lòng Nhập Số Điện Thoại")]
        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Số Điện Thoại Không Hợp Lệ.")]
        public string PhoneNumber { get; set; }
      
        [DisplayName("Mật Khẩu")]
        [Required(ErrorMessage = "Vui Lòng Nhập Mật Khẩu")]
        public string Password { get; set; }
    }
}