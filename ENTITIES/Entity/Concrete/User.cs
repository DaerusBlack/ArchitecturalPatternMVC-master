using ENTITIES.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entity.Concrete
{
    [Table("Users")]
    public class User :BaseEntity
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz")]        
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre Boş Bırakılamaz")]
        public string Password { get; set; }

        public List<Article> Articles { get; set; }
    }
}
