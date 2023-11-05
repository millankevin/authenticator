using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public int? FkIdEstado { get; set; }

    public int? FkIdUsuario { get; set; }

    public string Identificacion { get; set; } = null!;

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public string Email { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string NumeroContacto { get; set; } = null!;

    public string? NumeroContactoAlt { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Estado? FkIdEstadoNavigation { get; set; }

    public virtual Usuario? FkIdUsuarioNavigation { get; set; }
}
