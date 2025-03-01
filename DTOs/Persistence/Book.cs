using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs.Persistence
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        [ForeignKey("AuthorID")]
        public virtual Author Author { get; set; }
        public int AuthorID { get; set; }

    }
}
