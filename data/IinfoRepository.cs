using System;
using System.Threading.Tasks;
using Plant.API.models;

namespace Plant.API.data {
    public interface IinfoRepository {
        Task<Info> getInfos ();
        Task<Info> getInfos (int version);
        Task<Info> getInfos (DateTime lastUpdate);
        Task<Info> setInfo ();
    }
}