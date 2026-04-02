namespace Empty.Sdk;

/// <summary>
/// Sets an environment variable when created and restores it when disposed.
/// </summary>
public sealed class DisposableEnvironmentVariable : IDisposable
{
    private readonly string _key;
    private readonly string? _previousValue;

    public DisposableEnvironmentVariable(string key, string? value)
    {
        _key = key;
        _previousValue = Environment.GetEnvironmentVariable(key);

        Environment.SetEnvironmentVariable(key, value);
    }

    public void Dispose()
    {
        Environment.SetEnvironmentVariable(_key, _previousValue ?? string.Empty);
    }
}
