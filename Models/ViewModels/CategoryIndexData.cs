namespace Moldoveanu_Alex_Laborator2.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<BookCategory> BookCategories { get; set; } 
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
