namespace AspTodo.Infra.Data.Constants
{
    public static class ColumnType
    {
        public static readonly string Int = "int";
        public static readonly string String = "nvarchar(255)";
        public static readonly string ShortString = "nvarchar(63)";
        public static readonly string LongString = "nvarchar(MAX)";
        public static readonly string DateTime = "datetime2";
        public static readonly string Boolean = "Bit";
    }
}