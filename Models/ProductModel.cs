
namespace API.Models
{
    public class ProductModel
    {
        /// <summary>
        /// Obtiene o establece el nombre del producto.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del producto.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad en stock del producto.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de creación del producto.
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
