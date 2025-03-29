using Microsoft.Extensions.Options;

public class AppSettingsWireRepository : IWireRepository
{
    private readonly WireRulesOptions _options;

    public AppSettingsWireRepository(IOptions<WireRulesOptions> options)
    {
        _options = options.Value;
    }

    public Task<int> GetWireCountForDateAsync(DateTime date)
    {
        // Simulate from config — in production, replace with DB logic
        return Task.FromResult(25); // For example
    }

    public Task<List<string>> GetAllowedDebitAccountsAsync()
    {
        return Task.FromResult(_options.AllowedDebitAccounts ?? new List<string>());
    }

    public decimal GetAmountThreshold() => _options.AmountThreshold;

    public int GetDailyWireCountThreshold() => _options.DailyWireCountThreshold;
}
