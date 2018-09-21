using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace GiftBagOfBases.ViewModel
{
    public abstract class GiftViewModel
    {
        [Required]
        [JsonProperty("id")]
        public Guid AggregateId { get; set; }
    }
}