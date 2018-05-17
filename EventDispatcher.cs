using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace DH.Observer
{
    public class EventDispatcher
    {
        private Dictionary<Type, ISubject> subjects;

        public EventDispatcher()
        {
            subjects = new Dictionary<Type, ISubject>();
        }

        public void Subscribe<SubjectType>(IObserver<SubjectType> observer)
        {
            CreateSubjectIfNotExist<SubjectType>();
            
            Subject<SubjectType> subject = FindSubjectWithType(typeof(SubjectType)) as Subject<SubjectType>;
            subject.Attach(observer);
        }

        void CreateSubjectIfNotExist<SubjectType>()
        {
            if(!subjects.ContainsKey(typeof(SubjectType)))
                subjects.Add(typeof(SubjectType), new Subject<SubjectType>());
        }

        public void Unsubscribe<SubjectType>(IObserver<SubjectType> observer)
        {
            Subject<SubjectType> subject = FindSubjectWithType(typeof(SubjectType)) as Subject<SubjectType>;
            subject.Detach(observer);
        }

        private ISubject FindSubjectWithType(Type subjectType)
        {
            if (!subjects.ContainsKey(subjectType))
                throw new Exception("Subject does not exist type: " + subjectType);

            ISubject subject = subjects[subjectType];
            return subject;
        }

        public void Dispatch<SubjectType>(SubjectType notification)
        {
            CreateSubjectIfNotExist<SubjectType>();
            
            Subject<SubjectType> subject = FindSubjectWithType(typeof(SubjectType)) as Subject<SubjectType>;
            subject.NotifyAll(notification);
        }
    }
}