using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;

namespace PL
{
    public class Program
    {
        static string path = @"..\..\..\DataSource\";
        static string Orders = @"Orders.xml";
        static string GuestRequestFileName = @"Request.xml";
        static string HostingUnitsFileName = @"HostingUnits.xml";
        static string HostsFileName = @"Hosts.xml";
        static string Configurations = @"Configurations.xml";
        static string BanksFileName = @"Banks.xml";
        public static void SaveToXML<T>(T source, string fileName)
        {
            try
            {
                FileStream file = new FileStream(path + fileName, FileMode.OpenOrCreate);
                XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
                xmlSerializer.Serialize(file, source);
                file.Close();
            }
            catch
            {
                Console.WriteLine("AAAAAA");
            }

        }
        public static void Main()
        {
            SaveToXML(new List<BE.HostingUnit>()
            {new BE.HostingUnit() }, HostingUnitsFileName);

            //var values = Enum.GetValues(typeof(Types));
            //foreach(var a in values )
            //{
            //    Console.WriteLine(a.ToString());

            //}


            //BL.IBL a = BL.FactorySingleton.Instance;
            //#region add Requests
            //Console.WriteLine("--------------------------ERROR'S-------------------------------");
            //try
            //{
            //    a.addGuestRequest(new BE.GuestRequest()
            //    {
            //        PrivateName = "Aba",
            //        FamilyName = "Taber",
            //        MailAddress = "a@a.a",
            //        EntryDate = new DateTime(2020, 2, 13),
            //        ReleaseDate = new DateTime(2020, 3, 13),
            //        Area = Areas.Center,
            //        SubArea = SubAreas.Netanya,
            //        Type = Types.All,
            //        Adults = 2,
            //        Children = 0,
            //        Pool = ThreeChoice.necessary,
            //        Jacuzzi = ThreeChoice.optional,
            //        Garden = ThreeChoice.optional,
            //        ChildrensAttractions = ThreeChoice.optional,
            //        wifi = ThreeChoice.optional,
            //        accessibility = ThreeChoice.optional,
            //        Meals = meals.not_interested,
            //        specialMmeal = special_meal.non,
            //    });
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //try
            //{
            //    a.addGuestRequest(new BE.GuestRequest()
            //    {
            //        PrivateName = "Moshe",
            //        FamilyName = "Helfgot",
            //        MailAddress = "a@ayy.a",
            //        EntryDate = new DateTime(2020, 6, 13),
            //        ReleaseDate = new DateTime(2020, 6, 23),
            //        Area = Areas.All,
            //        SubArea = SubAreas.All,
            //        Type = Types.All,
            //        Adults = 2,
            //        Children = 3,
            //        Pool = ThreeChoice.optional,
            //        Jacuzzi = ThreeChoice.optional,
            //        Garden = ThreeChoice.optional,
            //        ChildrensAttractions = ThreeChoice.optional,
            //        wifi = ThreeChoice.optional,
            //        accessibility = ThreeChoice.optional,
            //        Meals = meals.not_interested,
            //        specialMmeal = special_meal.non,
            //    });
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //try
            //{
            //    a.addGuestRequest(new BE.GuestRequest()
            //    {
            //        PrivateName = "Yaakov",
            //        FamilyName = "Goldshtin",
            //        MailAddress = "a@a.a",
            //        EntryDate = new DateTime(2020, 3, 20),
            //        ReleaseDate = new DateTime(2020, 3, 23),
            //        Area = Areas.All,
            //        SubArea = SubAreas.All,
            //        Type = Types.All,
            //        Adults = 2,
            //        Children = 3,
            //        Pool = ThreeChoice.optional,
            //        Jacuzzi = ThreeChoice.optional,
            //        Garden = ThreeChoice.optional,
            //        ChildrensAttractions = ThreeChoice.optional,
            //        wifi = ThreeChoice.optional,
            //        accessibility = ThreeChoice.optional,
            //        Meals = meals.not_interested,
            //        specialMmeal = special_meal.non,
            //    });
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //try
            //{
            //    a.addGuestRequest(new BE.GuestRequest()
            //    {
            //        PrivateName = "Yaankov",
            //        FamilyName = "zozo",
            //        MailAddress = "a@a.a",
            //        EntryDate = new DateTime(2020, 3, 23),
            //        ReleaseDate = new DateTime(2020, 3, 23),
            //        Area = Areas.All,
            //        SubArea = SubAreas.All,
            //        Type = Types.All,
            //        Adults = 2,
            //        Children = 3,
            //        Pool = ThreeChoice.optional,
            //        Jacuzzi = ThreeChoice.optional,
            //        Garden = ThreeChoice.optional,
            //        ChildrensAttractions = ThreeChoice.optional,
            //        wifi = ThreeChoice.optional,
            //        accessibility = ThreeChoice.optional,
            //        Meals = meals.not_interested,
            //        specialMmeal = special_meal.non,
            //    });
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //try
            //{
            //    a.addGuestRequest(new BE.GuestRequest()
            //    {
            //        PrivateName = "Yaankov",
            //        FamilyName = "coco",
            //        MailAddress = "a@abb.a",
            //        EntryDate = new DateTime(2020, 3, 21),
            //        ReleaseDate = new DateTime(2020, 3, 23),
            //        Area = Areas.All,
            //        SubArea = SubAreas.All,
            //        Type = Types.All,
            //        Adults = 2,
            //        Children = 3,
            //        Pool = ThreeChoice.optional,
            //        Jacuzzi = ThreeChoice.optional,
            //        Garden = ThreeChoice.optional,
            //        ChildrensAttractions = ThreeChoice.optional,
            //        wifi = ThreeChoice.optional,
            //        accessibility = ThreeChoice.optional,
            //        Meals = meals.not_interested,
            //        specialMmeal = special_meal.non,
            //    });
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //#endregion

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
            //    new BE.Host()
            //    {
            //        PrivateName = "Chna",
            //        FamilyName = "Esterzon",
            //        FhoneNumber = "05276140977",
            //        MailAddress = "bb@b.b",
            //        BankBranch = a.getBankBranchs().ToList()[0],
            //        BankAccountNumber = 2468,
            //        CollectionClearance = false,
            //    });
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
            //    a.addHostingUnit(new BE.HostingUnit()
            //    {
            //        HostID = 10000002,
            //        HostingUnitName = "chofeshTow",
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
            //#endregion

            //#region add order
            //try
            //{
            //    a.addOrder(new BE.Order()
            //    {
            //        HostingUnitKey = 10000001,
            //        HostID = 10000001,
            //        GuestRequestKey = 10000002,
            //    });
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e.Message);
            //}
            //try
            //{
            //    a.addOrder(new BE.Order()
            //    {
            //        HostingUnitKey = 10000002,
            //        HostID = 10000001,
            //        GuestRequestKey = 10000003,
            //    });
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e.Message);
            //}
            //try
            //{
            //    a.addOrder(new BE.Order()
            //    {
            //        HostingUnitKey = 10000002,
            //        HostID = 10000001,
            //        GuestRequestKey = 10000004,
            //    });
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e.Message);
            //}
            //Console.WriteLine("\n\n--------------------------Guest requests-------------------------------");
            //foreach (var item in a.getGuestRequests())
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine('\n');
            //}
            //Console.WriteLine("--------------------------Hosting units-------------------------------");
            //foreach (var item in a.getHostingUnits())
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine('\n');
            //}
            //Console.WriteLine("--------------------------Orders-------------------------------");
            //foreach (var item in a.getOrders())
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine('\n');
            //}

            //#endregion
            Console.ReadKey();
        }
    }
}




