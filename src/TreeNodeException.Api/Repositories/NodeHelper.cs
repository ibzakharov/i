using TreeNodeException.Api.Models;

namespace TreeNodeException.Api.Repositories;

public static class NodeHelper
{
    public static async Task LoadChildrenAsync(Node node, ApplicationDbContext context)
    {
        if (node.Child != null && node.Child.Count > 0)
        {
            foreach (var child in node.Child)
            {
                await context.Entry(child).Collection(c => c.Child).LoadAsync();
                await LoadChildrenAsync(child, context); // рекурсивная загрузка
            }
        }
    }
}