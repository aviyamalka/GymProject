
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using GymProject.Data;

namespace GymProject.Logic
{
    public class BussinessLogic
    {

        IMemoryCache _cache;
        public BussinessLogic(IMemoryCache cache)
        {
            _cache = cache;
        }
        public List<string> GetCitiesNamesFromCache()
        {
            List<string> citiesLst = _cache.Get<List<string>>("citiesLst");

            if (citiesLst == null)
            {
                //citiesLst=GetCitiesNamesFormDB();
                _cache.Set<List<string>>("citiesLst", citiesLst);
            }
            return citiesLst;
        }
        //public List<string> GetCitiesNamesFormDB()
        //{
        //   //Get cities from DB
        //}

    }
}
