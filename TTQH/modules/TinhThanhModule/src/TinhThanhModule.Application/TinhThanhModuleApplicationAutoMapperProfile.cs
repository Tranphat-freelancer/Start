using AutoMapper;
using TinhThanhModule.TinhThanhs;

namespace TinhThanhModule;

public class TinhThanhModuleApplicationAutoMapperProfile : Profile
{
    public TinhThanhModuleApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<TinhThanh, TinhThanhDto>();
        CreateMap<CreateUpdateTinhThanhDto, TinhThanh>();
        //Nếu báo lỗi mapper check Application Module

    }
}
