using AutoMapper;
using BlackArm.API.DTOs.StylesDto;
using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackArm.API.Controllers;



[ApiController]
[Route("api/style")]
public class StyleController : ControllerBase
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public StyleController(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _logger = logger;
        _mapper = mapper;
    }


    [HttpGet]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)] 
    public async Task<IActionResult> GetAllStyles()
    {
        var style = await _repositoryManager.Style.GetWrestlingStylesAsync(cancellationToken: default,trackChanges:false);
        var stylesDto = _mapper.Map<IEnumerable<WrestlingStyleDto>>(style);
        return Ok(stylesDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateStyle([FromBody] WrestlingStyleForCreationDto dto)
    {
        var styleEntity = _mapper.Map<WrestlingStyle>(dto);
        _repositoryManager.Style.AddWrestlingStyle(styleEntity);
        await _repositoryManager.SaveAsync();
        
        var entityToReturn = _mapper.Map<WrestlingStyleDto>(styleEntity);

        //return CreatedAtRoute("CompetitionById", new { Id = compToReturn.CompetitionId }, compToReturn);
        return Ok(entityToReturn);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteStyle(Guid id)
    {
        var style = await _repositoryManager.Style.GetWrestlingStyleAsync(id, cancellationToken: default,trackChanges:true);
        if (style == null )
        {
            _logger.LogError($"Style with ID {id} not found");
        }
        _repositoryManager.Style.RemoveWrestlingStyle(style);
        _repositoryManager.SaveAsync();
        return NoContent();
    }
}