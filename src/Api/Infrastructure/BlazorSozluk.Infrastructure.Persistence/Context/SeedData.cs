using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Common.Infrastructure;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Infrastructure.Persistence.Context;

internal class SeedData
{
    private static List<User> GetUsers()
    {
        var result = new Faker<User>("tr")
            .RuleFor(i => i.Id, i => Guid.NewGuid())
            .RuleFor(i => i.CreateDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(i => i.FirstName, i => i.Person.FirstName)
            .RuleFor(i => i.LastName, i => i.Person.LastName)
            .RuleFor(i => i.EmailAddress, i => i.Internet.Email())
            .RuleFor(i => i.UserName, i => i.Internet.UserName())
            .RuleFor(i => i.Password, i => PasswordEncryptor.Encrypt(i.Internet.Password()))
            .RuleFor(i => i.EmailConfirmed, i => i.PickRandom(true, false))
            .Generate(500);

        return result;

    }

    public async Task SeedAsync(IConfiguration configuration)
    {
        var dbContextBuilder = new DbContextOptionsBuilder();
        dbContextBuilder.UseSqlServer(configuration["BlazorSozlukDbConnectionString"]);
        var context = new BlazorSozlukContext(dbContextBuilder.Options);
        var users = GetUsers();
        var userIds = users.Select(x => x.Id);
        await context.Users.AddRangeAsync(users);
        var guids = Enumerable.Range(0,150).Select(x=>Guid.NewGuid()).ToList();
        int counter = 0;

        var entries = new Faker<Entry>("tr")
            .RuleFor(x => x.Id, guids[counter++])
            .RuleFor(x => x.CreateDate, x => x.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(x => x.Subject, x => x.Lorem.Sentence(5, 5))
            .RuleFor(x => x.Subject, x => x.Lorem.Sentence(5, 5))
            .RuleFor(x => x.Content, x => x.Lorem.Paragraph(2))
            .RuleFor(x => x.CreatedById, x => x.PickRandom(userIds))
            .Generate(150);

        await context.Entries.AddRangeAsync(entries);

        var comments = new Faker<EntryComment>("tr")
            .RuleFor(x => x.Id,  Guid.NewGuid())
            .RuleFor(x => x.CreateDate, x => x.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(x => x.Content, x => x.Lorem.Paragraph(2))
            .RuleFor(x => x.CreatedById, x => x.PickRandom(userIds))
            .RuleFor(x => x.EntryId, x => x.PickRandom(guids))
            .Generate(1000);

        await context.EntryComments.AddRangeAsync(comments);
        await context.SaveChangesAsync();



    }
}
