using MottuGestor.Domain.Entities;

namespace MottuGestor.Domain.Interfaces;

public interface IPatioRepository
{
    Task<Patio?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Patio patio, CancellationToken ct = default);
    Task UpdateAsync(Patio patio, CancellationToken ct = default);
}