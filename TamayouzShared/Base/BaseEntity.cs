using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TamayouzShared.Utils;

namespace TamayouzShared.Base
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        private DateTime? createdDate;

        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }
        public bool isActive { get; set; } 

        public string baseUrl() { return Constanse.BaseUrl + Constanse.UploadsDir; }
    }
}
