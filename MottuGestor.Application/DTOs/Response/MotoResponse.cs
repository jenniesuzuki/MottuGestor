using MottuGestor.Domain.ValueObjects;

namespace MottuGestor.Application.DTOs.Response;

public record MotoResponse(Guid MotoId, Placa Placa, string Modelo, string Marca, RfidTag Rfid, int Ano, string? Problema, string? Localizacao, string Status);