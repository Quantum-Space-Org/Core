namespace Quantum.Core
{
    public class Nullable<T>
    {
        private readonly T _getValue;

        private Nullable(T value1) => _getValue = value1;

        public static Nullable<T> Instance(T value)
        {
            return new Nullable<T>(value);
        }
        public static Nullable<T> Instance(object value)
        {
            return new Nullable<T>((T)value);
        }

        public bool IsPresent() => _getValue != null;

        public T GetValue() => _getValue;
    }
}