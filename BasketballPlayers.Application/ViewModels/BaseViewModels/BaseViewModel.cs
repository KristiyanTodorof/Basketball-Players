using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.ViewModels.BaseViewModels
{
    public abstract class BaseViewModel<TKey>
    {
        public TKey Id { get; set; }
    }
}
