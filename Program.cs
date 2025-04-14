namespace AirLineReservationConsoleSystem
{
    internal class Program
    {



        // Airline Reservation System Functions

        // ──────────────────────────────

        // 1. Arrays for Flights

        public static int maxFlights = 10;

        public static string[] flightCodes = new string[maxFlights];

        public static string[] fromCities = new string[maxFlights];

        public static string[] toCities = new string[maxFlights];

        public static DateTime[] departureTimes = new DateTime[maxFlights];

        public static int[] durations = new int[maxFlights];

        public static int[] prices = new int[maxFlights];

        public static string[] destinations = new string[maxFlights];

        public static string[] passengerNames = new string[maxFlights];

        public static int flightCount = 0; // to track number of added flights

        // ──────────────────────────────

        // 2. Arrays for Bookings

        public static int maxBookings = 20;

        public static string[] bookingIDs = new string[maxBookings];

        public static string[] bookedFlightCodes = new string[maxBookings];

        public static string[] bookedFromCities = new string[maxBookings];

        public static string[] bookedToCities = new string[maxBookings];

        public static DateTime[] bookedDepartureTimes = new DateTime[maxBookings];

        public static int[] bookedDurations = new int[maxBookings];

        public static int[] bookedPrices = new int[maxBookings];

        public static string[] bookedDestinations = new string[maxBookings];

        public static string[] bookedPassengerNames = new string[maxBookings];

        public static int bookingCount = 0; // to track number of bookings

        // ──────────────────────────────

        // 1. Shows a stylized welcome screen

        public static string DisplayWelcomeMessage()
        {
            // Display welcome message
            Console.WriteLine("=====================================");
            Console.WriteLine("Welcome to the Airline Reservation System");
            Console.WriteLine("=====================================");
            Console.WriteLine("Developed by [Ahmed Al Subhi]");
            Console.WriteLine("=====================================");
            return "Welcome!";
        }

        // 2. Ends the program or loop with a thank-you message

        public static string ExitApplication()
        {
            // Display exit message
            Console.WriteLine("Thank you for using the Airline Reservation System. Goodbye!");
            // Exit the application
            Environment.Exit(0);
            return "Exiting...";
        }

        // 4. Adds a new flight using provided details (uses named parameters)

        public static string AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration, int basePrice, string destination)
        {
            // Check if flight array is full
            if (flightCount >= maxFlights)
            {
                return "Flight list is full. Cannot add more flights.";
            }

            // Add flight details to arrays
            flightCodes[flightCount] = flightCode;
            fromCities[flightCount] = fromCity;
            toCities[flightCount] = toCity;
            departureTimes[flightCount] = departureTime;
            durations[flightCount] = duration;
            prices[flightCount] = basePrice;
            destinations[flightCount] = destination;
            passengerNames[flightCount] = ""; // Initialize with empty string

            flightCount++;

            // print details of the added flight
            return $"Flight {flightCode} added successfully: From {fromCity} to {toCity}, " +
                   $"Departure: {departureTime}, Duration: {duration} mins, Price: ${basePrice}, " +
                   $"Destination: {destination}";
        }

        // ──────────────────────────────

        // Flight and Passenger Management

        // ──────────────────────────────

        // 5. Prints all available flights to the console

        public static string DisplayAllFlights()
        {
            // Check if there are any flights
            if (flightCount == 0)
            {
                return "No flights available.";
            }

            // Print all flight details
            string flightDetails = "Available Flights:\n";
            for (int i = 0; i < flightCount; i++)
            {
                flightDetails += $"{flightCodes[i]}: From {fromCities[i]} to {toCities[i]}, " +
                                 $"Departure: {departureTimes[i]}, Duration: {durations[i]} mins, " +
                                 $"Price: ${prices[i]}, Destination: {destinations[i]}\n";
            }

            return flightDetails;
        }

        // Added missing function: Find Flight by Code
        public static string FindFlightByCode(string code)
        {
            // Search for flight code in the array
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodes[i] == code)
                {
                    return $"Flight {code} found: From {fromCities[i]} to {toCities[i]}, " +
                           $"Departure: {departureTimes[i]}, Duration: {durations[i]} mins, " +
                           $"Price: ${prices[i]}, Destination: {destinations[i]}";
                }
            }
            return $"Flight {code} not found.";
        }

        // 7. Updates the departure time of a flight (ref parameter lets us modify original)

        public static string UpdateFlightDeparture(ref DateTime departure)
        {
            // Check if there are any flights
            if (flightCount == 0)
            {
                return "No flights available to update.";
            }

            // Update flight departure time
            Console.Write("Enter flight code to update: ");
            string flightCode = Console.ReadLine();

            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodes[i] == flightCode)
                {
                    departureTimes[i] = departure;
                    return $"Flight {flightCode} departure time updated to {departure}.";
                }
            }

            return $"Flight {flightCode} not found.";
        }

        // 8. Cancels a flight booking and returns passenger name via out

        public static string CancelFlightBooking(out string passengerName)
        {
            // Check if there are any bookings
            if (bookingCount == 0)
            {
                passengerName = "No bookings to cancel.";
                return passengerName;
            }

            // Cancel the booking
            Console.Write("Enter booking ID to cancel: ");
            string bookingID = Console.ReadLine();

            for (int i = 0; i < bookingCount; i++)
            {
                if (bookingIDs[i] == bookingID)
                {
                    passengerName = bookedPassengerNames[i];

                    // Shift remaining bookings
                    for (int j = i; j < bookingCount - 1; j++)
                    {
                        bookingIDs[j] = bookingIDs[j + 1];
                        bookedFlightCodes[j] = bookedFlightCodes[j + 1];
                        bookedFromCities[j] = bookedFromCities[j + 1];
                        bookedToCities[j] = bookedToCities[j + 1];
                        bookedDepartureTimes[j] = bookedDepartureTimes[j + 1];
                        bookedDurations[j] = bookedDurations[j + 1];
                        bookedPrices[j] = bookedPrices[j + 1];
                        bookedDestinations[j] = bookedDestinations[j + 1];
                        bookedPassengerNames[j] = bookedPassengerNames[j + 1];
                    }

                    bookingCount--;
                    Console.WriteLine($"Booking {bookingID} cancelled successfully.");
                    return passengerName;
                }
            }

            passengerName = "Booking ID not found.";
            return passengerName;
        }

        // ──────────────────────────────

        // Passenger Booking Functions

        // ──────────────────────────────

        // 9. Books a flight for a passenger (uses optional flightCode)

        public static string BookFlight(string passengerName, string flightCode = "Default001")
        {
            // Check if booking array is full
            if (bookingCount >= maxBookings)
            {
                return "Booking list is full. Cannot add more bookings.";
            }

            // Search for flight code in the flight array
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodes[i] == flightCode)
                {
                    // Add booking details to arrays
                    bookingIDs[bookingCount] = GenerateBookingID(passengerName);
                    bookedFlightCodes[bookingCount] = flightCodes[i];
                    bookedFromCities[bookingCount] = fromCities[i];
                    bookedToCities[bookingCount] = toCities[i];
                    bookedDepartureTimes[bookingCount] = departureTimes[i];
                    bookedDurations[bookingCount] = durations[i];
                    bookedPrices[bookingCount] = prices[i];
                    bookedDestinations[bookingCount] = destinations[i];
                    bookedPassengerNames[bookingCount] = passengerName;

                    bookingCount++;

                    return $"Flight {flightCode} booked successfully for {passengerName}. " +
                           $"Booking ID: {bookingIDs[bookingCount - 1]}";
                }
            }

            return $"Flight {flightCode} not found.";
        }

        // 10. Checks if a flight code exists in the system

        public static string ValidateFlightCode(string flightCode)
        {
            // Search for flight code in the array
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodes[i] == flightCode)
                {
                    return $"Flight {flightCode} is valid.";
                }
            }

            return $"Flight {flightCode} is not valid.";
        }

        // 11. Generates booking ID

        public static string GenerateBookingID(string passengerName)
        {
            // Create a random number generator
            Random random = new Random();

            // Generate a 6-digit random number
            int randomNumber = random.Next(001, 500);

            // Create a booking ID using the passenger name and random number
            string bookingID = $"{passengerName.ToUpper()}-{randomNumber}";
            return bookingID;
        }

        // 12. Displays the full details of a flight using its code

        public static string DisplayFlightDetails(string code)
        {
            // Search for flight code in the array
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodes[i] == code)
                {
                    return $"Flight {code}: From {fromCities[i]} to {toCities[i]}, " +
                           $"Departure: {departureTimes[i]}, Duration: {durations[i]} mins, " +
                           $"Price: ${prices[i]}, Destination: {destinations[i]} ";
                }
            }

            return $"Flight {code} not found.";
        }

        // 13. Filters and displays bookings to a certain destination

        public static string SearchBookingsByDestination(string toCity)
        {
            // Check if there are any bookings
            if (bookingCount == 0)
            {
                return "No bookings available.";
            }

            // Filter and display bookings
            string bookingDetails = $"Bookings to {toCity}:\n";
            bool foundBookings = false;

            for (int i = 0; i < bookingCount; i++)
            {
                if (bookedToCities[i] == toCity)
                {
                    bookingDetails += $"{bookingIDs[i]}: Flight {bookedFlightCodes[i]}, " +
                                      $"From {bookedFromCities[i]}, Departure: {bookedDepartureTimes[i]}, " +
                                      $"Duration: {bookedDurations[i]} mins, Price: ${bookedPrices[i]}, " +
                                      $"Passenger: {bookedPassengerNames[i]}\n";
                    foundBookings = true;
                }
            }

            if (!foundBookings)
            {
                return $"No bookings found for destination {toCity}.";
            }

            return bookingDetails;
        }

        // ──────────────────────────────

        // Function Overloading

        // ──────────────────────────────

        // 14. Calculates total fare (basic version: integer price)
        // Modified to return string for consistency
        public static int CalculateFare(int basePrice, int numTickets)
        {
            // Calculate total fare
            int totalFare = basePrice * numTickets;
            return totalFare;
        }

        // 15. Overloaded version using floating point price
        // Modified to return string for consistency
        public static string CalculateFare(double basePrice, int numTickets)
        {
            // Calculate total fare
            double totalFare = basePrice * numTickets;
            return $"Total fare: ${totalFare}";
        }

        // 16. Overloaded version with discount applied

        public static int CalculateFare(int basePrice, int numTickets, int discount = 0)
        {
            int total = basePrice * numTickets;
            int discountAmount = (total * discount) / 100;
            int finalAmount = total - discountAmount;
            return finalAmount;
        }

        // ──────────────────────────────

        // System Utilities & Final Flow

        // ──────────────────────────────

        // 17. Confirms a user action (e.g., cancel booking)

        public static string ConfirmAction(string action)
        {
            // Confirm action
            Console.Write($"Are you sure you want to {action}? (y/n): ");
            string confirmation = Console.ReadLine();

            if (confirmation.ToLower() == "y")
            {
                return $"{action} confirmed.";
            }
            else
            {
                return $"{action} cancelled.";
            }
        }

        // 18. Displays a menu for user interaction

        public static string DisplayMenu()
        {
            // Display menu options
            Console.WriteLine("1. Add Flight");
            Console.WriteLine("2. Display All Flights");
            Console.WriteLine("3. Find Flight by Code");
            Console.WriteLine("4. Update Flight Departure");
            Console.WriteLine("5. Cancel Flight Booking");
            Console.WriteLine("6. Book Flight");
            Console.WriteLine("7. Validate Flight Code");
            Console.WriteLine("8. Display Flight Details");
            Console.WriteLine("9. Search Bookings by Destination");
            Console.WriteLine("10. Exit Application");

            return "Menu displayed.";
        }

        // 18. Main function that runs the entire app loop

        public static void StartSystem()
        {
            while (true)
            {
                // Clear console
                Console.Clear();

                // Display welcome message
                DisplayWelcomeMessage();

                // Display menu
                DisplayMenu();

                // Get user choice
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                // Handle user choice
                switch (choice)
                {
                    case "1":
                        // Add flight
                        Console.Write("Enter flight code: ");
                        string flightCode = Console.ReadLine();
                        Console.Write("Enter from city: ");
                        string fromCity = Console.ReadLine();
                        Console.Write("Enter to city: ");
                        string toCity = Console.ReadLine();
                        Console.Write("Enter departure time (yyyy-mm-dd hh:mm): ");
                        DateTime departureTime;

                        // Added error handling for date parsing
                        if (!DateTime.TryParse(Console.ReadLine(), out departureTime))
                        {
                            Console.WriteLine("Invalid date format. Using current date/time.");
                            departureTime = DateTime.Now;
                        }

                        Console.Write("Enter duration (in minutes): ");
                        int duration = int.Parse(Console.ReadLine());
                        // Added error handling for duration
                        if (duration <= 0)
                        {
                            Console.WriteLine("Invalid duration. Using 60 minutes as default.");
                            duration = 60;
                        }

                        Console.Write("Enter price: ");
                        int basePrice = int.Parse(Console.ReadLine());
                        // Added error handling for price
                        if (basePrice <= 0)
                        {
                            Console.WriteLine("Invalid price. Using 100 as default.");
                            basePrice = 100;
                        }

                        // Added error handling for destination
                        Console.Write("Enter destination: ");
                        string destination = Console.ReadLine();

                        // Call AddFlight function
                        string addFlightResult = AddFlight(flightCode, fromCity, toCity, departureTime, duration, basePrice, destination);
                        Console.WriteLine(addFlightResult);
                        // Added confirmation message
                        string confirmAdd = ConfirmAction("add flight");
                        Console.WriteLine(confirmAdd);
                        break;

                    case "2":
                        // Display all flights
                        string displayFlightsResult = DisplayAllFlights();
                        Console.WriteLine(displayFlightsResult);
                        // Added confirmation message
                        string confirmDisplay = ConfirmAction("display all flights");
                        Console.WriteLine(confirmDisplay);
                        break;

                    case "3":
                        // Find flight by code
                        Console.Write("Enter flight code to find: ");
                        string findFlightCode = Console.ReadLine();
                        string findFlightResult = FindFlightByCode(findFlightCode);
                        Console.WriteLine(findFlightResult);
                        // Added confirmation message
                        string confirmFind = ConfirmAction("find flight");
                        break;

                    case "4":
                        // Update flight departure
                        Console.Write("Enter new departure time (yyyy-mm-dd hh:mm): ");
                        DateTime newDepartureTime;
                        // Added error handling for date parsing
                        if (!DateTime.TryParse(Console.ReadLine(), out newDepartureTime))
                        {
                            Console.WriteLine("Invalid date format. Using current date/time.");
                            newDepartureTime = DateTime.Now;
                        }
                        string updateFlightResult = UpdateFlightDeparture(ref newDepartureTime);
                        Console.WriteLine(updateFlightResult);
                        // Added confirmation message
                        string confirmUpdate = ConfirmAction("update flight departure");
                        Console.WriteLine(confirmUpdate);
                        break;

                    case "5":
                        // Cancel flight booking
                        string passengerName;
                        string cancelBookingResult = CancelFlightBooking(out passengerName);
                        Console.WriteLine(cancelBookingResult);
                        // Added confirmation message
                        string confirmCancel = ConfirmAction("cancel flight booking");
                        Console.WriteLine(confirmCancel);
                        break;

                    case "6":
                        // Book flight
                        // input promo code 

                        Console.Write("Enter passenger name: ");
                        string passengerNameToBook = Console.ReadLine();

                        Console.Write("Enter flight code to book: ");
                        string bookFlightCode = Console.ReadLine();

                        // Lookup price by flight code
                        int flightPrice = 0;
                        bool found = false;
                        for (int i = 0; i < flightCount; i++)
                        {
                            if (flightCodes[i] == bookFlightCode)
                            {
                                flightPrice = prices[i];
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Flight code not found. Using default price $100.");
                            flightPrice = 100;
                        }

                        // Ask for number of tickets
                        Console.Write("Enter number of tickets: ");
                        int numTickets;
                        bool isValidTickets = int.TryParse(Console.ReadLine(), out numTickets); // parse to int
                        if (!isValidTickets || numTickets <= 0)
                        {
                            Console.WriteLine("Invalid number of tickets. Using 1 as default.");
                            numTickets = 1;
                        }

                        // Ask for promo code
                        Console.Write("Enter promo code or leave blank: ");
                        string promoCode = Console.ReadLine();
                        int discount = 0;

                        if (promoCode == "Air20")
                        {
                            discount = 20;
                        }
                        else if (promoCode == "Air30")
                        {
                            discount = 30;
                        }
                        else if (promoCode == "Air50")
                        {
                            discount = 50;
                        }
                        else if (promoCode == "")
                        {
                            Console.WriteLine("Invalid promo code. No discount applied.");
                            discount = 0;
                        }

                        // Calculate final price directly
                        int finalPrice;
                        if (discount > 0)
                        { 
                            finalPrice = CalculateFare(flightPrice, numTickets, discount);
                            Console.WriteLine($"Total fare (after {discount}% discount): ${finalPrice}");
                        }
                        else
                        {
                            finalPrice = CalculateFare(flightPrice, numTickets);
                            Console.WriteLine($"Total fare: ${finalPrice}");
                        }

                        // Book the flight
                        string bookFlightResult = BookFlight(passengerNameToBook, bookFlightCode);

                        // Update final calculated price in the booking array
                        if (bookingCount > 0)
                        {
                            bookedPrices[bookingCount - 1] = finalPrice;
                        }

                        Console.WriteLine(bookFlightResult);
                        break;


                    case "7":
                        // Validate flight code
                        Console.Write("Enter flight code to validate: ");
                        string validateFlightCode = Console.ReadLine();
                        string validateFlightResult = ValidateFlightCode(validateFlightCode);
                        Console.WriteLine(validateFlightResult);
                        // Added confirmation message
                        string confirmValidate = ConfirmAction("validate flight code");
                        Console.WriteLine(confirmValidate);
                        break;

                    case "8":
                        // Display flight details
                        Console.Write("Enter flight code to display details: ");
                        string displayFlightCode = Console.ReadLine();
                        string displayFlightResult = DisplayFlightDetails(displayFlightCode);
                        Console.WriteLine(displayFlightResult);
                        // Added confirmation message
                        string confirmDisplayDetails = ConfirmAction("display flight details");
                        Console.WriteLine(confirmDisplayDetails);
                        break;

                    case "9":
                        // Search bookings by destination
                        Console.Write("Enter destination city to search bookings: ");
                        string searchDestination = Console.ReadLine();
                        string searchBookingsResult = SearchBookingsByDestination(searchDestination);
                        Console.WriteLine(searchBookingsResult);
                        // Added confirmation message
                        string confirmSearch = ConfirmAction("search bookings by destination");
                        Console.WriteLine(confirmSearch);
                        break;

                    case "10":
                        // Exit application
                        string exitResult = ExitApplication();
                        Console.WriteLine(exitResult);
                        break;

                    default:
                        // Invalid choice
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                // Pause before returning to menu
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            // Start the airline reservation system
            StartSystem();
        }

    }
}
