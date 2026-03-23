namespace DiLaEmp.Utils.Calendar.Objects
{
    public class CalendarAppointment : IComparable<CalendarAppointment>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string? Text { get; set; }

        public int CompareTo(CalendarAppointment? other)
        {
            int comparition = 0;
            if (this.Start < other!.Start)
            {
                comparition = -1;
            }
            else if (this.Start > other.Start)
            {
                comparition = 1;
            }
            else if (this.End < other.End)
            {
                comparition = -1;
            }
            else if (this.End > other.End)
            {
                comparition = 1;
            }
            else if (this.Text is not null && other.Text is not null)
            {
                comparition = this.Text.CompareTo(other.Text);
            }
            else if (this.Text is null && other.Text is null)
            {
                comparition = 0;
            }
            else if (this.Text is not null)
            {
                comparition = 1;
            }
            else if (other.Text is not null)
            {
                comparition = -1;
            }
            return comparition;
        }
    }
}
