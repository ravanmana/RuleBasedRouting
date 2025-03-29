public class DailyWireCountRule : IWireUpdateRule
{
    private readonly int _threshold;
    private readonly IWireRepository _repository;

    public DailyWireCountRule(int threshold, IWireRepository repository)
    {
        _threshold = threshold;
        _repository = repository;
    }

    public async Task<bool> ShouldUpdateAsync(WireRequest wire)
    {
        var count = await _repository.GetWireCountForDateAsync(wire.RequestedDate);
        return count < _threshold;
    }
}
