using CafeteriaWebApi.Data.Entities;

namespace CafeteriaWebApi.Services.Interfaces
{
    public interface IProductService
    {
        public int CreateProduct(Product product);
        public int UpdateProduct(Product product);
        public void DeleteProduct(int productId);
        public Product GetProductById(int id);
        public List<Product> GetAllProducts();

    }
}
