using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using YEGNA_BETS.Data;
using YEGNA_BETS.Models;
using YEGNA_BETS.Models.Domain;
using YEGNA_BETS.Tools;

namespace YEGNA_BETS.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> user;
        private readonly ApplicationDbContext applicationDbContext;

        public UserController(UserManager<ApplicationUser> user, ApplicationDbContext applicationDbContext)
        {
            this.user = user;
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var User = await user.FindByIdAsync(user.GetUserId(this.User));

            var Life = await applicationDbContext.Life.FirstOrDefaultAsync(x => x.User == User);
            int RemaingBets;
            if (Life != null)
            {
                RemaingBets = Life.RemaingBets;
                if (RemaingBets <= 0)
                {
                    return View(0);
                }
            else
            {
                return View(Life.RemaingBets);
            }
        }
            return View(0);

        }
        [AllowAnonymous]
        public async Task<IActionResult> BuyPackage()
        {
            var packages = await applicationDbContext.Package.ToListAsync();
            return View(packages);
        }
        [HttpGet]
        public async Task<IActionResult> GetTicket(Guid Id)
        {
            var package = await applicationDbContext.Package.FirstOrDefaultAsync(x => x.Id == Id);

            if (package != null)
            {
                var viewModel = new AddTransactionViewModel()
                {
                    PackageType = package.Id,
                    Type = package.Name,
                };
                return await Task.Run(() => View(viewModel));
            }

            return RedirectToAction("Tickets");
        }
        [HttpPost]
        public async Task<IActionResult> VerifyTicket(AddTransactionViewModel newTransaction)
        {
            var tickets = await applicationDbContext.Ticket.FirstOrDefaultAsync(x => x.TicketCode == newTransaction.TicketCode && x.IsUsed==0 && x.packType == newTransaction.PackageType);
            if (tickets != null)
            {
                var package = await applicationDbContext.Package.FirstOrDefaultAsync(x => x.Name == tickets.Type);

                //var Id = user.GetUserId(this.User);
                //var User = await user.FindByIdAsync(Id);
                var User = await user.FindByIdAsync(user.GetUserId(this.User));

                var life = await applicationDbContext.Life.FirstOrDefaultAsync(x => x.User == User);

                if(life != null)
                {
                    life.RemaingBets += package.Value;
                    await applicationDbContext.SaveChangesAsync();
                }
                else
                {
                    var newlife = new Life()
                    {
                        Id = Guid.NewGuid(),
                        RemaingBets = package.Value,
                        User = User,
                        Timestamp = DateTime.Now,
                    };
                    await applicationDbContext.AddAsync(newlife);
                    await applicationDbContext.SaveChangesAsync();
                }

                tickets.IsUsed = 1;
                var NewTransaction = new Transaction()
                {
                    Id = Guid.NewGuid(),
                    User = User,
                    Ticket = tickets,
                    Timestamp = DateTime.Now,
                };
                await applicationDbContext.AddAsync(NewTransaction);
                await applicationDbContext.SaveChangesAsync();
                return Redirect("Index");

            }
            else
            {
                return RedirectToAction("TicketNotFound");
            }

        }
        public IActionResult TicketNotFound()
        {
            return View();
        }
        public IActionResult Transactions()
        {
            return View();
        }
    }
}
