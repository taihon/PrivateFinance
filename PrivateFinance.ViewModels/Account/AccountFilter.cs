namespace PrivateFinance.ViewModels
{
    public class AccountFilter
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public RangeFilter<decimal> Balance { get; set; }
    }
}