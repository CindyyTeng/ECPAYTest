﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFModels.Models
{
    public partial class order_status
    {
        public order_status()
        {
            orders = new HashSet<order>();
        }

        [Key]
        public int Id { get; set; }
        [Column("order_status")]
        [StringLength(50)]
        public string order_status1 { get; set; }

        [InverseProperty("order_status")]
        public virtual ICollection<order> orders { get; set; }
    }
}