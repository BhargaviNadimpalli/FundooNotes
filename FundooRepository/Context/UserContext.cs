using FundooModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Context
{
    public class UserContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<NotesModel> notes { get; set; }

        public DbSet<CollaboratorModel> collaborators { get; set; }     
        public UserContext(DbContextOptions options) : base(options)
        {
          
        }

    }
}
