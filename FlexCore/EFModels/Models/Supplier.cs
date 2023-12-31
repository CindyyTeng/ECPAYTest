﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFModels.Models
{
    [Index("SupplierCompanyNumber", Name = "UQ__Supplier__AE8E9B418F60BEDC", IsUnique = true)]
    public partial class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Required]
        [StringLength(50)]
        public string SupplierCompanyName { get; set; }
        public bool? HasCertificate { get; set; }
        [StringLength(50)]
        public string Supply_Material { get; set; }
        public int? SupplierCompanyPhone { get; set; }
        [StringLength(250)]
        public string SupplierCompanyEmail { get; set; }
        [StringLength(250)]
        public string SupplierCompanyAddress { get; set; }
        public int? SupplierCompanyNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SupplierStartDate { get; set; }
    }
}