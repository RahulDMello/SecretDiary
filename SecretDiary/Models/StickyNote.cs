using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecretDiary.Models
{
    public class StickyNote
    {
        [Key]
        public int EntryID { get; set; }
        public string UserID { get; set; }
        public string Entry { get; set; }
    }
}