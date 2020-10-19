using Moq;
using NUnit.Framework;
using RESTfulWebAPI.Application.Movie.Commands;
using RESTfulWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Tests.ApplicationTests.Movie.Querys;

namespace Tests.Tests.ApplicationTests.Movie.Commands
{
    [TestFixture]
    internal class UpdateMovieCommandTest : BaseMovieTest
    {
        IUpdateMovieCommand _updateMovieCommand;


        [Test]
        public void TestShouldUpdateMovie()
        {
            _updateMovieCommand = new UpdateMovieCommand(base._mockContext.Object);
            _updateMovieCommand.Execute(base._movie);

            base._mockContext
            .Verify(p => p.Save(), Times.Once);
        }
    }
}
