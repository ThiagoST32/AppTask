﻿namespace AppTask.Models
{
    public class SubTaskModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public bool IsCompleted { get; set; }
    }
}
