using API.Models;
using API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Controlador que maneja las operaciones relacionadas con los productos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Constructor del controlador ProductController.
        /// </summary>
        /// <param name="productService">Una instancia del servicio de productos que implementa la interfaz IProductService.</param>
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        /// <summary>
        /// Obtiene todos los productos almacenados en la base de datos.
        /// </summary>
        /// <returns>Un IActionResult que contiene una lista de ProductEntity en formato JSON si la operación es exitosa.</returns>
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = this._productService.GetAllProduct();
            return Ok(products);
        }

        /// <summary>
        /// Crea un nuevo producto en la base de datos.
        /// </summary>
        /// <param name="product">El objeto ProductModel que contiene los detalles del nuevo producto en formato JSON en el cuerpo de la solicitud.</param>
        /// <returns>Un IActionResult que indica si la operación de creación fue exitosa.</returns>
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductModel product)
        {
            this._productService.CreateProduct(product);
            return Ok();
        }

        /// <summary>
        /// Elimina un producto de la base de datos mediante su ID.
        /// </summary>
        /// <param name="id">El ID del producto a eliminar proporcionado como parámetro de consulta (query parameter).</param>
        /// <returns>Un IActionResult que indica si la operación de eliminación fue exitosa.</returns>
        [HttpDelete]
        public IActionResult DeleteProduct([FromQuery] int id)
        {
            this._productService.DeleteProduct(id);
            return Ok();
        }

        /// <summary>
        /// Obtiene un producto de la base de datos mediante su ID.
        /// </summary>
        /// <param name="id">El ID del producto a obtener proporcionado como parte de la URL.</param>
        /// <returns>Un IActionResult que contiene el objeto ProductEntity correspondiente al producto encontrado en formato JSON si la operación es exitosa.</returns>
        [HttpGet]
        [Route("getproduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProducBytId(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
