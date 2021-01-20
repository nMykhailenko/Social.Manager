using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Social.Manager.BLL.PersonalInformations.Contract;
using Social.Manager.BLL.PersonalInformations.ModelsDto;
using Social.Manager.DAL.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Social.Manager.BLL.PersonalInformations
{
    public class PersonalInformationService : IPersonalInformationService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public PersonalInformationService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<PersonalInformationDto>> GetByPagesAsync(int skip = 0, int take = 20)
        {
            var entities = await _context.PersonnalInformations
                .OrderBy(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            var result = _mapper.Map<IEnumerable<PersonalInformationDto>>(entities);
            return result;
        }

        public async Task<IEnumerable<PersonalInformationDto>> SearchAsync(SearchPersonalInformationDto searchDto)
        {
            var query = _context.PersonnalInformations.AsQueryable();
            if (searchDto.HasFacebookLink.HasValue)
            {
                query = query.Where(x => !string.IsNullOrEmpty(x.FacebookLink) == searchDto.HasFacebookLink.Value);
            }

            var entities = await query.ToListAsync();
            
            var result = _mapper.Map<IEnumerable<PersonalInformationDto>>(entities);
            return result;
        }
    }
}
