using AutoMapper;
using Main.Mains;

namespace Main;

public class MainApplicationAutoMapperProfile : Profile
{
    public MainApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<MainApp, MainAppDto>();
        CreateMap<CreateUpdateMainAppDto, MainApp>();
    }
}
