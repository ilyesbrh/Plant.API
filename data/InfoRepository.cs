using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plant.API.models;

namespace Plant.API.data
{
    public class InfoRepository : IinfoRepository
    {
        private readonly DataContext context;

        public InfoRepository(DataContext context)
        {
            this.context = context;
        }


        public async Task<Info> getInfos()
        {
            var result = await this.context.Infos.OrderBy(x=>x.Version).Take(1).ToListAsync();
            if(result.Count != 0)
                return result[0];
            else
                return null;
        }

        public Task<Info> getInfos(int version)
        {
            throw new NotImplementedException();
        }

        public Task<Info> getInfos(DateTime lastUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<Info> setInfo()
        {
            throw new NotImplementedException();
        }
    }
}