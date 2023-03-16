namespace GossipingBusDrivers
{
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