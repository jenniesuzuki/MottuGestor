using Microsoft.EntityFrameworkCore;
using MottuGestor.Domain.Entities;
using MottuGestor.Domain.Interfaces;
using MottuGestor.Infrastructure.Context;

namespace MottuGestor.Infrastructure.Repositories;

public class PatioRepository : IPatioRepository
{
    private readonly MottuGestorContext _ctx;
    public PatioRepository(MottuGestorContext ctx) => _ctx = ctx;

    public Task<Patio?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        _ctx.Patios.Include("_motos").FirstOrDefaultAsync(p => p.PatioId == id, ct);

    public async Task AddAsync(Patio patio, CancellationToken ct = default)
    {
        await _ctx.Patios.AddAsync(patio, ct);
        await _ctx.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Patio patio, CancellationToken ct = default)
    {
        _ctx.Patios.Update(patio);
        await _ctx.SaveChangesAsync(ct);
    }
}