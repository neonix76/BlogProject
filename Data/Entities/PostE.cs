namespace BlogProject.Data.Entities
{
    public class PostE
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public int BlogEId { get; set; }
        public BlogE? BlogE { get; set; }
    }
}
