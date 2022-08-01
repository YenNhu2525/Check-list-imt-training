using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Areas.Identity.Data;
using ToDoList.Models;

namespace ToDoList.Areas.Identity.Data;

public class ToDoListContext : IdentityDbContext<ToDoListUser>
{
    public ToDoListContext(DbContextOptions<ToDoListContext> options)
        : base(options)
    {
    }

    public DbSet<ToDo> ToDos { get; set; }
    //public static ToDoListContext Create()
    //{
    //    return new ToDoListContext();
    //}

protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
