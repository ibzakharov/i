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
    public async Task<ActionResult<NodeDto>> CreateNode(
        [Required] string treeName,
        int? parentNodeId,
        [Required] string nodeName)
    {
        var tree = await _treeRepository.GetTreeByNameAsync(treeName);

        if (tree == null)
        {
            throw TreeNotFoundException.Throw();
        }

        if (parentNodeId != null)
        {
            var parentNode = await _nodeRepository.GetNodeByIdAsync(parentNodeId.Value);
            if (parentNode == null)
            {
                throw NodeNotFoundException.Throw();
            }
        }

        var node = await _nodeRepository.GetNodeByNameAsync(tree.TreeId, nodeName);
        if (node != null)
        {
            throw NodeAlreadyExistsException.Throw();
        }

        node = new Node
        {
            ParentId = parentNodeId,
            TreeId = tree.TreeId,
            Name = nodeName
        };

        await _nodeRepository.AddNodeAsync(node);

        return Ok();
    }

    [HttpPost("rename")]
    public async Task<IActionResult> RenameNode(
        [Required] string treeName,
        [Required] int nodeId,
        [Required] string newNodeName)
    {
        var tree = await _treeRepository.GetTreeByNameAsync(treeName);

        if (tree == null)
        {
            throw TreeNotFoundException.Throw();
        }

        var node = await _nodeRepository.GetNodeByIdAsync(nodeId);
        if (node == null)
        {
            throw NodeNotFoundException.Throw();
        }

        node.Name = newNodeName;

        await _nodeRepository.UpdateNodeAsync(node);

        return Ok();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteNode(
        [Required] string treeName,
        [Required] int nodeId)
    {
        var tree = await _treeRepository.GetTreeByNameAsync(treeName);

        if (tree == null)
        {
            throw TreeNotFoundException.Throw();
        }

        var node = await _nodeRepository.GetNodeByIdAsync(nodeId);
        if (node == null)
        {
            throw NodeNotFoundException.Throw();
        }

        await _nodeRepository.DeleteNodeAsync(node);

        return Ok();
    }
}