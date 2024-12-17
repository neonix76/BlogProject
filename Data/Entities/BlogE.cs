namespace BlogProject.Data.Entities
{
    public class BlogE
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PostE> Posts { get; set; } = new List<PostE>();
    }
}
