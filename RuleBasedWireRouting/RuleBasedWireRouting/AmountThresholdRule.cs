public class AmountThresholdRule : IWireUpdateRule
{
    private readonly decimal _thresholdAmount;

    public AmountThresholdRule(decimal thresholdAmount)
    {
        _thresholdAmount = thresholdAmount;
    }

    public Task<bool> ShouldUpdateAsync(WireRequest wire)
    {
        return Task.FromResult(wire.Amount < _thresholdAmount);
    }
}

