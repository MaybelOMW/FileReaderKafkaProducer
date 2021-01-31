using System.Threading.Tasks;

namespace ReadCSV.Service
{
    interface IService
    {
        Task Start();
        void Stop();
    }
}
