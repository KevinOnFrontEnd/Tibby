﻿namespace Tibby.Models
{
    public class QuoteResponse
    {
        public double amount_in { get; set; }
        public double amount_out { get; set; }
        public bool price_warning { get; set; }
        public double fee { get; set; }
        public string asset_id { get; set; }
        public double input_reserve { get; set; }
        public double output_reserve { get; set; }
        public double price_impact { get; set; }
    }
}