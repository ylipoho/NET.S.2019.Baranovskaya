namespace BankSystem.Gradations
{
    public class GoldGradation : Gradation
    {
        public override int withdrawCost => 5;

        public override int depositCost => 5;

        public override string Name => "Gold";

        public override int GetBonusScoreDecrease(int money)
        {
            return withdrawCost * money / 100;
        }

        public override int GetBonusScoreIncrease(int money)
        {
            return depositCost * money  + 20;
        }
    }
}
