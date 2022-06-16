using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Main.Mains
{

    
    public class MainAppService :
        CrudAppService<
            MainApp, //The Book entity
            MainAppDto, //Used to show books
            long, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateMainAppDto>, //Used to create/update a book
        IMainAppService //implement the IBookAppService
    {
        public MainAppService(IRepository<MainApp, long> repository)
            : base(repository)
        {

        }
    }
}
