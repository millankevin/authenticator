using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Authenticator.Models;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditoriaPermiso> AuditoriaPermisos { get; set; }

    public virtual DbSet<AuditoriaUsuario> AuditoriaUsuarios { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<HistorialAccesoUsuario> HistorialAccesoUsuarios { get; set; }

    public virtual DbSet<HistoricoContrasena> HistoricoContrasenas { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<Panel> Panels { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PermisoUsuario> PermisoUsuarios { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolPermisoModulo> RolPermisoModulos { get; set; }

    public virtual DbSet<RolPermisoPanel> RolPermisoPanels { get; set; }

    public virtual DbSet<Sesion> Sesions { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-OPRDTK9;Initial Catalog=Prueba;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate = true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditoriaPermiso>(entity =>
        {
            entity.HasKey(e => e.IdAuditoriaPermiso).HasName("PK__auditori__CABD22CBAB758A1F");

            entity.ToTable("auditoria_Permiso");

            entity.HasIndex(e => e.FkIdPermiso, "IX_auditoria_Permiso_fk_id_permiso");

            entity.HasIndex(e => e.FkIdUsuario, "IX_auditoria_Permiso_fk_id_usuario");

            entity.Property(e => e.IdAuditoriaPermiso).HasColumnName("id_auditoria_permiso");
            entity.Property(e => e.Detalles).HasColumnName("detalles");
            entity.Property(e => e.FechaEvento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_evento");
            entity.Property(e => e.FkIdPermiso).HasColumnName("fk_id_permiso");
            entity.Property(e => e.FkIdUsuario).HasColumnName("fk_id_usuario");
            entity.Property(e => e.IdResgistroAfectado).HasColumnName("id_resgistro_afectado");
            entity.Property(e => e.NombreTabla)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_tabla");

            entity.HasOne(d => d.FkIdPermisoNavigation).WithMany(p => p.AuditoriaPermisos)
                .HasForeignKey(d => d.FkIdPermiso)
                .HasConstraintName("FK__auditoria__fk_id__534D60F1");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithMany(p => p.AuditoriaPermisos)
                .HasForeignKey(d => d.FkIdUsuario)
                .HasConstraintName("FK__auditoria__fk_id__5441852A");
        });

        modelBuilder.Entity<AuditoriaUsuario>(entity =>
        {
            entity.HasKey(e => e.IdAuditoriaUsuario).HasName("PK__auditori__1A419DCE48BD235D");

            entity.ToTable("auditoria_usuario");

            entity.HasIndex(e => e.FkIdPermiso, "IX_auditoria_usuario_fk_id_permiso");

            entity.HasIndex(e => e.FkIdUsuario, "IX_auditoria_usuario_fk_id_usuario");

            entity.Property(e => e.IdAuditoriaUsuario).HasColumnName("id_auditoria_usuario");
            entity.Property(e => e.Detalles)
                .IsUnicode(false)
                .HasColumnName("detalles");
            entity.Property(e => e.FechaEvento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_evento");
            entity.Property(e => e.FkIdPermiso).HasColumnName("fk_id_permiso");
            entity.Property(e => e.FkIdUsuario).HasColumnName("fk_id_usuario");
            entity.Property(e => e.IdResgistroAfectado).HasColumnName("id_resgistro_afectado");

            entity.HasOne(d => d.FkIdPermisoNavigation).WithMany(p => p.AuditoriaUsuarios)
                .HasForeignKey(d => d.FkIdPermiso)
                .HasConstraintName("FK__auditoria__fk_id__4F7CD00D");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithMany(p => p.AuditoriaUsuarios)
                .HasForeignKey(d => d.FkIdUsuario)
                .HasConstraintName("FK__auditoria__fk_id__5070F446");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__estado__86989FB24613AF0C");

            entity.ToTable("estado");

            entity.HasIndex(e => e.Descripcion, "IX_estado_descripcion");

            entity.HasIndex(e => e.IdEstado, "IX_estado_id");

            entity.Property(e => e.IdEstado)
                .ValueGeneratedNever()
                .HasColumnName("id_estado");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<HistorialAccesoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdHistorialAcceso).HasName("PK__historia__86226BC314FF9D09");

            entity.ToTable("historial_acceso_usuario");

            entity.HasIndex(e => e.FkIdUsuario, "IX_historial_acceso_usuario_fk_id_usuario");

            entity.Property(e => e.IdHistorialAcceso).HasColumnName("id_historial_acceso");
            entity.Property(e => e.DireccionIp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("direccion_ip");
            entity.Property(e => e.FechaInicioSesion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio_sesion");
            entity.Property(e => e.FkIdUsuario).HasColumnName("fk_id_usuario");
            entity.Property(e => e.InformacionDispositivo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("informacion_dispositivo");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithMany(p => p.HistorialAccesoUsuarios)
                .HasForeignKey(d => d.FkIdUsuario)
                .HasConstraintName("FK__historial__fk_id__571DF1D5");
        });

        modelBuilder.Entity<HistoricoContrasena>(entity =>
        {
            entity.HasKey(e => e.IdHistorico).HasName("PK__historic__76E62AC3D65EE446");

            entity.ToTable("historico_contrasena");

            entity.HasIndex(e => e.FkIdUsuario, "IX_historico_contrasena_fk_id_usuario");

            entity.Property(e => e.IdHistorico).HasColumnName("id_historico");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FkIdUsuario).HasColumnName("fk_id_usuario");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithMany(p => p.HistoricoContrasenas)
                .HasForeignKey(d => d.FkIdUsuario)
                .HasConstraintName("FK__historico__fk_id__4CA06362");
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.IdModulo).HasName("PK__modulo__B2584DFC77F136D4");

            entity.ToTable("modulo");

            entity.HasIndex(e => e.FkIdEstado, "IX_modulo_fk_id_estado");

            entity.Property(e => e.IdModulo).HasColumnName("id_modulo");
            entity.Property(e => e.Abreviatura)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("abreviatura");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FkIdEstado).HasColumnName("fk_id_estado");

            entity.HasOne(d => d.FkIdEstadoNavigation).WithMany(p => p.Modulos)
                .HasForeignKey(d => d.FkIdEstado)
                .HasConstraintName("FK__modulo__fk_id_es__29572725");
        });

        modelBuilder.Entity<Panel>(entity =>
        {
            entity.HasKey(e => e.IdPanel).HasName("PK__panel__3C151263E155CF29");

            entity.ToTable("panel");

            entity.HasIndex(e => new { e.FkIdModulo, e.FkIdEstado }, "IX_panel_composite");

            entity.Property(e => e.IdPanel).HasColumnName("id_panel");
            entity.Property(e => e.Carpeta).HasColumnName("carpeta");
            entity.Property(e => e.Dependencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dependencia");
            entity.Property(e => e.FkIdEstado).HasColumnName("fk_id_estado");
            entity.Property(e => e.FkIdModulo).HasColumnName("fk_id_modulo");
            entity.Property(e => e.Habilitado).HasColumnName("habilitado");
            entity.Property(e => e.Interfaz)
                .IsUnicode(false)
                .HasColumnName("interfaz");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Ruta)
                .IsUnicode(false)
                .HasColumnName("ruta");

            entity.HasOne(d => d.FkIdEstadoNavigation).WithMany(p => p.Panels)
                .HasForeignKey(d => d.FkIdEstado)
                .HasConstraintName("FK__panel__fk_id_est__34C8D9D1");

            entity.HasOne(d => d.FkIdModuloNavigation).WithMany(p => p.Panels)
                .HasForeignKey(d => d.FkIdModulo)
                .HasConstraintName("FK__panel__fk_id_mod__33D4B598");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__permiso__228F224F1CF2C253");

            entity.ToTable("permiso");

            entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<PermisoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdPermisoUsuario).HasName("PK__permiso___8DD52D36FD91CA8D");

            entity.ToTable("permiso_usuario");

            entity.HasIndex(e => new { e.FkIdUsuario, e.FkIdPanel, e.FkIdEstado, e.FkIdPermiso }, "IX_permiso_usuario_composite");

            entity.Property(e => e.IdPermisoUsuario).HasColumnName("id_permiso_usuario");
            entity.Property(e => e.FkIdEstado).HasColumnName("fk_id_estado");
            entity.Property(e => e.FkIdPanel).HasColumnName("fk_id_panel");
            entity.Property(e => e.FkIdPermiso).HasColumnName("fk_id_permiso");
            entity.Property(e => e.FkIdUsuario).HasColumnName("fk_id_usuario");

            entity.HasOne(d => d.FkIdEstadoNavigation).WithMany(p => p.PermisoUsuarios)
                .HasForeignKey(d => d.FkIdEstado)
                .HasConstraintName("FK__permiso_u__fk_id__44FF419A");

            entity.HasOne(d => d.FkIdPanelNavigation).WithMany(p => p.PermisoUsuarios)
                .HasForeignKey(d => d.FkIdPanel)
                .HasConstraintName("FK__permiso_u__fk_id__4316F928");

            entity.HasOne(d => d.FkIdPermisoNavigation).WithMany(p => p.PermisoUsuarios)
                .HasForeignKey(d => d.FkIdPermiso)
                .HasConstraintName("FK__permiso_u__fk_id__440B1D61");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithMany(p => p.PermisoUsuarios)
                .HasForeignKey(d => d.FkIdUsuario)
                .HasConstraintName("FK__permiso_u__fk_id__4222D4EF");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__persona__228148B06A316B46");

            entity.ToTable("persona");

            entity.HasIndex(e => e.FkIdEstado, "IX_persona_fk_id_estado");

            entity.HasIndex(e => e.FkIdUsuario, "IX_persona_fk_id_usuario");

            entity.HasIndex(e => e.Email, "UQ__persona__AB6E61640E059DE9").IsUnique();

            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.FkIdEstado).HasColumnName("fk_id_estado");
            entity.Property(e => e.FkIdUsuario).HasColumnName("fk_id_usuario");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("identificacion");
            entity.Property(e => e.NumeroContacto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("numero_contacto");
            entity.Property(e => e.NumeroContactoAlt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("numero_contacto_alt");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("primer_apellido");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("primer_nombre");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("segundo_apellido");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("segundo_nombre");

            entity.HasOne(d => d.FkIdEstadoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.FkIdEstado)
                .HasConstraintName("FK__persona__fk_id_e__48CFD27E");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.FkIdUsuario)
                .HasConstraintName("FK__persona__fk_id_u__49C3F6B7");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__rol__6ABCB5E0E54A5A2F");

            entity.ToTable("rol");

            entity.HasIndex(e => e.FkIdEstado, "IX_rol_fk_id_estado");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Abreviatura)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("abreviatura");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FkIdEstado).HasColumnName("fk_id_estado");

            entity.HasOne(d => d.FkIdEstadoNavigation).WithMany(p => p.Rols)
                .HasForeignKey(d => d.FkIdEstado)
                .HasConstraintName("FK__rol__fk_id_estad__267ABA7A");
        });

        modelBuilder.Entity<RolPermisoModulo>(entity =>
        {
            entity.HasKey(e => e.IdPermisoModulo).HasName("PK__rol_perm__B9B129CBB4D8785F");

            entity.ToTable("rol_permiso_modulo");

            entity.HasIndex(e => new { e.FkIdRol, e.FkIdModulo, e.FkIdPermiso, e.FkIdEstado }, "IX_permiso_modulo_composite");

            entity.Property(e => e.IdPermisoModulo).HasColumnName("id_permiso_modulo");
            entity.Property(e => e.FkIdEstado).HasColumnName("fk_id_estado");
            entity.Property(e => e.FkIdModulo).HasColumnName("fk_id_modulo");
            entity.Property(e => e.FkIdPermiso).HasColumnName("fk_id_permiso");
            entity.Property(e => e.FkIdRol).HasColumnName("fk_id_rol");

            entity.HasOne(d => d.FkIdEstadoNavigation).WithMany(p => p.RolPermisoModulos)
                .HasForeignKey(d => d.FkIdEstado)
                .HasConstraintName("FK__rol_permi__fk_id__30F848ED");

            entity.HasOne(d => d.FkIdModuloNavigation).WithMany(p => p.RolPermisoModulos)
                .HasForeignKey(d => d.FkIdModulo)
                .HasConstraintName("FK__rol_permi__fk_id__2F10007B");

            entity.HasOne(d => d.FkIdPermisoNavigation).WithMany(p => p.RolPermisoModulos)
                .HasForeignKey(d => d.FkIdPermiso)
                .HasConstraintName("FK__rol_permi__fk_id__300424B4");

            entity.HasOne(d => d.FkIdRolNavigation).WithMany(p => p.RolPermisoModulos)
                .HasForeignKey(d => d.FkIdRol)
                .HasConstraintName("FK__rol_permi__fk_id__2E1BDC42");
        });

        modelBuilder.Entity<RolPermisoPanel>(entity =>
        {
            entity.HasKey(e => e.IdPermisoPanel).HasName("PK__rol_perm__CBA4D44BFB0996C1");

            entity.ToTable("rol_permiso_panel");

            entity.HasIndex(e => new { e.FkIdRol, e.FkIdPanel, e.FkIdEstado, e.FkIdPermiso }, "IX_permiso_panel_composite");

            entity.Property(e => e.IdPermisoPanel).HasColumnName("id_permiso_panel");
            entity.Property(e => e.FkIdEstado).HasColumnName("fk_id_estado");
            entity.Property(e => e.FkIdPanel).HasColumnName("fk_id_panel");
            entity.Property(e => e.FkIdPermiso).HasColumnName("fk_id_permiso");
            entity.Property(e => e.FkIdRol).HasColumnName("fk_id_rol");

            entity.HasOne(d => d.FkIdEstadoNavigation).WithMany(p => p.RolPermisoPanels)
                .HasForeignKey(d => d.FkIdEstado)
                .HasConstraintName("FK__rol_permi__fk_id__3A81B327");

            entity.HasOne(d => d.FkIdPanelNavigation).WithMany(p => p.RolPermisoPanels)
                .HasForeignKey(d => d.FkIdPanel)
                .HasConstraintName("FK__rol_permi__fk_id__38996AB5");

            entity.HasOne(d => d.FkIdPermisoNavigation).WithMany(p => p.RolPermisoPanels)
                .HasForeignKey(d => d.FkIdPermiso)
                .HasConstraintName("FK__rol_permi__fk_id__398D8EEE");

            entity.HasOne(d => d.FkIdRolNavigation).WithMany(p => p.RolPermisoPanels)
                .HasForeignKey(d => d.FkIdRol)
                .HasConstraintName("FK__rol_permi__fk_id__37A5467C");
        });

        modelBuilder.Entity<Sesion>(entity =>
        {
            entity.HasKey(e => e.IdSesion).HasName("PK__sesion__8D3F9DFE1919C100");

            entity.ToTable("sesion");

            entity.HasIndex(e => e.FkIdUsuario, "IX_sesion_fk_id_usuario");

            entity.Property(e => e.IdSesion).HasColumnName("id_sesion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaExpiracion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_expiracion");
            entity.Property(e => e.FkIdUsuario).HasColumnName("fk_id_usuario");
            entity.Property(e => e.TokenSesion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("token_sesion");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithMany(p => p.Sesions)
                .HasForeignKey(d => d.FkIdUsuario)
                .HasConstraintName("FK__sesion__fk_id_us__5CD6CB2B");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.IdToken).HasName("PK__token__3C2FA9C4AC1EEF25");

            entity.ToTable("token");

            entity.HasIndex(e => e.FkIdUsuario, "IX_token_fk_id_usuario");

            entity.Property(e => e.IdToken).HasColumnName("id_token");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaExpiracion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_expiracion");
            entity.Property(e => e.FkIdUsuario).HasColumnName("fk_id_usuario");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.TokenValor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("token_valor");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.FkIdUsuario)
                .HasConstraintName("FK__token__fk_id_usu__59FA5E80");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__4E3E04ADF566818B");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.FkIdEstado, "IX_usuario_fk_id_estado");

            entity.HasIndex(e => e.FkIdRol, "IX_usuario_fk_id_rol");

            entity.HasIndex(e => e.Usuario1, "UQ__usuario__9AFF8FC620813B3A").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Bloqueo).HasColumnName("bloqueo");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.FechaBloqueo)
                .HasColumnType("datetime")
                .HasColumnName("fecha_bloqueo");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.FkIdEstado).HasColumnName("fk_id_estado");
            entity.Property(e => e.FkIdRol).HasColumnName("fk_id_rol");
            entity.Property(e => e.Intento).HasColumnName("intento");
            entity.Property(e => e.MostrarSegundoFa).HasColumnName("mostrar_segundo_fa");
            entity.Property(e => e.SegundoFactor).HasColumnName("segundo_factor");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.FkIdEstadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkIdEstado)
                .HasConstraintName("FK__usuario__fk_id_e__3F466844");

            entity.HasOne(d => d.FkIdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkIdRol)
                .HasConstraintName("FK__usuario__fk_id_r__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
