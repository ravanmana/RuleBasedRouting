public interface IWireUpdateRule
{
    Task<bool> ShouldUpdateAsync(WireRequest wire);
}
