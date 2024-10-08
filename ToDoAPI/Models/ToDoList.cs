﻿namespace ToDoAPI.Models
{
    public class ToDoList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedById {  get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Deleted { get; set; } = false;
        public virtual Users CreatedBy { get; set; }
        public virtual ICollection<ListUser>? ListUsers { get; set; }
    }
    public class ToDoListPayload
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
