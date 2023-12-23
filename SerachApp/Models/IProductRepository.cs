namespace SerachApp.Models
{
    public interface IProductRepository
    {
        public List<Product> GetAll();

        public List<Product> getFilterResult(FilterModel filterModel);
    }
}
