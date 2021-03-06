namespace Report.Service.StaticLibrary
{
    public enum AppName
    {
        local1,
        local2,
        local3,
        local4
    }

    public enum ReponseCode
    {
        Success = 0,
        Error = 1,
        Pending = 2
    }
    public static class ApiConstants
    {
        public const string SystemException = "501";
        public const string SqlException = "502";
        public const string ErrorMessage = "Error";
        public const string SuccessMessage = "Success";
        public const string CommonErrorMessage = "Something Went Wrong. Please, Try Again Later";
    }
}
