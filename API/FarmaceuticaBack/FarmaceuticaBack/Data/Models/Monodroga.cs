﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FarmaceuticaBack.Models;

public partial class Monodroga
{
    public int IdMonodroga { get; set; }

    public string Monodroga1 { get; set; }

    public virtual ICollection<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();
}