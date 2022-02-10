using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TKMaster.AulaEnsino.Core.Domain.Interfaces.Notifications;
using TKMaster.AulaEnsino.Core.Domain.Notifications;
using TKMaster.AulaEnsino.Core.WebApi.ViewModels.Responses;

namespace TKMaster.AulaEnsino.Core.WebApi.Controllers
{
    public abstract class APIController : ControllerBase
    {
        #region Properties

        protected readonly DomainNotificationHandler _notifications;
        protected IEnumerable<DomainNotification> Notifications =>
                    _notifications.GetNotifications();

        #endregion

        #region Constructor

        protected APIController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        #endregion

        #region Methods

        protected bool IsValidOperation() =>
            (!_notifications.HasNotifications());

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new ResponseSuccess<object>
                {
                    Success = true,
                    Data = result
                });
            }

            return Conflict(new ResponseFalha
            {
                Success = false,
                Errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        #endregion
        //#region Properties

        //protected readonly DomainNotificationHandler _notifications;

        //protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        //#endregion

        //#region Constructor

        //public APIController(INotificationHandler<DomainNotification> notifications)
        //{
        //    _notifications = (DomainNotificationHandler)notifications;
        //}

        //#endregion

        //#region Methods

        //protected bool IsValidOperation() => (!_notifications.HasNotifications());

        //protected new IActionResult Response(object result = null)
        //{
        //    if (IsValidOperation())
        //    {
        //        return Ok(new ResponseSuccess<object>
        //        {
        //            Success = true,
        //            Data = result
        //        });
        //    }

        //    return Conflict(new ResponseFalha
        //    {
        //        Success = false,
        //        Erros = _notifications.GetNotifications().Select(n => n.Value)
        //    });
        //}

        //#endregion
    }
}
