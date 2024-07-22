using Core.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Data
{
    public static class AreaDb
    {
        

        public static List<AreaModel> areas = new List<AreaModel>()
        {
           new AreaModel(){AreaId=1,AreaInspector="pal138373@gmail.com",StartAddress="Civil Lines,Prayagraj,India",EndAddress="Katra,Prayagraj,India" },
            new AreaModel(){AreaId=1,AreaInspector="palayush20052002@gmail.com",StartAddress="Katra,Prayagraj,India",EndAddress="Rajapur,Prayagraj,India" }
        };

        
    }
}
