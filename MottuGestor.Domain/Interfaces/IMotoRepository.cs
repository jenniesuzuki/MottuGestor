using MottuGestor.Domain.Entities;
using MottuGestor.Domain.ValueObjects;

namespace MottuGestor.Domain.Interfaces;

public interface IMotoRepository
{
    Task<Moto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Moto moto, CancellationToken ct = default);
    Task UpdateAsync(Moto moto, CancellationToken ct = default);
    Task<bool> PlacaExisteAsync(string placa, CancellationToken ct = default);
}