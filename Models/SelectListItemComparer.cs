using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GoalTracker.Models;

public class SelectListItemComparer : IEqualityComparer<SelectListItem>
{
    public bool Equals(SelectListItem? a, SelectListItem? b) 
    {
        if (ReferenceEquals(a, b)) 
        {
            return true;
        }

        if (a is null || b is null) 
        {   
            return false;
        }

        return a.Value == b.Value && a.Text == b.Text;
    }

    public int GetHashCode(SelectListItem item)
    {
        int hashText = item.Text == null ? 0 : item.Text.GetHashCode();
        int hashValue = item.Value == null ? 0 : item.Value.GetHashCode();

        return hashText ^ hashValue;
    }
}