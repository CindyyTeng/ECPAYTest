﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFModels.Models
{
    public partial class ProjectTagItem
    {
        [Key]
        public int fk_ProjectTagId { get; set; }
        [Key]
        [StringLength(254)]
        [Unicode(false)]
        public string fk_ProductId { get; set; }

        [ForeignKey("fk_ProductId")]
        [InverseProperty("ProjectTagItems")]
        public virtual Product fk_Product { get; set; }
    }
}