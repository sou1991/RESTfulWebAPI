using Moq;
using NUnit.Framework;
using RESTfulWebAPI.Application.Movie.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Tests.ApplicationTests.Movie.Querys;

namespace Tests.Tests.ApplicationTests.Movie.Commands
{
    [TestFixture]
    internal class CreateMovieCommandTest : BaseMovieTest
    {
        ICreateMovieCommand _createMovieCommand;

        [Test]
        public void TestShouldUpdateMovie()
        {
            _createMovieCommand = new CreateMovieCommand(base._mockContext.Object);
            _createMovieCommand.Execute(base._movie);

            base._mockContext
            .Verify(p => p.Save(), Times.Once);
        }
    }
}
