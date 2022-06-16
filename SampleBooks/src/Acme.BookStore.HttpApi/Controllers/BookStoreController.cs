using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.BookStore.Controllers
{
    [RemoteService(Name = "Default")]
    [ControllerName("Books")]
    [Route("api/app/book")]
    public class BookStoreController : AbpControllerBase, IBookAppService
    {
        protected IBookAppService BookAppService { get; }

        public BookStoreController(IBookAppService BookAppService)
        {
            this.BookAppService = BookAppService;
        }
        [HttpPost]
        public virtual Task<BookDto> CreateAsync(CreateUpdateBookDto input)
        {
            return BookAppService.CreateAsync(input);
        }
        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return BookAppService.DeleteAsync(id);
        }
        [HttpGet]
        [Route("{id}")]
        public virtual Task<BookDto> GetAsync(Guid id)
        {
            return BookAppService.GetAsync(id);
        }
        [HttpGet]
        public virtual Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return BookAppService.GetListAsync(input);
        }
        [HttpPut]
        [Route("{id}")]
        public virtual Task<BookDto> UpdateAsync(Guid id, CreateUpdateBookDto input)
        {
            return BookAppService.UpdateAsync(id, input);
        }
    }
}
