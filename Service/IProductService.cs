using API.Models;

namespace API.Service
{
    /// <summary>
    /// Interfaz que define los métodos para realizar operaciones relacionadas con la gestión de productos.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Crea un nuevo producto en la base de datos.
        /// </summary>
        /// <param name="product">El objeto ProductModel con los detalles del producto a crear.</param>
        void CreateProduct(ProductModel product);

        /// <summary>
        /// Elimina un producto de la base de datos mediante su ID.
        /// </summary>
        /// <param name="id">El identificador único del producto a eliminar.</param>
        void DeleteProduct(int id);

        /// <summary>
        /// Actualiza la información de un producto existente en la base de datos.
        /// </summary>
        /// <param name="product">El objeto ProductModel con los nuevos detalles del producto.</param>
        void UpdateProduct(ProductModel product);

        /// <summary>
        /// Obtiene una lista de todos los productos almacenados en la base de datos.
        /// </summary>
        /// <returns>Una lista de ProductEntity que contiene todos los productos.</returns>
        List<ProductEntity> GetAllProduct();

        /// <summary>
        /// Obtiene un producto de la base de datos mediante su ID.
        /// </summary>
        /// <param name="id">El identificador único del producto a recuperar.</param>
        /// <returns>El objeto ProductEntity correspondiente al producto encontrado, o null si no se encuentra.</returns>
        ProductEntity GetProducBytId(int id);

        /// <summary>
        /// Elimina varios productos de la base de datos de una sola vez, utilizando una lista de IDs de productos.
        /// </summary>
        /// <param name="ids">Una lista de enteros con los identificadores únicos de los productos a eliminar en lote.</param>
        void DeleteProducts(List<int> ids);
    }
}