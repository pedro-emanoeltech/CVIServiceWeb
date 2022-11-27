using AutoMapper;
using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Pages.Conta;
using CVIServiceWebApp.Pages.Perfil;

namespace CVIServiceWebApp.AutoMapper
{
    public class RequestToResponseMapper :Profile
    {
        public RequestToResponseMapper()
        {
            //REQUEST 
            CreateMap<AuthenticateRequest, ContaResponse>(MemberList.Destination).ReverseMap();
            CreateMap<ContaRequest, ContaResponse>(MemberList.Destination).ReverseMap();
            CreateMap<CandidaturaRequest, CandidaturaResponse>(MemberList.Destination).ReverseMap();
            CreateMap<CargoRequest, CargoResponse>(MemberList.Destination).ReverseMap();
            CreateMap<CidadeRequest, CidadeResponse>(MemberList.Destination).ReverseMap();
            CreateMap<ContatoRequest, ContatoResponse>(MemberList.Destination).ReverseMap();
            CreateMap<CursoFormacaoAcademicaRequest, CursoFormacaoAcademicaResponse>(MemberList.Destination).ReverseMap();
            CreateMap<CursoRequest, CursoResponse>(MemberList.Destination).ReverseMap();
            CreateMap<EnderecoRequest, EnderecoResponse>(MemberList.Destination).ReverseMap();
            CreateMap<EscolaridadeRequest, EscolaridadeResponse>(MemberList.Destination).ReverseMap();
            CreateMap<EstadoRequest, EstadoResponse>(MemberList.Destination).ReverseMap();
            CreateMap<HistoricoProfissionalRequest, HistoricoProfissionalResponse>(MemberList.Destination).ReverseMap();
            CreateMap<IdiomaRequest, IdiomaResponse>(MemberList.Destination).ReverseMap();
            CreateMap<NacionalidadeRequest, NacionalidadeResponse>(MemberList.Destination).ReverseMap();
            CreateMap<ObjetivoRequest, ObjetivoResponse>(MemberList.Destination).ReverseMap();
            CreateMap<PaisRequest, PaisResponse>(MemberList.Destination).ReverseMap();
            CreateMap<PerfilRequest, PerfilResponse>(MemberList.Destination).ReverseMap();
            CreateMap<SegmentoRequest, SegmentoResponse>(MemberList.Destination).ReverseMap();
            CreateMap<VagaRequest, VagaResponse>(MemberList.Destination).ReverseMap();
            CreateMap<AuthenticateRequest, AuthenticateResponse>(MemberList.Destination).ReverseMap();
        }
    }
}
