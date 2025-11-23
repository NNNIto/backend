using MediatR;

namespace Foodstagram.Application.Shares.GetShareSuggestions;

public sealed record GetShareSuggestionsQuery()
    : IRequest<IReadOnlyList<ShareSuggestionModel>>;
