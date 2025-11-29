using Foodstagram.Application.Common.Interfaces;
using MediatR;

namespace Foodstagram.Application.Shares.GetShareSuggestions;

public sealed class GetShareSuggestionsHandler
    : IRequestHandler<GetShareSuggestionsQuery, IReadOnlyList<ShareSuggestionModel>>
{
    private readonly IShareRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public GetShareSuggestionsHandler(IShareRepository repository, ICurrentUserService currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<IReadOnlyList<ShareSuggestionModel>> Handle(GetShareSuggestionsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetShareSuggestionsAsync(
            _currentUser.UserId, cancellationToken);
    }
}
