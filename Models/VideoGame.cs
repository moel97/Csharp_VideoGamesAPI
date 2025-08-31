﻿namespace VideoGameApi.Models
{
    public class VideoGame
    {
        public int id{ get; set; }
        public string? Title { get; set; }
        public string? Platform { get; set; }
        public string? Developer { get; set; }
        public string? Publisher { get; set; }
    }
}
