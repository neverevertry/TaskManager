namespace Domain.DTO
{
    public class TaskDTO
    {
        public string name { get; set; }

        public string authorName { get; set; }

        public DateTime DateTimeOfStarting { get; set; }

        public DateTime PredictedDateTimeOfClosing { get; set; }

        public string status { get; set; }

        public int id { get; set; }
    }
}
