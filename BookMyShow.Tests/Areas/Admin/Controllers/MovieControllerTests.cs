using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyShow.Areas.Admin.Controllers;
using BookMyShow.Data.Repository.IRepository;
using BookMyShow.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BookMyShow.Tests.Areas.Admin.Controllers
{
    public class MovieControllerTests
    {
        private static Mock<IRepository<Movie>> _movieRepository = new Mock<IRepository<Movie>>();
        private static Mock<IWebHostEnvironment> _hosting = new Mock<IWebHostEnvironment>();
        MovieController movieController = new MovieController(_movieRepository.Object, _hosting.Object);

        [Fact]
        public void Index()
        {
            var result = movieController.Index() as ViewResult;

            Assert.NotNull(result);
        }
    }
}
