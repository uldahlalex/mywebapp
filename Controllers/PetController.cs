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
    public List<Pet> CreatePet([FromBody]Pet pet)
    {
        db.MyFakePetDatabase.Add(pet);
        return db.MyFakePetDatabase;
    }
    
    //todo: Create PUT/update method + DELETE method
    
}