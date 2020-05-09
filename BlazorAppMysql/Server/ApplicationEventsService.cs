using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAppMysql.Server
{
   
        public class ApplicationEventsService : IHostedService

        {

            // We need to inject the IServiceProvider so we can create

            // the scoped service, MyDbContext

            private readonly IServiceProvider _serviceProvider;

           // IOptions<Parametres> _parametres;

            public ApplicationEventsService(IServiceProvider serviceProvider)

            {

                _serviceProvider = serviceProvider;

             //   _parametres = parametres;

            }



            public async Task StartAsync(CancellationToken cancellationToken)

            {

                // Create a new scope to retrieve scoped services

                using (var scope = _serviceProvider.CreateScope())

                {

                    // Get the DbContext instance

                    //var myDbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();



                    ////Do the migration asynchronously

                    //await myDbContext.Database.MigrateAsync();

                }



                //  await new UtilisateurADCrud(_parametres).GetUtilisateurAT2();

            }



            // noop

            public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        }

    
}
 
