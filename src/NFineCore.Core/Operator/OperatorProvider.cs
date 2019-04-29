using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
namespace NFineCore.Core
{
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }
        private string LoginUserKey = "nfine_login_user";

        public OperatorModel GetOperator()
        {
            //Session 模式            
            string sessionString = StaticHttpContext.Current.Session.GetString(LoginUserKey);
            if (!string.IsNullOrEmpty(sessionString))
            {
                OperatorModel operatorModel = JsonConvert.DeserializeObject<OperatorModel>(sessionString);
                //OperatorModel operatorModel = StaticHttpContext.Current.Session.Get<OperatorModel>(LoginUserKey);
                return operatorModel;
            }
            else
            {
                return null;
            }

            //Cookie模式
            //string cookieString = string.Empty;
            //StaticHttpContext.Current.Request.Cookies.TryGetValue(LoginUserKey, out cookieString);
            //if (!string.IsNullOrEmpty(cookieString))
            //{
            //    OperatorModel operatorModel = new OperatorModel();
            //    operatorModel = DESEncrypt.Decrypt(cookieString).ToObject<OperatorModel>();
            //    return operatorModel;
            //}
            //else
            //{
            //    return null;
            //}
        }
        public void AddOperator(OperatorModel operatorModel)
        {
            //Session 模式
            StaticHttpContext.Current.Session.SetString(LoginUserKey, JsonConvert.SerializeObject(operatorModel));
            //StaticHttpContext.Current.Session.Set(LoginUserKey, operatorModel);            

            //Cookie 模式
            //StaticHttpContext.Current.Response.Cookies.Append(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()), new CookieOptions()
            //{
            //    //Expires = System.DateTime.Now.AddMinutes(60)
            //});
        }
        public void RemoveOperator()
        {
            StaticHttpContext.Current.Session.Remove(LoginUserKey);

            //Cookie 模式
            //StaticHttpContext.Current.Response.Cookies.Delete(LoginUserKey);
        }
    }
}
