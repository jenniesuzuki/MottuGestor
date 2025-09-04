using MottuGestor.Domain.ValueObjects;

namespace MottuGestor.Application.DTOs.Request;

public record MotoRequest(string Placa, string Modelo, string Marca, RfidTag Rfid, int Ano, Guid PatioId);