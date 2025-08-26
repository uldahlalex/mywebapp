using Microsoft.AspNetCore.Mvc;

namespace mywebapp.Controllers;

public class Pet
{
    public string Name { get; set; }
}

[ApiController]
public class PetController(MyFakeDatabase db) : ControllerBase
{
    
    [Route("/api/pets")]
    [HttpGet]
    public List<Pet> GetAllPets()
    {
        return db.MyFakePetDatabase;
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
    public object DeletePet([FromRoute]int id)
    {
        //lookup in the DB first pet with id = id and delete it (optionally return it)
        return id;
    }
    
    //todo: Create PUT/update method + DELETE method
    
}