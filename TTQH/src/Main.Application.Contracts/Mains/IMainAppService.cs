using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Main.Mains
{

    public interface IMainAppService :
        ICrudAppService< //Defines CRUD methods
            MainAppDto, //Used to show books
            long, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateMainAppDto> //Used to create/update a book
    {

    }
}
