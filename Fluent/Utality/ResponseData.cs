using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluent.Utality
{
    public class ResponseData
    {
        public object result { get; set; }
        public string message { get; set; }



        public static string GetModelErrros(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.Where(E => E.Errors.Count > 0)
                         .SelectMany(E => E.Errors)
                         .Select(E => E.ErrorMessage)
                         .ToList();

            // return errors;
            return string.Join(",", errors.ToArray());
        }
    }
}
