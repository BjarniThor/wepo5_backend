﻿using System.Data.Entity;

namespace verk5.Models
{
    public class verk5Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<verk5.Models.verk5Context>());

        public verk5Context() : base("name=DefaultConnection")
        {
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Video> Videos { get; set; }
    }
}
