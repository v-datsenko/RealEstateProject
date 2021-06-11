using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public interface IValidationService<T> where T : class
    {
        public bool Valid(T obj);
    }
}
