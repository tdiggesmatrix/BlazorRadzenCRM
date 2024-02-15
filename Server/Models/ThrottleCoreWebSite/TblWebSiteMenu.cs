using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite
{
    [Table("tblWebSiteMenu", Schema = "dbo")]
    public partial class TblWebSiteMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public int? fldParentID { get; set; }

        public bool? fldEnabled { get; set; }

        public string fldSection { get; set; }

        [Column("fldMenu-Name")]
        public string fldMenuName { get; set; }

        public int? fldLanguage_RecordID { get; set; }

        [Column("fldMenu-Caption")]
        public string fldMenuCaption { get; set; }

        [Column("fldMenu-IconName")]
        public string fldMenuIconName { get; set; }

        public string fldAction { get; set; }

        public string fldActivity { get; set; }

        public short? fldOrder { get; set; }

        public bool? fldVisible { get; set; }

        public string fldSecurityKey { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}