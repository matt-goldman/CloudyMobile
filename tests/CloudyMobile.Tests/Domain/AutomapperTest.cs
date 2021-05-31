using AutoMapper;
using CloudyMobile.Application.Batch.Common;
using CloudyMobile.Application.Common.Mappings;
using CloudyMobile.Application.Ingredients.Queries.Common;
using CloudyMobile.Application.Recipes.Common;
using CloudyMobile.Domain.Entities;
using NUnit.Framework;
using System;

namespace CloudyMobile.Application.UnitTests.Common.Mappings
{
    public class AutomapperTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public AutomapperTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Test]
        [TestCase(typeof(Ingredient), typeof(IngredientDto))]
        [TestCase(typeof(CloudyMobile.Domain.Entities.Batch), typeof(BatchDto))]
        [TestCase(typeof(BatchSample), typeof(SampleDto))]
        [TestCase(typeof(Recipe), typeof(RecipeDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}