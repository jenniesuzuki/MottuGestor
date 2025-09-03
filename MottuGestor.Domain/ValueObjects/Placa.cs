namespace MottuGestor.Domain.ValueObjects;

public class Placa : IEquatable<Placa>
{
    public string Value { get; }
    private Placa() { } // EF
    public Placa(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Placa obrigatória.");
        var normalizada = value.Trim().ToUpperInvariant();
        if (normalizada.Length < 7 || normalizada.Length > 8) 
            throw new ArgumentException("Placa inválida.");
        Value = normalizada;
    }
    public override string ToString() => Value;

    public bool Equals(Placa? other) => other is not null && Value == other.Value;
    public override bool Equals(object? obj) => obj is Placa p && Equals(p);
    public override int GetHashCode() => Value.GetHashCode();
}