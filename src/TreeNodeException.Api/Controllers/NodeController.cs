using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TreeNodeException.Api.Dtos;
using TreeNodeException.Api.Exceptions;
using TreeNodeException.Api.Repositories;

[Route("api/node")]
[ApiController]
public class NodeController : ControllerBase
{
    private readonly INodeRepository _nodeRepository;
    private readonly ITreeRepository _treeRepository;

    public NodeController(INodeRepository nodeRepository, ITreeRepository treeRepository)
    {
        _nodeRepository = nodeRepository;
        _treeRepository = treeRepository;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateNode(
        [FromQuery, Required] string treeName,
        [FromQuery, Required] int parentNodeId,
        [FromQuery, Required] string nodeName)
    {
        var parentNode = await _nodeRepository.GetNodeByIdAndNameAsync(parentNodeId, treeName);

        if (parentNode == null)
        {
            throw NodeNotFoundException.Throw(parentNodeId);
        }

        var node = await _nodeRepository.GetNodeByParentIdAndNameAsync(parentNodeId, nodeName);
        if (node != null)
        {
            throw NodeDuplicateNameException.Throw();
        }

        node = new Node
        {
            ParentId = parentNodeId,
            Name = nodeName
        };

        await _nodeRepository.AddNodeAsync(node);

        return Ok();
    }

    [HttpPost("rename")]
    public async Task<IActionResult> RenameNode(
        [FromQuery, Required] string treeName,
        [FromQuery, Required] int nodeId,
        [FromQuery, Required] string newNodeName)
    {
        var node = await FindNodeAsync(treeName, nodeId);

        if (node == null)
        {
            throw NodeNotFoundException.Throw(nodeId);
        }

        node.Name = newNodeName;

        await _nodeRepository.UpdateNodeAsync(node);

        return Ok();
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteNode(
        [FromQuery, Required] string treeName,
        [FromQuery, Required] int nodeId)
    {
        var node = await FindNodeAsync(treeName, nodeId);

        if (node.Children.Count > 0)
        {
            throw NodeContainsChildrenException.Throw();
        }

        await _nodeRepository.DeleteNodeAsync(node);

        return Ok();
    }

    private async Task<Node> FindNodeAsync(string treeName, int nodeId)
    {
        var tree = await _treeRepository.GetTreeChildrenByNameAsync(treeName);

        if (tree == null)
        {
            throw TreeNotFoundException.Throw(treeName);
        }

        return FindNodeById(tree, nodeId);
    }

    private Node FindNodeById(Node node, int nodeId)
    {
        if (node.NodeId == nodeId)
        {
            return node;
        }

        foreach (var child in node.Children)
        {
            var result = FindNodeById(child, nodeId);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }
}