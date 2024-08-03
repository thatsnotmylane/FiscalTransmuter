namespace FiscalTransmuter;

public static class Transmorgrifying
{
    public static string MassageCategory(string category)
    {
        switch (category)
        {
            case "Hobbies":
            case "Movies & Dvds":
            case "Music":
                return ENTERTAINMENT;
            case "Spa & Massage":
            case "Hair":
                return PERSONAL_CARE;
            case "Arts":
            case "Gifts & Donations":
            case "Gift":
            case "Clothing":
            case "Sporting Goods":
                return SHOPPING;
            case "Eyecare":
            case "Dentist":
            case "Pharmacy":
                return DOCTOR;
            case "Internet":
            case "Bills & Utilities":
            case "Mobile Phone":
                return UTILITIES;
            case "Food & Dining":
            case "Fast Food":
            case "Coffee Shops":
            case "Restaurants":
            case "Alcohol & Bars":
                return EATING_OUT;
            case "Gas":
            case "Auto & Transport":
            case "Parking":
            case "Service & Parts":
                return CARS;
            case "Pet Food & Supplies":
            case "Veterinary":
                return DOGS;
            case "Home Services":
            case "Home Improvement":
            case "Furnishings":
                return HOME;
            case "Air Travel":
            case "Rental Car & Taxi":
            case "Hotel":
                return TRAVEL;
            case "Credit Card Payment":
                return TRANSFER;
            default:
                return category;
        }
    }

