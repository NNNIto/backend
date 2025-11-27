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
        
        CreateMap<FeedItemResult, FeedItemDto>();
        CreateMap<GetFeedResult, FeedResponseDto>();

        
        CreateMap<CommentResult, CommentDto>();
        CreateMap<PostDetailResult, PostDetailDto>();

        
        CreateMap<StorySummaryModel, StoryDto>();
        CreateMap<Foodstagram.Application.Stories.GetStoryDetail.StoryDetailResult, StoryDetailDto>()
            .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => s.MediaUrl));

        
        CreateMap<ProfileHeaderModel, ProfileHeaderDto>();
        CreateMap<MyPostModel, MyPostDto>();

        
        CreateMap<ActivityItemModel, Api.Dtos.Activity.ActivityItemDto>();

        
        CreateMap<UserSummaryModel, UserSummaryDto>();
    }
}
