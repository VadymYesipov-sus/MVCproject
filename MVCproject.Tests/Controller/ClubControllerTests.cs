using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCproject.Controllers;
using MVCproject.Interfaces;
using MVCproject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCproject.Tests.Controller
{
    public class ClubControllerTests
    {
        private IClubRepository _clubRepository;
        private IPhotoService _photoService;
        private IHttpContextAccessor _httpContextAccessor;
        private ClubController _clubController;

        public ClubControllerTests()
        {
            //Dependencies
            _clubRepository = A.Fake<IClubRepository>();
            _photoService = A.Fake<IPhotoService>();
            _httpContextAccessor = A.Fake<IHttpContextAccessor>();
            // httpContextAccessor - cannot unit test it because its static, need to refactor function in order to unit test

            //SUT
            _clubController = new ClubController(_clubRepository, _photoService, _httpContextAccessor);
        }

        [Fact]
        public void ClubController_Index_ReturnsSuccess()
        {
            //Arrange - what do i need to bring in
            var clubs = A.Fake<IEnumerable<Club>>();
            A.CallTo(() => _clubRepository.GetAll()).Returns(clubs);
            //Act
            var result = _clubController.Index();

            //Assert - object check(actions), and check viewModels if you dont know what to check
            result.Should().BeOfType <Task<IActionResult>>();

        }

        [Fact]
        public void ClubController_Detail_ReturnsSuccess()
        {
            //Arrange
            var id = 1;
            var club = A.Fake<Club>();
            A.CallTo(() => _clubRepository.GetByIdAsync(id)).Returns(club);
            //Act
            var result = _clubController.Detail(id);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        
        public void ClubController_Delete_ReturnsSuccess()
        {
            //Arrange
            var id = 1;
            var clubDetail = A.Fake<Club>();
            A.CallTo(() => _clubRepository.GetByIdAsync(id)).Returns(clubDetail);

            //Act
            var result = _clubController.Delete(id);
            //Assert
            result.Should().BeOfType<Task<IActionResult>> ();

        }
    }
}
