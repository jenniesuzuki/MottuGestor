using MottuGestor.Domain.Enums;
using MottuGestor.Domain.ValueObjects;

namespace MottuGestor.Domain.Entities;

public class Patio
{
    public Guid PatioId { get; private set; }
    public string Nome { get; private set; }
    private readonly List<Moto> _motos = new();
    public IReadOnlyCollection<Moto> Motos => _motos.AsReadOnly();

    private Patio() {} // EF
    public Patio(string nome)
    {
        PatioId = Guid.NewGuid();
        Nome = string.IsNullOrWhiteSpace(nome) ? throw new ArgumentException("Nome obrigatório.") : nome.Trim();
    }

    public Moto AdicionarMoto(Placa placa, string modelo, string marca, RfidTag rfid, int ano)
    {
        var moto = new Moto(placa, modelo, marca, rfid, ano);
        _motos.Add(moto);
        return moto;
    }

    public void RemoverMoto(Guid motoId)
    {
        var moto = _motos.SingleOrDefault(m => m.MotoId == motoId) 
                   ?? throw new KeyNotFoundException("Moto não encontrada.");
        _motos.Remove(moto);
    }
}