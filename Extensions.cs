namespace FiscalTransmuter;

public static class Extensions
{
    public static void Transmorgrify(this HomoginizedLine line, string match, string? description, string category)
    {
        if (line.Description?.ToLower().Contains(match.ToLower()) == true)
        {
            if (String.IsNullOrEmpty(description) == false)
            {
                line.Description = description;
            }
            line.Category = category;
            line.TransmorgrifiedCount++;
        }
    }
}
