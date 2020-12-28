using System;

namespace Tools
{
    public static class DisposableExtensions
    {
        public static void AddTo(this IDisposable disposable, CompositeDisposable composite)
        {
            composite.Add(disposable);
        }
    }
}
