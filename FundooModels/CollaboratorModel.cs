﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModels
{
    public class CollaboratorModel
    {
        [Key]
        public int ColId { get; set; }

        
        public int NotesId { get; set; }

        
        [ForeignKey("NotesId")]
        public NotesModel notesModel { get; set; }

        
        [Required]     
        public string ColEmail { get; set; }
    }
}
