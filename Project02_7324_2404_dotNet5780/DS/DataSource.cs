using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{
    public class DataSource
    {
        public static List<GuestRequest> guestRequests = new List<GuestRequest>()
        {
            new BE.GuestRequest()
                {
                    GuestRequestKey = 10000001,
                    PrivateName = "Yaakov",
                    FamilyName = "Goldshtin",
                    MailAddress = "a@a.a",
                    EntryDate = new DateTime(2020, 3, 20),
                    ReleaseDate = new DateTime(2020, 3, 23),
                    Area = Areas.All,
                    SubArea = SubAreas.All,
                    Type = Types.All,
                    Adults = 2,
                    Children = 3,
                    Pool = ThreeChoice.optional,
                    Jacuzzi = ThreeChoice.optional,
                    Garden = ThreeChoice.optional,
                    ChildrensAttractions = ThreeChoice.optional,
                    wifi = ThreeChoice.optional,
                    accessibility = ThreeChoice.optional,
                    Meals = meals.not_interested,
                    specialMmeal = special_meal.non,
                }
    };

        public static List<HostingUnit> hostingUnits = new List<HostingUnit>()
        {
            new HostingUnit()
            {
                HostID = 10000002,
                HostingUnitKey = 10000003,
                HostingUnitName = "chofeshTow",
                Area = Areas.Jerusalem,
                SubArea = SubAreas.Beit_Shemesh,
                Type = Types.Camping,
                num_beds = 10,
                Pool = true,
                Jacuzzi = true,
                Garden = true,
                ChildrensAttractions = true,
                wifi = true,
                accessibility = true,
                Diary = new bool[12,31],
            },
            new HostingUnit()
            {
                HostID = 10000002,
                HostingUnitKey =10000002,
                HostingUnitName = "chofeshTow",
                Area = Areas.Jerusalem,
                SubArea = SubAreas.Beit_Shemesh,
                Type = Types.Camping,
                num_beds = 10,
                Pool = true,
                Jacuzzi = true,
                Garden = true,
                ChildrensAttractions = true,
                wifi = true,
                accessibility = true,
                 Diary = new bool[12,31],
            },
            new HostingUnit()
    {
        HostID = 10000002,
        HostingUnitKey =10000004,
        HostingUnitName = "chofeshOne",
        Area = Areas.Jerusalem,
        SubArea = SubAreas.Beit_Shemesh,
        Type = Types.Camping,
        num_beds = 10,
        Pool = true,
        Jacuzzi = true,
        Garden = true,
        ChildrensAttractions = true,
        wifi = true,
        accessibility = true,
         Diary = new bool[12,31],
    }
    };

        public static List<Host> hosts = new List<Host>()
        {
            new BE.Host()
    {
                HostID = 10000002,
        PrivateName = "name1",
        FamilyName = "Esterzon",
        passwordeHash = "11".GetHashCode(),
        FhoneNumber = "05276140977",
        MailAddress = "bb@b.b",
        BankBranch = new BankBranch()
           {
                 BankNumber = 123,
                 BankName ="Hapoalim",
                 BranchNumber = 765,
                 BranchAddress = "ggg",
                 BranchCity = "jerusalem"
           },
        BankAccountNumber = 2468,
        CollectionClearance = false,
    }
    };

        public static List<Order> orders = new List<Order>()
        {
            new BE.Order()
                {
                    HostingUnitKey = 10000002,
                    HostID = 10000002,
                    GuestRequestKey = 10000004,
                }
    };

        public static List<BankBranch> bankBranches = new List<BankBranch>()
        {
           new BankBranch()
           {
                 BankNumber = 123,
                 BankName = "Hapoalim",
                 BranchNumber = 765,
                 BranchAddress = "ggg",
                 BranchCity = "jerusalem"
           }
        };
    }
}
//#region add host
//try
//{
//    a.addHost(
//    new BE.Host()
//    {
//        PrivateName = "chayim",
//        FamilyName = "Berenshtane",
//        FhoneNumber = "05276140976",
//        MailAddress = "aa@a.a",
//        BankBranch = a.getBankBranchs().ToList()[0],
//        BankAccountNumber = 1357,
//        CollectionClearance = true,
//    });
//}
//catch (Exception e)
//{

//    Console.WriteLine(e.Message);
//}
//try
//{
//    a.addHost(
//    
//}
//catch (Exception e)
//{

//    Console.WriteLine(e.Message);
//}
//#endregion

//#region add hosting unit
//try
//{
//    a.addHostingUnit(new BE.HostingUnit()
//    {
//        HostID = 10000001,
//        HostingUnitName = "chofeshOne",
//        Area = Areas.Jerusalem,
//        SubArea = SubAreas.Beit_Shemesh,
//        Type = Types.Camping,
//        num_beds = 10,
//        Pool = true,
//        Jacuzzi = true,
//        Garden = true,
//        ChildrensAttractions = true,
//        wifi = true,
//        accessibility = true,

//    });
//}
//catch (Exception e)
//{

//    Console.WriteLine(e.Message);
//}

//try
//{
//    a.addHostingUnit(
//}
//catch (Exception e)
//{

//    Console.WriteLine(e.Message);
//}
//#endregion