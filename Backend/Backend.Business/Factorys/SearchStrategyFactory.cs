using System;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Business;

public class SearchStrategyFactory
{
    private readonly IServiceProvider _serviceProvider;
    public SearchStrategyFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public ISearchStrategy GetStrategy(string searchType)
    {
        return searchType.ToLower() switch
        {
            "normal" => _serviceProvider.GetRequiredService<SimpleSearchStrategy>(),
            _ => _serviceProvider.GetRequiredService<SimpleSearchStrategy>()
        };
    }
}
