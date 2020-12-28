using System;
using System.Collections.Generic;

namespace Tools
{
    public static class ObservableExtensions
    {
        public static IDisposable Subscribe<T>(this IObservable<T> observable, Action<T> onNext)
        {
            IObserver<T> observer = new ActionToObserver<T>(onNext);
            return observable.Subscribe(observer);  
        }

        public static IDisposable Subscribe<T>(this IObservable<T> observable, IObserver<T> observer)
        {
            return observable.Subscribe(observer);
        }
    }


    public class ObservableProperty<T> : IObservable<T>
    {
        private bool m_HasValue = false;
        private T m_Value;
        private readonly Subject<T> m_Subject = new Subject<T>();

        public T Value
        {
            get => m_Value;
            set
            {
                m_HasValue = true;
                if (EqualityComparer<T>.Default.Equals(m_Value, value) == false || m_HasValue == true) // change m_HasValue == true for this project when <T> is bool and it should trigger no matter is false or bool
                {
                    m_HasValue = true;
                    m_Value = value;
                    m_Subject.OnNext(m_Value);
                }
            }
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            IDisposable subscription = null;
            try
            {
                if (m_HasValue)
                {
                    observer.OnNext(m_Value);
                }
            }
            finally
            {
                subscription = m_Subject.Subscribe(observer);
            }
            return subscription;
        }
    }

    public interface ISubject<T> : IObservable<T>, IObserver<T> { }
}
