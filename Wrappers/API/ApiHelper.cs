using System;

namespace Wrappers
{
    public class ApiHelper
    {
        public static void SearchAndDelete(string lastName)
        {
            var wrestlers = API.SearchWrestlers(lastName);
            foreach (var wrestler in wrestlers)
                API.DeleteWrestler(wrestler.ID);
        }

        public static WrestlerEntity CreateRandomWrestler()
        {
            var rnd = new Random();
            var wrestler = new WrestlerEntity();
            wrestler.LastName = "LName" + DateTime.Now.ToString("yyMMddHHmmssffff");
            wrestler.FirstName = "FName" + DateTime.Now.Millisecond;
            wrestler.MiddleName = "MName" + DateTime.Now.Millisecond;
            wrestler.DateOfBirth = String.Format("{0}-{1}-{2}", rnd.Next(1, 31), rnd.Next(1, 13), rnd.Next(1000, 2000));
            wrestler.Region1id = rnd.Next(2, 29);
            wrestler.Region2id = rnd.Next(2, 29);
            wrestler.Fst1id = rnd.Next(2, 9);
            wrestler.Fst2id = rnd.Next(2, 9);
            //wrestler.Trainer1id = rnd.Next(556, 558);
            //wrestler.Trainer2id = rnd.Next(556, 558);
            wrestler.Trainer1id = 556;
            wrestler.Trainer2id = 557;
            //wrestler.Trainer1name = "Trainer1 T.T.";
            //wrestler.Trainer2name = "Trainer2 T.T.";
            wrestler.StyleId = rnd.Next(1, 4);
            wrestler.AgeId = rnd.Next(1, 4);
            wrestler.Year = rnd.Next(2013, 2018);
            wrestler.CardId = rnd.Next(1, 4);

            var id = API.CreateWrestler(wrestler);
            wrestler.ID = id;
            return wrestler;
        }
    }
}