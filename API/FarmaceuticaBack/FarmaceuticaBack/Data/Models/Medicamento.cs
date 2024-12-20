﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FarmaceuticaBack.Models;

public partial class Medicamento
{
    public int IdMedicamento { get; set; }

    public int IdMonodroga { get; set; }

    public string NombreComercial { get; set; }

    public int IdLaboratorio { get; set; }

    public int IdMarca { get; set; }

    public bool VentaLibre { get; set; }

    public int IdPresentacion { get; set; }

    public string Descripcion { get; set; }

    public decimal Precio { get; set; }

    public bool? Activo { get; set; }

    public virtual Laboratorio IdLaboratorioNavigation { get; set; }

    public virtual Marca IdMarcaNavigation { get; set; }

    public virtual Monodroga IdMonodrogaNavigation { get; set; }

    public virtual Presentacion IdPresentacionNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<MedicamentosLote> MedicamentosLotes { get; set; } = new List<MedicamentosLote>();
}