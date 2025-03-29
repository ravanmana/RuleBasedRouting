public class DebitAccountRule : IWireUpdateRule
{
    private readonly IWireRepository _repository;

    public DebitAccountRule(IWireRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ShouldUpdateAsync(WireRequest wire)
    {
        var allowedAccounts = await _repository.GetAllowedDebitAccountsAsync();
        return allowedAccounts.Contains(wire.DebitAccount);
    }
}
