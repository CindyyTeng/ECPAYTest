﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFModels.Models
{
    [Index("ActivityStatusDescription", Name = "UQ__Activity__732635EC1A064DF7", IsUnique = true)]
    public partial class ActivityStatus
    {
        public ActivityStatus()
        {
            Activities = new HashSet<Activity>();
        }

        [Key]
        public int ActivityStatusId { get; set; }
        [StringLength(50)]
        public string ActivityStatusDescription { get; set; }

        [InverseProperty("fk_ActivityStatus")]
        public virtual ICollection<Activity> Activities { get; set; }
    }
}