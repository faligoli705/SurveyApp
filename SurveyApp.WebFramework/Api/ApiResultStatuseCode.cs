﻿using System.ComponentModel.DataAnnotations;

namespace SurveyApp.WebFramework.Api
{
    public enum ApiResultStatuseCode
    {
        [Display(Name ="عملیات با موفقیت انجام شد")]
        Success=0,

        [Display(Name = "خطایی در سرور رخ داده است")]
        ServerError =1,

        [Display(Name = "پارامترهای ارسالی معتبر نیستند")]
        BadRequest =2,

        [Display(Name = "یافت نشد")]
        NotFound =3,

        [Display(Name = "لیست خالی است")]
        ListEmpty =4
    }
}
