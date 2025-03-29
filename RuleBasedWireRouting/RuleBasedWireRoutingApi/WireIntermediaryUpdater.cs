public class WireIntermediaryUpdater
{
    private readonly IEnumerable<IWireUpdateRule> _rules;

    public WireIntermediaryUpdater(IEnumerable<IWireUpdateRule> rules)
    {
        _rules = rules;
    }

    public async Task<bool> ShouldUpdateIntermediaryAsync(WireRequest wire)
    {
        foreach (var rule in _rules)
        {
            if (await rule.ShouldUpdateAsync(wire))
            {
                return true;
            }
        }
        return false;
    }
}
