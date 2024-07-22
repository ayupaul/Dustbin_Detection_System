using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.FetchCoordinates
{
    public interface ICoordinatesService
    {
       Task<Coordinates> GetCoordinates(string address);
    }
}
