namespace FormApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();
        static Repository()
        {
            _categories.Add(new Category {CategoryId = 1, Name ="Telefon"});
            _categories.Add(new Category {CategoryId = 2, Name ="Bilgisayar"});

            _products.Add(new Product{ProductId = 1, Name="İphone 14", Price =40000, IsActive= true,Image="1.jpg",CategoryId =1});
             _products.Add(new Product{ProductId = 2, Name="İphone 15", Price =50000    , IsActive= true,Image="2.jpg",CategoryId =1});
             _products.Add(new Product{ProductId = 3, Name="İphone 13", Price =30000    , IsActive= true,Image="3.jpg",CategoryId =1});
             _products.Add(new Product{ProductId = 4, Name="İphone 13 pro", Price =35000    , IsActive= true,Image="4.jpg",CategoryId =1});

             _products.Add(new Product{ProductId = 5, Name="MackBook Air", Price =180000    , IsActive= true,Image="5m.jpg",CategoryId =2});
             _products.Add(new Product{ProductId = 6, Name="MackBook Pro", Price =200000    , IsActive= true,Image="6m.jpg",CategoryId =2});

        }
        
        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }
        public static void CreateProduct(Product entity)
        {
            _products.Add(entity);
        }
        public static void EditProduct(Product updatedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);
            if(entity != null)
            {
                entity.Name = updatedProduct.Name;
                entity.Price = updatedProduct.Price;
                entity.Image = updatedProduct.Image;
                entity.CategoryId = updatedProduct.CategoryId;
                entity.IsActive = updatedProduct.IsActive;
            }
        }
        public static void EditIsActive(Product updatedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);
            if(entity != null)
            {
                entity.IsActive = updatedProduct.IsActive;
            }
        }
         
         public static void DeleteProduct(Product deletedProduct)
         {
            var entity = _products.FirstOrDefault(p => p.ProductId == deletedProduct.ProductId);
            if(entity != null)
            {
               _products.Remove(entity);
            }
         }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }

    }
}