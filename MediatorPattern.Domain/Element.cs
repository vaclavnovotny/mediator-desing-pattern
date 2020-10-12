namespace MediatorPattern.Domain
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ImageId { get; set; }
        public virtual Size Size { get; set; }
        public virtual Position Position { get; set; }
    }
}
