using API.Data;
using API.Models;

namespace API.Service
{


    public class ProductService : IProductService
    {
        private readonly StoreDBContext _context;

        /// <summary>
        /// Constructor de la clase ProductService.
        /// </summary>
        /// <param name="context">El contexto de la base de datos.</param>
        public ProductService(StoreDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Crea un nuevo producto en la base de datos.
        /// </summary>
        /// <param name="product">El objeto ProductModel con los detalles del producto a crear.</param>
        public void CreateProduct(ProductModel product)
        {
            ProductEntity productEntity = new()
            {
                Name = product.Name,
                Description = product.Description,
                Stock = product.Stock,
                CreateDate = DateTime.Now
            };
            _context.Products.Add(productEntity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Elimina un producto de la base de datos mediante su ID.
        /// </summary>
        /// <param name="id">El identificador único del producto a eliminar.</param>
        public void DeleteProduct(int id)
        {
            ProductEntity productDelete = this.GetProducBytId(id);
            _context.Products.Remove(productDelete);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtiene un producto de la base de datos mediante su ID.
        /// </summary>
        /// <param name="id">El identificador único del producto a recuperar.</param>
        /// <returns>El objeto ProductEntity correspondiente al producto encontrado, o null si no se encuentra.</returns>
        public ProductEntity GetProducBytId(int id)
        {
            return _context.Products.Find(id);
        }

        /// <summary>
        /// Obtiene una lista de todos los productos almacenados en la base de datos.
        /// </summary>
        /// <returns>Una lista de ProductEntity que contiene todos los productos.</returns>
        public List<ProductEntity> GetAllProduct()
        {
            return _context.Products.ToList();
        }

        /// <summary>
        /// Actualiza la información de un producto existente en la base de datos.
        /// </summary>
        /// <param name="product">El objeto ProductModel con los nuevos detalles del producto.</param>
        public void UpdateProduct(ProductModel product)
        {
            ProductEntity productEntity = new()
            {
                Name = product.Name,
                Description = product.Description,
                Stock = product.Stock,
                CreateDate = DateTime.Now
            };
            _context.Products.Update(productEntity);
            _context.SaveChanges();

            // Puedes manejar aquí el caso en que el producto no exista si es necesario.
        }

        /// <summary>
        /// Elimina varios productos de la base de datos de una sola vez, utilizando una lista de IDs de productos.
        /// </summary>
        /// <param name="ids">Una lista de enteros con los identificadores únicos de los productos a eliminar en lote.</param>
        public void DeleteProducts(List<int> ids)
        {
            var productsToDelete = _context.Products.Where(p => ids.Contains(p.Id)).ToList();
            _context.Products.RemoveRange(productsToDelete);
            _context.SaveChanges();
        }

    }
}
