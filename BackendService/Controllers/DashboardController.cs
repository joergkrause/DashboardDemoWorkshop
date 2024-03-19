using BusinessLogicLayer;
using BusinessLogicLayer.TransferObjects;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public class DashboardController(IDashboardWidgetManager manager) : ControllerBase
  {

    [HttpGet(Name = "GetDashboards")]
    [ProducesResponseType(typeof(IEnumerable<DashboardDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
      var dtos = await manager.GetDashboards();
      return Ok(dtos);
    }

    [HttpGet("{id:int}", Name = "GetDashboardById")]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(DashboardDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      try
      {
        var dto = await manager.GetDashboardById(id);
        if (dto == null)
        {
          return NotFound();
        }
        return Ok(dto);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("search", Name = "SearchDashboards")]
    [ProducesResponseType(typeof(IEnumerable<DashboardListDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Search([FromQuery] string name)
    {
      //var   dtos = manager.GetDashboards(name);
      //return Ok(dtos);
      throw new NotImplementedException();
    }

    [HttpPost(Name = "CreateDashboard")]
    [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody]  DashboardCreateDto dto)
    {
      await manager.CreateDashboard(dto);
      return Created();
    }

    [HttpPut("{id:int}", Name = "UpdateDashboard")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] DashboardUpdateDto dto)
    {
      dto.Id = id;
      await manager.UpdateDashboard(dto);
      return NoContent();
    }

    [HttpDelete("{id:int}", Name = "DeleteDashboard")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      // await manager.DeleteDashboard(id);
      return NoContent();
    }
  }
}
