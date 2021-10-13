using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModels
{
    public class NotesModel
    {
        [Key]
        public int NotesId { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public string Remainder { get; set; }

        public string Color { get; set; }

        public string Image { get; set; }

        [DefaultValue(false)]
        public bool Is_Archive { get; set; }

        [DefaultValue(false)]
        public bool Is_Trash { get; set; }

        [DefaultValue(false)]
        public bool Is_Pin { get; set; }


        [ForeignKey("UserModel")]
        public int UserId { get; set; }

        public virtual UserModel UserModel { get; set; }
    }
}
