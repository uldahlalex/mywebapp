using Microsoft.AspNetCore.Mvc;

namespace mywebapp.Controllers;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
}

[ApiController]
[ResponseCache(NoStore = true, Duration = 0)]
public class PetController(MyFakeDatabase db) : ControllerBase
{
    
    [Route("/api/pets")]
    [HttpGet]
    public List<Pet> GetAllPets()
    {
        return db.MyFakePetDatabase.ToList();
    }

    [HttpPost(nameof(CreatePet))]
    public ActionResult<List<Pet>> CreatePet([FromBody]Pet pet)
    {
        if (pet.Name.Length < 2)
            return BadRequest("Validation error: too short name");
        
        db.MyFakePetDatabase.Add(pet);
        return db.MyFakePetDatabase;
    }

    [HttpDelete]
    [Route("pet/{id}")]
    public Pet DeletePet([FromRoute]int id)
    {
        var pet = db.MyFakePetDatabase.First(p => p.Id == id);
        db.MyFakePetDatabase.Remove(pet);
        return pet;
    }

    [HttpPut]
    [Route("pet/{id}")]
    public Pet UpdatePet([FromRoute] int id, [FromBody] Pet pet)
    {
        var existingPet = db.MyFakePetDatabase.First(p => p.Id == id);
        existingPet.Name = pet.Name;
        return existingPet;
    }
    
}