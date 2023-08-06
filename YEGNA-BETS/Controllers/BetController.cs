using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;
using NuGet.Versioning;
using YEGNA_BETS.Data;
using YEGNA_BETS.Models;
using YEGNA_BETS.Models.Domain;
using YEGNA_BETS.Tools;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace YEGNA_BETS.Controllers
{
    [Authorize]
    public class BetController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> user;
        private static Guid BetIdHolder;
        public BetController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> user)
        {
            this._applicationDbContext = applicationDbContext;
            this.user = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetMatches()
        {
           string userId = user.GetUserId(this.User);
           var Life = _applicationDbContext.Life.FirstOrDefault(u => u.UserId == userId);
            int RemaingBets;
            if (Life != null)
            {
                RemaingBets = Life.RemaingBets;
                if (RemaingBets == 0)
                {
                    return RedirectToAction("Deposit");
                }
            }
            else
            {
                return RedirectToAction("Deposit");
            }


            return View();
        }
       
        public IActionResult Deposit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewBet(List<GetMatchesViewModel> Matches)
        {
            var Better = await user.FindByIdAsync(user.GetUserId(this.User));

            var newBet = new Bet()
            {
                Id = Guid.NewGuid(),
                User = Better,
                UserId = Better.Id,
                Budget =0,
                TAX =0,
                VAT = 0,
                NoMatches = Matches.Count(),
                WinnerStake = null,
                IsChecked = 0,
                Timestamp = DateTime.Now,
            };
            await _applicationDbContext.AddAsync(newBet);
            await _applicationDbContext.SaveChangesAsync();

            foreach (var match in Matches)
            {
                var newMatch = new Match()
                {
                    Id = Guid.NewGuid(),
                    BetCode = newBet,
                    BetId = newBet.Id,
                    HomeTeam = match.HomeTeam,
                    AwayTeam = match.AwayTeam,
                    OddForHomeTeam = match.OddForHomeTeam,
                    OddForAwayTeam = match.OddForAwayTeam,
                    OddForDraw = match.OddForDraw,
                    Outcome = 0,
                    Timestamp = DateTime.Now,
                };
                await _applicationDbContext.AddAsync(newMatch);

            }
            await _applicationDbContext.SaveChangesAsync();
            var send = new NewBetViewModel()
            {
                BetId = newBet.Id,
            };
            return View(send);

        }

        [HttpPost]
        public async Task<IActionResult> GenerateBets(NewBetViewModel UpdateBet)
        {
            var Bet = await _applicationDbContext.Bet.FindAsync(UpdateBet.BetId);
            if (Bet != null)
            {
                Bet.TAX = UpdateBet.TAX;
                Bet.VAT = UpdateBet.VAT; 
                Bet.Budget = UpdateBet.Budget;

                await _applicationDbContext.SaveChangesAsync();
                
                var Matches = await _applicationDbContext.Match.Where(s => s.BetCode == Bet).ToListAsync(); 
                

                List<Pattern> patterns =  _applicationDbContext.Pattern.Where(x => x.NoMatches == Matches.Count).ToList();

                if(patterns != null)
                {
                    //Check if the bet has been already been generated
                    var isBetted = await _applicationDbContext.Stake.FirstOrDefaultAsync(x => x.BetCode == Bet);
                    if (isBetted == null)
                    {
                        //Generate Possible Stake Tickets
                        foreach (Pattern pattern in patterns)
                        {
                            var Stake = new Stake();
                            Stake.Pattern = pattern.Patterns;
                            Stake.BetId = Bet.Id;
                            Stake.Luck = pattern.successCount;
                            Stake.Id = Guid.NewGuid();
                            Stake.BetCode = Bet;
                            Stake.IsWinner = 0;
                            Stake.Timestamp = DateTime.Now;
                            double probabilityOfSuccess = 1;
                            double totalOdds = 1;
                            for (int i = 0; i < Matches.Count; i++)
                            {
                                var Possibility = new Possibility();
                                Possibility.Id = Guid.NewGuid();
                                Possibility.Timestamp = DateTime.Now;
                                Possibility.StakeCode = Stake;
                                Possibility.stakeCode = Stake.Id;
                                if (pattern.Patterns[i] == 'W')
                                {
                                    totalOdds *= Matches[i].OddForHomeTeam;
                                    Possibility.HomeTeam = Matches[i].HomeTeam;
                                    Possibility.AwayTeam = Matches[i].AwayTeam;
                                    Possibility.Outcome = "W";
                                    probabilityOfSuccess *= ((1 / Matches[i].OddForHomeTeam));
                                }
                                else if (pattern.Patterns[i] == 'D')
                                {
                                    totalOdds *= Matches[i].OddForDraw;
                                    Possibility.HomeTeam = Matches[i].HomeTeam;
                                    Possibility.AwayTeam = Matches[i].AwayTeam;
                                    Possibility.Outcome = "D";
                                    probabilityOfSuccess *= ((1 / Matches[i].OddForDraw));
                                }
                                else
                                {
                                    totalOdds *= Matches[i].OddForAwayTeam;
                                    Possibility.HomeTeam = Matches[i].HomeTeam;
                                    Possibility.AwayTeam = Matches[i].AwayTeam;
                                    Possibility.Outcome = "L";
                                    probabilityOfSuccess *= ((1 / Matches[i].OddForAwayTeam));
                                }
                                await _applicationDbContext.AddAsync(Possibility);

                            }
                            Stake.Probability = (Math.Round((probabilityOfSuccess * 1 / 3), 3) * 100);
                            Stake.TotalOdds = Math.Round(totalOdds, 3);
                            //Payout = (Budget / (1 + VAT)) * (1 - Tax) * Total odds
                            Stake.PayOut = (Bet.Budget / (1 + (Bet.VAT / 100)) * (1 - (Bet.TAX / 100))) * totalOdds;
                            Stake.PayOut = Math.Round(Stake.PayOut, 3, MidpointRounding.AwayFromZero);
                            await _applicationDbContext.AddAsync(Stake);
                            await _applicationDbContext.SaveChangesAsync();
                        }
                    }
                }
                else
                {
                    List<string> outcomes = new List<string>();
                    ToolKit.CalculateOutcomes(Matches.Count, "", outcomes);
                    //Generate patterns and add if there is new patterns found
                    foreach (var outcome in outcomes)
                    {
                        var pattern = await _applicationDbContext.Pattern.FirstOrDefaultAsync(x => x.Patterns == outcome);
                        if (pattern == null)
                        {
                            var newPattern = new Pattern()
                            {
                                Id = Guid.NewGuid(),
                                Patterns = outcome,
                                NoMatches = Matches.Count,
                                successCount = 0,
                                Timestamp = DateTime.Now,
                            };
                            await _applicationDbContext.AddAsync(newPattern);
                            await _applicationDbContext.SaveChangesAsync();
                        }
                    }

                    //Check if the bet has been already been generated
                    var isBetted = await _applicationDbContext.Stake.FirstOrDefaultAsync(x => x.BetCode == Bet);
                    if (isBetted == null)
                    {
                        //Generate Possible Stake Tickets
                        foreach (string pattern in outcomes)
                        {
                            var patternS = await _applicationDbContext.Pattern.FirstOrDefaultAsync(x => x.Patterns == pattern);
                            var Stake = new Stake();
                            Stake.Pattern = pattern;
                            Stake.BetId = Bet.Id;
                            Stake.Luck = patternS.successCount;
                            Stake.Id = Guid.NewGuid();
                            Stake.BetCode = Bet;
                            Stake.IsWinner = 0;
                            Stake.Timestamp = DateTime.Now;
                            double probabilityOfSuccess = 1;
                            double totalOdds = 1;
                            for (int i = 0; i < Matches.Count; i++)
                            {
                                var Possibility = new Possibility();
                                Possibility.Id = Guid.NewGuid();
                                Possibility.Timestamp = DateTime.Now;
                                Possibility.StakeCode = Stake;
                                Possibility.stakeCode = Stake.Id;
                                if (pattern[i] == 'W')
                                {
                                    totalOdds *= Matches[i].OddForHomeTeam;
                                    Possibility.HomeTeam = Matches[i].HomeTeam;
                                    Possibility.AwayTeam = Matches[i].AwayTeam;
                                    Possibility.Outcome = "W";
                                    probabilityOfSuccess *= ((1 / Matches[i].OddForHomeTeam));
                                }
                                else if (pattern[i] == 'D')
                                {
                                    totalOdds *= Matches[i].OddForDraw;
                                    Possibility.HomeTeam = Matches[i].HomeTeam;
                                    Possibility.AwayTeam = Matches[i].AwayTeam;
                                    Possibility.Outcome = "D";
                                    probabilityOfSuccess *= ((1 / Matches[i].OddForDraw));
                                }
                                else
                                {
                                    totalOdds *= Matches[i].OddForAwayTeam;
                                    Possibility.HomeTeam = Matches[i].HomeTeam;
                                    Possibility.AwayTeam = Matches[i].AwayTeam;
                                    Possibility.Outcome = "L";
                                    probabilityOfSuccess *= ((1 / Matches[i].OddForAwayTeam));
                                }
                                await _applicationDbContext.AddAsync(Possibility);

                            }
                            Stake.Probability = (Math.Round((probabilityOfSuccess * 1 / 3), 3) * 100);
                            Stake.TotalOdds = Math.Round(totalOdds, 3);
                            //Payout = (Budget / (1 + VAT)) * (1 - Tax) * Total odds
                            Stake.PayOut = (Bet.Budget / (1 + (Bet.VAT / 100)) * (1 - (Bet.TAX / 100))) * totalOdds;
                            Stake.PayOut = Math.Round(Stake.PayOut, 3, MidpointRounding.AwayFromZero);
                            await _applicationDbContext.AddAsync(Stake);
                            await _applicationDbContext.SaveChangesAsync();
                        }
                    }
                }
                

                

                //Sorted by payout
                var AllPossibleStakes = await _applicationDbContext.Stake
                     .Where(s => s.BetCode == Bet)
                     .OrderByDescending(s => s.PayOut)
                     .ToListAsync();
                
                //decreement life count
                string userId = user.GetUserId(this.User);
                var Life = _applicationDbContext.Life.FirstOrDefault(u => u.UserId == userId);
                Life.RemaingBets -= 1;
                _applicationDbContext.SaveChanges();

                //return View(AllPossibleStakes);
                return View("Stakes", AllPossibleStakes);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> History()
        {
            var BetHistory = await _applicationDbContext.Bet
                .Where(b => b.UserId == user.GetUserId(this.User))
                .OrderByDescending(b => b.Timestamp)
                .ToListAsync(); return View(BetHistory);
        }
        
        public async Task<IActionResult> CrossCheck()
        {
            var User = await user.FindByIdAsync(user.GetUserId(this.User));
            var allBetsByUser = await _applicationDbContext.Bet
                .Where(U => U.User == User)
                .OrderByDescending(b => b.Timestamp)
                .ToListAsync();
            return View(allBetsByUser);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetMatchResult(Guid Id)
        {
            var bet =  _applicationDbContext.Bet.Find(Id);
            var matches =  _applicationDbContext.Match.Where(m => m.BetCode == bet).ToList();
            BetIdHolder = Id;
            return View(matches);
        }

        [HttpPost]
        public IActionResult Stakes(string MatchesResult)
        {
            Stake NewWinnerStake =  _applicationDbContext.Stake.FirstOrDefault(s => s.Pattern == MatchesResult && s.BetId == BetIdHolder);
            Stake OldWinnerStake = _applicationDbContext.Stake.FirstOrDefault(s => s.IsWinner == 1 && s.BetId == BetIdHolder);

            var bet = _applicationDbContext.Bet.FirstOrDefault(s => s.Id == NewWinnerStake.BetId);

            if (NewWinnerStake == null)
                return RedirectToAction("Index");
            else
            {
                NewWinnerStake.IsWinner = 1;

                var pattern = _applicationDbContext.Pattern.FirstOrDefault(p => p.Patterns == MatchesResult);

                var lostStakes = _applicationDbContext.Stake.Where(s => s.Id != NewWinnerStake.Id && s.BetId == NewWinnerStake.BetId).ToList();
                var storedPattern = new Pattern();
                foreach (var record in lostStakes)
                {
                    storedPattern = _applicationDbContext.Pattern.FirstOrDefault(p => p.Patterns == record.Pattern);
                    if (record.IsWinner == 1)
                    {
                        storedPattern.successCount -= 1;
                    }
                    record.IsWinner = -1;
                    record.Luck = storedPattern.successCount;
                }
                _applicationDbContext.SaveChanges();

                if (OldWinnerStake != null)
                {
                    if (NewWinnerStake.Pattern != OldWinnerStake.Pattern)
                    {
                        pattern.successCount += 1;
                    }
                }
                else
                {
                    pattern.successCount += 1;
                }
                NewWinnerStake.IsWinner = 1;
                NewWinnerStake.Luck = pattern.successCount;

            }
            bet.IsChecked = 1;
            _applicationDbContext.SaveChanges();


            var newS = _applicationDbContext.Stake.OrderByDescending(s => s.PayOut).Where(s => s.BetId == NewWinnerStake.BetId).ToList();
            //   var all = await _applicationDbContext.Stake.Where(s => s.BetCode.Id == bet.Id).ToListAsync();

            return View(newS);
        }

        [HttpGet]
        public IActionResult Stakes(Guid Id)
        {
            var allStakes =  _applicationDbContext.Stake.OrderByDescending(s => s.Pattern).Where(s=>s.BetId == Id).ToList();     
            return View(allStakes);
        }

        [HttpGet]
        public async Task<IActionResult> StakeDetails(Guid Id)
        {
            var stake = await _applicationDbContext.Stake.FindAsync(Id);
            var possibilities = await _applicationDbContext.Possibility.Where(m => m.StakeCode == stake).ToListAsync();
            var stakeDetailsViewModel = new StakeDetailsViewModel()
            {
                Possibilities = possibilities,
                stake = stake,
            };
            return View(stakeDetailsViewModel);            
        }

        public async Task<IActionResult> Patterns()
        {
            var patterns = await _applicationDbContext.Pattern.OrderByDescending(p => p.successCount).ToListAsync();
            return View(patterns);
        }
    }
}
