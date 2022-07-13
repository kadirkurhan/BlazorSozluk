using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.ViewModels.RequestModels
{
    public class CreateEntryCommand:IRequest<Guid>
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid? CreatedBy { get; set; }
        public CreateEntryCommand()
        {

        }

        public CreateEntryCommand(string subject, string content, Guid? createdBy)
        {
            Subject = subject;
            Content = content;
            CreatedBy = createdBy;
        }
    }
}
