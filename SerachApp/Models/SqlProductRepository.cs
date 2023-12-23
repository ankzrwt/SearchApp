using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SerachApp.Models
{
    public class SqlProductRepository: IProductRepository
    {
        private AppDbContext context;

        public SqlProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<Product> GetAll()
        {
            foreach(var product in context.products)
            {
                Console.WriteLine(product.ProductId);
            }
            return context.products.ToList();
        }

        public List<Product> getFilterResult(FilterModel filterModel)
        {
            var result = new List<Product>();
            string productName = filterModel.ProductName ?? null;
            string size = filterModel.Size ?? null;
            string Conjunction = filterModel.Conjunction ?? null;
            string Category = filterModel.Category ?? null;
            int? price = filterModel.Price ?? null ;
            DateTime? mfgDate = filterModel.MfgDate ?? null;
            Console.WriteLine(filterModel.MfgDate);


            Console.WriteLine(filterModel.Price);
            try
            {
                result = context.products.FromSqlRaw("EXEC SearchProducts @productName, @Size, @Price,@MfgDate, @Category,@Conjunction",
                                                    new SqlParameter("@productName", (object)productName ?? DBNull.Value),
                                                    new SqlParameter("@Size", (object)size ?? DBNull.Value), 
                                                    new SqlParameter("@Price", (object)price ?? DBNull.Value),
                                                    new SqlParameter("@MfgDate",(object)mfgDate ?? DBNull.Value),
                                                    new SqlParameter("@Category", (object)Category ?? DBNull.Value),
                                                    new SqlParameter("@Conjunction", (object)Conjunction ?? DBNull.Value)

                                                    ).ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
    }
}
