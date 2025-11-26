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
using Foodstagram.Application.Activities.GetActivities;

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
        CreateMap<Foodstagram.Application.Stories.GetStoryDetail.StoryDetailResult, StoryDetailDto>()
            .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => s.MediaUrl));

        // Profile
        CreateMap<ProfileHeaderModel, ProfileHeaderDto>();
        CreateMap<MyPostModel, MyPostDto>();

        // Activity
        CreateMap<ActivityItemModel, Api.Dtos.Activity.ActivityItemDto>();

        // Common
        CreateMap<UserSummaryModel, UserSummaryDto>();
    }
}
