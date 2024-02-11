namespace Equitel.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        public string? Descripcion { get; set; }

        public string? Modelo { get; set; }

        public int? CantidadEnBodega { get; set; }

        public decimal? ValorVenta { get; set; }
    }
}