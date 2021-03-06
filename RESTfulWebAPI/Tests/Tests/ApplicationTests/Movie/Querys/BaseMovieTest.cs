﻿using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using RESTfulWebAPI.Application;
using RESTfulWebAPI.Application.Movie.Querys;
using RESTfulWebAPI.Entities;
using RESTfulWebAPI.Infrastructure;
using RESTfulWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.Tests.ApplicationTests.Movie.Querys
{
    [TestFixture]
    internal class BaseMovieTest
    {
        protected readonly int _id = 1;
        protected readonly string _title = "dummy_titile";
        protected readonly string _filmDirector = "dummy__filmDirector";
        protected readonly DateTime _releaseDate = DateTime.Now;
        protected MovieModel _movie;
        protected ISearchMovieQuery _searchMovieQuery;
        protected Mock<IDataBaseService> _mockContext;

        [SetUp]
        public void SetUp()
        {
            var movieEntity = new List<MovieEntity>()
            {
                new MovieEntity()
                {
                    id = _id,
                    title = _title,
                    film_director = _filmDirector,
                    release_date = _releaseDate
                }
            }.AsQueryable();

            _movie = new MovieModel()
            {
                id = _id,
                title = _title,
                film_director = _filmDirector,
                release_date = _releaseDate
            };

            var mockMyEntity = new Mock<DbSet<MovieEntity>>();
            // DbSetとテスト用データを紐付け
            mockMyEntity.As<IQueryable<Type>>().Setup(m => m.Provider).Returns(movieEntity.Provider);
            mockMyEntity.As<IQueryable<Type>>().Setup(m => m.Expression).Returns(movieEntity.Expression);
            mockMyEntity.As<IQueryable<Type>>().Setup(m => m.ElementType).Returns(movieEntity.ElementType);
            mockMyEntity.As<IQueryable<MovieEntity>>().Setup(m => m.GetEnumerator()).Returns(movieEntity.GetEnumerator());

            _mockContext = new Mock<IDataBaseService>();
            _mockContext.Setup(m => m.Movie).Returns(mockMyEntity.Object);

            _searchMovieQuery = new SearchMovieQuery(_mockContext.Object);

        }

        [Test]
        public void TestShouldGetMovieList()
        {
            var results = _searchMovieQuery.Execute(_movie);
            var result = results.First();

            Assert.That(result.id, Is.EqualTo(_id));
        }
    }
}
