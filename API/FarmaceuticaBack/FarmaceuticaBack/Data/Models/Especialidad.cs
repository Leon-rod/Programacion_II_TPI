﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FarmaceuticaBack.Models;

public partial class Especialidad
{
    public int IdTipoEspecialidad { get; set; }

    public string NombreEspecialidad { get; set; }

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}