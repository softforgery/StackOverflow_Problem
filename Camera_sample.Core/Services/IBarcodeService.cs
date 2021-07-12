using Camera_sample.Core.Constants;
using System.Threading;
using System.Threading.Tasks;

namespace Camera_sample.Core.Services
{
    public interface IBarcodeService
    {
        Task<BarcodeResult> Read(BarcodeReadConfiguration config = null, CancellationToken token = default(CancellationToken));

    }
}
