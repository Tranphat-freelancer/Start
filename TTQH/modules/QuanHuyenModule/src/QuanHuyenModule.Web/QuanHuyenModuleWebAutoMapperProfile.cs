using AutoMapper;
using QuanHuyenModule.QuanHuyens;

namespace QuanHuyenModule.Web;

public class QuanHuyenModuleWebAutoMapperProfile : Profile
{
    public QuanHuyenModuleWebAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<QuanHuyenDto,CreateUpdateQuanHuyenDto>();
    }
}