    public static HomoginizedLine Transmogrify(HomoginizedLine line)
    {
        line.Transmorgrify("Youtube Subs", "Youtube", ENTERTAINMENT);
        line.Transmorgrify("venmo", "Venmo", TRANSFER);
        line.Transmorgrify("xcel", "Xcel Energy Bill", UTILITIES);
        line.Transmorgrify("discord", "Discord", ENTERTAINMENT);
        line.Transmorgrify("Planted", null, CHARITY);
        line.Transmorgrify("Account Conv", null, TRANSFER);
        line.Transmorgrify("Ach Co Dept Revenue Costtaxrfd", "Colorado Tax Refund 2023", TAXES);
        if (line.IsChecking == true)
        {
            line.Transmorgrify("Education Brands Direct", "Community Brands Paycheck (Checking)", INCOME);
        }
        else if (line.IsSavings == true)
        {
            line.Transmorgrify("Education Brands Direct", "Community Brands Paycheck (Savings)", SAVINGS);
        }
        line.Transmorgrify("Usaa Credit Card Payment", "Credit Card Usaa", TRANSFER);
        line.Transmorgrify("Rocket Mortgage", "Mortgage Payment", "Mortgage");
        line.Transmorgrify("Chase Credit Crd", "Credit Card Chase", TRANSFER);
        line.Transmorgrify("Instant transfer", TRANSFER, TRANSFER);
        line.Transmorgrify("Jagex", "Runescape", ENTERTAINMENT);
        line.Transmorgrify("E8yoga", "E8 Yoga", INCOME);
        line.Transmorgrify("Yeager Farm Home", "HOA", HOME);
        line.Transmorgrify("Fid Bkg Svc Llc", "Fidelity Roth IRA", SAVINGS);
        line.Transmorgrify("Aspiration Pay What is Fair", null, BANK);
        line.Transmorgrify("Cardkingdom", "Magic Cards", ENTERTAINMENT);
        line.Transmorgrify("Steam Games", "Steam Games", ENTERTAINMENT);
        line.Transmorgrify("Michaels Stores", "Michaels", SHOPPING);
        line.Transmorgrify("Mtgo Magic", "Magic Online", ENTERTAINMENT);
        line.Transmorgrify("City Payroll", "Louisville Rec", INCOME);
        line.Transmorgrify("Red Cat Apothecar Boulde", "Red Cat Apothecary", SHOPPING);
        line.Transmorgrify("Twitchinter", "Twitch", ENTERTAINMENT);
        line.Transmorgrify("Google Nest", "Google Nest", HOME);
        line.Transmorgrify("Mobile Check Deposit", null, INCOME);
        line.Transmorgrify("Urban Hotdog", "Urban Hotdog", EATING_OUT);
        line.Transmorgrify("ATM Fee Reimbursement", "ATM Fee Reimbursement", BANK);
        line.Transmorgrify("ATM Withdrawal", null, TRANSFER);
        line.Transmorgrify("Comotorveh Co.", "Colorado DMV", CARS);
        line.Transmorgrify("Annual Aspiration Plus Charge", null, BANK);
        line.Transmorgrify("Conde Nast", "Bone Appetie", ENTERTAINMENT);
        line.Transmorgrify("Abiquiu Inn Abiquiu Nm", "Abiquiu Inn", TRAVEL);
        line.Transmorgrify("Ach Irs Treas 310 Tax Ref", "Federal Refund", TAXES);
        line.Transmorgrify("Blizzardent", "Blizzard", ENTERTAINMENT);
        line.Transmorgrify("Usaa.Com Pay Ext Life", "Life Insurance", INSURANCE);
        line.Transmorgrify("Interest Earned", null, INCOME);
        line.Transmorgrify("Foreign Transaction Fee", null, BANK);
        line.Transmorgrify("Paypal Universalmu 4029357733 Ca", "Taylor Swift Merch?", SHOPPING);
        line.Transmorgrify("Plant Your Change - Reward", null, BANK);
        line.Transmorgrify("Sq Buenos Nachos Llc Erie Co", "Buenos Nachos Erie", EATING_OUT);
        line.Transmorgrify("Mspbna", "Etrade Roth IRA", SAVINGS);
        line.Transmorgrify("Transfer to Wells Fargo", null, TRANSFER);
        line.Transmorgrify("Colorado Sports", null, DOCTOR);
        line.Transmorgrify("Dry Storage", null, EATING_OUT);
        line.Transmorgrify("Suti&co", null, EATING_OUT);
        line.Transmorgrify("AMZN Mktp US", "Amazon", SHOPPING);
        line.Transmorgrify("CHIPOTLE", "Chipotle", EATING_OUT);
        line.Transmorgrify("LPAH.VET", "Longs Peak Animal Hospital", DOGS);
        line.Transmorgrify("PARKMOBILE", "Parking", CARS);
        line.Transmorgrify("PARRYS LONGMONT CO", "Parry's Pizza", EATING_OUT);
        line.Transmorgrify("SWEET COW", "Sweet Cow", EATING_OUT);
        line.Transmorgrify("SHERPAS ADVENTURE REST", "Sherpa's Restrault", EATING_OUT);
        line.Transmorgrify("TRADER JOE", "Trader Joe's", GROCERIES);
        line.Transmorgrify("TST* LANDLINE DOUGHNUTS", "Laneline Doughnuts", EATING_OUT);
        line.Transmorgrify("Midjourney", "Midjourney", ENTERTAINMENT);
        line.Transmorgrify("Tryotter Gurkhas Rest", "Gurkhas", EATING_OUT);
        line.Transmorgrify("Microsoft", "Microsoft", SHOPPING);
        line.Transmorgrify("Vail Resorts Management Company", "Skiing", ENTERTAINMENT);
        line.Transmorgrify("Top Golf", "Top Golf", ENTERTAINMENT);
        line.Transmorgrify("Pyl Advanced Community Se", "HOA", HOME);
        line.Transmorgrify("Personaldevelopmentsch", "Personal Development School", PERSONAL_CARE);
        line.Transmorgrify("The Old Mine", "The Old Mine", EATING_OUT);
        line.Transmorgrify("Costco", "Costco", GROCERIES);
        line.Transmorgrify("Shoes & Brews", null, EATING_OUT);
        line.Transmorgrify("Tesco", null, GROCERIES);
        line.Transmorgrify("Wonder / Boulder", null, EATING_OUT);
        line.Transmorgrify("Your Butcher Frank", null, EATING_OUT);
        line.Transmorgrify("Moxie Bread", null, EATING_OUT);
        line.Transmorgrify("The Mountain Fountain", null, EATING_OUT);
        line.Transmorgrify("Prager Brothers Carls", null, EATING_OUT);
        line.Transmorgrify("Spruce Confections", null, EATING_OUT);
        line.Transmorgrify("The Longmont Axe Hous", null, ENTERTAINMENT);
        line.Transmorgrify("Erick Schats Bakkery", null, EATING_OUT);
        line.Transmorgrify("Gelato Boy", null, EATING_OUT);
        line.Transmorgrify("Pohala.net", null, SHOPPING);
        line.Transmorgrify("Present Llc", "Presetn CBD", EATING_OUT);
        line.Transmorgrify("Longmont Climbing", "Longmont Climbing", HEALTH_AND_FITNESS);
        line.Transmorgrify("Fi D77nwn", "Google Fi", UTILITIES);
        line.Transmorgrify("Vital Climbing Gym", null, HEALTH_AND_FITNESS);
        line.Transmorgrify("Timbers Tap House", null, EATING_OUT);
        line.Transmorgrify("USAA Insurance Payment", "USAA Insurance Payment (Car)", CARS);
        line.Transmorgrify("2.23101E+11", "Credit Card Payment", TRANSFER);
        line.Transmorgrify("2.23101E+11", "Credit Card Payment", TRANSFER);
        line.Transmorgrify("223101140521", "Credit Card Payment", TRANSFER);
        line.Transmorgrify("Reward Points Redemption", null, INCOME);
        line.Transmorgrify("Idemia Tsa Precheck", "TSA Pre-Check", TRAVEL);
        line.Transmorgrify("Rocky Mountain National", null, TRAVEL);
        line.Transmorgrify("Brooksee Endurance Ev", "Revel Race", HEALTH_AND_FITNESS);
        line.Transmorgrify("Fi ", "Google Fi", UTILITIES);
        line.Transmorgrify("Vauxwall East London", null, HEALTH_AND_FITNESS);
        line.Transmorgrify("Mile End Climbing Wall London", null, HEALTH_AND_FITNESS);
        line.Transmorgrify("Daybreak Game Company", "MTGO", ENTERTAINMENT);
        line.Transmorgrify("Benugo British Museum London", "High Tea British Museam", EATING_OUT);
        line.Transmorgrify("Northern Colorado Womlyons", "Massage Tyrin", HEALTH_AND_FITNESS);

        return line;
    }

