
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Common.Models;

namespace Foodstagram.Application.Common.Interfaces;




public interface IShareRepository
{
    
    
    
    Task<IReadOnlyList<UserSummaryModel>> GetShareSuggestionsAsync(
        long userId,
        CancellationToken cancellationToken);
}
