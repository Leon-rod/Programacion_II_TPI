﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FarmaceuticaBack.Models;

public partial class Personal
{
    public int IdPersonal { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public DateOnly FechaNac { get; set; }

    public string Calle { get; set; }

    public string Numero { get; set; }

    public int IdBarrio { get; set; }

    public int TipoDoc { get; set; }

    public string NroDoc { get; set; }

    public int? IdGenero { get; set; }
    [JsonIgnore]
    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual Barrio IdBarrioNavigation { get; set; }

    public virtual TiposGenero IdGeneroNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<PersonalCargosEstablecimiento> PersonalCargosEstablecimientos { get; set; } = new List<PersonalCargosEstablecimiento>();

    public virtual TiposDocumento TipoDocNavigation { get; set; }
}