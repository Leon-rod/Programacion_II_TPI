﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FarmaceuticaBack.Models;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string Cargo1 { get; set; }

    public virtual ICollection<PersonalCargosEstablecimiento> PersonalCargosEstablecimientos { get; set; } = new List<PersonalCargosEstablecimiento>();
}