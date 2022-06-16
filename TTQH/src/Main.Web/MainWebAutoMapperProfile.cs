using AutoMapper;
using Main.Mains;

namespace Main.Web;

public class MainWebAutoMapperProfile : Profile
{
    public MainWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<MainAppDto, CreateUpdateMainAppDto>();
    }
}
