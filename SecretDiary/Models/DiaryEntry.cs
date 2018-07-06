using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace SecretDiary.Models
{
    //[Validator(typeof(DiaryEntryValidator))]
    public class DiaryEntry
    {
        [Key]
        public int EntryID { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }
        public string Entry { get; set; }
    }

    //public class diaryentryvalidator : abstractvalidator<diaryentry>
    //{
    //    public diaryentryvalidator()
    //    {
    //        rulefor(x => new validatorhelper{ entrydate = x.entrydate, userid = x.userid, user = x.user }).must(beuniqueurl).withmessage("you already have an entry for this date.");
    //    }

    //    private bool beuniqueurl(validatorhelper vhelper)
    //    {
    //        return new applicationdbcontext().entries.firstordefault(x => dbfunctions.truncatetime(x.entrydate) == vhelper.entrydate.date && x.userid == vhelper.userid) == null;
    //    }
    //}

    //public class validatorhelper
    //{
    //    public datetime entrydate;
    //    public string userid;
    //    public applicationuser user;
    //}

}