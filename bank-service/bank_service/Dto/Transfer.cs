using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace bank_service.Dto
{
    [DataContract]
    public class Transfer
    {
        [DataMember]
        [DisplayName("Số Tài Khoản")]
        [Required]
        public int AccountNumber { get; set; }
        [DataMember]
        [DisplayName("Tên")]
        [Required(ErrorMessage = "Vui Lòng Nhập Tên")]
        public string FistName { get; set; }
        [DataMember]
        [DisplayName("Họ và Tên Đệm")]
        [Required(ErrorMessage = "Vui Lòng Nhập Họ Và Tên Đệm")]
        public string LastName { get; set; }
        [DataMember]
        [DisplayName("Nhập số tiền")]
        [Required(ErrorMessage = "Vui Lòng Nhập Số Tiền Muốn Chuyển")]
        public string Amount { get; set; }
        [DataMember]
        [DisplayName("Mật Khẩu")]
        [Required(ErrorMessage = "Vui Lòng Nhập Mật Khẩu")]
        public string Password { get; set; }
    }
}