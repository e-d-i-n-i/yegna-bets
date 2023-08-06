using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YEGNA_BETS.Data;
using YEGNA_BETS.Models;
using YEGNA_BETS.Models.Domain;
using YEGNA_BETS.Tools;

namespace YEGNA_BETS.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _admin;
        private readonly ApplicationDbContext applicationDbContext;
        private ToolKit toolKit = new ToolKit();
        public AdminController(UserManager<ApplicationUser> admin, ApplicationDbContext applicationDbContext)
        {
            this._admin = admin;
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Insight()
        {
            var AppUsers = _admin.Users.ToList();
            // Calculate gender distribution
            var genderDistribution = AppUsers.GroupBy(u => u.Gender)
                                      .Select(g => new GenderData { Gender = g.Key ?? "Unknown", Count = g.Count() })
                                      .ToList();

            // Ensure that Gender property is not null
            genderDistribution.ForEach(g => g.Gender ??= "Unknown");
            return View(genderDistribution);
        }
       
        public IActionResult Bets()
        {
            return View();
        }
        public IActionResult Transactions()
        {
            return View();
        }
        public IActionResult Logs()
        {
            return View();
        }
        public IActionResult Interactions()
        {
            return View();
        }

        //TICKETS
        public async Task<IActionResult> Tickets()
        {
            var tickets = await applicationDbContext.Ticket.ToListAsync();
            return View(tickets);
        }
        public async Task<IActionResult> AvailPackages()
        {
            var packages = await applicationDbContext.Package.ToListAsync();
            return View(packages);
        }
        [HttpGet]
        public async Task<IActionResult> NewTicket(Guid Id)
        {
            var package = await applicationDbContext.Package.FirstOrDefaultAsync(x => x.Id == Id);

            if (package != null)
            {
                var viewModel = new AddTicketViewModel()
                {
                    Type = package.Name,
                    PackageId = package.Id,
                };
                return await Task.Run(() => View(viewModel));
            }

            return RedirectToAction("Tickets");
        }
        [HttpPost]
        public async Task<IActionResult> AddTicket(AddTicketViewModel newTicket)
        {
            var pack = await applicationDbContext.Package.FirstOrDefaultAsync(x => x.Id == newTicket.PackageId);

            for (int i=0; i < newTicket.Quantity; i++)
            {
                var ticket = new Ticket()
                {
                    Id = Guid.NewGuid(),
                    PackageType= pack,
                    IsUsed = 0,
                    Value = pack.Value,
                    Type = newTicket.Type,
                    TicketCode = toolKit.GenerateRandomString(10),
                    Timestamp = DateTime.Now,
                    Encoder = _admin.GetUserId(this.User),
                };
                await applicationDbContext.AddAsync(ticket);
                await applicationDbContext.SaveChangesAsync();

            }
            return RedirectToAction("Tickets");
        }
        [HttpGet]
        public async Task<IActionResult> TicketDetails(Guid Id)
        {
            var ticket = await applicationDbContext.Ticket.FirstOrDefaultAsync(x => x.Id == Id);

            if (ticket != null)
            {
                var viewModel = new TicketDetailsViewModel()
                {
                    Id= ticket.Id,
                    TicketCode= ticket.TicketCode,
                    IsUsed= ticket.IsUsed,
                    Value= ticket.Value,
                    PackageType = ticket.Type,
                    Timestamp = ticket.Timestamp,
                };
                return await Task.Run(() => View(viewModel));
            }

            return RedirectToAction("Tickets");
        }
        public async Task<IActionResult> RemoveTicket(TicketDetailsViewModel model)
        {
            var ticket = await applicationDbContext.Ticket.FindAsync(model.Id);
            if (ticket != null)
            {
                applicationDbContext.Ticket.Remove(ticket);
                await applicationDbContext.SaveChangesAsync();

                return RedirectToAction("Tickets");
            }

            return RedirectToAction("Tickets");
        }



        public IActionResult Users()
        {
            var AppUsers = _admin.Users.ToList();
            return View(AppUsers);
        }
        public IActionResult Patterns()
        {
            return View();
        }
        public IActionResult ExportData()
        {
            return View();
        }


        //PACKAGES
        public IActionResult Packages()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddPackage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPackage(AddPackageViewModel newPackage)
        {
            var package = new Package()
            {
                Id = Guid.NewGuid(),
                Name = newPackage.Name,
                Value = newPackage.Value,
                Price = newPackage.Price,
                Timestamp = DateTime.Now,
                Encoder = _admin.GetUserId(this.User),
            };
            await applicationDbContext.AddAsync(package);
            await applicationDbContext.SaveChangesAsync();

            return RedirectToAction("ListPackages");
        }
        [HttpGet]
        public async Task<IActionResult> ListPackages()
        {
            var packages = await applicationDbContext.Package.ToListAsync();
            return View(packages);
        }
        [HttpGet]
        public async Task<IActionResult> PackageDetails(Guid Id)
        {
            var package = await applicationDbContext.Package.FirstOrDefaultAsync(x => x.Id == Id);

            if (package != null)
            {
                var viewModel = new UpdatePackageViewModel()
                {
                    Id = package.Id,
                    Name = package.Name,
                    Value = package.Value,
                    Price = package.Price,
                    Timestamp = package.Timestamp,
                };
                return await Task.Run(() => View(viewModel));
            }

            return RedirectToAction("ListPackages");
        }
        [HttpPost]
        public async Task<IActionResult> PackageDetails(UpdatePackageViewModel model)
        {
            var package = await applicationDbContext.Package.FindAsync(model.Id);
            if (package != null)
            {
                package.Name = model.Name;
                package.Value = model.Value;
                package.Price = model.Price;

                await applicationDbContext.SaveChangesAsync();

                return RedirectToAction("ListPackages");
            }
            return RedirectToAction("ListPackages");
        }
        [HttpPost]
        public async Task<IActionResult> DeletePackage (UpdatePackageViewModel model)
        {
            var package = await applicationDbContext.Package.FindAsync(model.Id);
            if (package != null)
            {
                applicationDbContext.Package.Remove(package);
                await applicationDbContext.SaveChangesAsync();

                return RedirectToAction("ListPackages");
            }

            return RedirectToAction("ListPackages");
        }

    
    }
  
}
