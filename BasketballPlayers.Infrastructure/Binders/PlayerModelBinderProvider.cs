using BasketballPlayers.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Infrastructure.Binders
{
    public class PlayerModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if(context.Metadata.ModelType == typeof(Player))
            {
                return new PlayerModelBinder();
            }
            return null;
        }
    }
}
