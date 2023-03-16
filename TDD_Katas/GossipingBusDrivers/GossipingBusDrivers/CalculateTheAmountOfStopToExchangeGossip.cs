namespace GossipingBusDrivers
{
    public class CalculateTheAmountOfStopToExchangeGossip
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

    public class Driver
    {
        public Driver(int[] route)
        {
            Route = route;
            AmountOfGossips = 1;
            TotalAmountOfGossipsByDriver[this] = AmountOfGossips;
        }


        internal int[] Route { get; }
        private int CurrentStop { get; set; }
        internal int CurrentRoute => Route[CurrentStop];
        private int AmountOfGossips { get; }
        private int TotalAmountOfGossips => TotalAmountOfGossipsByDriver[this];
        internal bool GotNewGossips { get; private set; }
        private Dictionary<Driver, int> TotalAmountOfGossipsByDriver { get; } = new Dictionary<Driver, int>();


        internal void GetAllNewGossipsFrom(Driver nextDriver)
        {
            if (IsThereAnyNewGossipsToGetFrom(nextDriver))
                foreach (var driverAndTotalAmountOfGossips in nextDriver.TotalAmountOfGossipsByDriver)
                    GetNewGossipsAndUpdateTotalAmountOfGossipsIKnowThatAnotherDriverKnows(anotherDriver: driverAndTotalAmountOfGossips.Key, totalAmountOfGossipsOfAnotherDriver: driverAndTotalAmountOfGossips.Value);
        }

        private bool IsThereAnyNewGossipsToGetFrom(Driver anotherDriver)
        {
            return IsThereAnyNewGossipsToGetFrom(anotherDriver, anotherDriver.TotalAmountOfGossips);
        }

        private void GetNewGossipsAndUpdateTotalAmountOfGossipsIKnowThatAnotherDriverKnows(Driver anotherDriver, int totalAmountOfGossipsOfAnotherDriver)
        {
            GetGossipsFrom(anotherDriver);

            UpdateTotalAmountOfGossipsIKnowThatAnotherDriverKnows(anotherDriver, totalAmountOfGossipsOfAnotherDriver);
        }

        private void GetGossipsFrom(Driver anotherDriver)
        {
            if (!IKnowAnyGossipsOf(anotherDriver))
            {
                TotalAmountOfGossipsByDriver[this] += anotherDriver.AmountOfGossips;

                GotNewGossips = true;
            }
        }

        private void UpdateTotalAmountOfGossipsIKnowThatAnotherDriverKnows(Driver anotherDriver, int totalAmountOfGossipsOfAnotherDriver)
        {
            if (IsThereAnyNewGossipsToGetFrom(anotherDriver, totalAmountOfGossipsOfAnotherDriver))
                TotalAmountOfGossipsByDriver[anotherDriver] = totalAmountOfGossipsOfAnotherDriver;
        }

        private bool IsThereAnyNewGossipsToGetFrom(Driver anotherDriver, int totalAmountOfGossipsOfAnotherDriver)
        {
            return !IKnowAnyGossipsOf(anotherDriver) || totalAmountOfGossipsOfAnotherDriver > TotalAmountOfGossipsByDriver[anotherDriver];
        }

        private bool IKnowAnyGossipsOf(Driver anotherDriver)
        {
            return TotalAmountOfGossipsByDriver.ContainsKey(anotherDriver);
        }

        internal void GoToNextStop()
        {
            CurrentStop++;

            if (CurrentStop == Route.Length)
                CurrentStop = 0;

            GotNewGossips = false;
        }
    }
}