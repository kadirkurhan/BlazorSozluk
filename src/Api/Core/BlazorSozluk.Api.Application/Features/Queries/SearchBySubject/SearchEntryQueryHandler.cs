using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Common.ViewModels.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Features.Queries.SearchBySubject
{
    internal class SearchEntryQueryHandler : IRequestHandler<SearchEntryQuery, List<SearchEntryViewModel>>
    {
        private readonly IEntryRepository _entryRepository;
        public async Task<List<SearchEntryViewModel>> Handle(SearchEntryQuery request, CancellationToken cancellationToken)
        {
            var result = _entryRepository.Get(i => EF.Functions.Like(i.Subject, $"{request.SearchText}%")).Select(
                i=> new SearchEntryViewModel()
                {
                    Subject = i.Subject,
                    Id = i.Id,
                });
            return await result.ToListAsync(cancellationToken);
        }
    }
}
