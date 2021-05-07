using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_App_NetCore.Model {
    public class ProductsModel {
        public string NombreProducto { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public short? UnidadesDisponibles { get; set; }
    }
}
