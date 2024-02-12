using Equitel.Models;

namespace Equitel.Services.Contrato
{
    public interface IProductoService
    {
        Task<List<Producto>> GetListProducto(); 
        Task<Producto> GetProducto(int idProducto);
        Task<Producto> AddProducto(Producto modelo);
        Task<bool> UpdateProducto(Producto modelo);
        Task<bool> DeleteProducto(Producto modelo);
    }
}
