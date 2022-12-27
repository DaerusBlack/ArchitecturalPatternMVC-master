using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entity.Abstract
{
    public enum Status { Active =1, Modified, Passive}
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        DateTime _createDate = DateTime.Now;

        public DateTime CreateDate 
        {
            get => _createDate;
            set => _createDate = value; 
        }

        public DateTime? UpdateDate{ get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get => _status; set => _status = value; }

        Status _status = Status.Active;
    }
}
