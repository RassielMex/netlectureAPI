namespace netlectureAPI.Models
{
    public static class Grade
    {
        public static readonly string First = "Primero";
        public static readonly string Second = "Segundo";
        public static readonly string Third = "Tercero";

        public static bool IsGrade(string value)
        {
            return value == First || value == Second || value == Third;
        }
    }
}