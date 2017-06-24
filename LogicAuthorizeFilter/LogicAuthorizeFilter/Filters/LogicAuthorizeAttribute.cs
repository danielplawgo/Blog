using LogicAuthorizeFilter.App_Start;
using LogicAuthorizeFilter.Logic;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LogicAuthorizeFilter.Filters
{
    public class LogicAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public Type LogicType { get; set; }

        protected IUserLogic UserLogic
        {
            get
            {
                return UnityConfig.GetConfiguredContainer().Resolve<IUserLogic>();
            }
        }

        protected IAuthorizeLogic AuthorizeLogic
        {
            get
            {
                var logic = UnityConfig.GetConfiguredContainer().Resolve(LogicType) as IAuthorizeLogic;

                if (logic == null)
                {
                    throw new ArgumentException("Logic type doesn't implement IAuthorizeLogic");
                }

                return logic;
            }
        }

        public LogicAuthorizeAttribute(Type logicType)
        {
            LogicType = logicType;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (IsAuthenticated(filterContext) == false)
            {
                HandleUnauthorizedRequest(filterContext);
                return;
            }

            int? id = GetId(filterContext);

            if (id.HasValue == false)
            {
                return;
            }

            if (HasAccess(filterContext, id))
            {
                return;
            }

            HandleUnauthorizedRequest(filterContext);
        }

        private bool IsAuthenticated(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                return true;
            }

            return false;
        }

        private bool HasAccess(AuthorizationContext filterContext, int? id)
        {
            if (id.HasValue == false)
            {
                return false;
            }

            var user = UserLogic.GetByName(filterContext.RequestContext.HttpContext.User.Identity.Name);

            if (user == null)
            {
                HandleUnauthorizedRequest(filterContext);
                return true;
            }

            if (AuthorizeLogic.HasAccess(user, id.Value))
            {
                return true;
            }

            return false;
        }

        private int? GetId(AuthorizationContext filterContext)
        {
            string idValue = string.Empty;

            if (filterContext.RouteData.Values.Any(d => d.Key == "id"))
            {
                idValue = filterContext.RouteData.Values.FirstOrDefault(d => d.Key == "id").Value.ToString();
            }

            if (string.IsNullOrEmpty(idValue))
            {
                if (filterContext.HttpContext.Request.QueryString.AllKeys.Any(k => k == "id"))
                {
                    idValue = filterContext.HttpContext.Request.QueryString["id"];
                }
            }

            if (string.IsNullOrEmpty(idValue))
            {
                return null;
            }

            int id = 0;

            if (int.TryParse(idValue, out id) == false)
            {
                throw new ArgumentException("The id parameter in request has wrong value.");
            }

            return id;
        }

        protected void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Account",
                                action = "Login"
                            })
                        );
        }
    }
}