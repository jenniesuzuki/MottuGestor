using MottuGestor.Domain.Enums;
using MottuGestor.Domain.ValueObjects;

namespace MottuGestor.Domain.Entities;


public class Moto
{
    public Guid MotoId { get; private set; }
    public Placa Placa { get; private set; }
    public string Modelo { get; private set; }
    public string Marca { get; private set; }
    public RfidTag RfidTag { get; private set; }
    public int Ano { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public string Problema { get; private set; }
    public string Localizacao { get; private set; }
    public StatusMoto Status { get; private set; }

    public Moto(Guid motoId, Placa placa, string modelo, string marca, RfidTag rfidTag, int ano, DateTime dataCadastro, string problema, string localizacao, StatusMoto status)
    {
        MotoId = motoId;
        Placa = placa;
        Modelo = modelo;
        Marca = marca;
        RfidTag = rfidTag;
        Ano = ano;
        DataCadastro = dataCadastro;
        Problema = problema;
        Localizacao = localizacao;
        Status = status;
    }
    
    private Moto() {}

    public Moto(Placa motoId, string modelo, string marca, RfidTag rfid, int rfidTag)
    {
        throw new NotImplementedException();
    }


    // public Moto()
    // {
    //     DataCadastro = DateTime.UtcNow;
    //     Status = StatusMoto.Disponivel;
    // }
    //
    // // Métodos para alterar campos
    // public void AtualizarLocalizacao(string novaLocalizacao)
    // {
    //     Localizacao = novaLocalizacao;
    // }
    //
    // public void AtualizarProblema(string novoProblema)
    // {
    //     Problema = novoProblema;
    // }
    //
    // public void AlterarStatus(StatusMoto novoStatus)
    // {
    //     Status = novoStatus;
    // }
    //
    // public void AtualizarDados(string rfidTag, string placa, string modelo, string marca, int ano, string problema, string localizacao)
    // {
    //     RfidTag = rfidTag;
    //     Placa = placa;
    //     Modelo = modelo;
    //     Marca = marca;
    //     Ano = ano;
    //     Problema = problema;
    //     Localizacao = localizacao;
    // }
    
}