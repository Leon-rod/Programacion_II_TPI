﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FarmaceuticaBack.Models;

public partial class TiposPago
{
    public int IdTipoPago { get; set; }

    public string TipoPago { get; set; }

    public decimal? Descuento { get; set; }
    [JsonIgnore]
    public virtual ICollection<FacturasTiposPago> FacturasTiposPagos { get; set; } = new List<FacturasTiposPago>();
}