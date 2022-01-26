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
    public class TransactionHistoryDto
    {
        [DataMember]
        [DisplayName("Mã Giao Dịch")]
        [Required]
        public string TransactionId { get; set; }
        [DataMember]
        [DisplayName("Tên Người Gửi")]
        [Required]
        public string SenderName { get; set; }
        [DataMember]
        [DisplayName("Số Tiền")]
        [Required(ErrorMessage = "Vui Lòng Nhập Số Tiền")]
        public double Amount { get; set; }
        [DataMember]
        [DisplayName("STK Người Gửi")]
        [Required]
        public string SenderAccountNumber { get; set; }
        [DataMember]
        [DisplayName("STK Người Nhận")]
        [Required(ErrorMessage = "Vui Lòng Nhập Số Tài Khoản Người Nhận")]
        public string RecevierAccountNumber { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string TransactionType { get; set; }
        [DataMember]
        public DateTime CreactAt { get; set; }
        [DataMember]
        public DateTime UpdateAt { get; set; }
        [DataMember]
        public int Status { get; set; }
    }
}