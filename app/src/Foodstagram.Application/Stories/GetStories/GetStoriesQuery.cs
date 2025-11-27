
using System.Collections.Generic;
using Foodstagram.Application.Common.Models;
using MediatR;

namespace Foodstagram.Application.Stories.GetStories;




public sealed record GetStoriesQuery()
    : IRequest<IReadOnlyList<StorySummaryModel>>;
