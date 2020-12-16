using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace $safeprojectname$.Models
{
    public class Mpedido
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int PedidosID { get; set; }
        public string pedido { get; set; }
        public IList<Item> itens { get; set; } = new List<Item>();
    }
}
