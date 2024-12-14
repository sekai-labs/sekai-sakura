using System;

public abstract class GenericSekaiBuilder<T> where T : new()
{
    private readonly T _product;

    public static GenericSekaiBuilder<T> Builder()
    {
        return Activator.CreateInstance(typeof(T)) as GenericSekaiBuilder<T>;
    }

    public T Build()
    {
        return _product;
    }
}
