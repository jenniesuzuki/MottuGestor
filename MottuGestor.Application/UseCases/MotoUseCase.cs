using MottuGestor.Application.DTOs.Request;
using MottuGestor.Application.DTOs.Response;
using MottuGestor.Domain.Interfaces;
using MottuGestor.Domain.ValueObjects;

namespace MottuGestor.Application.UseCases;

public class MotoUseCase
{
    private readonly IPatioRepository _patioRepo;
    private readonly IMotoRepository _motoRepo;

    public MotoUseCase(IPatioRepository patioRepo, IMotoRepository motoRepo)
    {
        _patioRepo = patioRepo;
        _motoRepo = motoRepo;
    }

    public async Task<MotoResponse> HandleAsync(MotoRequest req, CancellationToken ct = default)
    {
        if (await _motoRepo.PlacaExisteAsync(req.Placa, ct))
            throw new InvalidOperationException("Placa já cadastrada.");

        var patio = await _patioRepo.GetByIdAsync(req.PatioId, ct) 
                    ?? throw new KeyNotFoundException("Pátio não encontrado.");

        var moto = patio.AdicionarMoto(new Placa(req.Placa), req.Modelo, req.Marca, new RfidTag(req.Rfid), req.Ano);
        await _patioRepo.UpdateAsync(patio, ct); // salva agregado com a nova moto

        return new MotoResponse(
            moto.MotoId, moto.Placa, moto.Modelo, moto.Marca, moto.RfidTag, moto.Ano, 
            moto.Problema, moto.Localizacao, moto.Status.ToString()
        );
    }
}