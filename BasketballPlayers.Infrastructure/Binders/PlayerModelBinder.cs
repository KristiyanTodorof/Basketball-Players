using BasketballPlayers.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Infrastructure.Binders
{
    public class PlayerModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value)) 
            {
                return;
            }

            try
            {
                if (Guid.TryParse(value, out Guid playerId))
                {
                   
                    var player = new Player
                    {
                        Id = playerId,
                        Name = "Player from custom binder"
                    };

                    bindingContext.Result = ModelBindingResult.Success(player);
                }
            }
            catch
            {
                bindingContext.ModelState.TryAddModelError(
                    modelName,
                    "Could not convert provided value to Player type.");
                return;
            }
        }
    }
}
