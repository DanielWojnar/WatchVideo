using System.ComponentModel.DataAnnotations;

namespace WatchVideo.Models;

public class SearchBox
{
    [StringLength(240, ErrorMessage = "Name is too long.")]
    public string? Search { get; set; }
}
