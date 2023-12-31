﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFModels.Models
{
    public partial class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }
        public int fk_MemberID { get; set; }

        [ForeignKey("fk_MemberID")]
        [InverseProperty("ShoppingCarts")]
        public virtual Member fk_Member { get; set; }
        [InverseProperty("CartItemNavigation")]
        public virtual CartItem CartItem { get; set; }
    }
}