using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Utilities
{
    public class OperationResult
    {
        public string Message { get; set; }=string.Empty;
        public OperationResultStatus Status { get; set; }

        public static OperationResult Error(string message)
        {
            return new OperationResult
            {
                Status = OperationResultStatus.Error,
                Message = message
            };

        }

        public static OperationResult Error()
        {
            return new OperationResult
            {
                Status = OperationResultStatus.Error,
                Message = " ناموفق عملیات بود "
            };

        }

        public static OperationResult NotFound(string message)
        {
            return new OperationResult
            {
                Status = OperationResultStatus.NotFound,
                Message = message
            };

        }

        public static OperationResult NotFound()
        {
            return new OperationResult
            {
                Status = OperationResultStatus.NotFound,
                Message = "عملیات یافت نشد"
            };

        }

        public static OperationResult Success()
        {
            return new OperationResult
            {
                Status = OperationResultStatus.Success,
                Message =  "عملیات موفق آمیز بود"
            };

        }

        public static OperationResult Success(string message)
        {
            return new OperationResult
            {
                Status = OperationResultStatus.Success,
                Message = message
            };

        }




    }
    public enum OperationResultStatus
        {
            Error=20,
            Success=200,
            NotFound=404
        }
    
     
}
