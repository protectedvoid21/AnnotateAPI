using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnnotateAPI; 

public class AnnotateDbContext : IdentityDbContext<AppUser, IdentityRole, string> {
    public AnnotateDbContext(DbContextOptions<AnnotateDbContext> options) : base(options) { }

    public DbSet<Picture> Pictures { get; set; }
    public DbSet<Coordinate> Coordinates { get; set; }
    public DbSet<BodyPartType> BodyPartTypes { get; set; }
    public DbSet<Annotation> Annotations { get; set; }
}