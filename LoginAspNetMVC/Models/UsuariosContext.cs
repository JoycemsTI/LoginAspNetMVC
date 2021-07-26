using System.Data.Entity;

public class UsuariosContext : DbContext
{
    public UsuariosContext() : base("Usuarios")
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
}