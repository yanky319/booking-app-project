public enum Areas
{
    All, North, Center, Jerusalem, South
}

public enum SubAreas
{
    All = 0,
    Zefat = 101, Haifa, Miron,
    Tel_Aviv = 201, Netanya, Ramat_Gan,
    Jerusalem = 301, Beit_Shemesh, Maale_Adumim,
    Ber_Sheva = 401, Dimona, Ashdod
}

public enum Types
{
   All, Zimmer, Hotel, Camping, 
}

public enum ThreeChoice
{
    optional, not_interested, necessary
}

public enum RequestStatus
{
    open, deal_closed, expired
}

public enum OrderStatus
{
    not_addressed, mail_sent, closed_with_deal, closed_without_deal
}

public enum meals
{
    not_interested, Breakfast, Full_board
}

public  enum special_meal
{
   non, Milk_free, Gluten_free, nut_free, vegetarian, Glatt_Kosher
}

public enum BankNames
{
   Hapoalim, Mercantile, mizrahi, leumi, Discount 
}