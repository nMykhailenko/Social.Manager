using AutoMapper;
using Social.Manager.BLL.PersonalInformations.ModelsDto;
using Social.Manager.DAL.Models;

namespace Social.Manager.BLL.Mappings
{
    public class SocialManagerMappingProfiles : Profile
    {
        public SocialManagerMappingProfiles()
        {
            CreateMap<PersonalInformation, PersonalInformationDto>();
        }
    }
}
