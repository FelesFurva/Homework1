namespace DataAccess.Context.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}