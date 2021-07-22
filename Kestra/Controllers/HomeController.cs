using Kestra.Models;
using Kestra.Models.Repositories;
using Kestra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Kestra.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IOrderRepository orderRepository;
        private readonly ITickerRepository tickerRepository;

        public HomeController(ITransactionRepository transactionRepository, IOrderRepository orderRepository, ITickerRepository tickerRepository)
        {
            this.transactionRepository = transactionRepository;
            this.orderRepository = orderRepository;
            this.tickerRepository = tickerRepository;
        }

        /// <summary>
        /// Return tickers and order types to populate the dropdown options and radio button labels.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            HomeViewModel viewModel = new()
            {
                Orders = orderRepository.GetAll(),
                Tickers = tickerRepository.GetAll(),
            };

            return View(viewModel);
        }

        /// <summary>
        /// Creates a dbo.Transaction record from the client.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(HomeViewModel request)
        {
            // build new Transaction
            Transaction newTransaction = new()
            {
                TickerId = request.selectedTickerId,
                OrderId = request.selectedOrderTypeId,
                Quantity = request.selectedQuantity,
                CreatedOnUtc = DateTime.UtcNow
            };

            // create new Transaction
            transactionRepository.Create(newTransaction);

            HomeViewModel resultViewModel = new()
            {
                Orders = orderRepository.GetAll(),
                Tickers = tickerRepository.GetAll(),
            };   

            return View(resultViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
