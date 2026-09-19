namespace WebAPI.Data
{
    public static class Messages
    {
        public static class Expense
        {
            public const string NotFound = "MSG-00001";
            public const string Found = "MSG-00002";
            public const string Added = "MSG-00003";
            public const string InvalidUpdateModel = "MSG-00004";
            public const string UpdatedSuccessfully = "MSG-00005";
            public const string NothingToUpdate = "MSG-00006";
            public const string Deleted = "MSG-00007";

            public static class Validations
            {
                public const string EmptyTitle = "MSG-00008";
                public const string InvalidAmount = "MSG-00009";
            }
        }
    }
}
