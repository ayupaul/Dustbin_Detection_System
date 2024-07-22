using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Services.AreaService
{
    public interface IAreaService
    {
        Task<string> GetAreaInspector(string targetAddress);
    }
}
