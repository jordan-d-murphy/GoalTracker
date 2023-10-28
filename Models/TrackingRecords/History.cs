using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Models;

public class History : TrackingRecord
{
    public History(ApplicationUser user, string action, TrackingRecord trackingRecord, string url) 
    {
        CreatedBy = user;
        CreatedDate = DateTime.Now;
        Action = action;
        TrackingRecord = trackingRecord;
        Url = url;
    }
    public string? Action { get; set; }

    public TrackingRecord TrackingRecord { get; set; }

    public string? Url { get; set; }

    public override string ToString()
    {
        return 
            $"{CreatedDate}\n" +
            $"User [Email: {CreatedBy?.Email} Id: {CreatedBy?.Id}]\n" + 
            $"Action: [{Action}]\n" + 
            $"Reference: [{TrackingRecord.GetType()} {TrackingRecord.Title} {TrackingRecord.Id}]\n" + 
            $"URL: [{Url}]";
    }

}
