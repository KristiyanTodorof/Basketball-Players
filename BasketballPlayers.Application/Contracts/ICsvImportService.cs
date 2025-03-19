using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.Contracts
{
    public interface ICsvImportService
    {
        Task ImportBasketballDataAsync(string filePath);
    }
}
