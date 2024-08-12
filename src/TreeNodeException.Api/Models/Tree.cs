public class Tree
{
    public int TreeId { get; set; }
    public string TreeName { get; set; }
    public ICollection<Node> Nodes { get; set; } = new List<Node>(); // Инициализация коллекции
}