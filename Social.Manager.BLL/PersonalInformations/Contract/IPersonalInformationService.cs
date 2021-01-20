using Social.Manager.BLL.PersonalInformations.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Social.Manager.BLL.PersonalInformations.Contract
{
    public interface IPersonalInformationService
    {
        Task<IEnumerable<PersonalInformationDto>> GetByPagesAsync(int skip = 0, int take = 20);
        Task<IEnumerable<PersonalInformationDto>> SearchAsync(SearchPersonalInformationDto searchDto);
    }
}
