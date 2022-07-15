using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Common.Infrastructure.Extensions;
using BlazorSozluk.Common.ViewModels.Page;
using BlazorSozluk.Common.ViewModels.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Features.Queries.GetEntryComments
{
    public class GetEntryCommentsQueryHandler : IRequestHandler<GetEntryCommentsQuery, PagedViewModel<GetEntryCommentsViewModel>>
    {
        private readonly IEntryCommentRepository _entryCommentRepository;
        private readonly IEntryRepository _entryRepository;

        public GetEntryCommentsQueryHandler(IEntryCommentRepository entryCommentRepository, IEntryRepository entryRepository)
        {
            _entryCommentRepository = entryCommentRepository;
            _entryRepository = entryRepository;
        }

        public async Task<PagedViewModel<GetEntryCommentsViewModel>> Handle(GetEntryCommentsQuery request, CancellationToken cancellationToken)
        {
            var query = _entryCommentRepository.AsQueryable();
            query = query.Include(i => i.EntryCommentFavorites)
                .Include(i => i.CreatedBy)
                .Include(i => i.EntryCommentVotes)
                .Where(i=>i.EntryId == request.EntryId);

            var list = query.Select(i => new GetEntryCommentsViewModel()
            {
                Id = i.Id,
                Content = i.Content,
                IsFavorited = request.UserId.HasValue && i.EntryCommentFavorites.Any(j => j.CreatedById == request.UserId),
                FavoritedCount = i.EntryCommentFavorites.Count,
                CreatedDate = i.CreateDate,
                CreatedByUserName = i.CreatedBy.UserName,
                VoteType = request.UserId.HasValue && i.EntryCommentVotes.Any(j => j.CreatedById == request.UserId)
                ? i.EntryCommentVotes.FirstOrDefault(j => j.CreatedById == request.UserId).VoteType
                : Common.ViewModels.VoteType.None,

            });

            var entries = await list.GetPaged(request.Page, request.PageSize);

            return entries;
        }
    }
}
