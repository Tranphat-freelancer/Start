using AutoMapper;
using QuanHuyenModule.QuanHuyens;

namespace QuanHuyenModule;

public class QuanHuyenModuleApplicationAutoMapperProfile : Profile
{
    public QuanHuyenModuleApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<QuanHuyen, QuanHuyenDto>();
        CreateMap<CreateUpdateQuanHuyenDto, QuanHuyen>();
    }
}
