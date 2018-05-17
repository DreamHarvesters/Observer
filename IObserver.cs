namespace DH.Observer
{
    public interface IObserver<SubjectType>
    {
        void Notify(SubjectType subject);
    }
}