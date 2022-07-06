namespace CourseManagementApi.Data
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual IList<Course> Courses { get; set; }
    }
}
