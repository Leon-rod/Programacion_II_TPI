﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FarmaceuticaBack.Models;

public partial class TiposProducto
{
    public int IdTipoProducto { get; set; }

    public string TipoProducto { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}