﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using ConferencePlanner.GraphQL.Extensions;

using HotChocolate;

using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
            context.Speakers.ToListAsync();

        public Task<Speaker> GetSpeakerAsync(
            int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}