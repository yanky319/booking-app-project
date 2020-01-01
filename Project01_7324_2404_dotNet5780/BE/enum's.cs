public enum Areas
{
    All, North, Center, Jerusalem, South
}

public enum SubAreas
{
    Zefat = 100, Haifa, Miron,
    Tel_Aviv = 200, Netanya, Ramat_Gan,
    Jerusalem = 300, Beit_Shemesh, Maale_Adumim,
    Beer_Sheva = 400,
}

public enum Types
{
    Zimmer, Hotel, Camping, Etc, 
}

public enum ThreeChoice
{
    not_interested, optional, necessary
}

public enum RequestStatus
{
    open, deal_closed, expired
}

public enum OrderStatus
{
    not_addressed, mail_sent, closed_with_deal, closed_without_deal
}
