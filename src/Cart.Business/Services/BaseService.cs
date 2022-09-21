using Cart.Business.interfaces.Notifications;
using Cart.Business.Notifications;
using Cart.Business.Validations.BaseValidation;
using Cart.Business.Validations.BaseValidation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Services
{
    public abstract class BaseService
    {
        protected readonly INotifier _notifier;
        protected BaseService(INotifier Notifier)
        {
            _notifier = Notifier;
        }

        protected void BuildNotify(ReturnValidation returnValidation)
        {
            foreach(var error in returnValidation.GetMessageErros)
            {
                Notify(error.Message);
            }
        }
        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool RunValidation<TM>(IValidationBase<TM> validation, TM entity) 
        {
            var resultValidation =  validation.IsValid(entity);
            if (resultValidation.IsValid) return true;

            BuildNotify(resultValidation);
            return false;
        }   
    }
}
