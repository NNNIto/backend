using AutoMapper;
using Foodstagram.Api.Dtos.Feed;
using Foodstagram.Api.Dtos.Posts;
using Foodstagram.Api.Dtos.Profile;
using Foodstagram.Api.Dtos.Common;
using Foodstagram.Application.Posts.GetFeed;
using Foodstagram.Application.Posts.GetPostDetail;
using Foodstagram.Application.Stories.GetStories;
using Foodstagram.Application.Profiles.GetCurrentProfile;
using Foodstagram.Application.Profiles.GetMyPosts;
using Foodstagram.Application.Common.Models;

namespace Foodstagram.Api.Mappings;

public sealed class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        // Feed
        CreateMap<FeedItemResult, FeedItemDto>();
        CreateMap<GetFeedResult, FeedResponseDto>();

        // Post detail
        CreateMap<CommentResult, CommentDto>();
        CreateMap<PostDetailResult, PostDetailDto>();

        // Stories
        CreateMap<StorySummaryModel, StoryDto>();

        // Profile
        CreateMap<ProfileHeaderModel, ProfileHeaderDto>();
        CreateMap<MyPostModel, MyPostDto>();

        // Common
        CreateMap<UserSummaryModel, UserSummaryDto>();
    }
}
