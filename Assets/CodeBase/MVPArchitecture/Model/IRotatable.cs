namespace CodeBase.MVPArchitecture.Model
{
    public interface IRotatable
    {
        float CosCurrentAngle { get; }
        float SinCurrentAngle { get; }
        
        void Rotate();
    }
}