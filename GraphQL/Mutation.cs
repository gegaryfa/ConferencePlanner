﻿using System.Threading.Tasks;

using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.Extensions;

using HotChocolate;

namespace ConferencePlanner.GraphQL
{
    public class Mutation
    {
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeakerAsync(
            AddSpeakerInput input,
            [ScopedService] ApplicationDbContext context)
        {
            var speaker = new Speaker
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            await context.Speakers.AddAsync(speaker);
            await context.SaveChangesAsync();

            return new AddSpeakerPayload(speaker);
        }
    }
}