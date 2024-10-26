﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FarmaceuticaBack.Models;

public partial class EmpresaLogistica
{
    public string Cuit { get; set; }

    public string NombreEmpresa { get; set; }

    public string Calle { get; set; }

    public string Numero { get; set; }

    public int IdBarrio { get; set; }
    [JsonIgnore]
    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual Barrio IdBarrioNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}