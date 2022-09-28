using Cart.Business.interfaces.Notifications;
using Cart.Business.Models;
using Cart.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;


namespace Cart.Business.Services
{
    public abstract class BaseService
    {
        protected readonly INotifier _notifier;
        protected BaseService(INotifier Notifier)
        {
            _notifier = Notifier;
        }

        protected void BuildNotify(ValidationResult returnValidation)
        {
            foreach(var error in returnValidation.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }
        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool RunValidation<TV, TM>( TV validation, TM entity) where TV : AbstractValidator<TM> where TM : Entity
        {
            var resultValidation =  validation.Validate(entity);
            if (resultValidation.IsValid) return true;

            BuildNotify(resultValidation);
            return false;
        }   
    }
}
