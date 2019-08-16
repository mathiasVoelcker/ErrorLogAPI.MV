using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorLogAPI.Library.MV
{
    public interface IErrorLogger
    {
        void Log(Exception ex);
    }
}
