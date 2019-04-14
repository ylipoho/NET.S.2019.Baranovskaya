namespace BankSystem
{
    /// <summary>
    /// Abstract class thas describes gradatoin of the bank account
    /// </summary>
    abstract public class Gradation
    {
        public  abstract string Name { get; }

        public abstract int withdrawCost { get; }
        public abstract int depositCost { get; }

        public abstract int GetBonusScoreIncrease(int money);
        public abstract int GetBonusScoreDecrease(int money);

    }
}
