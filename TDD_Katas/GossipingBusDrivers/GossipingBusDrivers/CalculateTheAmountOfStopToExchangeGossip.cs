namespace GossipingBusDrivers
{
    public class CalculateTheAmountOfStopToExchangeGossip
    {
        public string Do(Driver[] drivers)
        {
            if (!drivers.Any())
                return "Never";
            
            int amount = 0;

            Driver driver1 = drivers[0];
            Driver driver2 = drivers[1];
            Driver driver3 = drivers.Length == 3 ? drivers[2] : null;

            for (int min = 0; min < 480; min++)
            {
                bool increment = false;

                if (driver1.Route[driver1.CurrentStop] == driver2.Route[driver2.CurrentStop])
                {
                    int amountOfGossipsOfDriver1 = driver1.AmountOfGossips;
                    int amountOfGossipsOfDriver2 = driver2.AmountOfGossips;

                    if (!driver1.AmountOfGossipsByDriver.ContainsKey(driver2) || driver1.AmountOfGossipsByDriver[driver2] != driver2.AmountOfGossips)
                    {
                        driver1.AmountOfGossipsByDriver.TryGetValue(driver2, out int lastAmountOfGossips);

                        driver1.AmountOfGossips += (amountOfGossipsOfDriver2 - lastAmountOfGossips);

                        increment = true;                        
                    }

                    if (!driver2.AmountOfGossipsByDriver.ContainsKey(driver1) || driver2.AmountOfGossipsByDriver[driver1] != driver1.AmountOfGossips)
                    {
                        driver2.AmountOfGossipsByDriver.TryGetValue(driver1, out int lastAmountOfGossips);

                        driver2.AmountOfGossips += (amountOfGossipsOfDriver1 - lastAmountOfGossips);

                        increment = true;
                    }

                    driver1.AmountOfGossipsByDriver[driver2] = driver2.AmountOfGossips;
                    driver2.AmountOfGossipsByDriver[driver1] = driver1.AmountOfGossips;
                }

                if (driver3 != null && driver1.Route[driver1.CurrentStop] == driver3.Route[driver3.CurrentStop])
                {
                    if (!driver1.AmountOfGossipsByDriver.ContainsKey(driver3) || driver1.AmountOfGossipsByDriver[driver3] != driver3.AmountOfGossips)
                    {
                        driver1.AmountOfGossipsByDriver[driver3] = driver3.AmountOfGossips;
                        driver1.AmountOfGossips += driver3.AmountOfGossips;

                        increment = true;
                    }
                }

                if (driver3 != null && driver2.Route[driver2.CurrentStop] == driver3.Route[driver3.CurrentStop])
                {
                    if (!driver2.AmountOfGossipsByDriver.ContainsKey(driver3) || driver2.AmountOfGossipsByDriver[driver3] != driver3.AmountOfGossips)
                    {
                        driver2.AmountOfGossipsByDriver[driver3] = driver3.AmountOfGossips;
                        driver2.AmountOfGossips += driver3.AmountOfGossips;

                        increment = true;
                    }
                }                

                driver1.GoToNextStop();
                driver2.GoToNextStop();

                if (driver3 != null)
                    driver3.GoToNextStop();

                if (increment)
                    amount++;
            }

            return amount == 0 ? "Never" : amount.ToString();
        }
    }

    public class Driver
    {
        public Driver(int[] route)
        {
            Route = route;
        }

        public int[] Route { get; }
        public int CurrentStop { get; internal set; }
        public int AmountOfGossips { get; internal set; } = 1;
        public Dictionary<Driver, int> AmountOfGossipsByDriver { get; internal set; } = new Dictionary<Driver, int>();

        internal void GoToNextStop()
        {
            CurrentStop++;

            if (CurrentStop == Route.Length)
                CurrentStop = 0;
        }
    }
}