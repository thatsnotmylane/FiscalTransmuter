namespace FiscalTransmuter;

public static class Transmorgrifying
{
    public static string TransformCategory(UsaaLine line)
    {
        if(line.Description?.Contains("Youtube Subs") == true)
        {
            return "Entertainment";
        }
        else if(String.IsNullOrEmpty(line.Category) == false)
        {
            return line.Category;
        }
        return "Unknown";
    }

    public static string DeriveAspirationCategory(AspirationLine line)
    {
        if (line.Description?.Contains("Youtube Subs") == true)
        {
            return "Entertainment";
        }
        
        return "Unknown";
    }

    public static string DescriptionSanitizer(AspirationLine line)
    {
        if(line.Description?.ToLower().Contains("venmo") == true)
        {
            return "Venmo";
        }
        else
        {
            return line.Description;
        }
    }

    public static HomoginizedLine Transmogrify(HomoginizedLine line)
    {
        if (line.Description?.Contains("Youtube Subs") == true)
        {
            line.Description = "Youtube";
            line.Category = "Entertainment";
        }

        if (line.Description?.ToLower().Contains("venmo") == true)
        {
            line.Description = "Venmo";
            line.Category = "Transfer";
        }

        if(line.Description?.ToLower().Contains("xcel") == true)
        {
            line.Description = "Xcel Energy Bill";
            line.Category = "Utilites";
        }

        if(line.Description?.ToLower().Contains("Discord") == true)
        {
            line.Description = "Discord";
            line.Category = "Entertainment";
        }

        line.Transmorgrify("discord", "Discord", "Entertainment");
        line.Transmorgrify("Planted 1", null, "Charity");
        line.Transmorgrify("Account Conv", null, "Transfer");
        line.Transmorgrify("Ach Co Dept Revenue Costtaxrfd", "Colorado Tax Refund 2023", "Taxes");
        line.Transmorgrify("Education Brands Direct", "Community Brands Paycheck", "Income");
        line.Transmorgrify("Usaa Credit Card Payment", "Credit Card Usaa", "Transfer");
        line.Transmorgrify("Rocket Mortgage", "Mortgage Payment", "Mortgage");
        line.Transmorgrify("Chase Credit Crd", "Credit Card Chase", "Transfer");



        return line;
    }
}
