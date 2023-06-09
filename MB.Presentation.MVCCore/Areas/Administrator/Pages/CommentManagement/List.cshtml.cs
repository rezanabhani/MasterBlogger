using System.Collections.Generic;
using MB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        public List<CommentViewModel> Comments { get; set; }
        private readonly ICommentApplication _commentApplication;

        public ListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.GetList();
        }

        public IActionResult OnPostConfirm(long id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./List");
        }

        public IActionResult OnPostCancel(long id)
        {
           _commentApplication.Cancel(id);
           return RedirectToPage("./List");
        }
    }
}
