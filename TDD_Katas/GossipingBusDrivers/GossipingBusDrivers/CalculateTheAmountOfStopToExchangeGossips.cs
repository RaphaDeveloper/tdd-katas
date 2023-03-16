namespace GossipingBusDrivers
{
    public class CalculateTheAmountOfStopToExchangeGossips
    {
        public string Do(Driver[] drivers)
        {
            if (!drivers.Any())
                return "Never";

            return GoTroughAllStopsAndReturnTheLastStopWithGossipsExchange(drivers)?.ToString() ?? "Never";
        }

        private static int? GoTroughAllStopsAndReturnTheLastStopWithGossipsExchange(Driver[] drivers)
        {
            int? lastStopWithGossipsExchange = null;

            for (int stop = 1; stop <= 480; stop++)
            {
                foreach (var driversOfStop in GroupDriversByStop(drivers))
                {
                    if (ExchangeGossipsBetweenDrivers(driversOfStop))
                        lastStopWithGossipsExchange = stop;
                }

                SendDriversToNextStop(drivers);
            }

            return lastStopWithGossipsExchange;
        }

        private static IEnumerable<List<Driver>> GroupDriversByStop(Driver[] drivers)
        {
            var driversByStop = new Dictionary<int, List<Driver>>();

            foreach (var driver in drivers)
            {
                if (!driversByStop.ContainsKey(driver.CurrentRoute))
                    driversByStop[driver.CurrentRoute] = new List<Driver>();

                driversByStop[driver.CurrentRoute].Add(driver);
            }

            return driversByStop.Values;
        }

        private static bool ExchangeGossipsBetweenDrivers(IEnumerable<Driver> drivers)
        {
            return ExchangeGossipsBetweenDriversFromLeftToRight(drivers) | ExchangeGossipsBetweenDriversFromRightToLeft(drivers); 
        }

        private static bool ExchangeGossipsBetweenDriversFromLeftToRight(IEnumerable<Driver> drivers)
        {
            bool driversExchangedGossips = false;

            for (int i = 0; i + 1 < drivers.Count(); i++)
            {
                if (ExchangeGossipsBetweenCurrentAndNextDriver(drivers.ElementAt(i), drivers.ElementAt(i + 1)))
                    driversExchangedGossips = true;
            }

            return driversExchangedGossips;
        }

        private static bool ExchangeGossipsBetweenDriversFromRightToLeft(IEnumerable<Driver> drivers)
        {
            bool driversExchangedGossips = false;

            for (int i = drivers.Count() - 1; i - 1 >= 0; i--)
            {
                if (ExchangeGossipsBetweenCurrentAndNextDriver(drivers.ElementAt(i), drivers.ElementAt(i - 1)))
                    driversExchangedGossips = true;
            }

            return driversExchangedGossips;
        }

        private static bool ExchangeGossipsBetweenCurrentAndNextDriver(Driver currentDriver, Driver nextDriver)
        {
            currentDriver.GetAllNewGossipsFrom(nextDriver);

            return currentDriver.GotNewGossips;
        }

        private static void SendDriversToNextStop(Driver[] drivers)
        {
            foreach (var driver in drivers)
                driver.GoToNextStop();
        }
    }
}