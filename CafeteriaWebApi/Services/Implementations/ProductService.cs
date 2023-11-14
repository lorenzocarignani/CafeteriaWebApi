using CafeteriaWebApi.Data;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Services.Interfaces;

namespace CafeteriaWebApi.Services.Implementations
{
    public class ProductService : IProductService
    {
        readonly CafeteriaContext _context;
        public ProductService(CafeteriaContext context)
        {
            _context = context;
        }

        public int CreateProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return product.IdProduct;
        }

        public void DeleteProduct(int productId)
        {
            var id =_context.Products.SingleOrDefault(p => p.IdProduct == productId);
            _context.Remove(id);
            _context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
             return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.IdProduct == id);
        }

        public int UpdateProduct(Product product)
        {

        var existingProduct = _context.Products.SingleOrDefault(u => u.IdProduct == product.IdProduct);

        if (existingProduct == null)
            {
                return 0;
            }

            existingProduct.NameProduct = product.NameProduct;
            existingProduct.Price = product.Price;

            _context.Update(existingProduct);
            _context.SaveChanges();
            return existingProduct.IdProduct;

        }
    }
}
