﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFModels.Models
{
    [Table("CustomizedShoesPo")]
    public partial class CustomizedShoesPo
    {
        public CustomizedShoesPo()
        {
            CustomizedOrders = new HashSet<CustomizedOrder>();
            ShoesGroups = new HashSet<ShoesGroup>();
            ShoesPictures = new HashSet<ShoesPicture>();
        }

        [Key]
        public int ShoesProductId { get; set; }
        [Required]
        [StringLength(254)]
        public string ShoesName { get; set; }
        [StringLength(254)]
        public string ShoesDescription { get; set; }
        [StringLength(50)]
        public string ShoesOrigin { get; set; }
        public int ShoesUnitPrice { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndTime { get; set; }
        [Required]
        public bool? Status { get; set; }
        public int? fk_ShoesCategoryId { get; set; }
        public int? fk_ShoesColorId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCreateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataEditTime { get; set; }

        [ForeignKey("fk_ShoesCategoryId")]
        [InverseProperty("CustomizedShoesPos")]
        public virtual ShoesCategory fk_ShoesCategory { get; set; }
        [ForeignKey("fk_ShoesColorId")]
        [InverseProperty("CustomizedShoesPos")]
        public virtual ShoesColorCategory fk_ShoesColor { get; set; }
        [InverseProperty("Customized_Shoes")]
        public virtual ICollection<CustomizedOrder> CustomizedOrders { get; set; }
        [InverseProperty("fk_ShoesMain")]
        public virtual ICollection<ShoesGroup> ShoesGroups { get; set; }
        [InverseProperty("fk_ShoesPictureProduct")]
        public virtual ICollection<ShoesPicture> ShoesPictures { get; set; }
    }
}