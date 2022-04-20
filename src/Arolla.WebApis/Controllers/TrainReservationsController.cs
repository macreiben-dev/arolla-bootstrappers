using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainReservationCore;

namespace Arolla.WebApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainReservationsController
    {
        private ITrainRepository _repo;

        public TrainReservationsController(ITrainRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IEnumerable<Seat> Get(string trainName)
        {
            return _repo.GetAvaibleSeats(trainName);
        }
    }
}
