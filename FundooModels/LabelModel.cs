using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModels
{
   public class LabelModel
    {
        [Key]
        public int LabelId { get; set; }

        public int? NotesId { get; set; }

        [ForeignKey("NotesId")]
        public NotesModel NotesModel { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel UserModel { get; set; }

        [Required]
        public string LabelName { get; set; }

    }
}
