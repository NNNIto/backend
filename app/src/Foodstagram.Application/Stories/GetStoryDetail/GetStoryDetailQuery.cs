
using MediatR;

namespace Foodstagram.Application.Stories.GetStoryDetail;




public sealed record GetStoryDetailQuery(long StoryId)
    : IRequest<StoryDetailResult>;
