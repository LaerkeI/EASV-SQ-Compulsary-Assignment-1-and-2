namespace HotelBooking.ReqnrollCucumberTests.StepDefinitions
{
    [Binding]
    public sealed class CreateBookingStepDefinitions
    {
        private bool roomAvailable;
        private bool bookingConfirmed;
        private bool roomOccupied;
        private bool bookingCanceled;
        private bool bookingRejected;

        [Given("the hotel has rooms available")]
        public void GivenHotelHasRooms()
        {
            roomAvailable = true;
        }

        [Given("a room is available for the requested dates")]
        public void GivenRoomIsAvailable()
        {
            Assert.True(roomAvailable, "Room is not available");
        }

        [Given("no rooms are available for the requested dates")]
        public void GivenNoRoomsAvailable()
        {
            roomAvailable = false;
        }

        [When(@"I make a booking from ""(.*)"" to ""(.*)""")]
        public void WhenIMakeABooking(string startDate, string endDate)
        {
            if (roomAvailable)
                bookingConfirmed = true;
        }

        [When("I check in on {string}")]
        public void WhenICheckIn(string date)
        {
            if (bookingConfirmed)
                roomOccupied = true;
        }

        [When("I cancel the booking before {string}")]
        public void WhenICancelBookingBefore(string date)
        {
            if (bookingConfirmed)
                bookingCanceled = true;
        }

        [When("I do not check in on {string}")]
        public void WhenIDoNotCheckIn(string date)
        {
            if (bookingConfirmed)
            {
                bookingCanceled = true;
                roomOccupied = false;
            }
        }

        [When("I attempt to book a room from {string} to {string}")]
        public void WhenIAttemptToBook(string startDate, string endDate)
        {
            if (!roomAvailable)
                bookingRejected = true;
        }

        [Then("the booking should be confirmed")]
        public void ThenBookingShouldBeConfirmed()
        {
            Assert.True(bookingConfirmed, "Booking was not confirmed");
        }

        [Then("the room should be marked as occupied")]
        public void ThenRoomShouldBeMarkedAsOccupied()
        {
            Assert.True(roomOccupied, "Room was not marked as occupied");
        }

        [Then("the booking should be canceled")]
        public void ThenBookingShouldBeCanceled()
        {
            Assert.True(bookingCanceled, "Booking was not canceled");
        }

        [Then("the room should be available")]
        public void ThenRoomShouldBeAvailable()
        {
            Assert.False(roomOccupied, "Room is not available");
        }

        [Then("the booking should be rejected")]
        public void ThenBookingShouldBeRejected()
        {
            Assert.True(bookingRejected, "Booking was not rejected when expected");
        }
    }
}