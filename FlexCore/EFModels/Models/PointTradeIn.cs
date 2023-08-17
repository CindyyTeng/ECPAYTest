﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFModels.Models
{
    [Table("PointTradeIn")]
    public partial class PointTradeIn
    {
        [Key]
        public int PointTradeInId { get; set; }
        public int fk_MemberId { get; set; }
        public int? fk_OrderId { get; set; }
        [Required]
        [StringLength(30)]
        public string GiftThreshold { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string GetPoints { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string MaxGetPoints { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EffectiveDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ExpirationDate { get; set; }

        [ForeignKey("fk_MemberId")]
        [InverseProperty("PointTradeIns")]
        public virtual Member fk_Member { get; set; }
        [ForeignKey("fk_OrderId")]
        [InverseProperty("PointTradeIns")]
        public virtual order fk_Order { get; set; }
    }
}