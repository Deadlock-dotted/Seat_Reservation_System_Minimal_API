namespace Airplane_Reservation
{
    public static class FormatterClass
    {
        public static int FormatRowNumber(string seatNumber)
        {
            return Convert.ToInt32(seatNumber.Substring(0, 1));
        }

        public static char FormatSeat(string seatNumber)
        {
            return Convert.ToChar(seatNumber.Substring(1, 1)); 
        }
    }
}
