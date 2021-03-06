﻿
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
        private readonly ApplicationDbContext _context;
        IMemoryCache _cache;
        public BussinessLogic(IMemoryCache cache, ApplicationDbContext context)
        {
            _context = context;
            _cache = cache;
        }
        public List<string> GetCitiesNamesFromCache()
        {
            List<string> citiesLst = _cache.Get<List<string>>("citiesLst");

            if (citiesLst == null)
            {
                citiesLst=GetCitiesNamesFromDB();
                _cache.Set("citiesLst", citiesLst);
            }
            return citiesLst;
        }
        public List<string> GetCitiesNamesFromDB()
        {
            List<string> cities = _context.Addresses.Select(a => a.City).Distinct().ToList();
            cities.Insert(0, "-עיר-");//add default option 
            return cities;
        }
        public List<string> GetBranchesNamesFromCache()
        {
            List<string> branchesLst = _cache.Get<List<string>>("branchesLst");

            if (branchesLst == null)
            {
                branchesLst = GetBranchesNamesFromDB();
                _cache.Set("branchesLst", branchesLst);
            }
            return branchesLst;
        }
        public List<string> GetBranchesNamesFromDB()
        {
            List<string> branches = _context.Branch.Select(b=>b.Name).Distinct().ToList();
            branches.Insert(0, "-בחר סניף-");//add default option 
            return branches;
        }
        // TODO:implement function to get trainings from db and from cache
        public List<string> GetTrainingNamesFromCache()
        {
            List<string> trainingLst = _cache.Get<List<string>>("trainingLst");

            if (trainingLst == null)
            {
                trainingLst = GetTrainingNamesFromDB();
                _cache.Set("trainingLst", trainingLst);
            }
            return trainingLst;
        }
        public List<string> GetTrainingNamesFromDB()
        {
            List<string> trainings = _context.Training.Select(t =>t.Name).Distinct().ToList();
            trainings.Insert(0, "-אימון-");
            return trainings;
        }
    }
}
