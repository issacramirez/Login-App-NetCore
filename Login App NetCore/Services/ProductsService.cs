using Login_App_NetCore.DataAccess;
using Login_App_NetCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_App_NetCore.Services {
    public class ProductsService : ContextService {

        public IQueryable<Products> GetAllProducts() {
            return dataContext.Products.Select(s => s);
        }

        public Products GetProductById(int id) {
            var product = GetAllProducts().Where(w => w.ProductId == id).FirstOrDefault();
            if(product == null)
                throw new Exception("El id del producto ingresado no existe");
            return product;
        }

        public void UpdateProductPriceById(int id, decimal newPrice) {
            Products product = GetProductById(id);
            product.UnitPrice = newPrice;
            dataContext.SaveChanges();
        }

        public void DeleteProductById(int id) {
            Products product = GetProductById(id);
            dataContext.Products.Remove(product);
            dataContext.SaveChanges();
        }

        public void CreateNewProduct(ProductsModel Product) {
            var newProduct = new Products() {
                ProductName = Product.NombreProducto,
                UnitPrice = Product.PrecioUnitario,
                UnitsInStock = Product.UnidadesDisponibles
            };

            dataContext.Products.Add(newProduct);
            dataContext.SaveChanges();
        }
    }
}
