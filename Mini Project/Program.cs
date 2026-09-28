
    public class RentalBooking
    {
        public Customers Customer { get; set; }
        public Vehicles Car { get; set; }
        public int RentalDays { get; set; }
        public decimal BaseTotal { get; set; }
        public decimal FinalTotal { get; set; }

    }

    public class BookingCalculator
    {
        public decimal PriceTotal(decimal dailyPrice, int rentalDays)
        {
            return dailyPrice * rentalDays;
        }

    }

    public class RentalManager
    {
        private BookingCalculator calculator;

        public RentalManager()
        {
            calculator = new BookingCalculator();
        }

        public RentalBooking CreateBooking(Customers customer, Vehicles car, int rentalDays)
        {
            if (car.statue != Statue.avaliable)
            {
                return null;
            }

        decimal baseTotal = calculator.PriceTotal(car.Price, rentalDays);

          RentalBooking booking = new RentalBooking();

          booking.Customer = customer;
          booking.Car = car;
          booking.RentalDays = rentalDays;
          booking.BaseTotal = baseTotal;
          booking.FinalTotal = baseTotal;

          car.statue = Statue.Rented;

          return booking;

        }

    }
