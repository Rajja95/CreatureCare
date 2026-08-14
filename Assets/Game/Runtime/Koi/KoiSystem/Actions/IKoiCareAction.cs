namespace CreatureCare.Koi.Actions
{
    public interface IKoiCareAction
    {
        bool CanExecute { get; }

        void Execute();
    }
}