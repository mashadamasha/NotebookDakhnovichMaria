using Microsoft.EntityFrameworkCore;

namespace NotebookDakhnovichMaria.DatabaseFramework;

public class NoteContext : DbContext
{
    public DbSet<ContactDataDto> Contacts { get; set; }
    
    public NoteContext(DbContextOptions<NoteContext> options):base(options)
    {
        Database.EnsureCreated();
    }

    public NoteContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=NotebookBase.db");
}