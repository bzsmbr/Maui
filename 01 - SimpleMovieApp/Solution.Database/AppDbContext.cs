﻿namespace Solution.DataBase;

public class AppDbContext : DbContext
{
	public DbSet<MovieEntity> Movies { get; set; } //

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}
}
