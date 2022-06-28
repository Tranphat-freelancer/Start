using AutoMapper;
using QuanHuyenModule.QuanHuyens;
using TinhThanhModule.TinhThanhs;

namespace Ms.AppTTQH.Web;

public class AppTTQHWebAutoMapperProfile : Profile
{
    public AppTTQHWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<TinhThanhDto, CreateUpdateTinhThanhDto>();
        CreateMap<QuanHuyenDto, Pages.QuanHuyens.EditModalModel.EditQuanHuyenViewModel>();
        CreateMap<Pages.QuanHuyens.CreateModalModel.CreateQuanHuyenViewModel, CreateUpdateQuanHuyenDto>();
        CreateMap<Pages.QuanHuyens.EditModalModel.EditQuanHuyenViewModel, CreateUpdateQuanHuyenDto>();
    }
}
