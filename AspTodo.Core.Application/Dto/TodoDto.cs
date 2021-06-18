namespace AspTodo.Core.Application.Dto
{
    public class TodoDto
    {
        public int Id { get; set; }
        
        public bool Deleted { get; set; }
        
        public string CreatedAt { get; set; }
        
        public string UpdatedAt { get; set; }
        
        public string DeletedAt { get; set; }
    }
}