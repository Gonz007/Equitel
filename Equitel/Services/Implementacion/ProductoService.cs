using Microsoft.EntityFrameworkCore;
using Equitel.Models;
using Equitel.Services.Contrato;

namespace Equitel.Services.Implementacion
{
    public class ProductoService : IProductoService
    {
        private EquitelContext _dbContext;

        public ProductoService (EquitelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Producto> AddProducto(Producto modelo)
        {
            try
            {
                _dbContext.Productos.Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> DeleteProducto(Producto modelo)
        {
            try
            {
                _dbContext.Productos.Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Producto>> GetListProducto()
        {

            try
            {
                List<Producto> lista = new List<Producto>();
                lista = await _dbContext.Productos.ToListAsync();
                return lista;

            }catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<Producto> GetProducto(int idProducto)
        {
            try
            {
                Producto? find = new Producto();
                find = await _dbContext.Productos.FirstOrDefaultAsync(x => x.Id == idProducto);
                return find;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateProductoo(Producto modelo)
        {
            try
            {
                _dbContext.Productos.Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
