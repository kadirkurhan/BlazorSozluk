using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.ViewModels.RequestModels
{
    public class CreateEntryCommentCommand:IRequest<Guid>
    {
        public Guid EntryID { get; set; }
        public string Content { get; set; }
        public Guid? CreatedById { get; set; }

        public CreateEntryCommentCommand(Guid entryID, string content, Guid createdById)
        {
            EntryID = entryID;
            Content = content;
            CreatedById = createdById;
        }
    }
}
