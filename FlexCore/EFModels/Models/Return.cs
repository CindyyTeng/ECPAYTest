﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFModels.Models
{
    public partial class Return
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? 退貨日期 { get; set; }
        public int? fk訂單 { get; set; }
        public int? 退貨轉帳帳號 { get; set; }
        public bool? 退款狀態 { get; set; }
        public int? 退貨理由 { get; set; }

        [ForeignKey("fk訂單")]
        [InverseProperty("Returns")]
        public virtual order fk訂單Navigation { get; set; }
        [ForeignKey("退貨理由")]
        [InverseProperty("Returns")]
        public virtual ReturnReson 退貨理由Navigation { get; set; }
    }
}