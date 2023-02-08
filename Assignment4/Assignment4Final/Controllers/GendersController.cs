using Assignment4Final.Services;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models.DTO;
using ModelLibrary.Models.DTO.Candidates;

namespace Assignment4Final.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
public class GendersController : ControllerBase
{
    private readonly GendersService _gendersService;

    public GendersController(GendersService gendersService)
    {
        _gendersService = gendersService;
    }

    [HttpGet]
    // [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var genders = await _gendersService.GetAllAsync();
        var response = new BaseResponse<List<GenderDto>>
        {
            RequestId = Request.HttpContext.TraceIdentifier,
            Success = true,
            Data = genders
        };

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var gender = await _gendersService.GetAsync(id);
        if (gender == null)
        {
            return NotFound(
                new BaseResponse<GenderDto>
                {
                    RequestId = Request.HttpContext.TraceIdentifier,
                    Success = false,
                    Message = $"Gender with id {id} not found."
                }
            );
        }

        var response = new BaseResponse<GenderDto>
        {
            RequestId = Request.HttpContext.TraceIdentifier,
            Success = true,
            Data = gender
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] GenderDto genderDto)
    {
        var addedGender = await _gendersService.AddAsync(genderDto);
        if (addedGender == null)
        {
            return BadRequest(
                new BaseResponse<GenderDto>
                {
                    RequestId = Request.HttpContext.TraceIdentifier,
                    Success = false,
                    Message = "Failed to add gender."
                }
            );
        }

        var response = new BaseResponse<GenderDto>
        {
            RequestId = Request.HttpContext.TraceIdentifier,
            Success = true,
            Data = addedGender
        };

        return CreatedAtAction(nameof(Get), new { id = addedGender.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] GenderDto genderDto)
    {
        var updatedGender = await _gendersService.UpdateAsync(id, genderDto);
        if (updatedGender == null)
        {
            return NotFound(
                new BaseResponse<GenderDto>
                {
                    RequestId = Request.HttpContext.TraceIdentifier,
                    Success = false,
                    Message = $"Gender with id {id} not found."
                }
            );
        }

        var response = new BaseResponse<GenderDto>
        {
            RequestId = Request.HttpContext.TraceIdentifier,
            Success = true,
            Data = updatedGender
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedGender = await _gendersService.DeleteAsync(id);
        if (deletedGender == null)
        {
            return NotFound(
                new BaseResponse<GenderDto>
                {
                    RequestId = Request.HttpContext.TraceIdentifier,
                    Success = false,
                    Message = $"Gender with id {id} not found."
                }
            );
        }

        var response = new BaseResponse<GenderDto>
        {
            RequestId = Request.HttpContext.TraceIdentifier,
            Success = true,
            Data = deletedGender
        };

        return Ok(response);
    }
}
