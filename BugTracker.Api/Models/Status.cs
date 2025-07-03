namespace BugTracker.Api.Models
{
    public enum Status
    {
        [Display(Name = "Planning")]
        Planning = 1,
        [Display(Name = "In Progress")]
        InProgress = 2,
        [Display(Name = "Fixed")]
        Fixed = 3,
        [Display(Name = "Reopened")]
        Reopened = 4,
        [Display(Name = "Completed")]
        Completed = 5,
        [Display(Name = "On Hold")]
        OnHold = 6,
        [Display(Name = "Cancelled")]
        Cancelled = 7,
        [Display(Name = "Closed")]
        Closed = 8
    }
}
