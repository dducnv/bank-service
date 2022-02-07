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
    public class TransferDto
    {
        [DataMember]
        [DisplayName("Số Tài Khoản")]
        [Required]
        public string AccountNumberSender { get; set; }
        [DataMember]
        [DisplayName("Số Tài Khoản")]
        [Required]
        public string AccountNumberReceiver { get; set; }
        [DataMember]
        [DisplayName("Tên")]
        [Required(ErrorMessage = "Vui Lòng Nhập Họ Và Tên")]
        public string FullName { get; set; }
        [DataMember]
        [DisplayName("Nhập số tiền")]
        [Required(ErrorMessage = "Vui Lòng Nhập Số Tiền Muốn Chuyển")]
        public string Amount { get; set; }
        [DataMember]
        [DisplayName("Lời Nhắn")]
        [Required(ErrorMessage = "Vui Lòng Nhập Lời Nhắn")]
        public string Message { get; set; }
        [DataMember]
        [DisplayName("Mật Khẩu")]
        [Required(ErrorMessage = "Vui Lòng Nhập Mật Khẩu")]
        public string Password { get; set; }
    }
}