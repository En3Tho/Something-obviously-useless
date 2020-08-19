using System;
using System.Collections.Generic;

namespace En3Tho.HelperClasses.Delegates
{
    public static class Binder
    {
        // TODO: Rename params
        // TODO: More overloads
        // TODO: Bind function pointers?
        // TODO: Bind via method body?
        public static Func<A, C> Bind<A, B, C>(this Func<A, B> f, Func<B, C> g) => x => g(f(x));
        public static Action<A> Bind<A, B>(this Func<A, B> f, Action<B> g) => x => g(f(x));
        public static Func<A, D> Bind<A, B, C, D>(this Func<A, B> f, Func<B, C> g, Func<C, D> e) => x => e(g(f(x)));
        public static Func<A, E> Bind<A, B, C, D, E>(this Func<A, B> f, Func<B, C> g, Func<C, D> e, Func<D, E> r) => x => r(e(g(f(x))));

        public static void Test()
        {
            var list = new List<Guid>();
            var fnc = Bind<string, Guid>(Guid.Parse, list.Add);
            fnc(Guid.NewGuid().ToString());
        }
        
        public static Func<B, C> Curry<A, B, C>(this Func<A, B, C> f, A value) => x => f(value, x); // Capture

        public static Func<T, T> ToFunc<T>(this Action<T> f) => x =>
        {
            f(x);
            return x;
        };

        public static Action<T> ToAction<T, U>(this Func<T, U> f) => x => f(x);
    }
}