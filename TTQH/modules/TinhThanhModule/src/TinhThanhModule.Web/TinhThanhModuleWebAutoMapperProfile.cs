using AutoMapper;
using TinhThanhModule.TinhThanhs;

namespace TinhThanhModule.Web;

public class TinhThanhModuleWebAutoMapperProfile : Profile
{
    public TinhThanhModuleWebAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<TinhThanhDto,CreateUpdateTinhThanhDto>();
    }
}
