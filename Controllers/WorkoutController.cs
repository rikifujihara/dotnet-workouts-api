using Microsoft.AspNetCore.Mvc;
using workoutsbackend.Services;
using workoutsbackend.Models;
using Microsoft.AspNetCore.Components;
using Amazon.SecurityToken.Model;

namespace workoutsbackend.Controllers;

[Controller]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
public class WorkoutController : Controller
{
    private readonly MongoDBService _mongoDBService;

    public WorkoutController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Workout>> Get()
    {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Workout workout)
    {
        await _mongoDBService.CreateAsync(workout);
        return CreatedAtAction(nameof(Get), new { id = workout.Id }, workout);
    }

    [HttpPut]
    [Microsoft.AspNetCore.Mvc.Route("{id}")]
    public async Task<IActionResult> Put([FromRoute] string id, [FromBody] Workout workout)
    {
        await _mongoDBService.ReplaceAsync(id, workout);
        return Ok();
    }

    [HttpDelete]
    [Microsoft.AspNetCore.Mvc.Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }

}
