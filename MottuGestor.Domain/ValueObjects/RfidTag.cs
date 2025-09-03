namespace MottuGestor.Domain.ValueObjects;

public class RfidTag : IEquatable<RfidTag>
{
    public string Value { get; }
    private RfidTag() { } // EF
    public RfidTag(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("RFID obrigatório.");
        // Ex.: só letras/números, 8–32 chars
        var v = value.Trim().ToUpperInvariant();
        if (v.Length is < 8 or > 32) throw new ArgumentException("RFID inválido.");
        Value = v;
    }
    public override string ToString() => Value;
    public bool Equals(RfidTag? other) => other is not null && Value == other.Value;
    public override bool Equals(object? obj) => obj is RfidTag r && Equals(r);
    public override int GetHashCode() => Value.GetHashCode();
}