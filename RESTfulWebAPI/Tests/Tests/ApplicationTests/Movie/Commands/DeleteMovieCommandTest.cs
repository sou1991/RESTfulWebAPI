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
    internal class DeleteMovieCommandTest : BaseMovieTest
    {
        IDeleteMovieCommand _deleteMovieCommand;

        [Test]
        public void TestShouldDeleteMovie()
        {
            _deleteMovieCommand = new DeleteMovieCommand(base._mockContext.Object);
            _deleteMovieCommand.Execute(base._movie);

            base._mockContext
            .Verify(p => p.Save(), Times.Once);

        }
    }
}
