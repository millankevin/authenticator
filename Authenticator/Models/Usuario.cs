using System;
using System.Collections.Generic;

namespace Authenticator.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? FkIdRol { get; set; }

    public int? FkIdEstado { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public bool SegundoFactor { get; set; }

    public bool MostrarSegundoFa { get; set; }

    public int Intento { get; set; }

    public bool Bloqueo { get; set; }

    public DateTime? FechaBloqueo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<AuditoriaPermiso> AuditoriaPermisos { get; set; } = new List<AuditoriaPermiso>();

    public virtual ICollection<AuditoriaUsuario> AuditoriaUsuarios { get; set; } = new List<AuditoriaUsuario>();

    public virtual Estado? FkIdEstadoNavigation { get; set; }

    public virtual Rol? FkIdRolNavigation { get; set; }

    public virtual ICollection<HistorialAccesoUsuario> HistorialAccesoUsuarios { get; set; } = new List<HistorialAccesoUsuario>();

    public virtual ICollection<HistoricoContrasena> HistoricoContrasenas { get; set; } = new List<HistoricoContrasena>();

    public virtual ICollection<PermisoUsuario> PermisoUsuarios { get; set; } = new List<PermisoUsuario>();

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();

    public virtual ICollection<Sesion> Sesions { get; set; } = new List<Sesion>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
