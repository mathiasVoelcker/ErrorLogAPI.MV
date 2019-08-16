using Extensions.MV;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorLogAPI.Library.MV
{
    public class ErrorLogger : IErrorLogger
    {
        private static Logger _logger;

        public ErrorLogger(string filePath)
        {
            if (_logger == null)
            {
                _logger = new LoggerConfiguration()
                     .WriteTo.File(filePath,
                         rollingInterval: RollingInterval.Day,
                         rollOnFileSizeLimit: true,
                         fileSizeLimitBytes: 1000000,
                         retainedFileCountLimit: 14
                     ).CreateLogger();
            }
        }

        public ErrorLogger()
        {
            if (_logger == null)
            {
                var filePath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "/logs");
                _logger = new LoggerConfiguration()
                     .WriteTo.File(filePath,
                         rollingInterval: RollingInterval.Day,
                         rollOnFileSizeLimit: true,
                         fileSizeLimitBytes: 1000000,
                         retainedFileCountLimit: 14
                     ).CreateLogger();
            }

        }


        public void Log(Exception ex)
        {
            _logger.Write(LogEventLevel.Error, ex.FullExceptionLog());
        }
    }
}
