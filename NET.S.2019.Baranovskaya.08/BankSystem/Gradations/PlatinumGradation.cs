namespace BankSystem.Gradations
{
    public class PlatinumGradation : Gradation
    {

        public override int withdrawCost => 25;

        public override int depositCost => 2;

        public override string Name => "Platinum";

        public override int GetBonusScoreDecrease(int money)
        {
             return withdrawCost;
        }

        public override int GetBonusScoreIncrease(int money)
        {
            return depositCost * money + 15;
        }
    }
}
