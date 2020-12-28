using System;

namespace Tools
{
    //public class Observer
    //{
        //public class SkipFirstNotificationObserver<T> : IObserver<T>
        //{
        //    private bool m_IsFirstTime = true;
        //    private readonly IObserver<T> m_InnerObserver;

        //    public SkipFirstNotificationObserver(IObserver<T> innerObserver)
        //    {
        //        m_InnerObserver = innerObserver;
        //    }

        //    public void OnCompleted() { }
        //    public void OnError(Exception error) { }

        //    public void OnNext(T value)
        //    {
        //        if (m_IsFirstTime)
        //        {
        //            m_IsFirstTime = false;
        //        }
        //        else
        //        {
        //            m_InnerObserver.OnNext(value);
        //        }
        //    }
        //}

        public class ActionToObserver<T> : IObserver<T>
        {
            private readonly Action<T> m_Action;

            public ActionToObserver(Action<T> action)
            {
                m_Action = action;
            }

            public void OnCompleted() { }
            public void OnError(Exception error) { }

            public void OnNext(T value)
            {
                m_Action.Invoke(value);
            }
        }
    //}
}
