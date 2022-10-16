using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ProjectException : Exception
    {
        public HttpStatusCode _errorCode { get; }
        public object ExceptionData { get; protected set; }
        public ProjectException(string message, HttpStatusCode errorcode = HttpStatusCode.BadRequest, Exception innerexception = null)
            : base(message, innerexception)
        {
            _errorCode = errorcode;
        }
        //public int _errorCode { get; }
        //public ProjectException(string message ,int errorCode=400) : base(message)
        //{
        //    _errorCode = errorCode;
        //}
    }
}
