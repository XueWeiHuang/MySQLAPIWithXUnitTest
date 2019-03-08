using Microsoft.AspNetCore.Mvc;
using MySQLWebserver.Controllers;
using MySQLWebserver.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class ActorControllerFunctionTest
    {
        [Fact]
        public void GetActorByIDSmokeTest()
        {

            var controller = new ActorController();
            var result = controller.Get(101).Result as OkObjectResult;
            var actor = result.Value as Actor;
            Assert.Equal(actor.actor_id, 101);
            Assert.Equal(actor.first_name, "SUSAN");
            Assert.Equal(actor.last_name, "DAVIS");

        }
    }
}
