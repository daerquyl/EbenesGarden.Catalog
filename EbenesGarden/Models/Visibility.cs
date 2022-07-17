namespace Catalog.Models
{
    public enum VisibilityRange
    {
        NONE, MEDIUM, NORMAL, HIGH
    }

    public record Visibility(int Value, VisibilityRange Range)
    {
        public static readonly Visibility Default = new Visibility(0, VisibilityRange.NONE);
    }
}