using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TreeNodeException.Api.DTO;
using TreeNodeException.Api.Models;
using TreeNodeException.Api.Repositories;

namespace TreeNodeException.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreeController : ControllerBase
{
    private readonly ITreeRepository _treeRepository;
    private readonly IMapper _mapper;

    public TreeController(ITreeRepository treeRepository, IMapper mapper)
    {
        _treeRepository = treeRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TreeDTO>>> GetTrees()
    {
        var trees = await _treeRepository.GetAllTreesAsync();
        return Ok(_mapper.Map<IEnumerable<TreeDTO>>(trees));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TreeDTO>> GetTree(int id)
    {
        var tree = await _treeRepository.GetTreeByIdAsync(id);

        if (tree == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<TreeDTO>(tree));
    }

    [HttpGet("{id}/nodes")]
    public async Task<ActionResult<TreeNodesDTO>> GetTreeNodes(int id)
    {
        var tree = await _treeRepository.GetTreeByIdAsync(id);

        if (tree == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<TreeNodesDTO>(tree));
    }

    [HttpPost]
    public async Task<ActionResult<TreeDTO>> PostTree(ModifyTreeDTO treeDto)
    {
        var tree = _mapper.Map<Tree>(treeDto);
        tree = await _treeRepository.AddTreeAsync(tree);

        return CreatedAtAction(nameof(GetTree), new { id = tree.TreeID }, _mapper.Map<TreeDTO>(tree));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTree(int id, ModifyTreeDTO modifyTreeDto)
    {
        var tree = await _treeRepository.GetTreeByIdAsync(id);

        if (tree == null)
        {
            return NotFound();
        }

        _mapper.Map(modifyTreeDto, tree);
        await _treeRepository.UpdateTreeAsync(tree);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTree(int id)
    {
        var tree = await _treeRepository.GetTreeByIdAsync(id);
        if (tree == null)
        {
            return NotFound();
        }

        await _treeRepository.DeleteTreeAsync(id);

        return NoContent();
    }
}