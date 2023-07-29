using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    /// <summary>
    /// Clase que representa el contexto de la base de datos para la tienda.
    /// </summary>
    public class StoreDBContext : DbContext
    {
        /// <summary>
        /// Constructor de la clase StoreDBContext.
        /// </summary>
        /// <param name="options">Las opciones de configuración para el contexto de la base de datos.</param>
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options)
        {

        }

        /// <summary>
        /// Obtiene o establece el conjunto de entidades para la tabla de productos en la base de datos.
        /// </summary>
        public DbSet<ProductEntity> Products { get; set; }
    }
}
