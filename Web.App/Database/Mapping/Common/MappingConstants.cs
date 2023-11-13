namespace Web.App.Database.Mapping.Common
{
    public static class MappingConstants
    {
        public static class Database
        {
            public static class Lengths
            {
                public const int MaxVarchar = 65535;
                public const int MaxNvarchar = 21845;
                public const int RefCodeLength = 100;
                public const int DescriptionLength = 100;
                public const int LabelRefCodeLength = 100;
                public const int TenThousand = 10000;
                public const int OptSwatScanId = 50;
                public const int EmailLength = 254; //https://stackoverflow.com/a/574698
            }

            public static class Types
            {
                public const string Boolean = "tinyint(1)"; // In MySql, its the way to represent booleans (0 or 1)
                public const string Int = "int";
                public const string Varchar = "varchar";
                public const string Nvarchar = "nvarchar";
                public const string LongText = "longtext";
                public const string Text = "text";
                public const string MediumText = "mediumtext";
            }
        }
    }
}
