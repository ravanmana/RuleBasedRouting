var rules = new List<IWireUpdateRule>
{
    new AmountThresholdRule(10000),
    new DailyWireCountRule(50, wireRepo),
    new DebitAccountRule(wireRepo)
};

var updater = new WireIntermediaryUpdater(rules);

if (await updater.ShouldUpdateIntermediaryAsync(wire))
{
    wire.IntermediaryBank = "NEW_BANK_ID";
}
