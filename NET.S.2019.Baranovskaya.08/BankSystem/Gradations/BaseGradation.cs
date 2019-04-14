namespace BankSystem.Gradations
{
    public class BaseGradation : Gradation
    {

        public override int withdrawCost => 2;

        public override int depositCost => 2;

        public override string Name => "Base";

        public override int GetBonusScoreDecrease(int money)
        {
            return withdrawCost * money / 10;
        }

        public override int GetBonusScoreIncrease(int money)
        {
            return depositCost * money / 5;
        }
    }
}
