using TreeNodeException.Api.Models;

namespace TreeNodeException.Api.Repositories;

public static class NodeHelper
{
    public static async Task LoadChildrenAsync(Node node, ApplicationDbContext context)
    {
        if (node.Children != null && node.Children.Count > 0)
        {
            foreach (var child in node.Children)
            {
                await context.Entry(child).Collection(c => c.Children).LoadAsync();
                await LoadChildrenAsync(child, context); // рекурсивная загрузка
            }
        }
    }
}