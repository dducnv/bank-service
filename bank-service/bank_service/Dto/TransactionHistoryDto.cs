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
        [DisplayName("Lời Nhắn")]
        [Required(ErrorMessage = "Vui Lòng Nhập Số Tài Khoản Người Nhận")]
        public string Message { get; set; }
        [DataMember]
        [DisplayName("Loại Giao Dịch")]
        [Required]
        public string TransactionType { get; set; }
        [DataMember]
        [DisplayName("Ngày Gửi")]
        [Required]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        [Required]
        public DateTime UpdatedAt { get; set; }
        [DataMember]
        [DisplayName("Trạng Thái")]
        [Required]
        public int Status { get; set; }
    }
}