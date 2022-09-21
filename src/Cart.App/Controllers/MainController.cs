using Cart.Business.interfaces.Notifications;
using Cart.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cart.App.Controllers
{
    [ApiController]

    public abstract class MainController : ControllerBase
    {
        private readonly INotifier _notifier;
        protected MainController(INotifier Notifier)
        {
            _notifier = Notifier;
        }

        protected ActionResult CustomResult( object result = null)
        {
            if(ValidOperation())
            {
                return Ok(new
                {
                    sucess = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                sucess = false,
                errors = GetErrors().Select(e => e.Message)
            }) ;
        }

        public bool ValidOperation()
        {
            return !_notifier.HasNotification();
        }

        protected List<Notification> GetErrors()
        {
           return _notifier.GetNotification();
        }



        //ModelState.IsValid
        protected ActionResult CustomResult(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) BuildNotify(modelState);
            return CustomResult();
        }

        protected void BuildNotify(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e=>e.Errors); //take only errors
            foreach(var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                Notify(errorMsg);
            }
        }

        protected void Notify(string errorMsg)
        {
            _notifier.Handle(new Notification(errorMsg));   
        }
    }
}
