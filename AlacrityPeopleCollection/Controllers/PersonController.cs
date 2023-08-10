using AlacrityPeopleCollection.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlacrityPeopleCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private static readonly List<Person> People = new List<Person>
        {
            new Person()
            {
                PersonId = 1,
                Name = "Alice",
                Age = 20
            },
            new Person()
            {
                PersonId = 2,
                Name = "Bob",
                Age = 25
            },
            new Person()
            {
                PersonId = 3,
                Name = "Carol",
                Age= 30
            },
            new Person()
            {
                PersonId= 4,
                Name = "Dave",
                Age = 35
            }
        };


        // GET: api/<PersonController>
        [HttpGet]
        public List<Person> Get()
        {
            return People;
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            foreach (Person person in People)
            {
                if (person.PersonId == id)
                {
                    return person;
                }
            }
            return new Person();
            // return "Person with that ID does not exist";
        }

        // POST api/<PersonController>
        [HttpPost]
        public List<Person> Post([FromBody] PersonPostRequestModel newPerson)
        {
            int? newPersonId = People.Last().PersonId + 1;

            Person CreatedPerson = new()
            {
                PersonId = newPersonId,
                Name = newPerson.Name,
                Age = newPerson.Age
            };

            People.Add(CreatedPerson);

            return People;

        }

        [HttpGet("/youngest")]
        public Person GetYoungestOrOldestPerson()
        {
            return People.MinBy(x => x.Age);
        }

        [HttpGet("/oldest")]
        public Person GetOldestPerson()
        {
            return People.MaxBy(x => x.Age);
        }

        [HttpGet("/averageAge")]
        public decimal GetAverageAge()
        {
            int? ages = People.Sum(x => x.Age);
            return (int)ages/People.Count;
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public List<Person> Delete(int id)
        {
            foreach (Person person in People)
            {
                if (person.PersonId == id)
                {
                    People.Remove(person);
                    return People;
                }
            }
                return People;
        }

    }
}
