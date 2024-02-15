using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblData-DMS-Providers", Schema = "dbo")]
    public partial class TblDataDmSProvider
    {
        [Key]
        [Required]
        public int fldRecordID { get; set; }

        public string fldDMS_Company_Name { get; set; }

        public string fldDMS_Provider_Code { get; set; }

        public string fldDMS_Contact_Email { get; set; }

        public string fldDMS_Contact_Name { get; set; }

        public string fldDMS_Notes { get; set; }

        public string fldRecordIndex { get; set; }

        public short? fldIntegration_Type { get; set; }

        public string fldFTP_FolderName { get; set; }

        public string fldFTP_File_Extensions { get; set; }

        public string fldFTP_File_Prefixes { get; set; }

        public string fldFTP_Sample_Filename { get; set; }

        public bool? fldFTP_File_Compressed { get; set; }

        public bool? fldFTP_SubFolders { get; set; }

        public bool? fldFTP_MultipleFilesOneRecord { get; set; }

        public string fldFTP_NotesAboutProcessingFiles { get; set; }

        public DateTime? fldLastModifiedDate { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}