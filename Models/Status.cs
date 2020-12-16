using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace $safeprojectname$.Models
{
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string pedido { get; set; }
        public string status { get; set; }
        public long? itensAprovados { get; set; }
        public long? valorAprovado { get; set; }
    }
}
