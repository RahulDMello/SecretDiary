using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecretDiary.Models
{
    public class DiaryEntry
    {
        [Key]
        public int EntryID { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime EntryDate { get; set; }
        public string Entry { get; set; }
    }
}