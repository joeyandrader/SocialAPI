using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Facade
{
    public class PersonFacade(IPersonService _personService)
    {
        public async Task<Person> CreateAsync(Person createDTO)
        {
            return await _personService.CreateAsync(createDTO);
        }
    }
}
