using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Results
{
    public class Result : IResult
    {
        // :this(success)-> bu sinifin icerisindeki tek parametreli constructor'a success bilgisini gonder
        //iki parametre gonderilirse iki metotta otomatik calisir ve kod tekrari olmaz
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
