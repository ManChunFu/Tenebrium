﻿using System;
using System.Collections.Generic;

namespace Tools
{
    public class CompositeDisposable : IDisposable
    {
        private List<IDisposable> m_Disposables = new List<IDisposable>();

        public void Add(IDisposable disposable)
        {
            m_Disposables.Add(disposable);
        }
        public void Dispose()
        {
            foreach (IDisposable disposable in m_Disposables)
            {
                disposable.Dispose();
            }
            m_Disposables.Clear();
        }
    }
}
