using System.Collections.Generic;
using System.Threading.Tasks;
using VideoShare.Infrastructure.Dtos.FileContent;
using VideoShare.Infrastructure.Dtos.Generic;

namespace VideoShare.Infrastructure.Interfaces
{
    public interface IVideoShareService
    {
        Task<HttpResponseDto<List<FileContentDto>>> GetListOfFiles();
    }
}
