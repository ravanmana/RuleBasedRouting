public interface IWireRepository
{
    Task<int> GetWireCountForDateAsync(DateTime date);
    Task<List<string>> GetAllowedDebitAccountsAsync();
}
