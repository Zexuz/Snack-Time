using System.Threading.Tasks;
using Grpc.Core;
using SnackTime.Core.Media.Episodes;
using SnackTime.MediaServer.Service.Episode;
using SonarrSharp;

namespace SnackTime.MediaServer
{
    public class EpisodeController : Episode.EpisodeBase
    {
        private readonly EpisodeProvider _episodeProvider;

        public EpisodeController(EpisodeProvider episodeProvider)
        {
            _episodeProvider = episodeProvider;
        }

        public override async Task<GetByIdResponse> GetById(GetByIdRequest request, ServerCallContext context)
        {
            return new GetByIdResponse
            {
                Episode = await _episodeProvider.GetEpisodeById(request.Id)
            };
        }

        public override async Task<GetBySeriesIdResponse> GetBySeriesId(GetBySeriesIdRequest request, ServerCallContext context)
        {
            return new GetBySeriesIdResponse
            {
                Episodes = {await _episodeProvider.GetEpisodesForSeriesById(request.SeriesId)}
            };
        }
    }
}