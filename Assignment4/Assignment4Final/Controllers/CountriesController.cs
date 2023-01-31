using Assignment4Final.Services;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models.DTO;
using ModelLibrary.Models.DTO.Candidates;

namespace Assignment4Final.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly CountryService _countryService;

    public CountriesController(CountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var countries = await _countryService.GetAllAsync();
        var response = new BaseResponse<List<CountryDto>>
        {
            RequestId = Request.HttpContext.TraceIdentifier,
            Success = true,
            Data = countries
        };

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var country = await _countryService.GetAsync(id);
        if (country == null)
        {
            return NotFound(
                new BaseResponse<CountryDto>
                {
                    RequestId = Request.HttpContext.TraceIdentifier,
                    Success = false,
                    Message = $"Country with id {id} not found."
                }
            );
        }

        var response = new BaseResponse<CountryDto>
        {
            RequestId = Request.HttpContext.TraceIdentifier,
            Success = true,
            Data = country
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CountryDto countryDto)
    {
        var addedCountry = await _countryService.AddAsync(countryDto);
        if (addedCountry == null)
        {
            return BadRequest(
                new BaseResponse<CountryDto>
                {
                    RequestId = Request.HttpContext.TraceIdentifier,
                    Success = false,
                    Message = "Failed to add country."
                }
            );
        }

        var response = new BaseResponse<CountryDto>
        {
            RequestId = Request.HttpContext.TraceIdentifier,
            Success = true,
            Data = addedCountry
        };

        return CreatedAtAction(nameof(Get), new { id = addedCountry.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CountryDto countryDto)
    {
        var updatedCountry = await _countryService.UpdateAsync(id, countryDto);
        if (updatedCountry == null)
        {
            return NotFound(
                new BaseResponse<CountryDto>
                {
                    RequestId = Request.HttpContext.TraceIdentifier,
                    Success = false,
                    Message = $"Country with id {id} not found."
                }
            );
        }

        var response = new BaseResponse<CountryDto>
        {
            RequestId = Request.HttpContext.TraceIdentifier,
            Success = true,
            Data = updatedCountry
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedCountry = await _countryService.DeleteAsync(id);
        if (deletedCountry == null)
        {
            return NotFound(
                new BaseResponse<CountryDto>
                {
                    RequestId = Request.HttpContext.TraceIdentifier,
                    Success = false,
                    Message = $"Country with id {id} not found."
                }
            );
        }

        var response = new BaseResponse<CountryDto>
        {
            RequestId = Request.HttpContext.TraceIdentifier,
            Success = true,
            Data = deletedCountry
        };

        return Ok(response);
    }
}
