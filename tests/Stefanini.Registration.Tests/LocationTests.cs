using AutoMapper;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using Stefanini.Registration.Business.Mappers;
using Stefanini.Registration.Business.Services;
using Stefanini.Registration.Domain.Entities;
using Stefanini.Registration.Domain.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.Registration.Tests
{
    public class LocationTests
    {
        public readonly Mock<ILocationRepository> _locationRepository;
        public readonly IMapper _mapper;
        public readonly LocationService _artistService;

        public LocationTests()
        {
            _locationRepository = new Mock<ILocationRepository>();
            _mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new LocationProfile());
            }).CreateMapper();
            _artistService = new LocationService(_locationRepository.Object, _mapper);
        }

        [Fact]
        public async Task Get_Locations_With_Success()
        {
            // Arrange
            var entities = Builder<Location>.CreateListOfSize(20).Build();
            _locationRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Location, bool>>?>())).ReturnsAsync(entities.AsQueryable);

            // Act
            var response = await _artistService.GetAllLocationsAsync();

            // Assert
            response.Should().NotBeNullOrEmpty();
            response.Should().HaveCount(entities.Count);
        }

        [Fact]
        public async Task Get_Locations_With_Error()
        {
            // Arrange
            var emptyEntities = Enumerable.Empty<Location>();
            _locationRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Location, bool>>?>())).ReturnsAsync(emptyEntities.AsQueryable);

            // Act
            var response = await _artistService.GetAllLocationsAsync();

            // Assert
            response.Should().BeEmpty();
            response.Should().HaveCount(emptyEntities.ToList().Count);
        }
    }
}