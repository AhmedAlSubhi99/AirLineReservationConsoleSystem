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

        // 1. Shows welcome screen

        public static string DisplayWelcomeMessage()
        {
            // Display welcome message
            Console.WriteLine("=============================================");
            Console.WriteLine("| Welcome to the Airline Reservation System |");
            Console.WriteLine("=============================================");
            return "Welcome!";
        }

        // 2. Exit

        public static string ExitApplication()
        {
            // Added confirmation message
            string confirmExit = ConfirmAction("exit application");
            Console.WriteLine(confirmExit);
            if (confirmExit != "exit application confirmed.")
            {
                return "Application exit cancelled.";
            }
            else
            {
                Console.WriteLine("Application exit confirmed.");
            }
            // Display exit message
            Console.WriteLine("Thank you for using the Airline Reservation System. Goodbye!");
            // Exit the application
            Environment.Exit(0);
            return "Exiting...";
        }

        // 3. Adds a new flight 

        public static string AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration, int basePrice, string destination)
        {
            try
            {
                // Added confirmation message
                string confirmAdd = ConfirmAction("add flight");
                Console.WriteLine(confirmAdd);
                if (confirmAdd != "add flight confirmed.")
                {
                    return "Flight addition cancelled.";
                }
                else
                {
                    Console.WriteLine("Flight addition confirmed.");
                }
                // Check if flight code is empty
                if (string.IsNullOrEmpty(flightCode))
                {
                    return "Flight code cannot be empty.";
                }
                // Check if flight code already exists
                for (int i = 0; i < flightCount; i++)
                {
                    if (flightCodes[i] == flightCode)
                    {
                        return $"Flight code {flightCode} already exists.";
                    }
                }
                // Check if from city is empty
                if (string.IsNullOrEmpty(fromCity))
                {
                    return "From city cannot be empty.";
                }
                // Check if to city is empty
                if (string.IsNullOrEmpty(toCity))
                {
                    return "To city cannot be empty.";
                }
                // Check if departure time is in the past
                if (departureTime < DateTime.Now)
                {
                    return "Departure time cannot be in the past.";
                }
                // Check if duration is valid
                if (duration <= 0)
                {
                    return "Duration must be greater than zero.";
                }
                // Check if base price is valid
                if (basePrice <= 0)
                {
                    return "Base price must be greater than zero.";
                }
                // Check if destination is empty
                if (string.IsNullOrEmpty(destination))
                {
                    return "Destination cannot be empty.";
                }
                // Check if from city and to city are the same
                if (fromCity == toCity)
                {
                    return "From city and to city cannot be the same.";
                }
                if (flightCount == 0)
                {
                    // Initialize the arrays if this is the first flight
                    flightCodes = new string[maxFlights];
                    fromCities = new string[maxFlights];
                    toCities = new string[maxFlights];
                    departureTimes = new DateTime[maxFlights];
                    durations = new int[maxFlights];
                    prices = new int[maxFlights];
                    destinations = new string[maxFlights];
                }

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
                flightCount++;

                // print details of the added flight
                return $"Flight {flightCode} added successfully: From {fromCity} to {toCity}, " +
                       $"Departure: {departureTime}, Duration: {duration} mins, Price: ${basePrice}, " +
                       $"Destination: {destination}";
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during flight addition
                return $"Error adding flight due to : {ex.Message}";
            }
        }

        // ──────────────────────────────

        // Flight and Passenger Management

        // ──────────────────────────────

        // 5. Prints all flights

        public static string DisplayAllFlights()
        {
            try
            {
                // Added confirmation message
                string confirmDisplay = ConfirmAction("display all flights");
                Console.WriteLine(confirmDisplay);
                if (confirmDisplay != "display all flights confirmed.")
                {
                    return "Flight display cancelled.";
                }
                else
                {
                    Console.WriteLine("Flight display confirmed.");
                }
                // Check if there are any flights
                if (flightCount == 0)
                {
                    return "No flights available.";
                }

                // Print all flight details
                string flightDetails = "Available Flights:\n";
                for (int i = 0; i < flightCount; i++)
                {
                    flightDetails = $"{flightCodes[i]}: From {fromCities[i]} to {toCities[i]}, " + $"Departure: {departureTimes[i]}, Duration: {durations[i]} mins, " + $"Price: ${prices[i]}, Destination: {destinations[i]}\n";
                }

                return flightDetails;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during flight display
                return $"Error displaying flights due to : {ex.Message}";
            }
        }

        // 6. Find Flight by Code
        public static string FindFlightByCode(string code)
        {
            try
            {
                // Added confirmation message
                string confirmFind = ConfirmAction("find flight");
                Console.WriteLine(confirmFind);
                if (confirmFind != "find flight confirmed.")
                {
                    return "Flight search cancelled.";
                }
                else
                {
                    Console.WriteLine("Flight search confirmed.");
                }
                // Check if there are any flights
                if (flightCount == 0)
                {
                    return "No flights available.";
                }
                // Check if flight code is empty
                if (string.IsNullOrEmpty(code))
                {
                    return "Flight code cannot be empty.";
                }
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
            catch (Exception ex)
            {
                // Handle any exceptions that occur during flight search
                return $"Error finding flight due to : {ex.Message}";
            }
        }

        // 7. Updates the departure time of  flight

        public static string UpdateFlightDeparture(ref DateTime departure)
        {
            try
            {
                // Added confirmation message
                string confirmUpdate = ConfirmAction("update flight departure");
                Console.WriteLine(confirmUpdate);
                if (confirmUpdate != "update flight departure confirmed.")
                {
                    return "Flight update cancelled.";
                }
                else
                {
                    Console.WriteLine("Flight update confirmed.");
                }
                // Check if departure time is in the past
                if (departure < DateTime.Now)
                {
                    return "Departure time cannot be in the past.";
                }
                // Check if flight code is empty
                if (string.IsNullOrEmpty(flightCodes[0]))
                {
                    return "Flight code cannot be empty.";
                }

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
            catch (Exception ex)
            {
                // Handle any exceptions that occur during flight update
                return $"Error updating flight due to : {ex.Message}";
            }
        }

        // 8. Cancels a flight booking

        public static string CancelFlightBooking(out string passengerName)
        {
            try
            {
                // Added confirmation message
                string confirmCancel = ConfirmAction("cancel flight booking");
                Console.WriteLine(confirmCancel);
                if (confirmCancel != "cancel flight booking confirmed.")
                {
                    passengerName = "Flight cancellation cancelled.";
                    return passengerName;
                }
                else
                {
                    Console.WriteLine("Flight cancellation confirmed.");
                }

                // Initialize passenger name
                passengerName = string.Empty; // to avoid uninitialized variable error

                // Check if booking array is full
                if (bookingCount >= maxBookings)
                {
                    passengerName = "Booking list is full. Cannot cancel more bookings.";
                    return passengerName;
                }
                // Check if there are any flights
                if (flightCount == 0)
                {
                    passengerName = "No flights available to cancel.";
                    return passengerName;
                }
                // Check if there are any bookings
                if (bookingCount == 0)
                {
                    passengerName = "No bookings to cancel.";
                    return passengerName;
                }
                // Check if booking ID is empty
                if (string.IsNullOrEmpty(bookingIDs[0]))
                {
                    passengerName = "Booking ID cannot be empty.";
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
            catch (Exception ex)
            {
                // Handle any exceptions that occur during booking cancellation
                passengerName = $"Error cancelling booking due to : {ex.Message}";
                return passengerName;
            }
        }

        // ──────────────────────────────

        // Passenger Booking Functions

        // ──────────────────────────────

        // 9. Books flight

        public static string BookFlight(string passengerName, string flightCode)
        {
            try
            {
                // Added confirmation message
                string confirmBook = ConfirmAction("book flight");
                Console.WriteLine(confirmBook);
                if (confirmBook != "book flight confirmed.") // check confirmation
                {
                    return "Flight booking cancelled.";
                }
                else
                {
                    Console.WriteLine("Flight booking confirmed.");
                }
                // Check if passenger name is empty
                if (string.IsNullOrEmpty(passengerName))
                {
                    return "Passenger name cannot be empty.";
                }
                // Check if flight code is empty
                if (string.IsNullOrEmpty(flightCode))
                {
                    return "Flight code cannot be empty.";
                }
                // Check if there are any flights
                if (flightCount == 0)
                {
                    return "No flights available to book.";
                }
                // Check if there are any bookings
                if (bookingCount == 0)
                {
                    return "No bookings available.";
                }
                // Check if flight code is valid
                if (ValidateFlightCode(flightCode) != $"Flight {flightCode} is valid.")
                {
                    return $"Flight {flightCode} is not valid.";
                }
                // Check if passenger name already exists in bookings
                for (int i = 0; i < bookingCount; i++)
                {
                    if (bookedPassengerNames[i] == passengerName)
                    {
                        return $"Passenger {passengerName} already has a booking.";
                    }
                }
                // Check if flight code already exists in bookings
                for (int i = 0; i < bookingCount; i++)
                {
                    if (bookedFlightCodes[i] == flightCode)
                    {
                        return $"Flight {flightCode} is already booked.";
                    }
                }
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
            catch (Exception ex)
            {
                // Handle any exceptions that occur during flight booking
                return $"Error booking flight due to : {ex.Message}";
            }
        }

        // 10. Validate if  flight code exists

        public static string ValidateFlightCode(string flightCode)
        {
            try
            {
                // Added confirmation message
                string confirmValidate = ConfirmAction("validate flight code");
                Console.WriteLine(confirmValidate);
                if (confirmValidate != "validate flight code confirmed.")
                {
                    return "Flight validation cancelled.";
                }
                else
                {
                    Console.WriteLine("Flight validation confirmed.");
                }
                // Check if flight code is empty
                if (string.IsNullOrEmpty(flightCode))
                {
                    return "Flight code cannot be empty.";
                }
                // Check if there are any flights
                if (flightCount == 0)
                {
                    return "No flights available to validate.";
                }
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
            catch (Exception ex)
            {
                // Handle any exceptions that occur during flight validation
                return $"Error validating flight code due to : {ex.Message}";
            }
        }

        // 11. Generates booking ID

        public static string GenerateBookingID(string passengerName)
        {
            try
            {
                // Check if passenger name is empty
                if (string.IsNullOrEmpty(passengerName))
                {
                    return "Passenger name cannot be empty.";
                }
                // Create a random number generator
                Random random = new Random();

                // Generate random number
                int randomNumber = random.Next(001, 500);

                // Create a booking ID using the passenger name and random number
                string bookingID = $"{passengerName.ToUpper()}-{randomNumber}";
                return bookingID;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during booking ID generation
                return $"Error generating booking ID due to : {ex.Message}";
            }
        }

        // 12. Display full details of flight using code

        public static string DisplayFlightDetails(string code)
        {
            try
            {
                // Added confirmation message
                string confirmDisplayDetails = ConfirmAction("display flight details");
                Console.WriteLine(confirmDisplayDetails);
                if (confirmDisplayDetails != "display flight details confirmed.")
                {
                    return "Flight details display cancelled.";
                }
                else
                {
                    Console.WriteLine("Flight details display confirmed.");
                }
                // Check if flight code is empty
                if (string.IsNullOrEmpty(code))
                {
                    return "Flight code cannot be empty.";
                }
                // Check if there are any flights
                if (flightCount == 0)
                {
                    return "No flights available.";
                }
                // Check if flight code is valid
                if (ValidateFlightCode(code) != $"Flight {code} is valid.")
                {
                    return $"Flight {code} is not valid.";
                }
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
            catch (Exception ex)
            {
                // Handle any exceptions that occur during flight display
                return $"Error displaying flight details due to : {ex.Message}";
            }
        }

        // 13. Display or Search bookings by destination

        public static string SearchBookingsByDestination(string toCity)
        {
            try
            {
                // Added confirmation message
                string confirmSearch = ConfirmAction("search bookings by destination");
                Console.WriteLine(confirmSearch);
                if (confirmSearch != "search bookings by destination confirmed.")
                {
                    return "Booking search cancelled.";
                }
                else
                {
                    Console.WriteLine("Booking search confirmed.");
                }
                // Check if destination is empty
                if (string.IsNullOrEmpty(toCity))
                {
                    return "Destination city cannot be empty.";
                }
                // Check if there are any flights
                if (flightCount == 0)
                {
                    return "No flights available.";
                }
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
            catch (Exception ex)
            {
                // Handle any exceptions that occur during booking search
                return $"Error searching bookings due to : {ex.Message}";
            }
        }

        // ──────────────────────────────

        // Function Overloading

        // ──────────────────────────────

        // 14. Calculates total fare 

        // Modified to return string and integer
        public static int CalculateFare(int basePrice, int numTickets)
        {
            try
            {
                // Calculate total fare
                int totalFare = basePrice * numTickets;
                return totalFare;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during fare calculation
                Console.WriteLine($"Error calculating fare due to : {ex.Message}");
                return 0;
            }
        }

        public static string CalculateFare(double basePrice, int numTickets)
        {
            try
            {
                // Calculate total fare
                double totalFare = basePrice * numTickets;
                return $"Total fare: ${totalFare}";
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during fare calculation
                return $"Error calculating fare due to : {ex.Message}";
            }
        }

        // 15. Overloaded version with discount applied

        public static int CalculateFare(int basePrice, int numTickets, int discount = 0)
        {
            try
            {
                // Calculate total fare with discount
                double totalFare1;
            double totalFare = basePrice * numTickets;
            if (discount > 0)
            {
                totalFare1 = (totalFare * discount / 100);
                totalFare -= totalFare1; // apply discount
            }
            return (int)totalFare; // return as integer
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during fare calculation
                Console.WriteLine($"Error calculating fare due to : {ex.Message}");
                return 0;
            }
        }

        // ──────────────────────────────

        // System Utilities & Final Flow

        // ──────────────────────────────

        // 16. Confirms a user action (e.g., cancel booking)

        public static string ConfirmAction(string action)
        {
            try
            {
                // Check if action is empty
                if (string.IsNullOrEmpty(action))
                {
                    return "Action cannot be empty.";
                }
                // Display action confirmation message
                Console.WriteLine($"You are about to {action}.");

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
            catch (Exception ex)
            {
                // Handle any exceptions that occur during action confirmation
                return $"Error confirming action due to : {ex.Message}";
            }
        }

        // 17. Displays menu 

        public static string DisplayMenu()
        {
            try
            {
                // Display menu header
                Console.WriteLine("=====================================");
                Console.WriteLine("| Airline Reservation System Menu |");
                Console.WriteLine("=====================================");

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
                Console.WriteLine("=====================================");
                // Display menu footer
                Console.WriteLine("Please select an option from the menu above.");
                // Return menu display message
                Console.WriteLine("=====================================");
                return "Menu displayed.";

            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during menu display
                return $"Error displaying menu due to : {ex.Message}";

            }
        }

        // 18. Starts the system
        public static void StartSystem()
        {

            try
            {
                // Display welcome message
                DisplayWelcomeMessage();

                while (true)
                {
                    // Clear console
                    Console.Clear();

                    // Display menu
                    DisplayMenu();

                    // Get user choice
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    // Handle user choice
                    switch (choice)
                    {
                        // Add flight
                        case "1":
                            // Get flight details from user
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
                            break;

                        // Display all flights
                        case "2":
                            // Call DisplayAllFlights function
                            string displayFlightsResult = DisplayAllFlights();
                            Console.WriteLine(displayFlightsResult);
                            break;

                        // Find flight by code
                        case "3":
                            // Get flight code from user
                            Console.Write("Enter flight code to find: ");
                            string findFlightCode = Console.ReadLine();
                            // Call FindFlightByCode function
                            string findFlightResult = FindFlightByCode(findFlightCode);
                            Console.WriteLine(findFlightResult);
                            break;

                        // Update flight departure
                        case "4":
                            // Get new departure time from user
                            Console.Write("Enter new departure time (yyyy-mm-dd hh:mm): ");
                            DateTime newDepartureTime;
                            // Added error handling for date parsing
                            if (!DateTime.TryParse(Console.ReadLine(), out newDepartureTime)) // parse to DateTime If parsing fails, set to current date/time
                            {
                                Console.WriteLine("Invalid date format. Using current date/time.");
                                newDepartureTime = DateTime.Now;
                            }
                            string updateFlightResult = UpdateFlightDeparture(ref newDepartureTime); // pass by reference for departure time
                            Console.WriteLine(updateFlightResult);
                            break;

                        // Cancel flight booking
                        case "5":

                            string passengerName;
                            string cancelBookingResult = CancelFlightBooking(out passengerName);
                            Console.WriteLine(cancelBookingResult);
                            break;

                        // Book flight
                        case "6":

                            Console.Write("Enter passenger name: ");
                            string passengerNameToBook = Console.ReadLine();

                            Console.Write("Enter flight code to book: ");
                            string bookFlightCode = Console.ReadLine();

                            // Lookup price by flight code
                            int flightPrice = 0;
                            bool found = false;
                            for (int i = 0; i < flightCount; i++) // loop through flight codes
                            {
                                if (flightCodes[i] == bookFlightCode)
                                {
                                    flightPrice = prices[i]; // get price
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
                            bool isValidTickets = int.TryParse(Console.ReadLine(), out numTickets); // parse to integer if parsing fails, set to default value
                            if (!isValidTickets || numTickets <= 0) // check if valid
                            {
                                Console.WriteLine("Invalid number of tickets. Using 1 as default.");
                                numTickets = 1;
                            }
                            else if (numTickets > 10) // check if more than 10
                            {
                                Console.WriteLine("Maximum number of tickets is 10. Using 1 as default.");
                                numTickets = 1;
                            }
                            else if (numTickets < 0) // check if negative
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

                        // Validate flight code
                        case "7":

                            Console.Write("Enter flight code to validate: ");
                            string validateFlightCode = Console.ReadLine();
                            string validateFlightResult = ValidateFlightCode(validateFlightCode);
                            Console.WriteLine(validateFlightResult);
                            break;

                        // Display flight details
                        case "8":

                            Console.Write("Enter flight code to display details: ");
                            string displayFlightCode = Console.ReadLine();
                            string displayFlightResult = DisplayFlightDetails(displayFlightCode);
                            Console.WriteLine(displayFlightResult);
                            break;

                        // Search bookings by destination
                        case "9":

                            Console.Write("Enter destination city to search bookings: ");
                            string searchDestination = Console.ReadLine();
                            string searchBookingsResult = SearchBookingsByDestination(searchDestination);
                            Console.WriteLine(searchBookingsResult);
                            break;

                        // Exit application
                        case "10":

                            string exitResult = ExitApplication();
                            Console.WriteLine(exitResult);
                            break;

                        // Invalid choice
                        default:

                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }

                    // Pause before returning to menu
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during system startup
                Console.WriteLine($"Error starting system due to : {ex.Message}");
            }
        }

        // Main function
        static void Main(string[] args)
        {
            // Start the airline reservation system
            StartSystem();
        }

    }
}