    public const string DOGS = "Dogs";
    public const string INSURANCE = "Insurance";
    public const string EATING_OUT = "Eating Out";
    public const string ENTERTAINMENT = "Entertainment";
    public const string TRANSFER = "Transfer";
    public const string UTILITIES = "Utilities";
    public const string CHARITY = "Charity";
    public const string TAXES = "Taxes";
    public const string INCOME = "Income";
    public const string HOME = "Home";
    public const string BANK = "Bank";
    public const string SAVINGS = "Savings";
    public const string SHOPPING = "Shopping";
    public const string GROCERIES = "Groceries";
    public const string MORTGAGE = "Mortgage";
    public const string RESTAURANTS = "Restaurants";
    public const string ALCOHOL_AND_BARS = "Alcohol & Bars";
    public const string COFFEE_SHOPS = "Coffee Shops";
    public const string GAS = "Gas";
    public const string CLOTHING = "Clothing";
    public const string FAST_FOOD = "Fast Food";
    public const string FOOD_AND_DINING = "Food & Dining";
    public const string SPORTING_GOODS = "Sporting Goods";
    public const string ELECTRONICS_AND_SOFTWARE = "Electronics & Software";
    public const string HEALTH_AND_FITNESS = "Health & Fitness";
    public const string SERVICE_AND_PARTS = "Service & Parts";
    public const string UNCATEGORIZED = "Uncategorized";
    public const string TRAVEL = "Travel";
    public const string MUSIC = "Music";
    public const string VETERINARY = "Veterinary";
    public const string PARKING = "Parking";
    public const string BILLS_AND_UTILITIES = "Bills & Utilities";
    public const string DOMAIN_NAMES = "Domain Names";
    public const string PERSONAL_CARE = "Personal Care";
    public const string SPORTS = "Sports";
    public const string DOCTOR = "Doctor";
    public const string FURNISHINGS = "Furnishings";
    public const string HOBBIES = "Hobbies";
    public const string HOME_IMPROVEMENT = "Home Improvement";
    public const string PHARMACY = "Pharmacy";
    public const string EDUCATION = "Education";
    public const string GIFTS_AND_DONATIONS = "Gifts & Donations";
    public const string BUSINESS_SERVICES = "Business Services";
    public const string AIR_TRAVEL = "Air Travel";
    public const string HOTEL = "Hotel";
    public const string FINANCIAL = "Financial";
    public const string HOME_SERVICES = "Home Services";
    public const string HAIR = "Hair";
    public const string CARS = "Cars";


}
