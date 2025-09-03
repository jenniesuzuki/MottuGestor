using Microsoft.EntityFrameworkCore;
using MottuGestor.Domain.Entities;
using MottuGestor.Domain.Interfaces;
using MottuGestor.Infrastructure.Context;

namespace MottuGestor.Infrastructure.Repositories;

public class MotoRepository : IMotoRepository
{
    private readonly MottuGestorContext _ctx;
    public MotoRepository(MottuGestorContext ctx) => _ctx = ctx;

    public Task<Moto?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        _ctx.Motos.FirstOrDefaultAsync(m => m.MotoId == id, ct);

    public async Task AddAsync(Moto moto, CancellationToken ct = default)
    {
        await _ctx.Motos.AddAsync(moto, ct);
        await _ctx.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Moto moto, CancellationToken ct = default)
    {
        _ctx.Motos.Update(moto);
        await _ctx.SaveChangesAsync(ct);
    }

    public Task<bool> PlacaExisteAsync(string placa, CancellationToken ct = default) =>
        _ctx.Motos.AnyAsync(m => m.Placa.Value == placa, ct);
}