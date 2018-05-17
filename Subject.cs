using System;
using System.Collections.Generic;

namespace DH.Observer
{
    public class Subject<SubjectTemplate> : ISubject
    {
        private List<IObserver<SubjectTemplate>> observers = new List<IObserver<SubjectTemplate>>();
        private SubjectTemplate currentState;

        public virtual void Attach(IObserver<SubjectTemplate> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }

        public virtual void Detach(IObserver<SubjectTemplate> observer)
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }

        public virtual void NotifyAll(SubjectTemplate state)
        {
            foreach (IObserver<SubjectTemplate> observer in observers)
            {
                observer.Notify(state);
            }

            currentState = state;
        }

        private SubjectTemplate CurrentState
        {
            get { return currentState; }
        }

        public Type SubjectType
        {
            get { return typeof(SubjectTemplate); }
        }
    }
}